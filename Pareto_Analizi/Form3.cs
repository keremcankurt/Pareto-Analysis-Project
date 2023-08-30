using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pareto_Analizi
{
    public partial class Form3 : Form
    {
        string[,] veri;
        public Form3(string[,] dizi1)
        {
            InitializeComponent();
            veri = dizi1;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int n = veri.GetLength(0);
            string[] malzeme = new string[n];
            double[] toplamSatis = new double[n];
            double toplam = 0;
            for (int i = 0; i < n; i++)
            {
                malzeme[i] = veri[i, 0];
                toplamSatis[i] = Convert.ToDouble(veri[i, 1]) + Convert.ToDouble(veri[i, 2]);
                toplam += toplamSatis[i];
            }
            double yedek1;
            string yedek2;
            int maxIndex;
            for (int i = 0; i < n - 1; i++)
            {
                maxIndex = i;
                for (int j = i; j < n; j++)
                {
                    if (toplamSatis[j] > toplamSatis[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                yedek1 = toplamSatis[i];
                toplamSatis[i] = toplamSatis[maxIndex];
                toplamSatis[maxIndex] = yedek1;

                yedek2 = malzeme[i];
                malzeme[i] = malzeme[maxIndex];
                malzeme[maxIndex] = yedek2;
            }
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Malzeme Adı";
            dataGridView1.Columns[1].Name = "Toplam Satış";
            dataGridView1.Columns[2].Name = "Yüzde";
            dataGridView1.Columns[3].Name = "Kümülatif Yüzde";

            double[] yuzde = new double[n];
            double[] kum = new double[n];

            double baslangic = 0;
            for (int i = 0; i < n; i++)
            {
                yuzde[i] = toplamSatis[i] / toplam;
                kum[i] = yuzde[i] + baslangic;
                baslangic = kum[i];
                if (kum[i] <= 0.80)
                {
                    listBox1.Items.Add(malzeme[i]);
                }
                else if (kum[i] <= 0.95)
                {
                    listBox2.Items.Add(malzeme[i]);
                }
                else
                {
                    listBox3.Items.Add(malzeme[i]);
                }
            }
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add(malzeme[i], toplamSatis[i].ToString(), yuzde[i].ToString("#.##"), kum[i].ToString("#.##"));
            }

            label2.Text = listBox1.Items.Count.ToString();
            label3.Text = listBox2.Items.Count.ToString();
            label4.Text = listBox3.Items.Count.ToString();

            double level1 = 0;
            double level2 = 0;

            for (int i = 0; i < n; i++)
            {
                if (kum[i] > level1 && kum[i] <= 0.8)
                {
                    level1 = kum[i];
                }
                else if (kum[i] > level2 && kum[i] <= 0.95) level2 = kum[i];

            }
            label5.Text = level1.ToString("#.##");
            label6.Text = level2.ToString("#.##");
            label7.Text = 100.ToString("#.##");
        }

    }
}
