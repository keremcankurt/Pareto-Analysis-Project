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
    public partial class Form1 : Form
    {
        Context context = new Context();
        public Form1()
        {
            InitializeComponent();
        }
        void listele()
        {

            var malzemeler = (from i in context.malzemeler select i.MalzemeAdı).ToList();

            listView1.Items.Clear();
            foreach (var item in malzemeler)
            {
                listView1.Items.Add(item.ToString());
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripMenuItem1.Enabled = false;
            toolStripMenuItem2.Enabled = true;
            listele();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kod = 0;
            Malzeme malzeme = new Malzeme();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""
                && textBox4.Text != "" && textBox5.Text != "")
            {
                malzeme.MalzemeAdı = textBox1.Text;
                malzeme.YillikSatis = Convert.ToInt32(textBox2.Text);
                malzeme.BirimFiyat = Convert.ToInt32(textBox3.Text);
                malzeme.MalzemeKodu = comboBox1.Text;
                malzeme.MinStok = Convert.ToInt32(textBox4.Text);
                malzeme.TedarikSuresi = Convert.ToInt32(textBox5.Text);
                context.malzemeler.Add(malzeme);
                context.SaveChanges();
                listele();
            }
            else
            {
                MessageBox.Show("Önce alanları doldurunuz!");
            }
        }

        int kod = 0;


        private void button2_Click(object sender, EventArgs e)
        {
            if (kod == 0)
            {
                MessageBox.Show("Önce silinecek yeri seçin!");
            }
            else
            {
                var silinecek = context.malzemeler.Find(kod);
                context.malzemeler.Remove(silinecek);
                context.SaveChanges();
                listele();
                kod = 0;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";


            }

        }
        private void listView1_Click(object sender, EventArgs e)
        {
            kod = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            var secim = context.malzemeler.Find(kod);
            textBox1.Text = secim.MalzemeAdı.ToString();
            textBox2.Text = secim.YillikSatis.ToString();
            textBox3.Text = secim.BirimFiyat.ToString();
            comboBox1.Text = secim.MalzemeKodu.ToString();
            textBox4.Text = secim.MinStok.ToString();
            textBox5.Text = secim.TedarikSuresi.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kod == 0)
            {
                MessageBox.Show("Önce düzeltilecek yeri seçiniz!");
            }
            else
            {
                var duzeltilecek = context.malzemeler.Find(kod);

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""
                && textBox4.Text != "" && textBox5.Text != "")
                {
                    duzeltilecek.MalzemeAdı = (textBox1.Text);
                    duzeltilecek.YillikSatis = Convert.ToInt32(textBox2.Text);
                    duzeltilecek.BirimFiyat = Convert.ToInt32(textBox3.Text);
                    duzeltilecek.MalzemeKodu = comboBox1.Text;
                    duzeltilecek.MinStok = Convert.ToInt32(textBox4.Text);
                    duzeltilecek.TedarikSuresi = Convert.ToInt32(textBox5.Text);

                    context.SaveChanges();
                    listele();
                }
                else
                {
                    MessageBox.Show("Önce alanları doldurunuz!");
                }
                kod = 0;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ABC_Analizi ABC = new ABC_Analizi();
            ABC.Show();
            this.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SayiKontrol(TextBox tBox)
        {

            string gecici = tBox.Text;
            bool kontrol = true;
            for (int i = 0; i < gecici.Length; i++)
            {
                if (!Char.IsNumber(gecici[i]))
                {
                    kontrol = false;
                    break;
                }
            }
            if (!kontrol)
            {
                tBox.BackColor = Color.Red;
                MessageBox.Show("Lütfen sayı giriniz!");
                tBox.BackColor = Color.White;
                tBox.Text = "";


            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SayiKontrol(textBox2 as TextBox);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SayiKontrol(textBox3 as TextBox);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SayiKontrol(textBox4 as TextBox);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SayiKontrol(textBox5 as TextBox);
        }
    }
}
