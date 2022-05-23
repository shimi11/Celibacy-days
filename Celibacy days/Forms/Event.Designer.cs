namespace Celibacy_days.Forms
{
    partial class eventForm
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
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.list_events = new System.Windows.Forms.ListBox();
            this.save_event = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxData
            // 
            this.textBoxData.Enabled = false;
            this.textBoxData.Location = new System.Drawing.Point(80, 25);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.ReadOnly = true;
            this.textBoxData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxData.Size = new System.Drawing.Size(196, 20);
            this.textBoxData.TabIndex = 1;
            this.textBoxData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "תאריך";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "בחר אירוע";
            // 
            // list_events
            // 
            this.list_events.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_events.FormattingEnabled = true;
            this.list_events.ItemHeight = 16;
            this.list_events.Items.AddRange(new object[] {
            "< בחר >"});
            this.list_events.Location = new System.Drawing.Point(80, 106);
            this.list_events.Name = "list_events";
            this.list_events.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.list_events.Size = new System.Drawing.Size(196, 52);
            this.list_events.TabIndex = 7;
            this.list_events.Visible = false;
            this.list_events.SelectedIndexChanged += new System.EventHandler(this.list_events_SelectedIndexChanged);
            // 
            // save_event
            // 
            this.save_event.Location = new System.Drawing.Point(120, 180);
            this.save_event.Name = "save_event";
            this.save_event.Size = new System.Drawing.Size(118, 27);
            this.save_event.TabIndex = 8;
            this.save_event.Text = "שמור";
            this.save_event.UseVisualStyleBackColor = true;
            this.save_event.Visible = false;
            this.save_event.Click += new System.EventHandler(this.save_event_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(80, 89);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(196, 21);
            this.buttonSelect.TabIndex = 9;
            this.buttonSelect.Text = "< בחר >";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // eventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 219);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.save_event);
            this.Controls.Add(this.list_events);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "eventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "הוסף אירוע";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox list_events;
        private System.Windows.Forms.Button save_event;
        private System.Windows.Forms.Button buttonSelect;
    }
}