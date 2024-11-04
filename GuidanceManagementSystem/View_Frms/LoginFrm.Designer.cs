namespace GuidanceManagementSystem.View_Frms
{
    partial class LoginFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginFrm));
            this.cuiFormRounder1 = new CuoreUI.Components.cuiFormRounder();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cuiButton2 = new CuoreUI.Controls.cuiButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cuiTextBox22 = new CuoreUI.Controls.cuiTextBox2();
            this.cuiTextBox21 = new CuoreUI.Controls.cuiTextBox2();
            this.cuiButton1 = new CuoreUI.Controls.cuiButton();
            this.cuiFormDrag1 = new CuoreUI.cuiFormDrag(this.components);
            this.cuiSpinner1 = new CuoreUI.Controls.cuiSpinner();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cuiFormRounder1
            // 
            this.cuiFormRounder1.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cuiFormRounder1.Rounding = 10;
            this.cuiFormRounder1.TargetForm = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::GuidanceManagementSystem.Properties.Resources.log;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.cuiButton2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.cuiTextBox22);
            this.panel1.Controls.Add(this.cuiTextBox21);
            this.panel1.Location = new System.Drawing.Point(259, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 488);
            this.panel1.TabIndex = 4;
            // 
            // cuiButton2
            // 
            this.cuiButton2.BackColor = System.Drawing.Color.Transparent;
            this.cuiButton2.CheckButton = false;
            this.cuiButton2.Checked = false;
            this.cuiButton2.CheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton2.CheckedImageTint = System.Drawing.Color.White;
            this.cuiButton2.CheckedOutline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton2.Content = "Continue";
            this.cuiButton2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiButton2.ForeColor = System.Drawing.Color.White;
            this.cuiButton2.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton2.HoveredImageTint = System.Drawing.Color.White;
            this.cuiButton2.HoverOutline = System.Drawing.Color.Empty;
            this.cuiButton2.Image = null;
            this.cuiButton2.ImageAutoCenter = true;
            this.cuiButton2.ImageExpand = new System.Drawing.Point(0, 0);
            this.cuiButton2.ImageOffset = new System.Drawing.Point(0, 0);
            this.cuiButton2.ImageTint = System.Drawing.Color.White;
            this.cuiButton2.Location = new System.Drawing.Point(47, 408);
            this.cuiButton2.Name = "cuiButton2";
            this.cuiButton2.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(13)))), ((int)(((byte)(14)))));
            this.cuiButton2.NormalOutline = System.Drawing.Color.Empty;
            this.cuiButton2.OutlineThickness = 1.6F;
            this.cuiButton2.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiButton2.PressedImageTint = System.Drawing.Color.White;
            this.cuiButton2.PressedOutline = System.Drawing.Color.Empty;
            this.cuiButton2.Rounding = new System.Windows.Forms.Padding(8);
            this.cuiButton2.Size = new System.Drawing.Size(208, 48);
            this.cuiButton2.TabIndex = 7;
            this.cuiButton2.TextOffset = new System.Drawing.Point(0, 0);
            this.cuiButton2.Click += new System.EventHandler(this.cuiButton2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Image = global::GuidanceManagementSystem.Properties.Resources.eye_96px;
            this.pictureBox1.Location = new System.Drawing.Point(219, 345);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // cuiTextBox22
            // 
            this.cuiTextBox22.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.cuiTextBox22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cuiTextBox22.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cuiTextBox22.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiTextBox22.BorderSize = 1;
            this.cuiTextBox22.Content = "";
            this.cuiTextBox22.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cuiTextBox22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiTextBox22.ForeColor = System.Drawing.Color.DimGray;
            this.cuiTextBox22.Location = new System.Drawing.Point(47, 337);
            this.cuiTextBox22.Margin = new System.Windows.Forms.Padding(4);
            this.cuiTextBox22.Multiline = false;
            this.cuiTextBox22.Name = "cuiTextBox22";
            this.cuiTextBox22.Padding = new System.Windows.Forms.Padding(22, 9, 22, 0);
            this.cuiTextBox22.PasswordChar = true;
            this.cuiTextBox22.PlaceholderColor = System.Drawing.Color.DimGray;
            this.cuiTextBox22.PlaceholderText = "Password";
            this.cuiTextBox22.Rounding = 8;
            this.cuiTextBox22.Size = new System.Drawing.Size(208, 40);
            this.cuiTextBox22.TabIndex = 6;
            this.cuiTextBox22.TextOffset = new System.Drawing.Size(0, 0);
            this.cuiTextBox22.UnderlinedStyle = false;
            // 
            // cuiTextBox21
            // 
            this.cuiTextBox21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cuiTextBox21.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cuiTextBox21.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.cuiTextBox21.BorderSize = 1;
            this.cuiTextBox21.Content = "";
            this.cuiTextBox21.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cuiTextBox21.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiTextBox21.ForeColor = System.Drawing.Color.DimGray;
            this.cuiTextBox21.Location = new System.Drawing.Point(47, 289);
            this.cuiTextBox21.Margin = new System.Windows.Forms.Padding(4);
            this.cuiTextBox21.Multiline = false;
            this.cuiTextBox21.Name = "cuiTextBox21";
            this.cuiTextBox21.Padding = new System.Windows.Forms.Padding(22, 9, 22, 0);
            this.cuiTextBox21.PasswordChar = false;
            this.cuiTextBox21.PlaceholderColor = System.Drawing.Color.DimGray;
            this.cuiTextBox21.PlaceholderText = "Username";
            this.cuiTextBox21.Rounding = 8;
            this.cuiTextBox21.Size = new System.Drawing.Size(208, 40);
            this.cuiTextBox21.TabIndex = 5;
            this.cuiTextBox21.TextOffset = new System.Drawing.Size(0, 0);
            this.cuiTextBox21.UnderlinedStyle = false;
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
            this.cuiButton1.Location = new System.Drawing.Point(788, 12);
            this.cuiButton1.Name = "cuiButton1";
            this.cuiButton1.NormalBackground = System.Drawing.Color.Red;
            this.cuiButton1.NormalOutline = System.Drawing.Color.Empty;
            this.cuiButton1.OutlineThickness = 1.6F;
            this.cuiButton1.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cuiButton1.PressedImageTint = System.Drawing.Color.Transparent;
            this.cuiButton1.PressedOutline = System.Drawing.Color.Empty;
            this.cuiButton1.Rounding = new System.Windows.Forms.Padding(15);
            this.cuiButton1.Size = new System.Drawing.Size(30, 30);
            this.cuiButton1.TabIndex = 3;
            this.cuiButton1.TextOffset = new System.Drawing.Point(0, 0);
            this.cuiButton1.Click += new System.EventHandler(this.cuiButton1_Click);
            // 
            // cuiFormDrag1
            // 
            this.cuiFormDrag1.TargetForm = this;
            // 
            // cuiSpinner1
            // 
            this.cuiSpinner1.ArcColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cuiSpinner1.BackColor = System.Drawing.Color.Transparent;
            this.cuiSpinner1.Location = new System.Drawing.Point(788, 517);
            this.cuiSpinner1.Name = "cuiSpinner1";
            this.cuiSpinner1.RingColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.cuiSpinner1.RotateSpeed = 1F;
            this.cuiSpinner1.Rotation = 62.47591F;
            this.cuiSpinner1.Size = new System.Drawing.Size(30, 31);
            this.cuiSpinner1.TabIndex = 5;
            this.cuiSpinner1.Thickness = 3F;
            this.cuiSpinner1.Visible = false;
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(90)))), ((int)(((byte)(163)))));
            this.BackgroundImage = global::GuidanceManagementSystem.Properties.Resources.CCGSOMS;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(830, 560);
            this.Controls.Add(this.cuiSpinner1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cuiButton1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoginFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginFrm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginFrm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CuoreUI.Components.cuiFormRounder cuiFormRounder1;
        private CuoreUI.Controls.cuiButton cuiButton1;
        private System.Windows.Forms.Panel panel1;
        private CuoreUI.Controls.cuiTextBox2 cuiTextBox21;
        private CuoreUI.Controls.cuiTextBox2 cuiTextBox22;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CuoreUI.Controls.cuiButton cuiButton2;
        private CuoreUI.cuiFormDrag cuiFormDrag1;
        private CuoreUI.Controls.cuiSpinner cuiSpinner1;
    }
}