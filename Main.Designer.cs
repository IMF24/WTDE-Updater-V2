namespace WTDE_Updater_V2 {
    partial class Main {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            TotalProgress = new ProgressBar();
            LogoImage = new PictureBox();
            HeadLabel = new Label();
            TotalProgressPercent = new Label();
            TotalProgressLabel = new Label();
            EndUpdateButton = new Button();
            CurrentFileProgress = new ProgressBar();
            CurrentFileLabel = new Label();
            BeginUpdate = new Button();
            CurrentFileProgressPercent = new Label();
            BackgroundWorkerMain = new System.ComponentModel.BackgroundWorker();
            VersionInfoLabel = new Label();
            pictureBox1 = new PictureBox();
            TipLabel = new NewLabel();
            JoinDiscordButton = new Button();
            WTDESiteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)LogoImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TotalProgress
            // 
            TotalProgress.ForeColor = SystemColors.MenuHighlight;
            TotalProgress.Location = new Point(12, 252);
            TotalProgress.Name = "TotalProgress";
            TotalProgress.Size = new Size(976, 29);
            TotalProgress.TabIndex = 0;
            // 
            // LogoImage
            // 
            LogoImage.BackColor = Color.Transparent;
            LogoImage.BackgroundImage = Properties.Resources.logo;
            LogoImage.BackgroundImageLayout = ImageLayout.Stretch;
            LogoImage.Location = new Point(12, 5);
            LogoImage.Name = "LogoImage";
            LogoImage.Size = new Size(190, 198);
            LogoImage.TabIndex = 1;
            LogoImage.TabStop = false;
            // 
            // HeadLabel
            // 
            HeadLabel.AutoSize = true;
            HeadLabel.BackColor = Color.Transparent;
            HeadLabel.Font = new Font("Lexend", 16F, FontStyle.Regular, GraphicsUnit.Point);
            HeadLabel.ForeColor = Color.White;
            HeadLabel.Location = new Point(224, 12);
            HeadLabel.Name = "HeadLabel";
            HeadLabel.Size = new Size(540, 172);
            HeadLabel.TabIndex = 2;
            HeadLabel.Text = "Sit tight, we're updating your mod!\r\nUpdating to Version x...\r\n\r\nBe patient, make yourself a cup of tea...\r\n";
            // 
            // TotalProgressPercent
            // 
            TotalProgressPercent.Anchor = AnchorStyles.Right;
            TotalProgressPercent.BackColor = Color.Transparent;
            TotalProgressPercent.Font = new Font("Lexend", 16F, FontStyle.Regular, GraphicsUnit.Point);
            TotalProgressPercent.ForeColor = Color.White;
            TotalProgressPercent.Location = new Point(716, 206);
            TotalProgressPercent.Name = "TotalProgressPercent";
            TotalProgressPercent.Size = new Size(272, 43);
            TotalProgressPercent.TabIndex = 3;
            TotalProgressPercent.Text = "0%";
            TotalProgressPercent.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TotalProgressLabel
            // 
            TotalProgressLabel.AutoSize = true;
            TotalProgressLabel.BackColor = Color.Transparent;
            TotalProgressLabel.Font = new Font("Lexend", 16F, FontStyle.Regular, GraphicsUnit.Point);
            TotalProgressLabel.ForeColor = Color.White;
            TotalProgressLabel.Location = new Point(12, 206);
            TotalProgressLabel.Name = "TotalProgressLabel";
            TotalProgressLabel.Size = new Size(205, 43);
            TotalProgressLabel.TabIndex = 4;
            TotalProgressLabel.Text = "Total Progress";
            TotalProgressLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EndUpdateButton
            // 
            EndUpdateButton.Enabled = false;
            EndUpdateButton.Location = new Point(790, 491);
            EndUpdateButton.Name = "EndUpdateButton";
            EndUpdateButton.Size = new Size(198, 29);
            EndUpdateButton.TabIndex = 5;
            EndUpdateButton.Text = "Cancel Update";
            EndUpdateButton.UseVisualStyleBackColor = true;
            EndUpdateButton.Click += EndUpdateButton_Click;
            // 
            // CurrentFileProgress
            // 
            CurrentFileProgress.Location = new Point(12, 343);
            CurrentFileProgress.Name = "CurrentFileProgress";
            CurrentFileProgress.Size = new Size(976, 29);
            CurrentFileProgress.TabIndex = 6;
            // 
            // CurrentFileLabel
            // 
            CurrentFileLabel.AutoSize = true;
            CurrentFileLabel.BackColor = Color.Transparent;
            CurrentFileLabel.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CurrentFileLabel.ForeColor = Color.White;
            CurrentFileLabel.Location = new Point(12, 308);
            CurrentFileLabel.Name = "CurrentFileLabel";
            CurrentFileLabel.Size = new Size(321, 32);
            CurrentFileLabel.TabIndex = 7;
            CurrentFileLabel.Text = "Downloading File: NAME_HERE";
            CurrentFileLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // BeginUpdate
            // 
            BeginUpdate.Location = new Point(586, 491);
            BeginUpdate.Name = "BeginUpdate";
            BeginUpdate.Size = new Size(198, 29);
            BeginUpdate.TabIndex = 8;
            BeginUpdate.Text = "Start Update";
            BeginUpdate.UseVisualStyleBackColor = true;
            BeginUpdate.Click += BeginUpdate_Click;
            // 
            // CurrentFileProgressPercent
            // 
            CurrentFileProgressPercent.Anchor = AnchorStyles.Right;
            CurrentFileProgressPercent.BackColor = Color.Transparent;
            CurrentFileProgressPercent.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CurrentFileProgressPercent.ForeColor = Color.White;
            CurrentFileProgressPercent.Location = new Point(889, 308);
            CurrentFileProgressPercent.Name = "CurrentFileProgressPercent";
            CurrentFileProgressPercent.Size = new Size(99, 32);
            CurrentFileProgressPercent.TabIndex = 9;
            CurrentFileProgressPercent.Text = "0%";
            CurrentFileProgressPercent.TextAlign = ContentAlignment.MiddleRight;
            CurrentFileProgressPercent.Click += CurrentFileProgressPercent_Click;
            // 
            // BackgroundWorkerMain
            // 
            BackgroundWorkerMain.WorkerReportsProgress = true;
            BackgroundWorkerMain.DoWork += BackgroundWorkerMain_DoWork;
            // 
            // VersionInfoLabel
            // 
            VersionInfoLabel.AutoSize = true;
            VersionInfoLabel.BackColor = Color.Transparent;
            VersionInfoLabel.Font = new Font("Lexend", 10F, FontStyle.Regular, GraphicsUnit.Point);
            VersionInfoLabel.ForeColor = Color.White;
            VersionInfoLabel.Location = new Point(12, 466);
            VersionInfoLabel.Name = "VersionInfoLabel";
            VersionInfoLabel.Size = new Size(283, 54);
            VersionInfoLabel.TabIndex = 10;
            VersionInfoLabel.Text = "GHWT: DE Updater Vx by IMF24\r\nBG Image: Fox (FoxInari)\r\n";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.icon;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(818, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(170, 170);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // TipLabel
            // 
            TipLabel.BackColor = Color.Transparent;
            TipLabel.Font = new Font("Lexend", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TipLabel.ForeColor = Color.White;
            TipLabel.Location = new Point(21, 387);
            TipLabel.Name = "TipLabel";
            TipLabel.Size = new Size(753, 74);
            TipLabel.TabIndex = 12;
            TipLabel.Text = "Random Text Placeholder\r\n";
            TipLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // JoinDiscordButton
            // 
            JoinDiscordButton.BackColor = Color.Transparent;
            JoinDiscordButton.BackgroundImage = Properties.Resources.discord;
            JoinDiscordButton.BackgroundImageLayout = ImageLayout.Stretch;
            JoinDiscordButton.ForeColor = Color.White;
            JoinDiscordButton.Location = new Point(901, 383);
            JoinDiscordButton.Name = "JoinDiscordButton";
            JoinDiscordButton.Size = new Size(87, 87);
            JoinDiscordButton.TabIndex = 13;
            JoinDiscordButton.UseVisualStyleBackColor = false;
            JoinDiscordButton.Click += JoinDiscordButton_Click;
            // 
            // WTDESiteButton
            // 
            WTDESiteButton.BackColor = Color.Transparent;
            WTDESiteButton.BackgroundImage = Properties.Resources.website;
            WTDESiteButton.BackgroundImageLayout = ImageLayout.Stretch;
            WTDESiteButton.ForeColor = Color.White;
            WTDESiteButton.Location = new Point(790, 383);
            WTDESiteButton.Name = "WTDESiteButton";
            WTDESiteButton.Size = new Size(87, 87);
            WTDESiteButton.TabIndex = 14;
            WTDESiteButton.UseVisualStyleBackColor = false;
            WTDESiteButton.Click += WTDESiteButton_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = Properties.Resources.bg;
            ClientSize = new Size(1000, 532);
            Controls.Add(WTDESiteButton);
            Controls.Add(JoinDiscordButton);
            Controls.Add(TipLabel);
            Controls.Add(pictureBox1);
            Controls.Add(VersionInfoLabel);
            Controls.Add(CurrentFileProgressPercent);
            Controls.Add(BeginUpdate);
            Controls.Add(CurrentFileLabel);
            Controls.Add(CurrentFileProgress);
            Controls.Add(EndUpdateButton);
            Controls.Add(TotalProgressLabel);
            Controls.Add(TotalProgressPercent);
            Controls.Add(HeadLabel);
            Controls.Add(LogoImage);
            Controls.Add(TotalProgress);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            Text = "GHWT: Definitive Edition Updater - V2.0";
            Shown += Main_Load;
            FormClosing += Main_FormClosing;
            ((System.ComponentModel.ISupportInitialize)LogoImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Main_FormClosing1(object sender, FormClosingEventArgs e) {
            throw new NotImplementedException();
        }

        #endregion

        private ProgressBar TotalProgress;
        private PictureBox LogoImage;
        private Label HeadLabel;
        private Label TotalProgressLabel;
        private Button EndUpdateButton;
        private Label CurrentFileLabel;
        private Button BeginUpdate;
        public System.ComponentModel.BackgroundWorker BackgroundWorkerMain;
        public ProgressBar CurrentFileProgress;
        public Label CurrentFileProgressPercent;
        public Label TotalProgressPercent;
        private Label VersionInfoLabel;
        private PictureBox pictureBox1;
        public NewLabel TipLabel;
        private Button JoinDiscordButton;
        private Button WTDESiteButton;
    }
}
