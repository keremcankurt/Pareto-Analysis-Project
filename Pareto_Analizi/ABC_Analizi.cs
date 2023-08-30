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
    public partial class ABC_Analizi : Form
    {
        Context context = new Context();
        public ABC_Analizi()
        {
            InitializeComponent();
        }
        void listele()
        {
            var malzemeler = (from i in context.malzemeler select i).ToList();
            listView1.Items.Clear();
            foreach (var item in malzemeler)
            {
                listView1.Items.Add(item.Id.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.MalzemeKodu.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.MalzemeAdı.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.YillikSatis.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.BirimFiyat.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.MinStok.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.TedarikSuresi.ToString());
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void ABC_Analizi_Load(object sender, EventArgs e)
        {
            toolStripMenuItem1.Enabled = true;
            toolStripMenuItem2.Enabled = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = listView1.Items.Count;
            String[,] dizi1 = new String[n, 3];
            for (int i = 0; i < n; i++)
            {
                dizi1[i, 0] = listView1.Items[i].SubItems[2].Text.ToString();
                dizi1[i, 1] = listView1.Items[i].SubItems[3].Text.ToString();
                dizi1[i, 2] = listView1.Items[i].SubItems[4].Text.ToString();

            }

            if (n != 0)
            {
                Form3 form3 = new Form3(dizi1);
                form3.Show();
            }
        }

        private void ABC_Analizi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
