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
        int satir=20, sütun=20;
        int alan_sütun = 10, alan_satir = 19;
        string oyuncu_ismi;
        int bomba_sayisi = 0;
        int[,] alan_2d = new int[20, 20] ;


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


            oyun_kontrol();



        }

        
    
       


        public void oyun_baslat_Click(object sender, EventArgs e)
        {
            bool zorluk_secimi=false;
            
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


            for (int i = 0; i < sütun; i++)
            {
                for (int j = 0; j < satir; j++)
                {
                    alan_2d[i, j] = 1;
                }
            }
            // bombasız alanlara 1 bombalı alanlara 0 dedim
            bomba_yerlesimi();



        }

        public void oyun_kontrol()
        {
            
            if (yön=="aşağı")
            {
                alan_satir++;
                if (alan_satir==20)
                {
                    MessageBox.Show("Çok aşağı gittiniz");
                    alan_satir--;
                }
                else
                {
                    if (alan_2d[alan_sütun, alan_satir] == 0)
                    {
                        oyun_kaybetti();
                    }
                }
                
            }
           else if (yön == "yukarı")
            {
                --alan_satir;
            
                if (alan_satir == 0)
                {
                    oyun_kazandi();
                }

                else
                {
                    if (alan_2d[alan_sütun, alan_satir] == 0)
                    {
                        oyun_kaybetti();
                    }
                }

            }
           else if (yön == "sağ")
            {
                alan_sütun--;
                if (alan_sütun == -1)
                {
                    MessageBox.Show("Çok sağa gittiniz");
                    alan_sütun++;
                }
                else
                {
                    if (alan_2d[alan_sütun, alan_satir] == 0)
                    {
                        oyun_kaybetti();
                    }
                }

            }
          else  if (yön == "sol")
            {
                alan_sütun++;
                if (alan_sütun == 20)
                {
                    MessageBox.Show("Çok sola gittiniz");
                    alan_sütun--;
                }
                else
                {
                    if (alan_2d[alan_sütun, alan_satir] == 0)
                    {
                        oyun_kaybetti();
                    }
                }

            }


        }

        public void bomba_yerlesimi()
        {
            int i=1;
            int bomba_satir=0, bomba_sütun=0;
            Random rassal = new Random() ;
            while (i <= bomba_sayisi)
            {
                bomba_sütun = rassal.Next(0, 20);
                bomba_satir = rassal.Next(0, 20);
                if (alan_2d[bomba_sütun, bomba_satir] != 0)
                {
                    alan_2d[bomba_sütun, bomba_satir] = 0;
                    i++;
                }
                else
                {
                    continue;
                }
            }          
        }
        public void oyun_kaybetti()
        {
            MessageBox.Show("oyunu kaybettiniz");
        }
        public void oyun_kazandi()
        {
            MessageBox.Show("tebrikler oyunu kazandınız.");
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


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
