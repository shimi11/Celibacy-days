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
            this.labelCycleNight = new System.Windows.Forms.Label();
            this.labelCycleDay = new System.Windows.Forms.Label();
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
            // labelCycleNight
            // 
            this.labelCycleNight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCycleNight.AutoSize = true;
            this.labelCycleNight.BackColor = System.Drawing.Color.Red;
            this.labelCycleNight.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCycleNight.Location = new System.Drawing.Point(109, 14);
            this.labelCycleNight.Name = "labelCycleNight";
            this.labelCycleNight.Size = new System.Drawing.Size(32, 28);
            this.labelCycleNight.TabIndex = 3;
            this.labelCycleNight.Text = "ראית\r\nלילה";
            this.labelCycleNight.Visible = false;
            // 
            // labelCycleDay
            // 
            this.labelCycleDay.AutoSize = true;
            this.labelCycleDay.BackColor = System.Drawing.Color.Red;
            this.labelCycleDay.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCycleDay.Location = new System.Drawing.Point(3, 14);
            this.labelCycleDay.Name = "labelCycleDay";
            this.labelCycleDay.Size = new System.Drawing.Size(32, 28);
            this.labelCycleDay.TabIndex = 4;
            this.labelCycleDay.Text = "ראית\r\n  יום ";
            this.labelCycleDay.Visible = false;
            // 
            // DayBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.Controls.Add(this.labelCycleDay);
            this.Controls.Add(this.labelCycleNight);
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
        private System.Windows.Forms.Label labelCycleNight;
        private System.Windows.Forms.Label labelCycleDay;
    }
}
