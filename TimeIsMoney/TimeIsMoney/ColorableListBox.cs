﻿using System.Drawing;
using System.Windows.Forms;
using XMLModule;

namespace TimeIsMoney
{
    public class ColorableListBox : ListBox
    {
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

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
                        Color col = Color.FromArgb(0, 255 - (item.Priority * 60), 0);
                        SolidBrush greenBrush = new SolidBrush(col);
                        e.Graphics.FillRectangle(greenBrush, rect);
                    }
                    else if (item.Priority > 3 && item.Priority <= 7)
                    {
                        Color col = Color.FromArgb(0, 0, 255 - ((item.Priority - 4) * 60));
                        SolidBrush blueBrush = new SolidBrush(col);
                        e.Graphics.FillRectangle(blueBrush, rect);
                    }
                    else if (item.Priority > 7)
                    {
                        Color col = Color.FromArgb(255 - ((item.Priority - 8) * 60), 0, 0);
                        SolidBrush redBrush = new SolidBrush(col);
                        e.Graphics.FillRectangle(redBrush, rect);
                    }
                    e.Graphics.DrawString(item.Title,
                        Font, yellowBrush, new PointF(rect.X, rect.Y));

                    if (item.TimeEstimate > 0.0)
                        e.Graphics.DrawString(string.Format("{0} {1}",item.TimeEstimate.ToString(),item.TimeEstUnits), Font, yellowBrush, new PointF(rect.X + Width - 30, rect.Y));};
                }
            }
        }
    }
