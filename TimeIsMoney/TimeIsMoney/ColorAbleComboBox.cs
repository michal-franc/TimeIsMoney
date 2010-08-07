using System.Drawing;
using System.Windows.Forms;

namespace TimeIsMoney
{
    public class ColorAbleComboBox : ComboBox
    {
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            SolidBrush whiteBrush = new SolidBrush(Color.White);


            if (e.Index >= 0)
            {
                Rectangle rect = new Rectangle(
                    e.Bounds.X, e.Bounds.Y,
                    e.Bounds.Width, e.Bounds.Height);

                if (e.Index <= 3)
                {
                    e.Graphics.FillRectangle(greenBrush, rect);
                }
                else if (e.Index > 3 && e.Index <= 7)
                {
                    e.Graphics.FillRectangle(blueBrush, rect);
                }
                else if (e.Index > 7)
                {
                    e.Graphics.FillRectangle(redBrush, rect);
                }
                e.Graphics.DrawString(Items[e.Index].ToString(),
                    Font, whiteBrush, new PointF(rect.X, rect.Y));
            }
        }
    }
}
