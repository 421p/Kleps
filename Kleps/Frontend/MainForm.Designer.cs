namespace Kleps.Frontend
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.closeButton1 = new Kleps.Frontend.UserControls.CloseButton();
            this.ChromeBox = new Kleps.Frontend.ChromeBox();
            this.SuspendLayout();
            // 
            // closeButton1
            // 
            this.closeButton1.BackColor = System.Drawing.Color.Transparent;
            this.closeButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton1.BackgroundImage")));
            this.closeButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeButton1.Location = new System.Drawing.Point(577, 12);
            this.closeButton1.Name = "closeButton1";
            this.closeButton1.Size = new System.Drawing.Size(227, 205);
            this.closeButton1.TabIndex = 1;
            this.closeButton1.Click += new System.EventHandler(this.Exit);
            // 
            // ChromeBox
            // 
            this.ChromeBox.Location = new System.Drawing.Point(12, 12);
            this.ChromeBox.Name = "ChromeBox";
            this.ChromeBox.Size = new System.Drawing.Size(604, 360);
            this.ChromeBox.TabIndex = 0;
            this.ChromeBox.Load += new System.EventHandler(this.OnLoadChromeBox);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 384);
            this.Controls.Add(this.closeButton1);
            this.Controls.Add(this.ChromeBox);
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ChromeBox ChromeBox;
        private UserControls.CloseButton closeButton1;
    }
}

