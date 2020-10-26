using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MLBTS_Market_Calc
{
    public partial class Form1 : Form
    {
        double sellPrice, buyPrice = 0;
        double sellPriceAdj, sellPriceAdj2, sellPriceAdj3 = 0;
        string[] array;
        int total = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Buy Price...";
            textBox2.Text = "Sell Price...";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buyPrice = Convert.ToInt32(textBox1.Text);
            sellPrice = Convert.ToInt32(textBox2.Text);
            sellPriceAdj = (sellPrice * 0.1);
            sellPriceAdj2 = sellPrice - sellPriceAdj;
            sellPriceAdj3 = sellPriceAdj2 - buyPrice;
            MessageBox.Show("Purchased for: " + buyPrice + "\n\nSold for: " + sellPrice + "\n\nYou made " + sellPriceAdj3 + " stubs!");
            File.AppendAllText(@"D:\Users\Nicholas\Desktop\Stub Counter\StubCount.txt", Convert.ToString(sellPriceAdj3) + Environment.NewLine);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            total = 0;
            array = File.ReadAllLines(@"D:\Users\Nicholas\Desktop\Stub Counter\StubCount.txt");
            int[] array2 = array.Select(x => int.Parse(x)).ToArray();
            total = array2.Sum();
            MessageBox.Show("You have accumulated " + total + " stubs!");
        }
    }
}
