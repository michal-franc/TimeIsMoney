using System.Drawing;
using System.Windows.Forms;

namespace TimeIsMoney
{
    public class ColorAbleComboBox : ComboBox
    {
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Rectangle rect = new Rectangle(
                    e.Bounds.X, e.Bounds.Y,
                    e.Bounds.Width, e.Bounds.Height);

                if (e.Index <= 3)
                {
                    Color col = Color.FromArgb(0,255-(e.Index*60),0);
                    SolidBrush greenBrush = new SolidBrush(col);
                    e.Graphics.FillRectangle(greenBrush, rect);
                }
                else if (e.Index > 3 && e.Index <= 7)
                {
                    Color col = Color.FromArgb(0, 0, 255 - ((e.Index-4) * 60));
                    SolidBrush blueBrush = new SolidBrush(col);
                    e.Graphics.FillRectangle(blueBrush, rect);
                }
                else if (e.Index > 7)
                {
                    Color col = Color.FromArgb(255 - ((e.Index - 8) * 60), 0,0 );
                    SolidBrush redBrush = new SolidBrush(col);
                    e.Graphics.FillRectangle(redBrush, rect);
                }
                e.Graphics.DrawString(Items[e.Index].ToString(),
                    Font, new SolidBrush(Color.White), new PointF(rect.X, rect.Y));
            }
        }
    }
}
