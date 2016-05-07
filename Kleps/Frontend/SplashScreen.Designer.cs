using System;
namespace Kleps.Frontend {
    partial class SplashScreen {
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
            try {
                base.Dispose(disposing);   
            }catch(Exception e){
                base.BeginInvoke(new Action(() => base.Dispose(disposing)));
            }

           
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.LoaderBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LoaderBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoaderBox
            // 
            this.LoaderBox.Location = new System.Drawing.Point(12, 12);
            this.LoaderBox.Name = "LoaderBox";
            this.LoaderBox.Size = new System.Drawing.Size(260, 237);
            this.LoaderBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoaderBox.TabIndex = 0;
            this.LoaderBox.TabStop = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.LoaderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.Text = "SplashScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.LoaderBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LoaderBox;
    }
}