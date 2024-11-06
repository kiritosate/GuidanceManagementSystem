using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuidanceManagementSystem.methods
{
    internal class PrinterHelper
    {
        private Bitmap _panelBitmap;
        public event EventHandler PrintCompleted;

        // Method to capture the panel and start the print process
        public void PrintPanel(Panel panel)
        {
            _panelBitmap = CapturePanel(panel);

            if (_panelBitmap != null)
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                printDocument.PrintPage += PrintDocument_PrintPage;

                // Subscribe to the PrintDocument's EndPrint event to trigger PrintCompleted
                printDocument.EndPrint += (sender, e) => PrintCompleted?.Invoke(this, EventArgs.Empty);

                printDocument.Print();
            }
            else
            {
                MessageBox.Show("Failed to capture the panel for printing.");
            }
        }

        private Bitmap CapturePanel(Panel panel)
        {
            Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
            panel.DrawToBitmap(bitmap, new Rectangle(0, 0, panel.Width, panel.Height));
            return bitmap;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_panelBitmap != null)
            {
                float scaleX = (float)e.PageBounds.Width / _panelBitmap.Width;
                float scaleY = (float)e.PageBounds.Height / _panelBitmap.Height;
                float scale = Math.Min(scaleX, scaleY);

                int width = (int)(_panelBitmap.Width * scale);
                int height = (int)(_panelBitmap.Height * scale);

                e.Graphics.DrawImage(_panelBitmap, 0, 0, width, height);
            }

            e.HasMorePages = false;
        }
    }
}
