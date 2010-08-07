using System.Drawing;
using System.Windows.Forms;

namespace TimeIsMoney
{
    public class ColorableListBox : ListBox
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
                Task item = Items[e.Index] as Task;
                if (item != null)
                {
                    if (item.Priority <= 3)
                    {
                        e.Graphics.FillRectangle(greenBrush, rect);
                    }
                    else if (item.Priority > 3 && item.Priority <= 7)
                    {
                        e.Graphics.FillRectangle(blueBrush, rect);
                    }
                    else if (item.Priority > 7)
                    {
                        e.Graphics.FillRectangle(redBrush, rect);
                    }
                    e.Graphics.DrawString(item.Title,
                        Font, whiteBrush, new PointF(rect.X, rect.Y));
                }
            }
        }
    }
}
