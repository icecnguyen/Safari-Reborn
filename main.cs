using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Guna.UI2.WinForms;

namespace safari_reborn
{
    public class HistoryItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public partial class MainForm : Form
    {
        private List<HistoryItem> history = new List<HistoryItem>();
        private string historyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "history.json");

        public MainForm()
        {
            InitializeComponent();
            LoadAssets();
            LoadHistory();
            
            this.Load += async (s, e) => {
                CenterURLBar();
                animateWindow.SetAnimateWindow(this);
                await CreateNewTab("https://www.google.com");
            };
            
            // Shortcuts
            this.KeyPreview = true;
            this.KeyDown += (s, e) => {
                if (e.Control && e.KeyCode == Keys.T) _ = CreateNewTab("https://www.google.com");
                if (e.Control && e.KeyCode == Keys.W) {
                    if (tabBarControl.TabPages.Count > 0) {
                        tabBarControl.TabPages.Remove(tabBarControl.SelectedTab);
                        UpdateTabUI();
                    }
                }
                if (e.Control && e.KeyCode == Keys.R) btnReload_Click(s, e);
            };

            // Sync UI when tab changes
            tabBarControl.SelectedIndexChanged += (s, e) => SyncUIWithActiveTab();

            // Focus effects for URL Bar
            txtURL.Enter += (s, e) => {
                urlShadowPanel.ShadowDepth = 200;
                urlShadowPanel.FillColor = Color.FromArgb(70, 70, 70);
            };
            txtURL.Leave += (s, e) => {
                urlShadowPanel.ShadowDepth = 120;
                urlShadowPanel.FillColor = Color.FromArgb(60, 60, 60);
            };
        }

        private WebView2 GetActiveWebView()
        {
            if (tabBarControl.SelectedTab != null && tabBarControl.SelectedTab.Controls.Count > 0)
            {
                return tabBarControl.SelectedTab.Controls[0] as WebView2;
            }
            return null;
        }

        private void SyncUIWithActiveTab()
        {
            var webView = GetActiveWebView();
            if (webView != null && webView.Source != null)
            {
                txtURL.Text = webView.Source.AbsoluteUri;
            }
        }

        private async Task CreateNewTab(string url)
        {
            TabPage page = new TabPage("Loading...");
            page.BackColor = Color.FromArgb(30, 30, 30);

            WebView2 webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            webView.DefaultBackgroundColor = Color.FromArgb(15, 25, 35);

            page.Controls.Add(webView);
            tabBarControl.TabPages.Add(page);
            tabBarControl.SelectedTab = page;

            await webView.EnsureCoreWebView2Async(null);
            
            // Event Handlers
            webView.CoreWebView2.NavigationStarting += (s, e) => {
                if (tabBarControl.SelectedTab == page) progressBar.Visible = true;
            };
            
            webView.CoreWebView2.NavigationCompleted += (s, e) => {
                if (tabBarControl.SelectedTab == page) progressBar.Visible = false;
                page.Text = webView.CoreWebView2.DocumentTitle;
                this.Text = "Safari - " + page.Text;
                
                if (e.IsSuccess) {
                    AddHistory(page.Text, webView.Source.AbsoluteUri);
                }
                UpdateTabUI();
            };

            webView.CoreWebView2.ContextMenuRequested += (s, args) => {
                // Clear default menu to make it look cleaner/macOS style
                // Or just add our items
                var menuItems = args.MenuItems;
                
                var backItem = webView.CoreWebView2.Environment.CreateContextMenuItem("Back", null, CoreWebView2ContextMenuItemKind.Command);
                backItem.CustomItemSelected += (send, ex) => btnBack_Click(null, null);
                menuItems.Insert(0, backItem);

                var forwardItem = webView.CoreWebView2.Environment.CreateContextMenuItem("Forward", null, CoreWebView2ContextMenuItemKind.Command);
                forwardItem.CustomItemSelected += (send, ex) => btnForward_Click(null, null);
                menuItems.Insert(1, forwardItem);

                var reloadItem = webView.CoreWebView2.Environment.CreateContextMenuItem("Reload", null, CoreWebView2ContextMenuItemKind.Command);
                reloadItem.CustomItemSelected += (send, ex) => btnReload_Click(null, null);
                menuItems.Insert(2, reloadItem);

                var sep = webView.CoreWebView2.Environment.CreateContextMenuItem("", null, CoreWebView2ContextMenuItemKind.Separator);
                menuItems.Insert(3, sep);

                var copyUrlItem = webView.CoreWebView2.Environment.CreateContextMenuItem("Copy Page URL", null, CoreWebView2ContextMenuItemKind.Command);
                copyUrlItem.CustomItemSelected += (send, ex) => Clipboard.SetText(webView.Source.AbsoluteUri);
                menuItems.Insert(4, copyUrlItem);
            };

            webView.CoreWebView2.SourceChanged += (s, e) => {
                if (tabBarControl.SelectedTab == page) txtURL.Text = webView.Source.AbsoluteUri;
            };

            webView.CoreWebView2.NewWindowRequested += async (s, e) => {
                e.Handled = true;
                await CreateNewTab(e.Uri);
            };

            webView.CoreWebView2.DownloadStarting += (s, e) => {
                // For now, just let it download to default location
                // We could add a "Download Manager" UI here later
            };

            webView.CoreWebView2.Navigate(url);
        }

