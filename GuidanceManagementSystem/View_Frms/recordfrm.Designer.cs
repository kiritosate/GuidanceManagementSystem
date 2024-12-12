namespace GuidanceManagementSystem.View_Frms
{
    partial class recordfrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cuiLabel2 = new CuoreUI.Controls.cuiLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cuiLabel1 = new CuoreUI.Controls.cuiLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCourses = new System.Windows.Forms.ComboBox();
            this.cuiTextBox21 = new CuoreUI.Controls.cuiTextBox2();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cuiLabel2
            // 
            this.cuiLabel2.Content = "User/Registration";
            this.cuiLabel2.Font = new System.Drawing.Font("Segoe UI", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.cuiLabel2.HorizontalAlignment = CuoreUI.Controls.cuiLabel.HorizontalAlignments.Left;
            this.cuiLabel2.Location = new System.Drawing.Point(49, -221);
            this.cuiLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.cuiLabel2.Name = "cuiLabel2";
            this.cuiLabel2.Size = new System.Drawing.Size(1022, 49);
            this.cuiLabel2.TabIndex = 10;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 71);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.Size = new System.Drawing.Size(1022, 479);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // cuiLabel1
            // 
            this.cuiLabel1.Content = "User/Records";
            this.cuiLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cuiLabel1.Font = new System.Drawing.Font("Segoe UI", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.cuiLabel1.HorizontalAlignment = CuoreUI.Controls.cuiLabel.HorizontalAlignments.Left;
            this.cuiLabel1.Location = new System.Drawing.Point(15, 16);
            this.cuiLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.cuiLabel1.Name = "cuiLabel1";
            this.cuiLabel1.Size = new System.Drawing.Size(1022, 49);
            this.cuiLabel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 21);
            this.label1.TabIndex = 18;
            this.label1.Text = "Filter by course";
            // 
            // cmbCourses
            // 
            this.cmbCourses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCourses.FormattingEnabled = true;
            this.cmbCourses.Items.AddRange(new object[] {
            "COA",
            "CICS",
            "CHM",
            "CTED",
            "All"});
            this.cmbCourses.Location = new System.Drawing.Point(414, 36);
            this.cmbCourses.Name = "cmbCourses";
            this.cmbCourses.Size = new System.Drawing.Size(100, 29);
            this.cmbCourses.TabIndex = 16;
            this.cmbCourses.Text = "   --select--";
            // 
            // cuiTextBox21
            // 
            this.cuiTextBox21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cuiTextBox21.BackColor = System.Drawing.SystemColors.Control;
            this.cuiTextBox21.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cuiTextBox21.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiTextBox21.BorderSize = 1;
            this.cuiTextBox21.Content = "";
            this.cuiTextBox21.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cuiTextBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiTextBox21.ForeColor = System.Drawing.Color.Gray;
            this.cuiTextBox21.Location = new System.Drawing.Point(827, 23);
            this.cuiTextBox21.Margin = new System.Windows.Forms.Padding(4);
            this.cuiTextBox21.Multiline = false;
            this.cuiTextBox21.Name = "cuiTextBox21";
            this.cuiTextBox21.Padding = new System.Windows.Forms.Padding(15, 14, 15, 0);
            this.cuiTextBox21.PasswordChar = false;
            this.cuiTextBox21.PlaceholderColor = System.Drawing.Color.DimGray;
            this.cuiTextBox21.PlaceholderText = "Search...";
            this.cuiTextBox21.Rounding = 8;
            this.cuiTextBox21.Size = new System.Drawing.Size(210, 42);
            this.cuiTextBox21.TabIndex = 17;
            this.cuiTextBox21.TextOffset = new System.Drawing.Size(0, 0);
            this.cuiTextBox21.UnderlinedStyle = false;
            this.cuiTextBox21.ContentChanged += new System.EventHandler(this.cuiTextBox21_ContentChanged_1);
            // 
            // recordfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 560);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCourses);
            this.Controls.Add(this.cuiTextBox21);
            this.Controls.Add(this.cuiLabel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cuiLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "recordfrm";
            this.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.Text = "recordfrm";
            this.Load += new System.EventHandler(this.recordfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CuoreUI.Controls.cuiLabel cuiLabel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CuoreUI.Controls.cuiLabel cuiLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCourses;
        private CuoreUI.Controls.cuiTextBox2 cuiTextBox21;
    }
}