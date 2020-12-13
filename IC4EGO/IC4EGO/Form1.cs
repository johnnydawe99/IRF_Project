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
        Kapu kapu = new Kapu();
        public Form1()
        {
            InitializeComponent();
            labda.Top = (panel1.Height +kapu.Height) / 2-labda.Height-10;
            panel1.Controls.Add(labda);
            kapu.Top = ((panel1.Height -kapu.Height) / 2);
            kapu.Left = 910;
            panel1.Controls.Add(kapu);
            button1.Visible = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            tick += 1;
            if (tick>310)
            {
                timer1.Stop();
                button1.Visible = true;
            }
            else
            {
                labda.Mozog(tick);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            foUC kezelo = new foUC();
            panel1.Controls.Add(kezelo);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
