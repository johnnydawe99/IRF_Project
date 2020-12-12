using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IC4EGO
{
    class Kapu:Label
    {
        public Kapu()
        {
            AutoSize = false;
            Width = 150;
            Height = 250;
            Paint += Kapu_Paint;
        }

        private void Kapu_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected void DrawImage(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Yellow), 0, 0, Width / 10, Height);
            g.FillRectangle(new SolidBrush(Color.Yellow), 0, 0, Width , Height/50);
            g.FillRectangle(new SolidBrush(Color.Yellow), Width - Width / 20, 0, Width / 20, Height);
        }
    }
}
