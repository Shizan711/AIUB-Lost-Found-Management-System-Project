namespace AiubLost_Found
{
    partial class adminItems
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LFitemdataGridView = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SEARCHbutton = new System.Windows.Forms.Button();
            this.ADDbutton = new System.Windows.Forms.Button();
            this.DELETEbutton = new System.Windows.Forms.Button();
            this.UPDATEbutton = new System.Windows.Forms.Button();
            this.resetbtn = new System.Windows.Forms.Button();
            this.contactbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LocBox = new System.Windows.Forms.TextBox();
            this.namebox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.itemnamebox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.DescBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CategorycomboBox = new System.Windows.Forms.ComboBox();
            this.LFdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.StatuscomboBox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LFitemdataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Footlight MT Light", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 24);
            this.label8.TabIndex = 90;
            this.label8.Text = "Lost/Found Items:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.LFitemdataGridView);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(440, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 593);
            this.panel2.TabIndex = 93;
            // 
            // LFitemdataGridView
            // 
            this.LFitemdataGridView.AllowUserToAddRows = false;
            this.LFitemdataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LFitemdataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.LFitemdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LFitemdataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.LFitemdataGridView.Location = new System.Drawing.Point(16, 36);
            this.LFitemdataGridView.Name = "LFitemdataGridView";
            this.LFitemdataGridView.RowHeadersWidth = 51;
            this.LFitemdataGridView.RowTemplate.Height = 24;
            this.LFitemdataGridView.Size = new System.Drawing.Size(617, 545);
            this.LFitemdataGridView.TabIndex = 91;
            this.LFitemdataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LFitemdataGridView_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.SEARCHbutton);
            this.panel3.Controls.Add(this.ADDbutton);
            this.panel3.Controls.Add(this.DELETEbutton);
            this.panel3.Controls.Add(this.UPDATEbutton);
            this.panel3.Controls.Add(this.resetbtn);
            this.panel3.Controls.Add(this.contactbox);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.LocBox);
            this.panel3.Controls.Add(this.namebox);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.itemnamebox);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.DescBox);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.CategorycomboBox);
            this.panel3.Controls.Add(this.LFdateTimePicker);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.StatuscomboBox);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Location = new System.Drawing.Point(13, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(421, 596);
            this.panel3.TabIndex = 103;
            // 
            // SEARCHbutton
            // 
            this.SEARCHbutton.BackColor = System.Drawing.Color.Red;
            this.SEARCHbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SEARCHbutton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEARCHbutton.ForeColor = System.Drawing.Color.White;
            this.SEARCHbutton.Location = new System.Drawing.Point(18, 505);
            this.SEARCHbutton.Name = "SEARCHbutton";
            this.SEARCHbutton.Size = new System.Drawing.Size(134, 41);
            this.SEARCHbutton.TabIndex = 128;
            this.SEARCHbutton.TabStop = false;
            this.SEARCHbutton.Text = "SEARCH";
            this.SEARCHbutton.UseVisualStyleBackColor = false;
            this.SEARCHbutton.Click += new System.EventHandler(this.SEARCHbutton_Click);
            // 
            // ADDbutton
            // 
            this.ADDbutton.BackColor = System.Drawing.Color.SkyBlue;
            this.ADDbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ADDbutton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADDbutton.ForeColor = System.Drawing.Color.White;
            this.ADDbutton.Location = new System.Drawing.Point(158, 505);
            this.ADDbutton.Name = "ADDbutton";
            this.ADDbutton.Size = new System.Drawing.Size(82, 41);
            this.ADDbutton.TabIndex = 127;
            this.ADDbutton.TabStop = false;
            this.ADDbutton.Text = "ADD";
            this.ADDbutton.UseVisualStyleBackColor = false;
            this.ADDbutton.Click += new System.EventHandler(this.ADDbutton_Click);
            // 
            // DELETEbutton
            // 
            this.DELETEbutton.BackColor = System.Drawing.Color.SkyBlue;
            this.DELETEbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DELETEbutton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DELETEbutton.ForeColor = System.Drawing.Color.White;
            this.DELETEbutton.Location = new System.Drawing.Point(59, 552);
            this.DELETEbutton.Name = "DELETEbutton";
            this.DELETEbutton.Size = new System.Drawing.Size(140, 41);
            this.DELETEbutton.TabIndex = 126;
            this.DELETEbutton.TabStop = false;
            this.DELETEbutton.Text = "DELETE";
            this.DELETEbutton.UseVisualStyleBackColor = false;
            this.DELETEbutton.Click += new System.EventHandler(this.DELETEbutton_Click);
            // 
            // UPDATEbutton
            // 
            this.UPDATEbutton.BackColor = System.Drawing.Color.SkyBlue;
            this.UPDATEbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UPDATEbutton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UPDATEbutton.ForeColor = System.Drawing.Color.White;
            this.UPDATEbutton.Location = new System.Drawing.Point(244, 505);
            this.UPDATEbutton.Name = "UPDATEbutton";
            this.UPDATEbutton.Size = new System.Drawing.Size(137, 41);
            this.UPDATEbutton.TabIndex = 125;
            this.UPDATEbutton.TabStop = false;
            this.UPDATEbutton.Text = "UPDATE";
            this.UPDATEbutton.UseVisualStyleBackColor = false;
            this.UPDATEbutton.Click += new System.EventHandler(this.UPDATEbutton_Click);
            // 
            // resetbtn
            // 
            this.resetbtn.BackColor = System.Drawing.Color.SkyBlue;
            this.resetbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetbtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetbtn.ForeColor = System.Drawing.Color.White;
            this.resetbtn.Location = new System.Drawing.Point(208, 552);
            this.resetbtn.Name = "resetbtn";
            this.resetbtn.Size = new System.Drawing.Size(140, 41);
            this.resetbtn.TabIndex = 124;
            this.resetbtn.TabStop = false;
            this.resetbtn.Text = "RESET";
            this.resetbtn.UseVisualStyleBackColor = false;
            this.resetbtn.Click += new System.EventHandler(this.resetbtn_Click);
            // 
            // contactbox
            // 
            this.contactbox.BackColor = System.Drawing.Color.SkyBlue;
            this.contactbox.Font = new System.Drawing.Font("Candara", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactbox.ForeColor = System.Drawing.Color.Black;
            this.contactbox.Location = new System.Drawing.Point(18, 455);
            this.contactbox.Name = "contactbox";
            this.contactbox.Size = new System.Drawing.Size(363, 36);
            this.contactbox.TabIndex = 123;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Footlight MT Light", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(14, 428);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(224, 24);
            this.label10.TabIndex = 122;
            this.label10.Text = "Contact(Teams/Phone):";
            // 
            // LocBox
            // 
            this.LocBox.BackColor = System.Drawing.Color.SkyBlue;
            this.LocBox.Font = new System.Drawing.Font("Candara", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocBox.ForeColor = System.Drawing.Color.Black;
            this.LocBox.Location = new System.Drawing.Point(206, 195);
            this.LocBox.Name = "LocBox";
            this.LocBox.Size = new System.Drawing.Size(175, 36);
            this.LocBox.TabIndex = 114;
            // 
            // namebox
            // 
            this.namebox.BackColor = System.Drawing.Color.SkyBlue;
            this.namebox.Font = new System.Drawing.Font("Candara", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namebox.ForeColor = System.Drawing.Color.Black;
            this.namebox.Location = new System.Drawing.Point(18, 389);
            this.namebox.Name = "namebox";
            this.namebox.Size = new System.Drawing.Size(363, 36);
            this.namebox.TabIndex = 121;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Footlight MT Light", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(14, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(193, 24);
            this.label9.TabIndex = 120;
            this.label9.Text = "Name(Reported By):";
            // 
            // itemnamebox
            // 
            this.itemnamebox.BackColor = System.Drawing.Color.SkyBlue;
            this.itemnamebox.Font = new System.Drawing.Font("Candara", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemnamebox.ForeColor = System.Drawing.Color.Black;
            this.itemnamebox.Location = new System.Drawing.Point(18, 63);
            this.itemnamebox.Name = "itemnamebox";
            this.itemnamebox.Size = new System.Drawing.Size(363, 36);
            this.itemnamebox.TabIndex = 119;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Footlight MT Light", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(14, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 24);
            this.label11.TabIndex = 112;
            this.label11.Text = "Item:";
            // 
            // DescBox
            // 
            this.DescBox.BackColor = System.Drawing.Color.SkyBlue;
            this.DescBox.Font = new System.Drawing.Font("Candara", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescBox.ForeColor = System.Drawing.Color.Black;
            this.DescBox.Location = new System.Drawing.Point(18, 323);
            this.DescBox.Name = "DescBox";
            this.DescBox.Size = new System.Drawing.Size(363, 36);
            this.DescBox.TabIndex = 118;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Footlight MT Light", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 24);
            this.label12.TabIndex = 108;
            this.label12.Text = "Category:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Footlight MT Light", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 296);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 24);
            this.label13.TabIndex = 117;
            this.label13.Text = "Description:";
            // 
            // CategorycomboBox
            // 
            this.CategorycomboBox.BackColor = System.Drawing.Color.SkyBlue;
            this.CategorycomboBox.Font = new System.Drawing.Font("Candara", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CategorycomboBox.ForeColor = System.Drawing.Color.Black;
            this.CategorycomboBox.FormattingEnabled = true;
            this.CategorycomboBox.Items.AddRange(new object[] {
            "Electronic Devices",
            "ID Card",
            "Wallet/Bagpack",
            "Books",
            "Notes",
            "Stationary Items",
            "Others"});
            this.CategorycomboBox.Location = new System.Drawing.Point(18, 129);
            this.CategorycomboBox.Name = "CategorycomboBox";
            this.CategorycomboBox.Size = new System.Drawing.Size(363, 36);
            this.CategorycomboBox.TabIndex = 111;
            // 
            // LFdateTimePicker
            // 
            this.LFdateTimePicker.CalendarFont = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFdateTimePicker.CalendarForeColor = System.Drawing.Color.SkyBlue;
            this.LFdateTimePicker.CalendarMonthBackground = System.Drawing.Color.SkyBlue;
            this.LFdateTimePicker.CalendarTitleBackColor = System.Drawing.Color.White;
            this.LFdateTimePicker.CalendarTitleForeColor = System.Drawing.Color.White;
            this.LFdateTimePicker.CalendarTrailingForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.LFdateTimePicker.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFdateTimePicker.Location = new System.Drawing.Point(18, 261);
            this.LFdateTimePicker.Name = "LFdateTimePicker";
            this.LFdateTimePicker.Size = new System.Drawing.Size(363, 32);
            this.LFdateTimePicker.TabIndex = 116;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Footlight MT Light", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(204, 168);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 24);
            this.label14.TabIndex = 113;
            this.label14.Text = "Location:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Footlight MT Light", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(14, 234);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 24);
            this.label15.TabIndex = 115;
            this.label15.Text = "Date:";
            // 
            // StatuscomboBox
            // 
            this.StatuscomboBox.BackColor = System.Drawing.Color.SkyBlue;
            this.StatuscomboBox.Font = new System.Drawing.Font("Candara", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatuscomboBox.ForeColor = System.Drawing.Color.White;
            this.StatuscomboBox.FormattingEnabled = true;
            this.StatuscomboBox.Items.AddRange(new object[] {
            "Lost",
            "Found"});
            this.StatuscomboBox.Location = new System.Drawing.Point(18, 195);
            this.StatuscomboBox.Name = "StatuscomboBox";
            this.StatuscomboBox.Size = new System.Drawing.Size(181, 36);
            this.StatuscomboBox.TabIndex = 110;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Footlight MT Light", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(14, 168);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 24);
            this.label16.TabIndex = 109;
            this.label16.Text = "Status:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Footlight MT Light", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(14, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(326, 24);
            this.label17.TabIndex = 91;
            this.label17.Text = "Enter Details for Lost/Found Items:";
            // 
            // adminItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "adminItems";
            this.Size = new System.Drawing.Size(1090, 599);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LFitemdataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView LFitemdataGridView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox contactbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox LocBox;
        private System.Windows.Forms.TextBox namebox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox itemnamebox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox DescBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox CategorycomboBox;
        private System.Windows.Forms.DateTimePicker LFdateTimePicker;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox StatuscomboBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button SEARCHbutton;
        private System.Windows.Forms.Button ADDbutton;
        private System.Windows.Forms.Button DELETEbutton;
        private System.Windows.Forms.Button UPDATEbutton;
        private System.Windows.Forms.Button resetbtn;
    }
}
