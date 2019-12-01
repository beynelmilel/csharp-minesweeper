using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mayın_Tarlası
{
    public partial class mayin_tarlasi : Form
    {
        public mayin_tarlasi()
        {
            InitializeComponent();
        }
        string yön;
        int dakika , saniye ;
        int satir, sütun;
        string oyuncu_ismi;




        private void mayin_tarlasi_Load(object sender, EventArgs e)
        {

            string dosya_yolu = @"C:\Users\DELL\Desktop\oynayanlar.txt";
            if (File.Exists(dosya_yolu) == false)
            {
                FileStream fs = new FileStream(dosya_yolu, FileMode.Create);

                fs.Close();

            }

        }

        private void yön_click(object sender, EventArgs e)
        {
            
            Button yon = (Button)sender;


            if (yon.Text == "←")
            {
                yön = "sol";
            }
            else if (yon.Text == "→")
            {
                yön = "sağ";
            }
            else if (yon.Text == "↓")
            {
                yön = "aşağı";
            }
            else if (yon.Text == "↑")
            {
                yön = "yukarı";
            }



        }

        private void yrdm_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yunus Emre Eraslan\n" + "Görsel Programlama 2. Proje ");
        }

        private void skor_goster_Click(object sender, EventArgs e)
        {
            string dosya_yolu = @"C:\Users\DELL\Desktop\oynayanlar.txt";
            System.Diagnostics.Process.Start(dosya_yolu);
        }

        private void cell_paint(object sender, TableLayoutCellPaintEventArgs e)
        {

        }
        Point selectedCell = new Point();
        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
          
          
                if (e.Button == MouseButtons.Right)
                {

                    //show contextMenuStrip
                    selectedCell = new Point(e.X / (tableLayoutPanel1.Width / tableLayoutPanel1.ColumnCount), e.Y / (tableLayoutPanel1.Height / tableLayoutPanel1.RowCount));
                }
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void oyun_baslat_Click(object sender, EventArgs e)
        {
            bool zorluk_secimi=false;
            int bomba_sayisi = 0;
            if (radioButton1.Checked == true)
            {
                bomba_sayisi = 40;
                zorluk_secimi = true;
            }
            else if (radioButton2.Checked == true)
            {
                bomba_sayisi = 50;
                zorluk_secimi = true;

            }
            else if (radioButton3.Checked == true)
            {
                bomba_sayisi = 80;
                zorluk_secimi = true;
            }

            if (zorluk_secimi == true)
            {
                oyuncu_ismi = textBox1.Text;
                MessageBox.Show(oyuncu_ismi + " Kaydedildi.");

                timer1.Interval = 1000;
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Lütfen Zorluk Seçimi Yapınız.");
            }

      
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (saniye >= 10 && dakika >= 10)
            {
                süre.Text = (Convert.ToString(dakika) + " : ") + (Convert.ToString(saniye));
            }
            else if (saniye >= 10 && dakika <= 10)
            {
                süre.Text = "0" + (Convert.ToString(dakika) + " : ")  + (Convert.ToString(saniye));
            }
            else if (saniye <= 10 && dakika >= 10)
            {
                süre.Text =  (Convert.ToString(dakika) + " : ") + "0" + (Convert.ToString(saniye));
            }
            else if (saniye <= 10 && dakika <= 10)
            {
                süre.Text = "0" + (Convert.ToString(dakika) + " : ") + "0" + (Convert.ToString(saniye));
            }

            if (saniye == 59)
            {
                saniye = 0;
                dakika++;
            }

            saniye++;

        }
    }
}
