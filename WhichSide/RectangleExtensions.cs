using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichSide
{
    public static class RectangleExtensions
    {
        public static int CenterX(this Rectangle rect) {
            return rect.X + (rect.Width / 2);
        }

        public static int CenterY(this Rectangle rect) {
            return rect.Y + (rect.Height / 2);
        }
    }
}
