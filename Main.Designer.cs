namespace WTDE_Updater_V2 {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.LogoImage = new System.Windows.Forms.PictureBox();
            this.MainUpdaterPanel = new System.Windows.Forms.Panel();
            this.VersionInfoLabel = new System.Windows.Forms.Label();
            this.EndUpdateButton = new System.Windows.Forms.Button();
            this.JoinDiscordButton = new System.Windows.Forms.Button();
            this.WTDESiteButton = new System.Windows.Forms.Button();
            this.TipLabel = new System.Windows.Forms.Label();
            this.CurrentFileProgressPercent = new System.Windows.Forms.Label();
            this.CurrentFileLabel = new System.Windows.Forms.Label();
            this.CurrentFileProgress = new System.Windows.Forms.ProgressBar();
            this.TotalProgressPercent = new System.Windows.Forms.Label();
            this.TotalProgress = new System.Windows.Forms.ProgressBar();
            this.TotalProgressLabel = new System.Windows.Forms.Label();
            this.UpdaterLogoImage = new System.Windows.Forms.PictureBox();
            this.HeadLabel = new System.Windows.Forms.Label();
            this.BackgroundWorkerMain = new System.ComponentModel.BackgroundWorker();
            this.IntroPanel = new System.Windows.Forms.Panel();
            this.VersionInfoLabelHome = new System.Windows.Forms.Label();
            this.LocalUpdateDesc = new System.Windows.Forms.Label();
            this.OnlineUpdateDesc = new System.Windows.Forms.Label();
            this.LocalUpdateButton = new System.Windows.Forms.Button();
            this.OnlineUpdateButton = new System.Windows.Forms.Button();
            this.DiscordButtonHome = new System.Windows.Forms.Button();
            this.SiteButtonHome = new System.Windows.Forms.Button();
            this.UpdaterLogoImageHome = new System.Windows.Forms.PictureBox();
            this.HeadLabelHome = new System.Windows.Forms.Label();
            this.LogoImageHome = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImage)).BeginInit();
            this.MainUpdaterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpdaterLogoImage)).BeginInit();
            this.IntroPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpdaterLogoImageHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImageHome)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoImage
            // 
            this.LogoImage.BackColor = System.Drawing.Color.Transparent;
            this.LogoImage.BackgroundImage = global::WTDE_Updater_V2.Properties.Resources.logo;
            this.LogoImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoImage.Location = new System.Drawing.Point(10, 6);
            this.LogoImage.Name = "LogoImage";
            this.LogoImage.Size = new System.Drawing.Size(152, 158);
            this.LogoImage.TabIndex = 0;
            this.LogoImage.TabStop = false;
            // 
            // MainUpdaterPanel
            // 
            this.MainUpdaterPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainUpdaterPanel.Controls.Add(this.VersionInfoLabel);
            this.MainUpdaterPanel.Controls.Add(this.EndUpdateButton);
            this.MainUpdaterPanel.Controls.Add(this.JoinDiscordButton);
            this.MainUpdaterPanel.Controls.Add(this.WTDESiteButton);
            this.MainUpdaterPanel.Controls.Add(this.TipLabel);
            this.MainUpdaterPanel.Controls.Add(this.CurrentFileProgressPercent);
            this.MainUpdaterPanel.Controls.Add(this.CurrentFileLabel);
            this.MainUpdaterPanel.Controls.Add(this.CurrentFileProgress);
            this.MainUpdaterPanel.Controls.Add(this.TotalProgressPercent);
            this.MainUpdaterPanel.Controls.Add(this.TotalProgress);
            this.MainUpdaterPanel.Controls.Add(this.TotalProgressLabel);
            this.MainUpdaterPanel.Controls.Add(this.UpdaterLogoImage);
            this.MainUpdaterPanel.Controls.Add(this.HeadLabel);
            this.MainUpdaterPanel.Controls.Add(this.LogoImage);
            this.MainUpdaterPanel.Location = new System.Drawing.Point(771, 12);
            this.MainUpdaterPanel.Name = "MainUpdaterPanel";
            this.MainUpdaterPanel.Size = new System.Drawing.Size(800, 426);
            this.MainUpdaterPanel.TabIndex = 1;
            // 
            // VersionInfoLabel
            // 
            this.VersionInfoLabel.AutoSize = true;
            this.VersionInfoLabel.Font = new System.Drawing.Font("Lexend", 10F);
            this.VersionInfoLabel.ForeColor = System.Drawing.Color.White;
            this.VersionInfoLabel.Location = new System.Drawing.Point(10, 373);
            this.VersionInfoLabel.Name = "VersionInfoLabel";
            this.VersionInfoLabel.Size = new System.Drawing.Size(231, 44);
            this.VersionInfoLabel.TabIndex = 13;
            this.VersionInfoLabel.Text = "GHWT: DE Updater Vx by IMF24\r\nBG Image: Fox (FoxInari)";
            // 
            // EndUpdateButton
            // 
            this.EndUpdateButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EndUpdateButton.Location = new System.Drawing.Point(632, 393);
            this.EndUpdateButton.Name = "EndUpdateButton";
            this.EndUpdateButton.Size = new System.Drawing.Size(159, 23);
            this.EndUpdateButton.TabIndex = 12;
            this.EndUpdateButton.Text = "Cancel Update";
            this.EndUpdateButton.UseVisualStyleBackColor = true;
            this.EndUpdateButton.Click += new System.EventHandler(this.EndUpdateButton_Click);
            // 
            // JoinDiscordButton
            // 
            this.JoinDiscordButton.BackgroundImage = global::WTDE_Updater_V2.Properties.Resources.discord;
            this.JoinDiscordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.JoinDiscordButton.Location = new System.Drawing.Point(721, 306);
            this.JoinDiscordButton.Name = "JoinDiscordButton";
            this.JoinDiscordButton.Size = new System.Drawing.Size(70, 70);
            this.JoinDiscordButton.TabIndex = 11;
            this.JoinDiscordButton.UseVisualStyleBackColor = true;
            this.JoinDiscordButton.Click += new System.EventHandler(this.JoinDiscordButton_Click);
            // 
            // WTDESiteButton
            // 
            this.WTDESiteButton.BackgroundImage = global::WTDE_Updater_V2.Properties.Resources.website;
            this.WTDESiteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WTDESiteButton.Location = new System.Drawing.Point(632, 306);
            this.WTDESiteButton.Name = "WTDESiteButton";
            this.WTDESiteButton.Size = new System.Drawing.Size(70, 70);
            this.WTDESiteButton.TabIndex = 10;
            this.WTDESiteButton.UseVisualStyleBackColor = true;
            this.WTDESiteButton.Click += new System.EventHandler(this.WTDESiteButton_Click);
            // 
            // TipLabel
            // 
            this.TipLabel.Font = new System.Drawing.Font("Lexend", 12F);
            this.TipLabel.ForeColor = System.Drawing.Color.White;
            this.TipLabel.Location = new System.Drawing.Point(17, 310);
            this.TipLabel.Name = "TipLabel";
            this.TipLabel.Size = new System.Drawing.Size(602, 59);
            this.TipLabel.TabIndex = 9;
            this.TipLabel.Text = "Downloading File: NAME_HERE";
            // 
            // CurrentFileProgressPercent
            // 
            this.CurrentFileProgressPercent.Font = new System.Drawing.Font("Lexend", 12F);
            this.CurrentFileProgressPercent.ForeColor = System.Drawing.Color.White;
            this.CurrentFileProgressPercent.Location = new System.Drawing.Point(696, 246);
            this.CurrentFileProgressPercent.Name = "CurrentFileProgressPercent";
            this.CurrentFileProgressPercent.Size = new System.Drawing.Size(95, 25);
            this.CurrentFileProgressPercent.TabIndex = 8;
            this.CurrentFileProgressPercent.Text = "0%";
            this.CurrentFileProgressPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CurrentFileLabel
            // 
            this.CurrentFileLabel.AutoSize = true;
            this.CurrentFileLabel.Font = new System.Drawing.Font("Lexend", 12F);
            this.CurrentFileLabel.ForeColor = System.Drawing.Color.White;
            this.CurrentFileLabel.Location = new System.Drawing.Point(10, 246);
            this.CurrentFileLabel.Name = "CurrentFileLabel";
            this.CurrentFileLabel.Size = new System.Drawing.Size(256, 25);
            this.CurrentFileLabel.TabIndex = 7;
            this.CurrentFileLabel.Text = "Downloading File: NAME_HERE";
            // 
            // CurrentFileProgress
            // 
            this.CurrentFileProgress.Location = new System.Drawing.Point(10, 274);
            this.CurrentFileProgress.Name = "CurrentFileProgress";
            this.CurrentFileProgress.Size = new System.Drawing.Size(781, 23);
            this.CurrentFileProgress.TabIndex = 6;
            // 
            // TotalProgressPercent
            // 
            this.TotalProgressPercent.Font = new System.Drawing.Font("Lexend", 16F);
            this.TotalProgressPercent.ForeColor = System.Drawing.Color.White;
            this.TotalProgressPercent.Location = new System.Drawing.Point(622, 165);
            this.TotalProgressPercent.Name = "TotalProgressPercent";
            this.TotalProgressPercent.Size = new System.Drawing.Size(169, 35);
            this.TotalProgressPercent.TabIndex = 5;
            this.TotalProgressPercent.Text = "0%";
            this.TotalProgressPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalProgress
            // 
            this.TotalProgress.Location = new System.Drawing.Point(10, 202);
            this.TotalProgress.Name = "TotalProgress";
            this.TotalProgress.Size = new System.Drawing.Size(781, 23);
            this.TotalProgress.TabIndex = 4;
            // 
            // TotalProgressLabel
            // 
            this.TotalProgressLabel.AutoSize = true;
            this.TotalProgressLabel.Font = new System.Drawing.Font("Lexend", 16F);
            this.TotalProgressLabel.ForeColor = System.Drawing.Color.White;
            this.TotalProgressLabel.Location = new System.Drawing.Point(10, 165);
            this.TotalProgressLabel.Name = "TotalProgressLabel";
            this.TotalProgressLabel.Size = new System.Drawing.Size(169, 35);
            this.TotalProgressLabel.TabIndex = 3;
            this.TotalProgressLabel.Text = "Total Progress";
            // 
            // UpdaterLogoImage
            // 
            this.UpdaterLogoImage.BackColor = System.Drawing.Color.Transparent;
            this.UpdaterLogoImage.BackgroundImage = global::WTDE_Updater_V2.Properties.Resources.icon;
            this.UpdaterLogoImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdaterLogoImage.Location = new System.Drawing.Point(655, 12);
            this.UpdaterLogoImage.Name = "UpdaterLogoImage";
            this.UpdaterLogoImage.Size = new System.Drawing.Size(136, 136);
            this.UpdaterLogoImage.TabIndex = 2;
            this.UpdaterLogoImage.TabStop = false;
            // 
            // HeadLabel
            // 
            this.HeadLabel.AutoSize = true;
            this.HeadLabel.Font = new System.Drawing.Font("Lexend", 16F);
            this.HeadLabel.ForeColor = System.Drawing.Color.White;
            this.HeadLabel.Location = new System.Drawing.Point(179, 10);
            this.HeadLabel.Name = "HeadLabel";
            this.HeadLabel.Size = new System.Drawing.Size(441, 140);
            this.HeadLabel.TabIndex = 1;
            this.HeadLabel.Text = "Sit tight, we\'re updating your mod!\r\nUpdating to Version x...\r\n\r\nBe patient, make" +
    " yourself a cup of tea...";
            // 
            // BackgroundWorkerMain
            // 
            this.BackgroundWorkerMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerMain_DoWork);
            // 
            // IntroPanel
            // 
            this.IntroPanel.BackColor = System.Drawing.Color.Transparent;
            this.IntroPanel.Controls.Add(this.VersionInfoLabelHome);
            this.IntroPanel.Controls.Add(this.LocalUpdateDesc);
            this.IntroPanel.Controls.Add(this.OnlineUpdateDesc);
            this.IntroPanel.Controls.Add(this.LocalUpdateButton);
            this.IntroPanel.Controls.Add(this.OnlineUpdateButton);
            this.IntroPanel.Controls.Add(this.DiscordButtonHome);
            this.IntroPanel.Controls.Add(this.SiteButtonHome);
            this.IntroPanel.Controls.Add(this.UpdaterLogoImageHome);
            this.IntroPanel.Controls.Add(this.HeadLabelHome);
            this.IntroPanel.Controls.Add(this.LogoImageHome);
            this.IntroPanel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IntroPanel.Location = new System.Drawing.Point(2, 31);
            this.IntroPanel.Name = "IntroPanel";
            this.IntroPanel.Size = new System.Drawing.Size(800, 426);
            this.IntroPanel.TabIndex = 2;
            // 
            // VersionInfoLabelHome
            // 
            this.VersionInfoLabelHome.AutoSize = true;
            this.VersionInfoLabelHome.Font = new System.Drawing.Font("Lexend", 10F);
            this.VersionInfoLabelHome.ForeColor = System.Drawing.Color.White;
            this.VersionInfoLabelHome.Location = new System.Drawing.Point(10, 373);
            this.VersionInfoLabelHome.Name = "VersionInfoLabelHome";
            this.VersionInfoLabelHome.Size = new System.Drawing.Size(231, 44);
            this.VersionInfoLabelHome.TabIndex = 16;
            this.VersionInfoLabelHome.Text = "GHWT: DE Updater Vx by IMF24\r\nBG Image: Fox (FoxInari)";
            // 
            // LocalUpdateDesc
            // 
            this.LocalUpdateDesc.AutoSize = true;
            this.LocalUpdateDesc.Font = new System.Drawing.Font("Lexend", 10F);
            this.LocalUpdateDesc.ForeColor = System.Drawing.Color.White;
            this.LocalUpdateDesc.Location = new System.Drawing.Point(227, 250);
            this.LocalUpdateDesc.Name = "LocalUpdateDesc";
            this.LocalUpdateDesc.Size = new System.Drawing.Size(536, 44);
            this.LocalUpdateDesc.TabIndex = 15;
            this.LocalUpdateDesc.Text = "Run an update by copying all files from a given directory into the mod folder.\r\nT" +
    "his is mainly meant for testing updates before being pushed publicly.";
            // 
            // OnlineUpdateDesc
            // 
            this.OnlineUpdateDesc.AutoSize = true;
            this.OnlineUpdateDesc.Font = new System.Drawing.Font("Lexend", 10F);
            this.OnlineUpdateDesc.ForeColor = System.Drawing.Color.White;
            this.OnlineUpdateDesc.Location = new System.Drawing.Point(227, 170);
            this.OnlineUpdateDesc.Name = "OnlineUpdateDesc";
            this.OnlineUpdateDesc.Size = new System.Drawing.Size(552, 44);
            this.OnlineUpdateDesc.TabIndex = 14;
            this.OnlineUpdateDesc.Text = "Run an update by downloading the mod\'s package files from the Git repository.\r\nSl" +
    "ower, but the preferred method for new users.";
            // 
            // LocalUpdateButton
            // 
            this.LocalUpdateButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LocalUpdateButton.Location = new System.Drawing.Point(12, 250);
            this.LocalUpdateButton.Name = "LocalUpdateButton";
            this.LocalUpdateButton.Size = new System.Drawing.Size(195, 42);
            this.LocalUpdateButton.TabIndex = 13;
            this.LocalUpdateButton.Text = "Local Update";
            this.LocalUpdateButton.UseVisualStyleBackColor = true;
            this.LocalUpdateButton.Click += new System.EventHandler(this.LocalUpdateButton_Click);
            // 
            // OnlineUpdateButton
            // 
            this.OnlineUpdateButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OnlineUpdateButton.Location = new System.Drawing.Point(10, 170);
            this.OnlineUpdateButton.Name = "OnlineUpdateButton";
            this.OnlineUpdateButton.Size = new System.Drawing.Size(195, 42);
            this.OnlineUpdateButton.TabIndex = 12;
            this.OnlineUpdateButton.Text = "Online Update";
            this.OnlineUpdateButton.UseVisualStyleBackColor = true;
            this.OnlineUpdateButton.Click += new System.EventHandler(this.OnlineUpdateButton_Click);
            // 
            // DiscordButtonHome
            // 
            this.DiscordButtonHome.BackgroundImage = global::WTDE_Updater_V2.Properties.Resources.discord;
            this.DiscordButtonHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DiscordButtonHome.Location = new System.Drawing.Point(721, 344);
            this.DiscordButtonHome.Name = "DiscordButtonHome";
            this.DiscordButtonHome.Size = new System.Drawing.Size(70, 70);
            this.DiscordButtonHome.TabIndex = 11;
            this.DiscordButtonHome.UseVisualStyleBackColor = true;
            this.DiscordButtonHome.Click += new System.EventHandler(this.JoinDiscordButton_Click);
            // 
            // SiteButtonHome
            // 
            this.SiteButtonHome.BackgroundImage = global::WTDE_Updater_V2.Properties.Resources.website;
            this.SiteButtonHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SiteButtonHome.Location = new System.Drawing.Point(632, 344);
            this.SiteButtonHome.Name = "SiteButtonHome";
            this.SiteButtonHome.Size = new System.Drawing.Size(70, 70);
            this.SiteButtonHome.TabIndex = 10;
            this.SiteButtonHome.UseVisualStyleBackColor = true;
            this.SiteButtonHome.Click += new System.EventHandler(this.WTDESiteButton_Click);
            // 
            // UpdaterLogoImageHome
            // 
            this.UpdaterLogoImageHome.BackColor = System.Drawing.Color.Transparent;
            this.UpdaterLogoImageHome.BackgroundImage = global::WTDE_Updater_V2.Properties.Resources.icon;
            this.UpdaterLogoImageHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdaterLogoImageHome.Location = new System.Drawing.Point(655, 12);
            this.UpdaterLogoImageHome.Name = "UpdaterLogoImageHome";
            this.UpdaterLogoImageHome.Size = new System.Drawing.Size(136, 136);
            this.UpdaterLogoImageHome.TabIndex = 2;
            this.UpdaterLogoImageHome.TabStop = false;
            // 
            // HeadLabelHome
            // 
            this.HeadLabelHome.AutoSize = true;
            this.HeadLabelHome.Font = new System.Drawing.Font("Lexend", 16F);
            this.HeadLabelHome.ForeColor = System.Drawing.Color.White;
            this.HeadLabelHome.Location = new System.Drawing.Point(179, 10);
            this.HeadLabelHome.Name = "HeadLabelHome";
            this.HeadLabelHome.Size = new System.Drawing.Size(451, 140);
            this.HeadLabelHome.TabIndex = 1;
            this.HeadLabelHome.Text = "Welcome to the GHWT: DE updater suite!\r\n\r\nWhat type of update are you\r\nlooking to" +
    " run?";
            // 
            // LogoImageHome
            // 
            this.LogoImageHome.BackColor = System.Drawing.Color.Transparent;
            this.LogoImageHome.BackgroundImage = global::WTDE_Updater_V2.Properties.Resources.logo;
            this.LogoImageHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogoImageHome.Location = new System.Drawing.Point(10, 6);
            this.LogoImageHome.Name = "LogoImageHome";
            this.LogoImageHome.Size = new System.Drawing.Size(152, 158);
            this.LogoImageHome.TabIndex = 0;
            this.LogoImageHome.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::WTDE_Updater_V2.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(800, 426);
            this.Controls.Add(this.MainUpdaterPanel);
            this.Controls.Add(this.IntroPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GHWT: Definitive Edition Updater - V2.0";
            ((System.ComponentModel.ISupportInitialize)(this.LogoImage)).EndInit();
            this.MainUpdaterPanel.ResumeLayout(false);
            this.MainUpdaterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpdaterLogoImage)).EndInit();
            this.IntroPanel.ResumeLayout(false);
            this.IntroPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpdaterLogoImageHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImageHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoImage;
        private System.Windows.Forms.Panel MainUpdaterPanel;
        private System.Windows.Forms.Label CurrentFileLabel;
        private System.Windows.Forms.ProgressBar CurrentFileProgress;
        private System.Windows.Forms.Label TotalProgressPercent;
        private System.Windows.Forms.ProgressBar TotalProgress;
        private System.Windows.Forms.Label TotalProgressLabel;
        private System.Windows.Forms.PictureBox UpdaterLogoImage;
        private System.Windows.Forms.Label HeadLabel;
        private System.Windows.Forms.Label VersionInfoLabel;
        private System.Windows.Forms.Button EndUpdateButton;
        private System.Windows.Forms.Button JoinDiscordButton;
        private System.Windows.Forms.Button WTDESiteButton;
        private System.Windows.Forms.Label TipLabel;
        private System.Windows.Forms.Label CurrentFileProgressPercent;
        private System.ComponentModel.BackgroundWorker BackgroundWorkerMain;
        private System.Windows.Forms.Panel IntroPanel;
        private System.Windows.Forms.Button DiscordButtonHome;
        private System.Windows.Forms.Button SiteButtonHome;
        private System.Windows.Forms.PictureBox UpdaterLogoImageHome;
        private System.Windows.Forms.Label HeadLabelHome;
        private System.Windows.Forms.PictureBox LogoImageHome;
        private System.Windows.Forms.Label LocalUpdateDesc;
        private System.Windows.Forms.Label OnlineUpdateDesc;
        private System.Windows.Forms.Button LocalUpdateButton;
        private System.Windows.Forms.Button OnlineUpdateButton;
        private System.Windows.Forms.Label VersionInfoLabelHome;
    }
}

