using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Drawing;

namespace GuidanceManagementSystem.methods
{
    public class CustomTextBox : Panel
    {
        private TextBox innerTextBox;

        public Color BorderColor { get; set; } = Color.Gray;
        public int BorderThickness { get; set; } = 2;

        public event EventHandler TextChanged; // Expose TextChanged event

        public CustomTextBox()
        {
            // Initialize the inner TextBox
            innerTextBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Fill,
                Margin = new Padding(0)
            };

            // Subscribe to inner TextBox TextChanged event
            innerTextBox.TextChanged += InnerTextBox_TextChanged;

            // Add the inner TextBox to the Panel
            Controls.Add(innerTextBox);

            // Set panel padding for the border
            Padding = new Padding(BorderThickness);

            // Resize the inner TextBox when the panel resizes
            Resize += (s, e) => AdjustInnerTextBox();
        }

        public string Text
        {
            get => innerTextBox.Text;
            set => innerTextBox.Text = value;
        }

        public override Font Font
        {
            get => innerTextBox.Font;
            set => innerTextBox.Font = value;
        }

        public override Color BackColor
        {
            get => innerTextBox.BackColor;
            set => innerTextBox.BackColor = value;
        }

        public Color ForeColor
        {
            get => innerTextBox.ForeColor;
            set => innerTextBox.ForeColor = value;
        }

        public TextBox InnerTextBox => innerTextBox;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw border
            using (Pen p = new Pen(BorderColor, BorderThickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }

        private void AdjustInnerTextBox()
        {
            innerTextBox.Location = new Point(BorderThickness, BorderThickness);
            innerTextBox.Size = new Size(Width - 2 * BorderThickness, Height - 2 * BorderThickness);
        }

        private void InnerTextBox_TextChanged(object sender, EventArgs e)
        {
            TextChanged?.Invoke(this, e); // Raise the custom TextChanged event
        }
    }
}
