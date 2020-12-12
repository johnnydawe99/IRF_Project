using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IC4EGO
{
    class Labda :Button
    {
        public Labda()
        {
            AutoSize = false;
            Width = 60;
            Height = Width;
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
            int range = tick - 1 / 5;
            switch (range)
            {
                case 0:
                    Top += (1 / 2);
                    Left += 1;
                    break;
                case 1:
                    Top += (1 / 3);
                    Left += 1;
                    break;
                case 2:
                    Left += 1;
                    break;
                case 3:
                    Top += (1 / 2);
                    Left += 1;
                    break;
                case 4:
                    Top += (1 / 2);
                    Left += 1;
                    break;
            }
        }
    }
}
