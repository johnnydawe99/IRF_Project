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
        public foUC()
        {
            InitializeComponent();

            context.Meccs.Load();

            var eredmeny = (from y in context.Meccs
                            select y).ToList();

            listBox1.DataSource = (from x in eredmeny
                                   select x.hazai).Distinct().ToList();

            Refresh(eredmeny);

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

        void Refresh(List<Mecc> ered)
        {
            dataGridView1.DataSource = ered;
                        
            chart1.DataSource = dataGridView1.DataSource;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var eredmeny = (from x in context.Meccs
                            where x.hazai == listBox1.SelectedItem.ToString() || x.vendeg == listBox1.SelectedItem.ToString()
                            select x).ToList();
            Refresh(eredmeny);
        }
    }
}
