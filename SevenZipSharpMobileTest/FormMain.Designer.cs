namespace SevenZipSharpMobileTest
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.tb_Log = new System.Windows.Forms.TextBox();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // tb_Log
            // 
            this.tb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Log.Location = new System.Drawing.Point(0, 0);
            this.tb_Log.Multiline = true;
            this.tb_Log.Name = "tb_Log";
            this.tb_Log.Size = new System.Drawing.Size(240, 268);
            this.tb_Log.TabIndex = 0;
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Test";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tb_Log);
            this.Menu = this.mainMenu1;
            this.Name = "FormMain";
            this.Text = "SevenZipSharp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Log;
        private System.Windows.Forms.MenuItem menuItem1;
    }
}

