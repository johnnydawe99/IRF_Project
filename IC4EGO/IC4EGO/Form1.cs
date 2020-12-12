using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IC4EGO
{
    public partial class Form1 : Form
    {
        Labda labda = new Labda();
        int tick = 0;
        public Form1()
        {
            InitializeComponent();
            panel1.Controls.Add(labda);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            tick += 1;
            if (tick>310)
            {
                timer1.Stop();
            }
            else
            {
                labda.Mozog(tick);
            }
        }
    }
}
