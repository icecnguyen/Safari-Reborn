namespace safari_reborn
{
    partial class main
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnBack;
        private Button btnForward;
        private Button btnReload;
        private TextBox txtURL;
        private Panel topBar;
        private ProgressBar progressBar;
        private Microsoft.Web.WebView2.WinForms.WebView2 browser;

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
            this.btnBack = new Button();
            this.btnForward = new Button();
            this.btnReload = new Button();
            this.txtURL = new TextBox();
            this.topBar = new Panel();
            this.progressBar = new ProgressBar();
            this.browser = new Microsoft.Web.WebView2.WinForms.WebView2();

            // 
            // btnBack
            // 
            this.btnBack.Text = "<";
            this.btnBack.Width = 32;
            this.btnBack.Height = 32;
            this.btnBack.Location = new Point(5, 5);
            this.btnBack.Click += new EventHandler(this.btnBack_Click);
            this.btnBack.BackColor = Color.FromArgb(60, 60, 60);
            this.btnBack.ForeColor = Color.White;

            // 
            // btnForward
            // 
            this.btnForward.Text = ">";
            this.btnForward.Width = 32;
            this.btnForward.Height = 32;
            this.btnForward.Location = new Point(50, 5);
            this.btnForward.Click += new EventHandler(this.btnForward_Click);
            this.btnForward.BackColor = Color.FromArgb(60, 60, 60);
            this.btnForward.ForeColor = Color.White;

            // 
            // btnReload
            // 
            this.btnReload.Text = "⟳";
            this.btnReload.Width = 32;
            this.btnReload.Height = 32;
            this.btnReload.Location = new Point(95, 5);
            this.btnReload.Click += new EventHandler(this.btnReload_Click);
            this.btnReload.BackColor = Color.FromArgb(60, 60, 60);
            this.btnReload.ForeColor = Color.White;

            // 
            // txtURL
            // 
            this.txtURL.Location = new Point(140, 5);
            this.txtURL.Size = new Size(1200, 32);
            this.txtURL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtURL.KeyDown += new KeyEventHandler(this.txtURL_KeyDown);
            this.txtURL.BackColor = Color.FromArgb(50, 50, 50);
            this.txtURL.ForeColor = Color.White;
            this.txtURL.BorderStyle = BorderStyle.FixedSingle;

            // 
            // progressBar
            // 
            this.progressBar.Dock = DockStyle.Bottom;
            this.progressBar.Height = 3;
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            this.progressBar.BackColor = Color.FromArgb(45, 45, 45);
            this.progressBar.ForeColor = Color.DeepSkyBlue;

            // 
            // topBar
            // 
            this.topBar.Dock = DockStyle.Top;
            this.topBar.Height = 42;
            this.topBar.BackColor = Color.FromArgb(45, 45, 45);
            this.topBar.Controls.Add(this.btnBack);
            this.topBar.Controls.Add(this.btnForward);
            this.topBar.Controls.Add(this.btnReload);
            this.topBar.Controls.Add(this.txtURL);
            this.topBar.Controls.Add(this.progressBar);

            // 
            // browser
            // 
            this.browser.Dock = DockStyle.Fill;

            // 
            // main
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(1400, 800);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.topBar);
            this.Name = "main";
            this.Text = "Safari Reborn";
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;
        }
        #endregion
    }
}