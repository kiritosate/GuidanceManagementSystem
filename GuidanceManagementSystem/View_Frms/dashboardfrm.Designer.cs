namespace GuidanceManagementSystem.View_Frms
{
    partial class dashboardfrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashboardfrm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cuiLabel1 = new CuoreUI.Controls.cuiLabel();
            this.dockingPnl = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cuiLabel2 = new CuoreUI.Controls.cuiLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cuiLabel3 = new CuoreUI.Controls.cuiLabel();
            this.cuiButton7 = new CuoreUI.Controls.cuiButton();
            this.cuiButton6 = new CuoreUI.Controls.cuiButton();
            this.cuiButton5 = new CuoreUI.Controls.cuiButton();
            this.cuiButton4 = new CuoreUI.Controls.cuiButton();
            this.cuiButton3 = new CuoreUI.Controls.cuiButton();
            this.cuiButton8 = new CuoreUI.Controls.cuiButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cuiButton2 = new CuoreUI.Controls.cuiButton();
            this.cuiButton1 = new CuoreUI.Controls.cuiButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.splitContainer1.Panel2.Controls.Add(this.dockingPnl);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(849, 564);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cuiButton7);
            this.panel1.Controls.Add(this.cuiButton6);
            this.panel1.Controls.Add(this.cuiButton5);
            this.panel1.Controls.Add(this.cuiButton4);
            this.panel1.Controls.Add(this.cuiButton3);
            this.panel1.Location = new System.Drawing.Point(12, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 346);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cuiButton8);
            this.panel3.Controls.Add(this.cuiLabel1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 200);
            this.panel3.TabIndex = 0;
            // 
            // cuiLabel1
            // 
            this.cuiLabel1.Content = "Username";
            this.cuiLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel1.ForeColor = System.Drawing.Color.Gainsboro;
            this.cuiLabel1.HorizontalAlignment = CuoreUI.Controls.cuiLabel.HorizontalAlignments.Center;
            this.cuiLabel1.Location = new System.Drawing.Point(34, 164);
            this.cuiLabel1.Name = "cuiLabel1";
            this.cuiLabel1.Size = new System.Drawing.Size(162, 33);
            this.cuiLabel1.TabIndex = 1;
            // 
            // dockingPnl
            // 
            this.dockingPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockingPnl.Location = new System.Drawing.Point(0, 49);
            this.dockingPnl.Name = "dockingPnl";
            this.dockingPnl.Size = new System.Drawing.Size(638, 515);
            this.dockingPnl.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.panel2.Controls.Add(this.cuiLabel2);
            this.panel2.Controls.Add(this.cuiButton2);
            this.panel2.Controls.Add(this.cuiButton1);
            this.panel2.Controls.Add(this.cuiLabel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(638, 49);
            this.panel2.TabIndex = 6;
            // 
            // cuiLabel2
            // 
            this.cuiLabel2.Content = "Cagayan\\ State\\ University\\ @Lal-lo\\ Campus";
            this.cuiLabel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel2.ForeColor = System.Drawing.Color.Gainsboro;
            this.cuiLabel2.HorizontalAlignment = CuoreUI.Controls.cuiLabel.HorizontalAlignments.Center;
            this.cuiLabel2.Location = new System.Drawing.Point(3, 10);
            this.cuiLabel2.Name = "cuiLabel2";
            this.cuiLabel2.Size = new System.Drawing.Size(408, 33);
            this.cuiLabel2.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cuiLabel3
            // 
            this.cuiLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cuiLabel3.Content = "Date:Time";
            this.cuiLabel3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel3.ForeColor = System.Drawing.Color.Gainsboro;
            this.cuiLabel3.HorizontalAlignment = CuoreUI.Controls.cuiLabel.HorizontalAlignments.Left;
            this.cuiLabel3.Location = new System.Drawing.Point(435, 12);
            this.cuiLabel3.Name = "cuiLabel3";
            this.cuiLabel3.Size = new System.Drawing.Size(123, 28);
            this.cuiLabel3.TabIndex = 8;
            // 
            // cuiButton7
            // 
            this.cuiButton7.BackColor = System.Drawing.Color.Transparent;
            this.cuiButton7.CheckButton = false;
            this.cuiButton7.Checked = false;
            this.cuiButton7.CheckedBackground = System.Drawing.Color.Crimson;
            this.cuiButton7.CheckedImageTint = System.Drawing.Color.White;
            this.cuiButton7.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton7.Content = "Logout";
            this.cuiButton7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cuiButton7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiButton7.ForeColor = System.Drawing.Color.White;
            this.cuiButton7.HoverBackground = System.Drawing.Color.Crimson;
            this.cuiButton7.HoveredImageTint = System.Drawing.Color.White;
            this.cuiButton7.HoverOutline = System.Drawing.Color.Empty;
            this.cuiButton7.Image = global::GuidanceManagementSystem.Properties.Resources.fire_exit_500px;
            this.cuiButton7.ImageAutoCenter = true;
            this.cuiButton7.ImageExpand = new System.Drawing.Point(0, 0);
            this.cuiButton7.ImageOffset = new System.Drawing.Point(-5, 0);
            this.cuiButton7.ImageTint = System.Drawing.Color.White;
            this.cuiButton7.Location = new System.Drawing.Point(0, 300);
            this.cuiButton7.Margin = new System.Windows.Forms.Padding(10);
            this.cuiButton7.Name = "cuiButton7";
            this.cuiButton7.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.cuiButton7.NormalOutline = System.Drawing.Color.Empty;
            this.cuiButton7.OutlineThickness = 1.6F;
            this.cuiButton7.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton7.PressedImageTint = System.Drawing.Color.White;
            this.cuiButton7.PressedOutline = System.Drawing.Color.Empty;
            this.cuiButton7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cuiButton7.Rounding = new System.Windows.Forms.Padding(25);
            this.cuiButton7.Size = new System.Drawing.Size(184, 46);
            this.cuiButton7.TabIndex = 12;
            this.cuiButton7.TextOffset = new System.Drawing.Point(0, 0);
            this.cuiButton7.Click += new System.EventHandler(this.cuiButton7_Click);
            // 
            // cuiButton6
            // 
            this.cuiButton6.BackColor = System.Drawing.Color.Transparent;
            this.cuiButton6.CheckButton = false;
            this.cuiButton6.Checked = false;
            this.cuiButton6.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.cuiButton6.CheckedImageTint = System.Drawing.Color.White;
            this.cuiButton6.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton6.Content = "Reports";
            this.cuiButton6.Dock = System.Windows.Forms.DockStyle.Top;
            this.cuiButton6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiButton6.ForeColor = System.Drawing.Color.White;
            this.cuiButton6.HoverBackground = System.Drawing.Color.DodgerBlue;
            this.cuiButton6.HoveredImageTint = System.Drawing.Color.White;
            this.cuiButton6.HoverOutline = System.Drawing.Color.Empty;
            this.cuiButton6.Image = global::GuidanceManagementSystem.Properties.Resources.moleskine_50d0px;
            this.cuiButton6.ImageAutoCenter = true;
            this.cuiButton6.ImageExpand = new System.Drawing.Point(0, 0);
            this.cuiButton6.ImageOffset = new System.Drawing.Point(-5, 0);
            this.cuiButton6.ImageTint = System.Drawing.Color.White;
            this.cuiButton6.Location = new System.Drawing.Point(0, 138);
            this.cuiButton6.Margin = new System.Windows.Forms.Padding(10);
            this.cuiButton6.Name = "cuiButton6";
            this.cuiButton6.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.cuiButton6.NormalOutline = System.Drawing.Color.Empty;
            this.cuiButton6.OutlineThickness = 1.6F;
            this.cuiButton6.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton6.PressedImageTint = System.Drawing.Color.White;
            this.cuiButton6.PressedOutline = System.Drawing.Color.Empty;
            this.cuiButton6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cuiButton6.Rounding = new System.Windows.Forms.Padding(25);
            this.cuiButton6.Size = new System.Drawing.Size(184, 46);
            this.cuiButton6.TabIndex = 11;
            this.cuiButton6.TextOffset = new System.Drawing.Point(0, 0);
            this.cuiButton6.Click += new System.EventHandler(this.cuiButton6_Click);
            // 
            // cuiButton5
            // 
            this.cuiButton5.BackColor = System.Drawing.Color.Transparent;
            this.cuiButton5.CheckButton = false;
            this.cuiButton5.Checked = false;
            this.cuiButton5.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.cuiButton5.CheckedImageTint = System.Drawing.Color.White;
            this.cuiButton5.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton5.Content = "Records";
            this.cuiButton5.Dock = System.Windows.Forms.DockStyle.Top;
            this.cuiButton5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiButton5.ForeColor = System.Drawing.Color.White;
            this.cuiButton5.HoverBackground = System.Drawing.Color.DodgerBlue;
            this.cuiButton5.HoveredImageTint = System.Drawing.Color.White;
            this.cuiButton5.HoverOutline = System.Drawing.Color.Empty;
            this.cuiButton5.Image = global::GuidanceManagementSystem.Properties.Resources.note_500px;
            this.cuiButton5.ImageAutoCenter = true;
            this.cuiButton5.ImageExpand = new System.Drawing.Point(0, 0);
            this.cuiButton5.ImageOffset = new System.Drawing.Point(-5, 0);
            this.cuiButton5.ImageTint = System.Drawing.Color.White;
            this.cuiButton5.Location = new System.Drawing.Point(0, 92);
            this.cuiButton5.Margin = new System.Windows.Forms.Padding(10);
            this.cuiButton5.Name = "cuiButton5";
            this.cuiButton5.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.cuiButton5.NormalOutline = System.Drawing.Color.Empty;
            this.cuiButton5.OutlineThickness = 1.6F;
            this.cuiButton5.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton5.PressedImageTint = System.Drawing.Color.White;
            this.cuiButton5.PressedOutline = System.Drawing.Color.Empty;
            this.cuiButton5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cuiButton5.Rounding = new System.Windows.Forms.Padding(25);
            this.cuiButton5.Size = new System.Drawing.Size(184, 46);
            this.cuiButton5.TabIndex = 10;
            this.cuiButton5.TextOffset = new System.Drawing.Point(0, 0);
            this.cuiButton5.Click += new System.EventHandler(this.cuiButton5_Click);
            // 
            // cuiButton4
            // 
            this.cuiButton4.BackColor = System.Drawing.Color.Transparent;
            this.cuiButton4.CheckButton = false;
            this.cuiButton4.Checked = false;
            this.cuiButton4.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.cuiButton4.CheckedImageTint = System.Drawing.Color.White;
            this.cuiButton4.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton4.Content = "Registration";
            this.cuiButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.cuiButton4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiButton4.ForeColor = System.Drawing.Color.White;
            this.cuiButton4.HoverBackground = System.Drawing.Color.DodgerBlue;
            this.cuiButton4.HoveredImageTint = System.Drawing.Color.White;
            this.cuiButton4.HoverOutline = System.Drawing.Color.Empty;
            this.cuiButton4.Image = global::GuidanceManagementSystem.Properties.Resources.add_list_500px;
            this.cuiButton4.ImageAutoCenter = true;
            this.cuiButton4.ImageExpand = new System.Drawing.Point(0, 0);
            this.cuiButton4.ImageOffset = new System.Drawing.Point(-5, 0);
            this.cuiButton4.ImageTint = System.Drawing.Color.White;
            this.cuiButton4.Location = new System.Drawing.Point(0, 46);
            this.cuiButton4.Margin = new System.Windows.Forms.Padding(10);
            this.cuiButton4.Name = "cuiButton4";
            this.cuiButton4.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.cuiButton4.NormalOutline = System.Drawing.Color.Empty;
            this.cuiButton4.OutlineThickness = 1.6F;
            this.cuiButton4.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton4.PressedImageTint = System.Drawing.Color.White;
            this.cuiButton4.PressedOutline = System.Drawing.Color.Empty;
            this.cuiButton4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cuiButton4.Rounding = new System.Windows.Forms.Padding(25);
            this.cuiButton4.Size = new System.Drawing.Size(184, 46);
            this.cuiButton4.TabIndex = 9;
            this.cuiButton4.TextOffset = new System.Drawing.Point(0, 0);
            this.cuiButton4.Click += new System.EventHandler(this.cuiButton4_Click);
            // 
            // cuiButton3
            // 
            this.cuiButton3.BackColor = System.Drawing.Color.Transparent;
            this.cuiButton3.CheckButton = false;
            this.cuiButton3.Checked = false;
            this.cuiButton3.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.cuiButton3.CheckedImageTint = System.Drawing.Color.White;
            this.cuiButton3.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton3.Content = "Dashboard";
            this.cuiButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.cuiButton3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiButton3.ForeColor = System.Drawing.Color.White;
            this.cuiButton3.HoverBackground = System.Drawing.Color.DodgerBlue;
            this.cuiButton3.HoveredImageTint = System.Drawing.Color.White;
            this.cuiButton3.HoverOutline = System.Drawing.Color.Empty;
            this.cuiButton3.Image = global::GuidanceManagementSystem.Properties.Resources.home_500px;
            this.cuiButton3.ImageAutoCenter = true;
            this.cuiButton3.ImageExpand = new System.Drawing.Point(0, 0);
            this.cuiButton3.ImageOffset = new System.Drawing.Point(-5, 0);
            this.cuiButton3.ImageTint = System.Drawing.Color.White;
            this.cuiButton3.Location = new System.Drawing.Point(0, 0);
            this.cuiButton3.Margin = new System.Windows.Forms.Padding(10);
            this.cuiButton3.Name = "cuiButton3";
            this.cuiButton3.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.cuiButton3.NormalOutline = System.Drawing.Color.Empty;
            this.cuiButton3.OutlineThickness = 1.6F;
            this.cuiButton3.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton3.PressedImageTint = System.Drawing.Color.White;
            this.cuiButton3.PressedOutline = System.Drawing.Color.Empty;
            this.cuiButton3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cuiButton3.Rounding = new System.Windows.Forms.Padding(25);
            this.cuiButton3.Size = new System.Drawing.Size(184, 46);
            this.cuiButton3.TabIndex = 8;
            this.cuiButton3.TextOffset = new System.Drawing.Point(0, 0);
            this.cuiButton3.Click += new System.EventHandler(this.cuiButton3_Click);
            // 
            // cuiButton8
            // 
            this.cuiButton8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cuiButton8.BackColor = System.Drawing.Color.Transparent;
            this.cuiButton8.CheckButton = false;
            this.cuiButton8.Checked = false;
            this.cuiButton8.CheckedBackground = System.Drawing.Color.Red;
            this.cuiButton8.CheckedImageTint = System.Drawing.Color.White;
            this.cuiButton8.CheckedOutline = System.Drawing.Color.Red;
            this.cuiButton8.Content = "";
            this.cuiButton8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cuiButton8.ForeColor = System.Drawing.Color.White;
            this.cuiButton8.HoverBackground = System.Drawing.Color.DarkGray;
            this.cuiButton8.HoveredImageTint = System.Drawing.Color.Transparent;
            this.cuiButton8.HoverOutline = System.Drawing.Color.Empty;
            this.cuiButton8.Image = global::GuidanceManagementSystem.Properties.Resources.settings_500px;
            this.cuiButton8.ImageAutoCenter = true;
            this.cuiButton8.ImageExpand = new System.Drawing.Point(10, 10);
            this.cuiButton8.ImageOffset = new System.Drawing.Point(0, 0);
            this.cuiButton8.ImageTint = System.Drawing.Color.White;
            this.cuiButton8.Location = new System.Drawing.Point(12, 148);
            this.cuiButton8.Name = "cuiButton8";
            this.cuiButton8.NormalBackground = System.Drawing.Color.Transparent;
            this.cuiButton8.NormalOutline = System.Drawing.Color.Empty;
            this.cuiButton8.OutlineThickness = 1.6F;
            this.cuiButton8.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cuiButton8.PressedImageTint = System.Drawing.Color.Transparent;
            this.cuiButton8.PressedOutline = System.Drawing.Color.Empty;
            this.cuiButton8.Rounding = new System.Windows.Forms.Padding(25);
            this.cuiButton8.Size = new System.Drawing.Size(48, 45);
            this.cuiButton8.TabIndex = 6;
            this.cuiButton8.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GuidanceManagementSystem.Properties.Resources.COUNSELING;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cuiButton2
            // 
            this.cuiButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cuiButton2.BackColor = System.Drawing.Color.Transparent;
            this.cuiButton2.CheckButton = false;
            this.cuiButton2.Checked = false;
            this.cuiButton2.CheckedBackground = System.Drawing.Color.Red;
            this.cuiButton2.CheckedImageTint = System.Drawing.Color.White;
            this.cuiButton2.CheckedOutline = System.Drawing.Color.Red;
            this.cuiButton2.Content = "";
            this.cuiButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cuiButton2.ForeColor = System.Drawing.Color.White;
            this.cuiButton2.HoverBackground = System.Drawing.Color.ForestGreen;
            this.cuiButton2.HoveredImageTint = System.Drawing.Color.Transparent;
            this.cuiButton2.HoverOutline = System.Drawing.Color.Empty;
            this.cuiButton2.Image = global::GuidanceManagementSystem.Properties.Resources.subtract_50px;
            this.cuiButton2.ImageAutoCenter = true;
            this.cuiButton2.ImageExpand = new System.Drawing.Point(3, 3);
            this.cuiButton2.ImageOffset = new System.Drawing.Point(0, 0);
            this.cuiButton2.ImageTint = System.Drawing.Color.White;
            this.cuiButton2.Location = new System.Drawing.Point(564, 10);
            this.cuiButton2.Name = "cuiButton2";
            this.cuiButton2.NormalBackground = System.Drawing.Color.DarkCyan;
            this.cuiButton2.NormalOutline = System.Drawing.Color.Empty;
            this.cuiButton2.OutlineThickness = 1.6F;
            this.cuiButton2.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.cuiButton2.PressedImageTint = System.Drawing.Color.Transparent;
            this.cuiButton2.PressedOutline = System.Drawing.Color.Empty;
            this.cuiButton2.Rounding = new System.Windows.Forms.Padding(15);
            this.cuiButton2.Size = new System.Drawing.Size(30, 30);
            this.cuiButton2.TabIndex = 5;
            this.cuiButton2.TextOffset = new System.Drawing.Point(0, 0);
            this.cuiButton2.Click += new System.EventHandler(this.cuiButton2_Click_1);
            // 
            // cuiButton1
            // 
            this.cuiButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.cuiButton1.Location = new System.Drawing.Point(600, 10);
            this.cuiButton1.Name = "cuiButton1";
            this.cuiButton1.NormalBackground = System.Drawing.Color.Red;
            this.cuiButton1.NormalOutline = System.Drawing.Color.Empty;
            this.cuiButton1.OutlineThickness = 1.6F;
            this.cuiButton1.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cuiButton1.PressedImageTint = System.Drawing.Color.Transparent;
            this.cuiButton1.PressedOutline = System.Drawing.Color.Empty;
            this.cuiButton1.Rounding = new System.Windows.Forms.Padding(15);
            this.cuiButton1.Size = new System.Drawing.Size(30, 30);
            this.cuiButton1.TabIndex = 4;
            this.cuiButton1.TextOffset = new System.Drawing.Point(0, 0);
            this.cuiButton1.Click += new System.EventHandler(this.cuiButton1_Click);
            // 
            // dashboardfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 564);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dashboardfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dashboardfrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.dashboardfrm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CuoreUI.Controls.cuiButton cuiButton1;
        private CuoreUI.Controls.cuiButton cuiButton2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private CuoreUI.Controls.cuiButton cuiButton3;
        private CuoreUI.Controls.cuiButton cuiButton4;
        private CuoreUI.Controls.cuiButton cuiButton6;
        private CuoreUI.Controls.cuiButton cuiButton5;
        private CuoreUI.Controls.cuiButton cuiButton7;
        private CuoreUI.Controls.cuiLabel cuiLabel1;
        private CuoreUI.Controls.cuiButton cuiButton8;
        private System.Windows.Forms.Panel panel2;
        private CuoreUI.Controls.cuiLabel cuiLabel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel dockingPnl;
        private CuoreUI.Controls.cuiLabel cuiLabel3;
    }
}