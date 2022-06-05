using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entityprosedürler2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GorevEntities baglanti = new GorevEntities();
    
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
         public void elistele()
        {
            dataGridView1.DataSource = baglanti.Elistele();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            elistele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Elemanlar a = new Elemanlar();
            a.ElemanAdi = textBox1.Text;
            a.ElemanPozisyon = textBox2.Text;
            a.ElemanMaas = Convert.ToDecimal(textBox3.Text);
            a.ElemanStatu = textBox4.Text;
            a.GorevNo = Convert.ToInt32(textBox5.Text);
            baglanti.Eekle(a.ElemanAdi, a.ElemanPozisyon, a.ElemanMaas, a.ElemanStatu, a.GorevNo);
            baglanti.SaveChanges();
            elistele();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Elemanlar a = new Elemanlar();
           a.ElemanNo = Convert.ToInt32(textBox1.Tag);
           a.ElemanAdi = textBox1.Text;
           a.ElemanPozisyon = textBox2.Text;
           a.ElemanMaas = Convert.ToDecimal(textBox3.Text);
           a.ElemanStatu = textBox4.Text;
           a.GorevNo = Convert.ToInt32(textBox5.Text);
            baglanti.Eyenile(a.ElemanNo,a.ElemanAdi, a.ElemanPozisyon, a.ElemanMaas, a.ElemanStatu, a.GorevNo);
            baglanti.SaveChanges();
            dataGridView1.DataSource = baglanti.Elistele().ToList();



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow s = dataGridView1.CurrentRow;
            textBox1.Tag = s.Cells[0].Value.ToString();
            textBox1.Text = s.Cells[1].Value.ToString();
            textBox2.Text = s.Cells[2].Value.ToString();
            textBox3.Text = s.Cells[3].Value.ToString();
            textBox4.Text = s.Cells[4].Value.ToString();
            textBox5.Text = s.Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            baglanti.Esil(id);
            baglanti.SaveChanges();
            dataGridView1.DataSource = baglanti.Elistele().ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {  var getir=baglanti.Eara(textBox1.Text);
            dataGridView1.DataSource = getir.ToList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.join1();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Emaassirala();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
