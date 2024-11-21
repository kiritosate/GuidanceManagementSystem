namespace GuidanceManagementSystem.View_Frms
{
    partial class view_irf
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.printFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cuiButton1 = new CuoreUI.Controls.cuiButton();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printFormToolStripMenuItem,
            this.approveFormToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1240, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // printFormToolStripMenuItem
            // 
            this.printFormToolStripMenuItem.Name = "printFormToolStripMenuItem";
            this.printFormToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.printFormToolStripMenuItem.Text = "Print Form";
            this.printFormToolStripMenuItem.Click += new System.EventHandler(this.printFormToolStripMenuItem_Click);
            // 
            // approveFormToolStripMenuItem
            // 
            this.approveFormToolStripMenuItem.Name = "approveFormToolStripMenuItem";
            this.approveFormToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.approveFormToolStripMenuItem.Text = "Approve Form";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.MaximumSize = new System.Drawing.Size(1240, 1754);
            this.panel1.MinimumSize = new System.Drawing.Size(1240, 1754);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1240, 1754);
            this.panel1.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1240, 1754);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1232, 1728);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Page 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::GuidanceManagementSystem.Properties.Resources._731402e0_fe47_46db_8ebb_295e66760000_0;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.CausesValidation = false;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1226, 1722);
            this.panel2.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::GuidanceManagementSystem.Properties.Resources._731402e0_fe47_46db_8ebb_295e66760000_1;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1232, 1728);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Page 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cuiButton1
            // 
            this.cuiButton1.BackColor = System.Drawing.Color.Transparent;
            this.cuiButton1.CheckButton = false;
            this.cuiButton1.Checked = false;
            this.cuiButton1.CheckedBackground = System.Drawing.Color.Red;
            this.cuiButton1.CheckedImageTint = System.Drawing.Color.White;
            this.cuiButton1.CheckedOutline = System.Drawing.Color.Red;
            this.cuiButton1.Content = "";
            this.cuiButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cuiButton1.ForeColor = System.Drawing.Color.White;
            this.cuiButton1.HoverBackground = System.Drawing.Color.Maroon;
            this.cuiButton1.HoveredImageTint = System.Drawing.Color.Transparent;
            this.cuiButton1.HoverOutline = System.Drawing.Color.Empty;
            this.cuiButton1.Image = global::GuidanceManagementSystem.Properties.Resources.multiply_50px;
            this.cuiButton1.ImageAutoCenter = true;
            this.cuiButton1.ImageExpand = new System.Drawing.Point(3, 3);
            this.cuiButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.cuiButton1.ImageTint = System.Drawing.Color.White;
            this.cuiButton1.Location = new System.Drawing.Point(1184, 12);
            this.cuiButton1.Name = "cuiButton1";
            this.cuiButton1.NormalBackground = System.Drawing.Color.Red;
            this.cuiButton1.NormalOutline = System.Drawing.Color.Empty;
            this.cuiButton1.OutlineThickness = 1.6F;
            this.cuiButton1.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cuiButton1.PressedImageTint = System.Drawing.Color.Transparent;
            this.cuiButton1.PressedOutline = System.Drawing.Color.Empty;
            this.cuiButton1.Rounding = new System.Windows.Forms.Padding(15);
            this.cuiButton1.Size = new System.Drawing.Size(30, 30);
            this.cuiButton1.TabIndex = 13;
            this.cuiButton1.TextOffset = new System.Drawing.Point(0, 0);
            this.cuiButton1.Click += new System.EventHandler(this.cuiButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(295, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "22-2222";
            // 
            // view_irf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1240, 808);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cuiButton1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1240, 1754);
            this.Name = "view_irf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "view_irf";
            this.Load += new System.EventHandler(this.view_irf_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem printFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approveFormToolStripMenuItem;
        private CuoreUI.Controls.cuiButton cuiButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}