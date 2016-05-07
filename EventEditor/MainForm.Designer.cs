namespace EventEditor
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
            this.AddButton = new System.Windows.Forms.Button();
            this.EventsListBox = new System.Windows.Forms.ListBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EventTextBox = new System.Windows.Forms.TextBox();
            this.AnswersListBox = new System.Windows.Forms.ListBox();
            this.RightAnswerBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NewAnswerBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddAnswerButton = new System.Windows.Forms.Button();
            this.RemoveAnswerButton = new System.Windows.Forms.Button();
            this.NewEventButton = new System.Windows.Forms.Button();
            this.MegaOmegaParser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(365, 462);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(171, 22);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Update";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // EventsListBox
            // 
            this.EventsListBox.FormattingEnabled = true;
            this.EventsListBox.Location = new System.Drawing.Point(12, 12);
            this.EventsListBox.Name = "EventsListBox";
            this.EventsListBox.Size = new System.Drawing.Size(347, 472);
            this.EventsListBox.TabIndex = 1;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(674, 462);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(171, 22);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // EventTextBox
            // 
            this.EventTextBox.Location = new System.Drawing.Point(365, 103);
            this.EventTextBox.Multiline = true;
            this.EventTextBox.Name = "EventTextBox";
            this.EventTextBox.Size = new System.Drawing.Size(480, 184);
            this.EventTextBox.TabIndex = 3;
            // 
            // AnswersListBox
            // 
            this.AnswersListBox.FormattingEnabled = true;
            this.AnswersListBox.Location = new System.Drawing.Point(369, 361);
            this.AnswersListBox.Name = "AnswersListBox";
            this.AnswersListBox.Size = new System.Drawing.Size(433, 95);
            this.AnswersListBox.TabIndex = 4;
            // 
            // RightAnswerBox
            // 
            this.RightAnswerBox.Location = new System.Drawing.Point(448, 303);
            this.RightAnswerBox.Name = "RightAnswerBox";
            this.RightAnswerBox.Size = new System.Drawing.Size(401, 20);
            this.RightAnswerBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Right answer:";
            // 
            // NewAnswerBox
            // 
            this.NewAnswerBox.Location = new System.Drawing.Point(448, 330);
            this.NewAnswerBox.Name = "NewAnswerBox";
            this.NewAnswerBox.Size = new System.Drawing.Size(401, 20);
            this.NewAnswerBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "New answer:";
            // 
            // AddAnswerButton
            // 
            this.AddAnswerButton.Location = new System.Drawing.Point(808, 361);
            this.AddAnswerButton.Name = "AddAnswerButton";
            this.AddAnswerButton.Size = new System.Drawing.Size(41, 44);
            this.AddAnswerButton.TabIndex = 9;
            this.AddAnswerButton.Text = "ADD";
            this.AddAnswerButton.UseVisualStyleBackColor = true;
            // 
            // RemoveAnswerButton
            // 
            this.RemoveAnswerButton.Location = new System.Drawing.Point(808, 411);
            this.RemoveAnswerButton.Name = "RemoveAnswerButton";
            this.RemoveAnswerButton.Size = new System.Drawing.Size(41, 44);
            this.RemoveAnswerButton.TabIndex = 10;
            this.RemoveAnswerButton.Text = "REM";
            this.RemoveAnswerButton.UseVisualStyleBackColor = true;
            // 
            // NewEventButton
            // 
            this.NewEventButton.Location = new System.Drawing.Point(543, 462);
            this.NewEventButton.Name = "NewEventButton";
            this.NewEventButton.Size = new System.Drawing.Size(125, 22);
            this.NewEventButton.TabIndex = 11;
            this.NewEventButton.Text = "New";
            this.NewEventButton.UseVisualStyleBackColor = true;
            // 
            // MegaOmegaParser
            // 
            this.MegaOmegaParser.Location = new System.Drawing.Point(365, 12);
            this.MegaOmegaParser.Name = "MegaOmegaParser";
            this.MegaOmegaParser.Size = new System.Drawing.Size(480, 85);
            this.MegaOmegaParser.TabIndex = 12;
            this.MegaOmegaParser.Text = "MegaOmegaParser";
            this.MegaOmegaParser.UseVisualStyleBackColor = true;
            this.MegaOmegaParser.Click += new System.EventHandler(this.MegaOmegaParser_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 496);
            this.Controls.Add(this.MegaOmegaParser);
            this.Controls.Add(this.NewEventButton);
            this.Controls.Add(this.RemoveAnswerButton);
            this.Controls.Add(this.AddAnswerButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NewAnswerBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RightAnswerBox);
            this.Controls.Add(this.AnswersListBox);
            this.Controls.Add(this.EventTextBox);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EventsListBox);
            this.Controls.Add(this.AddButton);
            this.Name = "MainForm";
            this.Text = "Event Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListBox EventsListBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TextBox EventTextBox;
        private System.Windows.Forms.ListBox AnswersListBox;
        private System.Windows.Forms.TextBox RightAnswerBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewAnswerBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddAnswerButton;
        private System.Windows.Forms.Button RemoveAnswerButton;
        public System.Windows.Forms.Button NewEventButton;
        private System.Windows.Forms.Button MegaOmegaParser;
    }
}

