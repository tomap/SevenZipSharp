namespace SevenZipTestForms
{
    partial class FormMain
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
            this.pb_CompressProgress = new System.Windows.Forms.ProgressBar();
            this.pb_CompressWork = new System.Windows.Forms.ProgressBar();
            this.b_Compress = new System.Windows.Forms.Button();
            this.l_CompressProgress = new System.Windows.Forms.Label();
            this.tb_CompressDirectory = new System.Windows.Forms.TextBox();
            this.l_CompressDirectory = new System.Windows.Forms.Label();
            this.b_Browse = new System.Windows.Forms.Button();
            this.gb_Settings = new System.Windows.Forms.GroupBox();
            this.nup_VolumeSize = new System.Windows.Forms.NumericUpDown();
            this.l_Volumes = new System.Windows.Forms.Label();
            this.chb_Sfx = new System.Windows.Forms.CheckBox();
            this.l_Method = new System.Windows.Forms.Label();
            this.cb_Method = new System.Windows.Forms.ComboBox();
            this.l_CompressionLevel = new System.Windows.Forms.Label();
            this.trb_Level = new System.Windows.Forms.TrackBar();
            this.l_Format = new System.Windows.Forms.Label();
            this.cb_Format = new System.Windows.Forms.ComboBox();
            this.fbd_Directory = new System.Windows.Forms.FolderBrowserDialog();
            this.b_BrowseOut = new System.Windows.Forms.Button();
            this.l_CompressOutput = new System.Windows.Forms.Label();
            this.tb_CompressOutput = new System.Windows.Forms.TextBox();
            this.sfd_Archive = new System.Windows.Forms.SaveFileDialog();
            this.tbc_Main = new System.Windows.Forms.TabControl();
            this.tp_Extract = new System.Windows.Forms.TabPage();
            this.tb_Messages = new System.Windows.Forms.TextBox();
            this.pb_ExtractProgress = new System.Windows.Forms.ProgressBar();
            this.b_ExtractBrowseArchive = new System.Windows.Forms.Button();
            this.pb_ExtractWork = new System.Windows.Forms.ProgressBar();
            this.l_ExtractArchiveName = new System.Windows.Forms.Label();
            this.b_Extract = new System.Windows.Forms.Button();
            this.tb_ExtractArchive = new System.Windows.Forms.TextBox();
            this.l_ExtractProgress = new System.Windows.Forms.Label();
            this.tb_ExtractDirectory = new System.Windows.Forms.TextBox();
            this.b_ExtractBrowseDirectory = new System.Windows.Forms.Button();
            this.l_ExtractDirectory = new System.Windows.Forms.Label();
            this.tp_Compress = new System.Windows.Forms.TabPage();
            this.ofd_Archive = new System.Windows.Forms.OpenFileDialog();
            this.chb_Volumes = new System.Windows.Forms.CheckBox();
            this.gb_Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_VolumeSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Level)).BeginInit();
            this.tbc_Main.SuspendLayout();
            this.tp_Extract.SuspendLayout();
            this.tp_Compress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_CompressProgress
            // 
            this.pb_CompressProgress.Location = new System.Drawing.Point(6, 24);
            this.pb_CompressProgress.Name = "pb_CompressProgress";
            this.pb_CompressProgress.Size = new System.Drawing.Size(195, 16);
            this.pb_CompressProgress.TabIndex = 0;
            // 
            // pb_CompressWork
            // 
            this.pb_CompressWork.Location = new System.Drawing.Point(6, 46);
            this.pb_CompressWork.MarqueeAnimationSpeed = 25;
            this.pb_CompressWork.Name = "pb_CompressWork";
            this.pb_CompressWork.Size = new System.Drawing.Size(195, 16);
            this.pb_CompressWork.TabIndex = 1;
            // 
            // b_Compress
            // 
            this.b_Compress.Location = new System.Drawing.Point(207, 24);
            this.b_Compress.Name = "b_Compress";
            this.b_Compress.Size = new System.Drawing.Size(66, 38);
            this.b_Compress.TabIndex = 2;
            this.b_Compress.Text = "Compress";
            this.b_Compress.UseVisualStyleBackColor = true;
            this.b_Compress.Click += new System.EventHandler(this.b_Compress_Click);
            // 
            // l_CompressProgress
            // 
            this.l_CompressProgress.AutoSize = true;
            this.l_CompressProgress.Location = new System.Drawing.Point(6, 8);
            this.l_CompressProgress.Name = "l_CompressProgress";
            this.l_CompressProgress.Size = new System.Drawing.Size(48, 13);
            this.l_CompressProgress.TabIndex = 3;
            this.l_CompressProgress.Text = "Progress";
            // 
            // tb_CompressDirectory
            // 
            this.tb_CompressDirectory.Location = new System.Drawing.Point(6, 83);
            this.tb_CompressDirectory.Name = "tb_CompressDirectory";
            this.tb_CompressDirectory.Size = new System.Drawing.Size(195, 20);
            this.tb_CompressDirectory.TabIndex = 4;
            // 
            // l_CompressDirectory
            // 
            this.l_CompressDirectory.AutoSize = true;
            this.l_CompressDirectory.Location = new System.Drawing.Point(6, 67);
            this.l_CompressDirectory.Name = "l_CompressDirectory";
            this.l_CompressDirectory.Size = new System.Drawing.Size(109, 13);
            this.l_CompressDirectory.TabIndex = 5;
            this.l_CompressDirectory.Text = "Directory to compress";
            // 
            // b_Browse
            // 
            this.b_Browse.Location = new System.Drawing.Point(207, 83);
            this.b_Browse.Name = "b_Browse";
            this.b_Browse.Size = new System.Drawing.Size(66, 20);
            this.b_Browse.TabIndex = 6;
            this.b_Browse.Text = "Browse";
            this.b_Browse.UseVisualStyleBackColor = true;
            this.b_Browse.Click += new System.EventHandler(this.b_Browse_Click);
            // 
            // gb_Settings
            // 
            this.gb_Settings.Controls.Add(this.chb_Volumes);
            this.gb_Settings.Controls.Add(this.nup_VolumeSize);
            this.gb_Settings.Controls.Add(this.l_Volumes);
            this.gb_Settings.Controls.Add(this.chb_Sfx);
            this.gb_Settings.Controls.Add(this.l_Method);
            this.gb_Settings.Controls.Add(this.cb_Method);
            this.gb_Settings.Controls.Add(this.l_CompressionLevel);
            this.gb_Settings.Controls.Add(this.trb_Level);
            this.gb_Settings.Controls.Add(this.l_Format);
            this.gb_Settings.Controls.Add(this.cb_Format);
            this.gb_Settings.Location = new System.Drawing.Point(6, 157);
            this.gb_Settings.Name = "gb_Settings";
            this.gb_Settings.Size = new System.Drawing.Size(267, 142);
            this.gb_Settings.TabIndex = 7;
            this.gb_Settings.TabStop = false;
            this.gb_Settings.Text = "Settings";
            // 
            // nup_VolumeSize
            // 
            this.nup_VolumeSize.Location = new System.Drawing.Point(184, 78);
            this.nup_VolumeSize.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nup_VolumeSize.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nup_VolumeSize.Name = "nup_VolumeSize";
            this.nup_VolumeSize.Size = new System.Drawing.Size(75, 20);
            this.nup_VolumeSize.TabIndex = 7;
            this.nup_VolumeSize.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // l_Volumes
            // 
            this.l_Volumes.AutoSize = true;
            this.l_Volumes.Location = new System.Drawing.Point(181, 103);
            this.l_Volumes.Name = "l_Volumes";
            this.l_Volumes.Size = new System.Drawing.Size(59, 13);
            this.l_Volumes.TabIndex = 8;
            this.l_Volumes.Text = "bytes each";
            // 
            // chb_Sfx
            // 
            this.chb_Sfx.AutoSize = true;
            this.chb_Sfx.Location = new System.Drawing.Point(16, 119);
            this.chb_Sfx.Name = "chb_Sfx";
            this.chb_Sfx.Size = new System.Drawing.Size(93, 17);
            this.chb_Sfx.TabIndex = 6;
            this.chb_Sfx.Text = "Self-extraction";
            this.chb_Sfx.UseVisualStyleBackColor = true;
            // 
            // l_Method
            // 
            this.l_Method.AutoSize = true;
            this.l_Method.Location = new System.Drawing.Point(139, 22);
            this.l_Method.Name = "l_Method";
            this.l_Method.Size = new System.Drawing.Size(43, 13);
            this.l_Method.TabIndex = 5;
            this.l_Method.Text = "Method";
            // 
            // cb_Method
            // 
            this.cb_Method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Method.FormattingEnabled = true;
            this.cb_Method.Location = new System.Drawing.Point(184, 19);
            this.cb_Method.Name = "cb_Method";
            this.cb_Method.Size = new System.Drawing.Size(70, 21);
            this.cb_Method.TabIndex = 4;
            // 
            // l_CompressionLevel
            // 
            this.l_CompressionLevel.AutoSize = true;
            this.l_CompressionLevel.Location = new System.Drawing.Point(13, 55);
            this.l_CompressionLevel.Name = "l_CompressionLevel";
            this.l_CompressionLevel.Size = new System.Drawing.Size(92, 13);
            this.l_CompressionLevel.TabIndex = 3;
            this.l_CompressionLevel.Text = "Compression level";
            // 
            // trb_Level
            // 
            this.trb_Level.Location = new System.Drawing.Point(12, 71);
            this.trb_Level.Name = "trb_Level";
            this.trb_Level.Size = new System.Drawing.Size(153, 45);
            this.trb_Level.TabIndex = 2;
            this.trb_Level.Scroll += new System.EventHandler(this.trb_Level_Scroll);
            // 
            // l_Format
            // 
            this.l_Format.AutoSize = true;
            this.l_Format.Location = new System.Drawing.Point(9, 22);
            this.l_Format.Name = "l_Format";
            this.l_Format.Size = new System.Drawing.Size(39, 13);
            this.l_Format.TabIndex = 1;
            this.l_Format.Text = "Format";
            // 
            // cb_Format
            // 
            this.cb_Format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Format.FormattingEnabled = true;
            this.cb_Format.Location = new System.Drawing.Point(54, 19);
            this.cb_Format.Name = "cb_Format";
            this.cb_Format.Size = new System.Drawing.Size(77, 21);
            this.cb_Format.TabIndex = 0;
            // 
            // b_BrowseOut
            // 
            this.b_BrowseOut.Location = new System.Drawing.Point(207, 131);
            this.b_BrowseOut.Name = "b_BrowseOut";
            this.b_BrowseOut.Size = new System.Drawing.Size(66, 20);
            this.b_BrowseOut.TabIndex = 10;
            this.b_BrowseOut.Text = "Browse";
            this.b_BrowseOut.UseVisualStyleBackColor = true;
            this.b_BrowseOut.Click += new System.EventHandler(this.b_BrowseOut_Click);
            // 
            // l_CompressOutput
            // 
            this.l_CompressOutput.AutoSize = true;
            this.l_CompressOutput.Location = new System.Drawing.Point(6, 115);
            this.l_CompressOutput.Name = "l_CompressOutput";
            this.l_CompressOutput.Size = new System.Drawing.Size(88, 13);
            this.l_CompressOutput.TabIndex = 9;
            this.l_CompressOutput.Text = "Archive file name";
            // 
            // tb_CompressOutput
            // 
            this.tb_CompressOutput.Location = new System.Drawing.Point(6, 131);
            this.tb_CompressOutput.Name = "tb_CompressOutput";
            this.tb_CompressOutput.Size = new System.Drawing.Size(195, 20);
            this.tb_CompressOutput.TabIndex = 8;
            // 
            // sfd_Archive
            // 
            this.sfd_Archive.Title = "Save the archive to...";
            // 
            // tbc_Main
            // 
            this.tbc_Main.Controls.Add(this.tp_Extract);
            this.tbc_Main.Controls.Add(this.tp_Compress);
            this.tbc_Main.Location = new System.Drawing.Point(0, 0);
            this.tbc_Main.Name = "tbc_Main";
            this.tbc_Main.SelectedIndex = 0;
            this.tbc_Main.Size = new System.Drawing.Size(287, 330);
            this.tbc_Main.TabIndex = 7;
            // 
            // tp_Extract
            // 
            this.tp_Extract.Controls.Add(this.tb_Messages);
            this.tp_Extract.Controls.Add(this.pb_ExtractProgress);
            this.tp_Extract.Controls.Add(this.b_ExtractBrowseArchive);
            this.tp_Extract.Controls.Add(this.pb_ExtractWork);
            this.tp_Extract.Controls.Add(this.l_ExtractArchiveName);
            this.tp_Extract.Controls.Add(this.b_Extract);
            this.tp_Extract.Controls.Add(this.tb_ExtractArchive);
            this.tp_Extract.Controls.Add(this.l_ExtractProgress);
            this.tp_Extract.Controls.Add(this.tb_ExtractDirectory);
            this.tp_Extract.Controls.Add(this.b_ExtractBrowseDirectory);
            this.tp_Extract.Controls.Add(this.l_ExtractDirectory);
            this.tp_Extract.Location = new System.Drawing.Point(4, 22);
            this.tp_Extract.Name = "tp_Extract";
            this.tp_Extract.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Extract.Size = new System.Drawing.Size(279, 304);
            this.tp_Extract.TabIndex = 0;
            this.tp_Extract.Text = "Extract";
            this.tp_Extract.UseVisualStyleBackColor = true;
            // 
            // tb_Messages
            // 
            this.tb_Messages.Location = new System.Drawing.Point(6, 152);
            this.tb_Messages.Multiline = true;
            this.tb_Messages.Name = "tb_Messages";
            this.tb_Messages.Size = new System.Drawing.Size(263, 142);
            this.tb_Messages.TabIndex = 21;
            // 
            // pb_ExtractProgress
            // 
            this.pb_ExtractProgress.Location = new System.Drawing.Point(3, 19);
            this.pb_ExtractProgress.Name = "pb_ExtractProgress";
            this.pb_ExtractProgress.Size = new System.Drawing.Size(195, 16);
            this.pb_ExtractProgress.TabIndex = 11;
            // 
            // b_ExtractBrowseArchive
            // 
            this.b_ExtractBrowseArchive.Location = new System.Drawing.Point(204, 126);
            this.b_ExtractBrowseArchive.Name = "b_ExtractBrowseArchive";
            this.b_ExtractBrowseArchive.Size = new System.Drawing.Size(66, 20);
            this.b_ExtractBrowseArchive.TabIndex = 20;
            this.b_ExtractBrowseArchive.Text = "Browse";
            this.b_ExtractBrowseArchive.UseVisualStyleBackColor = true;
            this.b_ExtractBrowseArchive.Click += new System.EventHandler(this.b_ExtractBrowseArchive_Click);
            // 
            // pb_ExtractWork
            // 
            this.pb_ExtractWork.Location = new System.Drawing.Point(3, 41);
            this.pb_ExtractWork.MarqueeAnimationSpeed = 25;
            this.pb_ExtractWork.Name = "pb_ExtractWork";
            this.pb_ExtractWork.Size = new System.Drawing.Size(195, 16);
            this.pb_ExtractWork.TabIndex = 12;
            // 
            // l_ExtractArchiveName
            // 
            this.l_ExtractArchiveName.AutoSize = true;
            this.l_ExtractArchiveName.Location = new System.Drawing.Point(3, 110);
            this.l_ExtractArchiveName.Name = "l_ExtractArchiveName";
            this.l_ExtractArchiveName.Size = new System.Drawing.Size(88, 13);
            this.l_ExtractArchiveName.TabIndex = 19;
            this.l_ExtractArchiveName.Text = "Archive file name";
            // 
            // b_Extract
            // 
            this.b_Extract.Location = new System.Drawing.Point(204, 19);
            this.b_Extract.Name = "b_Extract";
            this.b_Extract.Size = new System.Drawing.Size(66, 38);
            this.b_Extract.TabIndex = 13;
            this.b_Extract.Text = "Extract";
            this.b_Extract.UseVisualStyleBackColor = true;
            this.b_Extract.Click += new System.EventHandler(this.b_Extract_Click);
            // 
            // tb_ExtractArchive
            // 
            this.tb_ExtractArchive.Location = new System.Drawing.Point(3, 126);
            this.tb_ExtractArchive.Name = "tb_ExtractArchive";
            this.tb_ExtractArchive.Size = new System.Drawing.Size(195, 20);
            this.tb_ExtractArchive.TabIndex = 18;
            // 
            // l_ExtractProgress
            // 
            this.l_ExtractProgress.AutoSize = true;
            this.l_ExtractProgress.Location = new System.Drawing.Point(3, 3);
            this.l_ExtractProgress.Name = "l_ExtractProgress";
            this.l_ExtractProgress.Size = new System.Drawing.Size(48, 13);
            this.l_ExtractProgress.TabIndex = 14;
            this.l_ExtractProgress.Text = "Progress";
            // 
            // tb_ExtractDirectory
            // 
            this.tb_ExtractDirectory.Location = new System.Drawing.Point(3, 78);
            this.tb_ExtractDirectory.Name = "tb_ExtractDirectory";
            this.tb_ExtractDirectory.Size = new System.Drawing.Size(195, 20);
            this.tb_ExtractDirectory.TabIndex = 15;
            // 
            // b_ExtractBrowseDirectory
            // 
            this.b_ExtractBrowseDirectory.Location = new System.Drawing.Point(204, 78);
            this.b_ExtractBrowseDirectory.Name = "b_ExtractBrowseDirectory";
            this.b_ExtractBrowseDirectory.Size = new System.Drawing.Size(66, 20);
            this.b_ExtractBrowseDirectory.TabIndex = 17;
            this.b_ExtractBrowseDirectory.Text = "Browse";
            this.b_ExtractBrowseDirectory.UseVisualStyleBackColor = true;
            this.b_ExtractBrowseDirectory.Click += new System.EventHandler(this.b_ExtractBrowseDirectory_Click);
            // 
            // l_ExtractDirectory
            // 
            this.l_ExtractDirectory.AutoSize = true;
            this.l_ExtractDirectory.Location = new System.Drawing.Point(3, 62);
            this.l_ExtractDirectory.Name = "l_ExtractDirectory";
            this.l_ExtractDirectory.Size = new System.Drawing.Size(82, 13);
            this.l_ExtractDirectory.TabIndex = 16;
            this.l_ExtractDirectory.Text = "Output directory";
            // 
            // tp_Compress
            // 
            this.tp_Compress.Controls.Add(this.pb_CompressProgress);
            this.tp_Compress.Controls.Add(this.b_BrowseOut);
            this.tp_Compress.Controls.Add(this.pb_CompressWork);
            this.tp_Compress.Controls.Add(this.l_CompressOutput);
            this.tp_Compress.Controls.Add(this.b_Compress);
            this.tp_Compress.Controls.Add(this.tb_CompressOutput);
            this.tp_Compress.Controls.Add(this.l_CompressProgress);
            this.tp_Compress.Controls.Add(this.gb_Settings);
            this.tp_Compress.Controls.Add(this.tb_CompressDirectory);
            this.tp_Compress.Controls.Add(this.b_Browse);
            this.tp_Compress.Controls.Add(this.l_CompressDirectory);
            this.tp_Compress.Location = new System.Drawing.Point(4, 22);
            this.tp_Compress.Name = "tp_Compress";
            this.tp_Compress.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Compress.Size = new System.Drawing.Size(279, 304);
            this.tp_Compress.TabIndex = 1;
            this.tp_Compress.Text = "Compress";
            this.tp_Compress.UseVisualStyleBackColor = true;
            // 
            // ofd_Archive
            // 
            this.ofd_Archive.Title = "Open an archive...";
            // 
            // chb_Volumes
            // 
            this.chb_Volumes.AutoSize = true;
            this.chb_Volumes.Location = new System.Drawing.Point(184, 55);
            this.chb_Volumes.Name = "chb_Volumes";
            this.chb_Volumes.Size = new System.Drawing.Size(66, 17);
            this.chb_Volumes.TabIndex = 10;
            this.chb_Volumes.Text = "Volumes";
            this.chb_Volumes.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 328);
            this.Controls.Add(this.tbc_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SevenZipSharp Windows Forms Demonstration";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.gb_Settings.ResumeLayout(false);
            this.gb_Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nup_VolumeSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Level)).EndInit();
            this.tbc_Main.ResumeLayout(false);
            this.tp_Extract.ResumeLayout(false);
            this.tp_Extract.PerformLayout();
            this.tp_Compress.ResumeLayout(false);
            this.tp_Compress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_CompressProgress;
        private System.Windows.Forms.ProgressBar pb_CompressWork;
        private System.Windows.Forms.Button b_Compress;
        private System.Windows.Forms.Label l_CompressProgress;
        private System.Windows.Forms.TextBox tb_CompressDirectory;
        private System.Windows.Forms.Label l_CompressDirectory;
        private System.Windows.Forms.Button b_Browse;
        private System.Windows.Forms.GroupBox gb_Settings;
        private System.Windows.Forms.Label l_Format;
        private System.Windows.Forms.ComboBox cb_Format;
        private System.Windows.Forms.FolderBrowserDialog fbd_Directory;
        private System.Windows.Forms.Label l_CompressionLevel;
        private System.Windows.Forms.TrackBar trb_Level;
        private System.Windows.Forms.Label l_Method;
        private System.Windows.Forms.ComboBox cb_Method;
        private System.Windows.Forms.CheckBox chb_Sfx;
        private System.Windows.Forms.Button b_BrowseOut;
        private System.Windows.Forms.Label l_CompressOutput;
        private System.Windows.Forms.TextBox tb_CompressOutput;
        private System.Windows.Forms.SaveFileDialog sfd_Archive;
        private System.Windows.Forms.TabControl tbc_Main;
        private System.Windows.Forms.TabPage tp_Extract;
        private System.Windows.Forms.TabPage tp_Compress;
        private System.Windows.Forms.TextBox tb_Messages;
        private System.Windows.Forms.ProgressBar pb_ExtractProgress;
        private System.Windows.Forms.Button b_ExtractBrowseArchive;
        private System.Windows.Forms.ProgressBar pb_ExtractWork;
        private System.Windows.Forms.Label l_ExtractArchiveName;
        private System.Windows.Forms.Button b_Extract;
        private System.Windows.Forms.TextBox tb_ExtractArchive;
        private System.Windows.Forms.Label l_ExtractProgress;
        private System.Windows.Forms.TextBox tb_ExtractDirectory;
        private System.Windows.Forms.Button b_ExtractBrowseDirectory;
        private System.Windows.Forms.Label l_ExtractDirectory;
        private System.Windows.Forms.OpenFileDialog ofd_Archive;
        private System.Windows.Forms.NumericUpDown nup_VolumeSize;
        private System.Windows.Forms.Label l_Volumes;
        private System.Windows.Forms.CheckBox chb_Volumes;
    }
}

