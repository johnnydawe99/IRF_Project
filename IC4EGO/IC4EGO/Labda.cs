using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IC4EGO
{
    public class Labda :Label
    {
        public Labda()
        {
            AutoSize = false;
            Width = 60;
            Height = Width;
            Top = 220;
            Paint += Labda_Paint;
        }

        private void Labda_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.White), 0, 0, Width, Height);
        }

        public void Mozog(int tick)
        {
            var range = (tick - 1) / 62;
            switch (range)
            {
                case 0:
                    Top -= 2;
                    Left += 3;
                    break;
                case 1:
                    Top -= 1;
                    Left += 3;
                    break;
                case 2:
                    Left += 3;
                    break;
                case 3:
                    Top += 1;
                    Left += 3;
                    break;
                case 4:
                    Top += 2;
                    Left += 3;
                    break;
            }
        }
    }
}
