using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Windows.Forms.DataVisualization.Charting;

namespace IC4EGO
{
    public partial class foUC : UserControl
    {
        MeccsEntities context = new MeccsEntities();

        DateTime kezd;
        DateTime veg;
        List<Mecc> eredmeny = new List<Mecc>();
        public foUC()
        {
            InitializeComponent();

            context.Meccs.Load();

            eredmeny = (from y in context.Meccs
                            select y).ToList();

            listBox1.DataSource = (from x in context.Meccs
                                   select x.hazai).Distinct().ToList();
            Refresh(eredmeny);
            
            kezd = (from i in context.Meccs
                    select i.datum).Min();
            veg = (from y in context.Meccs
                   select y.datum).Max();
        }

        public void Refresh(List<Mecc> ered)
        {
            dataGridView1.DataSource = ered;

            chart1.DataSource = (from i in ered
                                 group i by new { i.fordulo } into diagram
                                 select new {
                                 fordulo= diagram.Key.fordulo,
                                 nezoszam=diagram.Sum(i=>i.nezoszam)
                                 }).ToList();

            var series = chart1.Series[0];
            series.ChartType = SeriesChartType.Column;
            series.XValueMember = "fordulo";
            series.YValueMembers = "nezoszam";
            series.BorderWidth = 2;

            var legend = chart1.Legends[0];
            legend.Enabled = false;

            var chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            eredmeny = (from x in context.Meccs
                            where x.hazai == listBox1.SelectedItem.ToString() || x.vendeg == listBox1.SelectedItem.ToString()
                            select x).ToList();
            Refresh(eredmeny);
        }

        

        private void Tbkezd_TextChanged(object sender, EventArgs e)
        {
            kezd = DatumKonvert(tbkezd.Text);
            Console.WriteLine(kezd);
            var ered = (from x in eredmeny
                            where x.datum >= kezd && x.datum<=veg
                            select x).ToList();
            Refresh(ered);
        }

        
        private void Tbveg_TextChanged(object sender, EventArgs e)
        {
            veg = DatumKonvert(tbveg.Text);
            
            var ered = (from x in eredmeny
                            where x.datum <= veg && x.datum>=kezd
                            select x).ToList();
            Refresh(ered);
        }

        public bool CheckDate(string datum)
        {
            try
            {
                DateTime dt= DateTime.Parse(datum);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DateTime DatumKonvert(string datum)
        {
            if (CheckDate(datum)==true)
            {
                DateTime siker;
                DateTime.TryParse(datum, out siker);
                return siker;
            }
            else
            {
                return new DateTime(0001,01,01);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            eredmeny = (from i in context.Meccs
                            select i).ToList();
            Refresh(eredmeny);
        }
    }
}