        private void UpdateTabUI()
        {
            tabBar.Controls.Clear();
            SyncUIWithActiveTab();

            // Loop backwards because of Dock.Left
            for (int i = tabBarControl.TabPages.Count - 1; i >= 0; i--)
            {
                var page = tabBarControl.TabPages[i];
                var tabContainer = new Guna.UI2.WinForms.Guna2Panel {
                    Dock = DockStyle.Left,
                    Width = 160,
                    Padding = new Padding(4, 4, 4, 4)
                };

                var btn = new Guna.UI2.WinForms.Guna2Button();
                btn.Text = page.Text.Length > 18 ? page.Text.Substring(0, 15) + "..." : page.Text;
                btn.Dock = DockStyle.Fill;
                btn.FillColor = (tabBarControl.SelectedIndex == i) ? Color.FromArgb(60, 60, 60) : Color.Transparent;
                btn.HoverState.FillColor = Color.FromArgb(40, 255, 255, 255);
                btn.ForeColor = Color.White;
                btn.BorderRadius = 10;
                btn.Font = new Font("Segoe UI Semibold", 9F);
                btn.TextAlign = HorizontalAlignment.Left;
                btn.TextOffset = new Point(8, 0);

                int index = i;
                btn.Click += (s, e) => {
                    tabBarControl.SelectedIndex = index;
                    UpdateTabUI();
                };

                // Add close button (smaller, discrete)
                var closeBtn = new Guna.UI2.WinForms.Guna2Button {
                    Text = "×",
                    Size = new Size(18, 18),
                    Location = new Point(135, 9),
                    FillColor = Color.Transparent,
                    ForeColor = Color.FromArgb(150, 255, 255, 255),
                    BorderRadius = 9,
                    Anchor = AnchorStyles.Right
                };
                closeBtn.HoverState.FillColor = Color.FromArgb(100, 255, 0, 0);
                closeBtn.HoverState.ForeColor = Color.White;
                
                closeBtn.Click += (s, e) => {
                    tabBarControl.TabPages.RemoveAt(index);
                    if (tabBarControl.TabPages.Count == 0) this.Close();
                    UpdateTabUI();
                };

                tabContainer.Controls.Add(closeBtn);
                tabContainer.Controls.Add(btn);
                tabBar.Controls.Add(tabContainer);
            }
        }

        // ================== DATA PERSISTENCE ==================

