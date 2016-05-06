namespace Kleps.Frontend.UserControls {
    partial class CloseButton {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Kleps.Properties.Resources.close;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DoubleBuffered = true;
            this.Name = "CloseButton";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DownMouse);
            this.MouseEnter += new System.EventHandler(this.EnterMouse);
            this.MouseLeave += new System.EventHandler(this.RevertMouse);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RevertMouse);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
