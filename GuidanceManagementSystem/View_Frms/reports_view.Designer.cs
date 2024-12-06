namespace GuidanceManagementSystem.View_Frms
{
    partial class reports_view
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reports_view));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtStudentID = new CuoreUI.Controls.cuiTextBox2();
            this.cuiLabel2 = new CuoreUI.Controls.cuiLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.printDocument = new System.Windows.Forms.Button();
            this.exportexcel = new System.Windows.Forms.Button();
            this.exportpdf = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCourses = new System.Windows.Forms.ComboBox();
            this.cuiLabel1 = new CuoreUI.Controls.cuiLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbCourses);
            this.panel2.Controls.Add(this.cuiLabel1);
            this.panel2.Controls.Add(this.txtStudentID);
            this.panel2.Controls.Add(this.cuiLabel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(15, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 49);
            this.panel2.TabIndex = 10;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStudentID.BackColor = System.Drawing.SystemColors.Control;
            this.txtStudentID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtStudentID.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.txtStudentID.BorderSize = 1;
            this.txtStudentID.Content = "";
            this.txtStudentID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentID.ForeColor = System.Drawing.Color.Gray;
            this.txtStudentID.Location = new System.Drawing.Point(817, 4);
            this.txtStudentID.Margin = new System.Windows.Forms.Padding(4);
            this.txtStudentID.Multiline = false;
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Padding = new System.Windows.Forms.Padding(15, 14, 15, 0);
            this.txtStudentID.PasswordChar = false;
            this.txtStudentID.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtStudentID.PlaceholderText = "Search...";
            this.txtStudentID.Rounding = 8;
            this.txtStudentID.Size = new System.Drawing.Size(210, 42);
            this.txtStudentID.TabIndex = 7;
            this.txtStudentID.TextOffset = new System.Drawing.Size(0, 0);
            this.txtStudentID.UnderlinedStyle = false;
            // 
            // cuiLabel2
            // 
            this.cuiLabel2.Content = "User/Reports";
            this.cuiLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.cuiLabel2.Font = new System.Drawing.Font("Segoe UI", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.cuiLabel2.HorizontalAlignment = CuoreUI.Controls.cuiLabel.HorizontalAlignments.Left;
            this.cuiLabel2.Location = new System.Drawing.Point(0, 0);
            this.cuiLabel2.Name = "cuiLabel2";
            this.cuiLabel2.Size = new System.Drawing.Size(1028, 49);
            this.cuiLabel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(15, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 590);
            this.panel1.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.panel4.Location = new System.Drawing.Point(0, 533);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1027, 5);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.printDocument);
            this.panel3.Controls.Add(this.exportexcel);
            this.panel3.Controls.Add(this.exportpdf);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 533);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1028, 57);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1028, 535);
            this.dataGridView1.TabIndex = 0;
            // 
            // printDocument
            // 
            this.printDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printDocument.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.printDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printDocument.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printDocument.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.printDocument.Image = ((System.Drawing.Image)(resources.GetObject("printDocument.Image")));
            this.printDocument.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.printDocument.Location = new System.Drawing.Point(893, 11);
            this.printDocument.Name = "printDocument";
            this.printDocument.Size = new System.Drawing.Size(131, 43);
            this.printDocument.TabIndex = 4;
            this.printDocument.Text = "Print";
            this.printDocument.UseVisualStyleBackColor = false;
            this.printDocument.Click += new System.EventHandler(this.button3_Click);
            // 
            // exportexcel
            // 
            this.exportexcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportexcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.exportexcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportexcel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportexcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exportexcel.Image = ((System.Drawing.Image)(resources.GetObject("exportexcel.Image")));
            this.exportexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportexcel.Location = new System.Drawing.Point(759, 11);
            this.exportexcel.Name = "exportexcel";
            this.exportexcel.Size = new System.Drawing.Size(128, 43);
            this.exportexcel.TabIndex = 3;
            this.exportexcel.Text = "Export to excel";
            this.exportexcel.UseVisualStyleBackColor = false;
            this.exportexcel.Click += new System.EventHandler(this.exportexcel_Click);
            // 
            // exportpdf
            // 
            this.exportpdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportpdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.exportpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportpdf.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportpdf.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exportpdf.Image = ((System.Drawing.Image)(resources.GetObject("exportpdf.Image")));
            this.exportpdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportpdf.Location = new System.Drawing.Point(616, 11);
            this.exportpdf.Name = "exportpdf";
            this.exportpdf.Size = new System.Drawing.Size(137, 43);
            this.exportpdf.TabIndex = 0;
            this.exportpdf.Text = "Export to pdf";
            this.exportpdf.UseVisualStyleBackColor = false;
            this.exportpdf.Click += new System.EventHandler(this.exportpdf_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(651, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(137, 34);
            this.button4.TabIndex = 5;
            this.button4.Text = "View Report";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "Filter by course";
            // 
            // cmbCourses
            // 
            this.cmbCourses.FormattingEnabled = true;
            this.cmbCourses.Items.AddRange(new object[] {
            "COA",
            "CICS",
            "CHM",
            "CTED",
            "All"});
            this.cmbCourses.Location = new System.Drawing.Point(404, 18);
            this.cmbCourses.Name = "cmbCourses";
            this.cmbCourses.Size = new System.Drawing.Size(99, 29);
            this.cmbCourses.TabIndex = 12;
            // 
            // cuiLabel1
            // 
            this.cuiLabel1.Content = "User/Registration";
            this.cuiLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cuiLabel1.Font = new System.Drawing.Font("Segoe UI", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.cuiLabel1.HorizontalAlignment = CuoreUI.Controls.cuiLabel.HorizontalAlignments.Left;
            this.cuiLabel1.Location = new System.Drawing.Point(0, 49);
            this.cuiLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.cuiLabel1.Name = "cuiLabel1";
            this.cuiLabel1.Size = new System.Drawing.Size(1028, 0);
            this.cuiLabel1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(509, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "     Generate Report";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reports_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 622);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "reports_view";
            this.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.Text = "reports_view";
            this.Load += new System.EventHandler(this.reports_view_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private CuoreUI.Controls.cuiTextBox2 txtStudentID;
        private CuoreUI.Controls.cuiLabel cuiLabel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button exportpdf;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button printDocument;
        private System.Windows.Forms.Button exportexcel;
        private System.Windows.Forms.Button button4;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCourses;
        private CuoreUI.Controls.cuiLabel cuiLabel1;
        private System.Windows.Forms.Button button1;
    }
}