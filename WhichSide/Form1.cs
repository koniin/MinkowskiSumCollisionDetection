using System;
using System.Drawing;
using System.Windows.Forms;

namespace WhichSide {
    public partial class Form1 : Form {
        private Rectangle rectLeft = new Rectangle(53, 125, 50, 50);
        private Rectangle rectRight = new Rectangle(197, 125, 50, 50);
        private Rectangle rectTop = new Rectangle(125, 53, 50, 50);
        private Rectangle rectBottom = new Rectangle(125, 197, 50, 50);
        private Rectangle middle = new Rectangle(100, 100, 100, 100);

        public Form1() {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.FillRectangle(Brushes.BurlyWood, middle);
            e.Graphics.FillRectangle(Brushes.BlueViolet, rectLeft);
            e.Graphics.FillRectangle(Brushes.CadetBlue, rectRight);
            e.Graphics.FillRectangle(Brushes.DarkOliveGreen, rectTop);
            e.Graphics.FillRectangle(Brushes.IndianRed, rectBottom);
            
            base.OnPaint(e);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            CheckCollision(middle, rectLeft);
            CheckCollision(middle, rectRight);
            CheckCollision(middle, rectTop);
            CheckCollision(middle, rectBottom);

            Rectangle newRect = new Rectangle(e.X - 10, e.Y - 10, 20, 20);
            Graphics graphics = this.CreateGraphics();
            graphics.FillRectangle(Brushes.Red, newRect);
            CheckCollision(middle, newRect);
        }

        private void MarkRectangle(string mark, Rectangle rect) {
            Graphics graphics = this.CreateGraphics();
            graphics.DrawString(mark, DefaultFont, Brushes.Black, rect.X + 10, rect.Y + 15);
        }

        private void CheckCollision(Rectangle middleRectangle, Rectangle secondRectangle) {
            float w = 0.5f * (middleRectangle.Width + secondRectangle.Width);
            float h = 0.5f * (middleRectangle.Height + secondRectangle.Height);
            float dx = middleRectangle.CenterX() - secondRectangle.CenterX();
            float dy = middleRectangle.CenterY() - secondRectangle.CenterY();

            // Only calculate this if collision detection is not already done
            if (Math.Abs(dx) <= w && Math.Abs(dy) <= h)
            {
                float wy = w * dy;
                float hx = h * dx;

                if (wy > hx)
                    MarkRectangle(wy > -hx ? "Top" : "Right", secondRectangle);
                else
                    MarkRectangle(wy > -hx ? "Left" : "Bottom", secondRectangle);
            }
        }
    }
}

