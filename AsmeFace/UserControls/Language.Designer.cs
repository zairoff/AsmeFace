namespace AsmeFace.UserControls
{
    partial class Language
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EnglishPictureBox = new System.Windows.Forms.PictureBox();
            this.RussianPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RussianPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // EnglishPictureBox
            // 
            this.EnglishPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnglishPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EnglishPictureBox.Image = global::AsmeFace.Properties.Resources.uk;
            this.EnglishPictureBox.Location = new System.Drawing.Point(201, 135);
            this.EnglishPictureBox.Name = "EnglishPictureBox";
            this.EnglishPictureBox.Size = new System.Drawing.Size(184, 141);
            this.EnglishPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EnglishPictureBox.TabIndex = 0;
            this.EnglishPictureBox.TabStop = false;
            this.EnglishPictureBox.Click += new System.EventHandler(this.EnglishPictureBox_Click);
            // 
            // RussianPictureBox
            // 
            this.RussianPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RussianPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RussianPictureBox.Image = global::AsmeFace.Properties.Resources.ru;
            this.RussianPictureBox.Location = new System.Drawing.Point(391, 135);
            this.RussianPictureBox.Name = "RussianPictureBox";
            this.RussianPictureBox.Size = new System.Drawing.Size(184, 141);
            this.RussianPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RussianPictureBox.TabIndex = 1;
            this.RussianPictureBox.TabStop = false;
            this.RussianPictureBox.Click += new System.EventHandler(this.RussianPictureBox_Click);
            // 
            // Language
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RussianPictureBox);
            this.Controls.Add(this.EnglishPictureBox);
            this.Name = "Language";
            this.Size = new System.Drawing.Size(740, 440);
            ((System.ComponentModel.ISupportInitialize)(this.EnglishPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RussianPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox EnglishPictureBox;
        private System.Windows.Forms.PictureBox RussianPictureBox;
    }
}
