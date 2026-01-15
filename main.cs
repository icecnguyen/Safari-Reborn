using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace safari_reborn
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            InitBrowser();
        }

        private async void InitBrowser()
        {
            await browser.EnsureCoreWebView2Async();
            browser.CoreWebView2.Navigate("https://www.google.com");

            browser.CoreWebView2.NavigationStarting += (s, e) =>
            {
                progressBar.Visible = true;
            };

            browser.CoreWebView2.NavigationCompleted += (s, e) =>
            {
                progressBar.Visible = false;
                txtURL.Text = browser.Source?.AbsoluteUri ?? "";
                this.Text = browser.CoreWebView2.DocumentTitle;
            };
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (browser.CoreWebView2.CanGoBack)
                browser.CoreWebView2.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (browser.CoreWebView2.CanGoForward)
                browser.CoreWebView2.GoForward();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            browser.Reload();
        }

        private void txtURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string url = txtURL.Text;
                if (!url.StartsWith("http"))
                    url = "https://" + url;

                browser.CoreWebView2.Navigate(url);
            }
        }
    }
}