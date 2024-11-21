using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace GuidanceManagementSystem
{
    public class PrintPage
    {
        private Bitmap memorying;
        private Panel Panel1;

        public void Print(Panel pnl)
        {
            PrintPreviewDialog prntprvw = new PrintPreviewDialog();
            PrintDocument pntdoc = new PrintDocument();
            Panel1 = pnl;
            GetPrintArea(pnl);  // Capture the content of the panel as a bitmap

            // Add the PrintPage event handler
            pntdoc.PrintPage += Pntdoc_PrintPage;

            // Set the paper size to A4
            PrinterSettings ps = new PrinterSettings();
            ps.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);  // A4 in 1/100ths of an inch
            pntdoc.PrinterSettings = ps;

            // Set the print preview document
            prntprvw.Document = pntdoc;
            prntprvw.ShowDialog();
        }

        private void Pntdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Calculate the scaling factor to fit the panel contents on the A4 page
            float scale = Math.Min(e.MarginBounds.Width / memorying.Width, e.MarginBounds.Height / memorying.Height);

            // Draw the image on the A4 page with scaling
            e.Graphics.DrawImage(memorying, 0, 0, memorying.Width * scale, memorying.Height * scale);
        }

        private void GetPrintArea(Panel pnl)
        {
            // Create a bitmap for the panel
            memorying = new Bitmap(pnl.Width, pnl.Height);

            // Use DrawToBitmap to render the panel and its controls
            pnl.DrawToBitmap(memorying, new Rectangle(0, 0, pnl.Width, pnl.Height));

            // Optionally, if you want to manually render specific child controls (like TextBox, Label, etc.)
            // You could iterate over the controls and draw them manually, but DrawToBitmap already handles this.
        }
    }
}
