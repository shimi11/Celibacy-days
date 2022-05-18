namespace Celibacy_days.Forms
{
    partial class DayBox
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
            this.label_dayInMonth = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_dayInMonth
            // 
            this.label_dayInMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_dayInMonth.AutoSize = true;
            this.label_dayInMonth.Location = new System.Drawing.Point(59, 0);
            this.label_dayInMonth.Name = "label_dayInMonth";
            this.label_dayInMonth.Size = new System.Drawing.Size(24, 13);
            this.label_dayInMonth.TabIndex = 2;
            this.label_dayInMonth.Text = "day";
            this.label_dayInMonth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DayBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.Controls.Add(this.label_dayInMonth);
            this.Name = "DayBox";
            this.Size = new System.Drawing.Size(145, 144);
            this.Load += new System.EventHandler(this.DayBox_Load);
            this.Click += new System.EventHandler(this.DayBox_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_dayInMonth;
    }
}
