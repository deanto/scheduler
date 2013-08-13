using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PayScheduler.Structures;
using PayScheduler.Views;

namespace PayScheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ViewSettings vs; 

        private void Form1_Load(object sender, EventArgs e)
        {
            vs = ViewSettings.GetSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vs.dayx = Convert.ToInt32(textBox1.Text);
            vs.dayy = Convert.ToInt32(textBox2.Text);

            Month month = new Month();
            MonthSimpleDrow t = new MonthSimpleDrow();

            pictureBox1.Image = t.Drow(month);
        }
    }
}
