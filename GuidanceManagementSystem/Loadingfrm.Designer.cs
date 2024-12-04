namespace GuidanceManagementSystem
{
    partial class Loadingfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loadingfrm));
            this.cuiFormRounder1 = new CuoreUI.Components.cuiFormRounder();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cuiButton1 = new CuoreUI.Controls.cuiButton();
            this.SuspendLayout();
            // 
            // cuiFormRounder1
            // 
            this.cuiFormRounder1.OutlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cuiFormRounder1.Rounding = 10;
            this.cuiFormRounder1.TargetForm = this;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Green;
            this.progressBar1.Location = new System.Drawing.Point(185, 465);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(387, 18);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Value = 1;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
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
            this.cuiButton1.Image = null;
            this.cuiButton1.ImageAutoCenter = true;
            this.cuiButton1.ImageExpand = new System.Drawing.Point(3, 3);
            this.cuiButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.cuiButton1.ImageTint = System.Drawing.Color.White;
            this.cuiButton1.Location = new System.Drawing.Point(718, 12);
            this.cuiButton1.Name = "cuiButton1";
            this.cuiButton1.NormalBackground = System.Drawing.Color.Red;
            this.cuiButton1.NormalOutline = System.Drawing.Color.Empty;
            this.cuiButton1.OutlineThickness = 1.6F;
            this.cuiButton1.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cuiButton1.PressedImageTint = System.Drawing.Color.Transparent;
            this.cuiButton1.PressedOutline = System.Drawing.Color.Empty;
            this.cuiButton1.Rounding = new System.Windows.Forms.Padding(15);
            this.cuiButton1.Size = new System.Drawing.Size(30, 30);
            this.cuiButton1.TabIndex = 2;
            this.cuiButton1.TextOffset = new System.Drawing.Point(0, 0);
            this.cuiButton1.Visible = false;
            this.cuiButton1.Click += new System.EventHandler(this.cuiButton1_Click);
            // 
            // Loadingfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GuidanceManagementSystem.Properties.Resources.CCGSOMS;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(760, 525);
            this.Controls.Add(this.cuiButton1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(760, 525);
            this.MinimumSize = new System.Drawing.Size(760, 525);
            this.Name = "Loadingfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Loadingfrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CuoreUI.Components.cuiFormRounder cuiFormRounder1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private CuoreUI.Controls.cuiButton cuiButton1;
    }
}

