using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lw._9._13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0,73";
            textBox2.Text = "1,73";
            textBox3.Text = "0,1";
            textBox4.Text = "-2,0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double xmin = double.Parse(textBox1.Text);
            double xmax = double.Parse(textBox2.Text);
            double step = double.Parse(textBox3.Text);
            double b = double.Parse(textBox4.Text);

            int count = (int)Math.Ceiling((xmax - xmin) / step) + 1;

            double[] x = new double[count];
            double[] y1 = new double[count];
            double[] y2 = new double[count];

            for (int a = 0; a < count; a++)
            {
                x[a] = xmin + step * a;
                y1[a] = (Math.Pow(Math.Abs(a - b), 1d / 2d)) / (Math.Pow(Math.Abs(Math.Pow(b, 3) - Math.Pow(a, 3)), 3d / 2d)) + Math.Log(Math.Abs(a - b));
                y2[a] = (Math.Pow(Math.Abs(a + b), 1d / 2d));
            }

            chart1.ChartAreas[0].AxisX.Minimum = xmin;
            chart1.ChartAreas[0].AxisX.Maximum = xmax;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Math.Abs(step);

            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[1].Points.DataBindXY(x, y2);
        }
    }
}
