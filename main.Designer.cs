using System.Drawing;
using System.Windows.Forms;

namespace safari_reborn
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Component cho Form không viền và bo góc
        private Guna.UI2.WinForms.Guna2BorderlessForm borderlessForm;
        private Guna.UI2.WinForms.Guna2DragControl dragControl;

        // Các nút Traffic Lights kiểu macOS
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private Guna.UI2.WinForms.Guna2CircleButton btnMinimize;
        private Guna.UI2.WinForms.Guna2CircleButton btnMaximize;

        // Các control điều hướng
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2Button btnForward;
        private Guna.UI2.WinForms.Guna2Button btnSidebar;
        private Guna.UI2.WinForms.Guna2Button btnShare;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Guna.UI2.WinForms.Guna2Button btnNewTab;
        private Guna.UI2.WinForms.Guna2TextBox txtURL;
        private Guna.UI2.WinForms.Guna2ShadowPanel urlShadowPanel;
        private Guna.UI2.WinForms.Guna2Panel tabBar;
        private Guna.UI2.WinForms.Guna2GradientPanel topBar;
        private Guna.UI2.WinForms.Guna2Separator separator;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar;
        private Guna.UI2.WinForms.Guna2TabControl tabBarControl;
        private Guna.UI2.WinForms.Guna2AnimateWindow animateWindow;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.borderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.dragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnMaximize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.btnForward = new Guna.UI2.WinForms.Guna2Button();
            this.btnSidebar = new Guna.UI2.WinForms.Guna2Button();
            this.btnShare = new Guna.UI2.WinForms.Guna2Button();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.btnNewTab = new Guna.UI2.WinForms.Guna2Button();
            this.txtURL = new Guna.UI2.WinForms.Guna2TextBox();
            this.urlShadowPanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.tabBar = new Guna.UI2.WinForms.Guna2Panel();
            this.topBar = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.separator = new Guna.UI2.WinForms.Guna2Separator();
            this.progressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.tabBarControl = new Guna.UI2.WinForms.Guna2TabControl();
            this.animateWindow = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);

            this.topBar.SuspendLayout();
            this.SuspendLayout();

            // 
            // borderlessForm
            // 
            this.borderlessForm.ContainerControl = this;
            this.borderlessForm.BorderRadius = 12;
            this.borderlessForm.ResizeForm = true;
            this.borderlessForm.ShadowColor = Color.Black;

            // 
            // dragControl
            // 
            this.dragControl.TargetControl = this.topBar;
            this.dragControl.UseTransparentDrag = true;

            // 
            // topBar
            // 
            this.topBar.FillColor = Color.FromArgb(43, 43, 43); // Safari 18 Base Gray
            this.topBar.FillColor2 = Color.FromArgb(36, 36, 36);
            this.topBar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.topBar.Controls.Add(this.btnSidebar);
            this.topBar.Controls.Add(this.btnClose);
            this.topBar.Controls.Add(this.btnMinimize);
            this.topBar.Controls.Add(this.btnMaximize);
            this.topBar.Controls.Add(this.btnBack);
            this.topBar.Controls.Add(this.btnForward);
            this.topBar.Controls.Add(this.btnHome);
            this.topBar.Controls.Add(this.urlShadowPanel);
            this.topBar.Controls.Add(this.btnShare);
            this.topBar.Controls.Add(this.btnNewTab);
            this.topBar.Controls.Add(this.separator);
            this.topBar.Dock = DockStyle.Top;
            this.topBar.Height = 52; // Standard macOS Title Bar Height
            this.topBar.Name = "topBar";

            // 
            // btnClose
            // 
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.FillColor = Color.FromArgb(255, 95, 87);
            this.btnClose.Location = new Point(14, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(12, 12);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // btnMinimize
            // 
            this.btnMinimize.Cursor = Cursors.Hand;
            this.btnMinimize.FillColor = Color.FromArgb(255, 189, 46);
            this.btnMinimize.Location = new Point(34, 20);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new Size(12, 12);
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);

            // 
            // btnMaximize
            // 
            this.btnMaximize.Cursor = Cursors.Hand;
            this.btnMaximize.FillColor = Color.FromArgb(40, 201, 64);
            this.btnMaximize.Location = new Point(54, 20);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new Size(12, 12);
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);

            // 
            // btnSidebar
            // 
            this.btnSidebar.BorderRadius = 6;
            this.btnSidebar.Cursor = Cursors.Hand;
            this.btnSidebar.FillColor = Color.Transparent;
            this.btnSidebar.HoverState.FillColor = Color.FromArgb(40, 255, 255, 255);
            this.btnSidebar.Location = new Point(80, 10);
            this.btnSidebar.Name = "btnSidebar";
            this.btnSidebar.Size = new Size(32, 32);
            this.btnSidebar.ImageSize = new Size(16, 16);

            // 
            // btnBack
            // 
            this.btnBack.BorderRadius = 6;
            this.btnBack.Cursor = Cursors.Hand;
            this.btnBack.FillColor = Color.Transparent;
            this.btnBack.HoverState.FillColor = Color.FromArgb(40, 255, 255, 255);
            this.btnBack.Location = new Point(120, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new Size(32, 32);
            this.btnBack.ImageOffset = new Point(-1, 0);
            this.btnBack.ImageSize = new Size(16, 16);
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // 
            // btnForward
            // 
            this.btnForward.BorderRadius = 6;
            this.btnForward.Cursor = Cursors.Hand;
            this.btnForward.FillColor = Color.Transparent;
            this.btnForward.HoverState.FillColor = Color.FromArgb(40, 255, 255, 255);
            this.btnForward.Location = new Point(155, 10);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new Size(32, 32);
            this.btnForward.ImageOffset = new Point(1, 0);
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnHome
            // 
            this.btnHome.BorderRadius = 6;
            this.btnHome.Cursor = Cursors.Hand;
            this.btnHome.FillColor = Color.Transparent;
            this.btnHome.HoverState.FillColor = Color.FromArgb(40, 255, 255, 255);
            this.btnHome.Location = new Point(190, 10);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new Size(32, 32);
            this.btnHome.ImageSize = new Size(16, 16);
            this.btnHome.Click += (s,e) => {
                var wb = GetActiveWebView();
                if(wb != null) wb.CoreWebView2.Navigate("https://www.google.com");
            };

            // 
            // urlShadowPanel
            // 
            this.urlShadowPanel.BackColor = Color.Transparent;
            this.urlShadowPanel.Controls.Add(this.txtURL);
            this.urlShadowPanel.FillColor = Color.FromArgb(50, 50, 50);
            this.urlShadowPanel.Location = new Point(400, 10);
            this.urlShadowPanel.Name = "urlShadowPanel";
            this.urlShadowPanel.Radius = 14; 
            this.urlShadowPanel.ShadowColor = Color.Black;
            this.urlShadowPanel.ShadowDepth = 150;
            this.urlShadowPanel.ShadowShift = 3;
            this.urlShadowPanel.Size = new Size(600, 32);

            // 
            // txtURL
            // 
            this.txtURL.BackColor = Color.Transparent;
            this.txtURL.BorderRadius = 10;
            this.txtURL.BorderThickness = 0;
            this.txtURL.Dock = DockStyle.Fill;
            this.txtURL.FillColor = Color.FromArgb(50, 50, 50);
            this.txtURL.Font = new Font("Segoe UI", 10F);
            this.txtURL.ForeColor = Color.White;
            this.txtURL.Location = new Point(0, 0);
            this.txtURL.Name = "txtURL";
            this.txtURL.PlaceholderForeColor = Color.Gray;
            this.txtURL.PlaceholderText = "Search or enter website name";
            this.txtURL.Size = new Size(600, 40);
            this.txtURL.TextOffset = new Point(10, 0);
            this.txtURL.KeyDown += new KeyEventHandler(this.txtURL_KeyDown);
            // No directly assigned Unicode icons to avoid conversion errors
            this.txtURL.IconRightCursor = Cursors.Hand;
            this.txtURL.IconRightOffset = new Point(5, 0);
            this.txtURL.IconRightClick += (s, e) => this.btnReload_Click(s, e);

            // 
            // btnShare
            // 
            this.btnShare.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnShare.BorderRadius = 6;
            this.btnShare.Cursor = Cursors.Hand;
            this.btnShare.FillColor = Color.Transparent;
            this.btnShare.HoverState.FillColor = Color.FromArgb(40, 255, 255, 255);
            this.btnShare.Location = new Point(1260, 10);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new Size(32, 32);
            this.btnShare.ImageSize = new Size(14, 14);

            // 
            // btnNewTab
            // 
            this.btnNewTab.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnNewTab.BorderRadius = 6;
            this.btnNewTab.Cursor = Cursors.Hand;
            this.btnNewTab.FillColor = Color.Transparent;
            this.btnNewTab.HoverState.FillColor = Color.FromArgb(40, 255, 255, 255);
            this.btnNewTab.Location = new Point(1300, 10);
            this.btnNewTab.Name = "btnNewTab";
            this.btnNewTab.Size = new Size(32, 32);
            this.btnNewTab.ImageSize = new Size(14, 14);

            // 
            // separator
            // 
            this.separator.Dock = DockStyle.Bottom;
            this.separator.FillColor = Color.FromArgb(20, 20, 20);
            this.separator.Location = new Point(0, 51);
            this.separator.Name = "separator";
            this.separator.Size = new Size(1400, 1);

            // 
            // progressBar
            // 
            this.progressBar.Dock = DockStyle.Bottom;
            this.progressBar.FillColor = Color.Transparent;
            this.progressBar.Height = 2;
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = Color.FromArgb(10, 132, 255);
            this.progressBar.ProgressColor2 = Color.FromArgb(10, 132, 255);
            this.progressBar.Visible = false;
            this.progressBar.Value = 0;
            this.progressBar.Dock = DockStyle.Top; // Put at top of content area

            // 
            // tabBar
            // 
            this.tabBar.BackColor = Color.FromArgb(36, 36, 36);
            this.tabBar.Dock = DockStyle.Top;
            this.tabBar.Height = 36;
            this.tabBar.Name = "tabBar";

            // 
            // tabBarControl
            // 
            this.tabBarControl.Alignment = TabAlignment.Top;
            this.tabBarControl.Dock = DockStyle.Fill;
            this.tabBarControl.ItemSize = new Size(0, 1); // Hide default headers to use our custom bar
            this.tabBarControl.Location = new Point(0, 90);
            this.tabBarControl.Name = "tabBarControl";
            this.tabBarControl.SelectedIndex = 0;
            this.tabBarControl.Size = new Size(1400, 710);
            this.tabBarControl.SizeMode = TabSizeMode.Fixed;
            this.tabBarControl.TabIndex = 0;
            this.tabBarControl.TabButtonHoverState.BorderColor = Color.Empty;
            this.tabBarControl.TabButtonHoverState.FillColor = Color.FromArgb(40, 40, 40);
            this.tabBarControl.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            this.tabBarControl.TabButtonHoverState.ForeColor = Color.White;
            this.tabBarControl.TabButtonHoverState.InnerColor = Color.FromArgb(40, 40, 40);
            this.tabBarControl.TabButtonIdleState.BorderColor = Color.Empty;
            this.tabBarControl.TabButtonIdleState.FillColor = Color.FromArgb(33, 31, 28);
            this.tabBarControl.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            this.tabBarControl.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            this.tabBarControl.TabButtonIdleState.InnerColor = Color.FromArgb(33, 31, 28);
            this.tabBarControl.TabButtonSelectedState.BorderColor = Color.Empty;
            this.tabBarControl.TabButtonSelectedState.FillColor = Color.FromArgb(29, 37, 49);
            this.tabBarControl.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            this.tabBarControl.TabButtonSelectedState.ForeColor = Color.White;
            this.tabBarControl.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            this.tabBarControl.TabMenuBackColor = Color.FromArgb(33, 31, 28);
            this.tabBarControl.Visible = true;

            // 
            // MainForm
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ClientSize = new Size(1400, 800);
            this.Controls.Add(this.tabBarControl);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabBar);
            this.Controls.Add(this.topBar);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Safari Reborn";
            this.Resize += new System.EventHandler(this.main_Resize);
            this.urlShadowPanel.ResumeLayout(false);
            this.topBar.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
    }
}