        private void LoadHistory()
        {
            try {
                if (File.Exists(historyPath)) {
                    string json = File.ReadAllText(historyPath);
                    history = JsonSerializer.Deserialize<List<HistoryItem>>(json) ?? new List<HistoryItem>();
                }
            } catch { history = new List<HistoryItem>(); }
        }

        private void SaveHistory()
        {
            try {
                string json = JsonSerializer.Serialize(history);
                File.WriteAllText(historyPath, json);
            } catch { }
        }

        private void AddHistory(string title, string url)
        {
            if (string.IsNullOrEmpty(url) || url.StartsWith("about:")) return;
            history.Insert(0, new HistoryItem { Title = title, Url = url, Timestamp = DateTime.Now });
            if (history.Count > 1000) history.RemoveAt(history.Count - 1);
            SaveHistory();
        }

        // ================== LOGIC ĐIỀU HƯỚNG WEB ==================

        private void btnBack_Click(object sender, EventArgs e)
        {
            var webView = GetActiveWebView();
            if (webView != null && webView.CoreWebView2 != null && webView.CoreWebView2.CanGoBack)
                webView.CoreWebView2.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            var webView = GetActiveWebView();
            if (webView != null && webView.CoreWebView2 != null && webView.CoreWebView2.CanGoForward)
                webView.CoreWebView2.GoForward();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            var webView = GetActiveWebView();
            if (webView != null)
                webView.Reload();
        }

        private void txtURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string input = txtURL.Text.Trim();
                if (string.IsNullOrEmpty(input)) return;

                string url = input.Contains(".") && !input.Contains(" ") 
                    ? (input.StartsWith("http") ? input : "https://" + input)
                    : "https://www.google.com/search?q=" + Uri.EscapeDataString(input);

                var webView = GetActiveWebView();
                if (webView != null && webView.CoreWebView2 != null)
                {
                    webView.CoreWebView2.Navigate(url);
                }
            }
        }

        // ================== LOGIC CỬA SỔ (MACOS STYLE) ==================

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void main_Resize(object sender, EventArgs e)
        {
            CenterURLBar();
        }

        private void CenterURLBar()
        {
            // Center urlShadowPanel and limit its maximum width
            int maxWidth = 800;
            int margin = 320; 
            int newWidth = this.Width - (margin * 2);

            if (newWidth > maxWidth) newWidth = maxWidth;
            if (newWidth < 450) newWidth = 450;

            urlShadowPanel.Width = newWidth;
            urlShadowPanel.Left = (this.Width - urlShadowPanel.Width) / 2;
            urlShadowPanel.Top = (topBar.Height - urlShadowPanel.Height) / 2;
        }

        private void LoadAssets()
        {
            try
            {
                // Pixel-Perfect Icons
                btnBack.Image = LoadImage("back.png");
                btnForward.Image = LoadImage("forward.png");
                btnHome.Image = LoadImage("home.png");
                btnShare.Image = LoadImage("share.png");
                btnNewTab.Image = LoadImage("plus.png");
                btnSidebar.Image = LoadImage("sidebar.png"); 
                
                txtURL.IconLeft = LoadImage("lock.png");
                txtURL.IconRight = LoadImage("reload.png");

                txtURL.IconRightClick += (s, e) => btnReload_Click(s, e);
                
                // Bind New Tab button
                btnNewTab.Click += async (s, e) => await CreateNewTab("https://www.google.com");
            }
            catch { }
        }

        private Image LoadImage(string fileName)
        {
            try
            {
                // Check multiple possible paths for robustness
                string[] possiblePaths = {
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", fileName),
                    Path.Combine(Application.StartupPath, "Assets", fileName),
                    Path.Combine(Environment.CurrentDirectory, "Assets", fileName),
                    Path.Combine("Assets", fileName)
                };

                foreach (string path in possiblePaths)
                {
                    if (File.Exists(path))
                    {
                        return Image.FromFile(path);
                    }
                }
            }
            catch { }
            return null;
        }
    }
}