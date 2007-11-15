namespace monitorSwitcher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lblCurMode = new System.Windows.Forms.Label();
            this.m_notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.m_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToggleDisplayMode = new System.Windows.Forms.ToolStripMenuItem();
            this.forceSwitchMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.forceSwitchProjector = new System.Windows.Forms.ToolStripMenuItem();
            this.Quit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.m_contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "You are now in...";
            // 
            // m_lblCurMode
            // 
            this.m_lblCurMode.AutoSize = true;
            this.m_lblCurMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblCurMode.Location = new System.Drawing.Point(80, 33);
            this.m_lblCurMode.Name = "m_lblCurMode";
            this.m_lblCurMode.Size = new System.Drawing.Size(422, 37);
            this.m_lblCurMode.TabIndex = 2;
            this.m_lblCurMode.Text = "Monitor Mode (1600x1200)";
            // 
            // m_notifyIcon
            // 
            this.m_notifyIcon.ContextMenuStrip = this.m_contextMenu;
            this.m_notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("m_notifyIcon.Icon")));
            this.m_notifyIcon.Text = "Monitor Switcher - Windows+~ to switch";
            this.m_notifyIcon.Visible = true;
            // 
            // m_contextMenu
            // 
            this.m_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleDisplayMode,
            this.forceSwitchMonitor,
            this.forceSwitchProjector,
            this.about,
            this.toolStripSeparator1,
            this.Quit});
            this.m_contextMenu.Name = "m_contextMenu";
            this.m_contextMenu.Size = new System.Drawing.Size(283, 142);
            // 
            // ToggleDisplayMode
            // 
            this.ToggleDisplayMode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ToggleDisplayMode.Name = "ToggleDisplayMode";
            this.ToggleDisplayMode.Size = new System.Drawing.Size(282, 22);
            this.ToggleDisplayMode.Text = "Toggle Display Mode (Windows+~)";
            this.ToggleDisplayMode.Click += new System.EventHandler(this.ToggleDisplayMode_Click);
            // 
            // forceSwitchMonitor
            // 
            this.forceSwitchMonitor.Name = "forceSwitchMonitor";
            this.forceSwitchMonitor.Size = new System.Drawing.Size(282, 22);
            this.forceSwitchMonitor.Text = "Force Switch to Monitor Mode";
            this.forceSwitchMonitor.Click += new System.EventHandler(this.forceSwitchMonitor_Click);
            // 
            // forceSwitchProjector
            // 
            this.forceSwitchProjector.Name = "forceSwitchProjector";
            this.forceSwitchProjector.Size = new System.Drawing.Size(282, 22);
            this.forceSwitchProjector.Text = "Force Switch to Projector Mode";
            this.forceSwitchProjector.Click += new System.EventHandler(this.forceSwitchProjector_Click);
            // 
            // Quit
            // 
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(282, 22);
            this.Quit.Text = "Quit App";
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // m_timer
            // 
            this.m_timer.Tick += new System.EventHandler(this.OnTick);
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(282, 22);
            this.about.Text = "About...";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(279, 6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 86);
            this.Controls.Add(this.m_lblCurMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Switching Display Mode...";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.m_contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_lblCurMode;
        private System.Windows.Forms.NotifyIcon m_notifyIcon;
        private System.Windows.Forms.ContextMenuStrip m_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem ToggleDisplayMode;
        private System.Windows.Forms.ToolStripMenuItem Quit;
        private System.Windows.Forms.Timer m_timer;
        private System.Windows.Forms.ToolStripMenuItem forceSwitchMonitor;
        private System.Windows.Forms.ToolStripMenuItem forceSwitchProjector;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

