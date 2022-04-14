using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomControls
{
   public class CommaSeparatedNumberToolTip: ToolTip
    {

        private int pWidth;
        private int pHeight;

        public CommaSeparatedNumberToolTip(int Width,int Height)
        {
            pWidth = Width; pHeight = Height;
            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(this.OnPopup);
            this.Draw += new DrawToolTipEventHandler(this.OnDraw);
        }

        private void OnPopup(object sender, PopupEventArgs e) // use this event to set the size of the tool tip
        {
            e.ToolTipSize = new Size(pWidth,pHeight);       
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e) // use this event to customise the tool tip
        {
            Graphics g = e.Graphics;

            LinearGradientBrush b = new LinearGradientBrush(e.Bounds, Color.GreenYellow, Color.MintCream, 45f);

            g.FillRectangle(b, e.Bounds);

            g.DrawRectangle(new Pen(Brushes.Red, 1), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));

           // g.DrawString(e.ToolTipText, new Font("Arial", 20.0f, FontStyle.Bold), Brushes.Silver,
              //  new PointF(e.Bounds.X + 6, e.Bounds.Y + 6)); // shadow layer
            g.DrawString(e.ToolTipText, new Font("Arial", 20.0f, FontStyle.Regular), Brushes.Black,
                new PointF(e.Bounds.X + 5, e.Bounds.Y + 5)); // top layer           

            b.Dispose();
        }
    }
}
