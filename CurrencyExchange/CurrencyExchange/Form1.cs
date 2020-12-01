using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CurrencyExchange
{
    public partial class Form1 : Form
    {
        Dictionary<string, decimal> d;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            d = new Dictionary<string, decimal>();

            var doc = new XmlDocument();
            doc.Load(@"http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");

            XmlNodeList nodes = doc.SelectNodes("/*/*/*/*");

            for (int i = 0; i < nodes.Count; i++)
            {
                comboBox1.Items.Add(nodes[i].Attributes[0].Value);
                comboBox2.Items.Add(nodes[i].Attributes[0].Value);
                d.Add(nodes[i].Attributes[0].Value, Decimal.Parse(nodes[i].Attributes[1].Value));
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal d1 = d[comboBox1.SelectedItem.ToString()];
            decimal d2 = d[comboBox2.SelectedItem.ToString()];
            decimal d3 = Convert.ToDecimal(textBox1.Text);
            d3 = d3 * d2 / d1;
            textBox1.Text = "";
            label3.Text = d3.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
