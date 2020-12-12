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
            Width = 80;
            Height = Width;
            Paint += Labda_Paint;
        }

        private void Labda_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected void DrawImage(Graphics g)
        {
            //kör
            g.FillEllipse(new SolidBrush(Color.White), 0, 0, Width, Height); 
            //vízszintes
            g.FillRectangle(new SolidBrush(Color.Black), 0, Height / 2, Width, 2);
            g.FillRectangle(new SolidBrush(Color.Black), Width/15, (Height / 2)-(Height/4), 9*Width/10, 2);
            g.FillRectangle(new SolidBrush(Color.Black), Width / 15, (Height / 2) + (Height / 4), 9 * Width / 10, 2);
            //függőleges felső
            g.FillRectangle(new SolidBrush(Color.Black),  Height / 2,0,2 ,Width/5 );
            g.FillRectangle(new SolidBrush(Color.Black), (Height / 2) - (Height / 4),Width / 15 ,2 , Width / 6 );
            g.FillRectangle(new SolidBrush(Color.Black), (Height / 2) + (Height / 4), Width / 15, 2, Width / 6);
            //függőleges alsó
            g.FillRectangle(new SolidBrush(Color.Black), Height / 2, Height - Width / 5, 2, Width / 5);
            g.FillRectangle(new SolidBrush(Color.Black), (Height / 2) - (Height / 4), Height- Width / 15 - Width / 6, 2, Width / 6);
            g.FillRectangle(new SolidBrush(Color.Black), (Height / 2) + (Height / 4), Height- Width / 15 - Width / 6, 2, Width / 6);
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
