using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Hesap makinası   :
Donanım klavye ile de kullanılsın
Tek girdili hesaplamalar
sin(x) ,cos(x) ,tanx(x), atan(x), sqr(x), sqrt(x) 
1/x: Eğer x değeri alınmış ise sonucu hesapla,
sonucu txtbx1 yaz aksi taktirde hata ver

2) iki girdi alan hesaplamalar : x+y, x-y, x/y, x*y, x^y
+,-,/,*,^ tıklandı ise x değerini txtbx dan al 
işelmi al ,işlemi labela yaz, x değerini ve işlemi label1 e yaz.
= tıklandıysa y değerini txtbxdan al, x ve y hatasız alındıysa 
işlemi uygula sonucu hesapla labela yaz ,aksi durumda hata ver
 */

namespace HesapMakinesi3
{
    public partial class Form1 : Form
    {
        double x, y, sonuc;
        char islem;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Hesap Makinasi";
        }
        #region iki deger alan islemler
        private void button1_Click(object sender, EventArgs e)
        {
            //+
            islem = '+';
            x = Convert.ToDouble(textBox1.Text);
            label1.Text = x.ToString() + islem.ToString();
            textBox1.Text = ""; // y için metin kutusu temizle
            textBox1.Focus(); // imleci metin kutusuna odakla y'yi yazsın diye
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //-
            islem = '-';
            x = double.Parse(textBox1.Text);
            label1.Text = x.ToString() + islem;
            textBox1.Clear(); //metin kutusunu y için boşaltma
            textBox1.Focus(); // imleci metin kutusuna odakla
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //x
            islem = '*';
            x = double.Parse(textBox1.Text);
            label1.Text = x.ToString() + islem;
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // /
            islem = '/';
            x = Convert.ToDouble(textBox1.Text);
            label1.Text=x.ToString() + islem;
            textBox1.Clear();
            textBox1.Focus();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            // x üzeri y
            x = Convert.ToDouble(textBox1.Text);
            islem = '^';
            label1.Text = x.ToString() + islem;
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            // = basıldı o halde y değeri verilmiş olmalı 
            //  x,y değerini işleme sok, sonucu labela ve textboxa yaz
            sonuc = 0.0;
            y = Convert.ToDouble(textBox1.Text);
            if(islem == '+')
            {
                sonuc = x + y;
            }
            else if(islem == '-')
            {
                sonuc = x - y;
            }
            else if (islem == '*')
            {
                sonuc = x * y;
            }
            else if (islem == '/')
            {
                sonuc = x / y;
            }
            else if (islem == '^') //  btn click yap unutma !!!
            {
                sonuc = Math.Pow(x, y);
            }
            else
            {
                throw new Exception("işlem anlaşılmadı");
            }
            label1.Text = label1.Text + y.ToString() + "=";
            textBox1.Text = sonuc.ToString();
        }


        #endregion

        #region tek deger alan islemler
        private void button5_Click(object sender, EventArgs e)
        {
            //   1/x
            x = Convert.ToDouble(textBox1.Text);
            islem = 'T'; // çarpmaya göre tersi
            label1.Text = "1/" + x.ToString() + "=";
            sonuc = 1.0 / x;
            textBox1.Text = sonuc.ToString();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            // squrae : karesi 
            x = double.Parse(textBox1.Text);
            islem = '²';
            label1.Text = x.ToString() + islem;
            sonuc = x * x;
            textBox1.Text = sonuc.ToString();
        }



        private void button7_Click(object sender, EventArgs e)
        {
            // square root : kare kök
            x = double.Parse(textBox1.Text);
            islem = '√';
            label1.Text = x.ToString() + islem;
            sonuc = Math.Sqrt(x);
            textBox1.Text = sonuc.ToString();
        }



        private void button9_Click(object sender, EventArgs e)
        {
            // sin(x)
            x = double.Parse(textBox1.Text);
            islem = 's';
            label1.Text = "Sin("+x.ToString() + islem+")";
            //açıyı radyana çevirlerek sin hesapla
            sonuc = Math.Sin(Math.PI * x / 180.0);
            textBox1.Text = sonuc.ToString();
        }


        private void button10_Click(object sender, EventArgs e)
        {
            // cos(x)
            x = double.Parse(textBox1.Text);
            islem = 'c';
            label1.Text = "Cos(" + x.ToString() + islem + ")";
            //açıyı radyana çevirlerek sin hesapla
            sonuc = Math.Cos(Math.PI * x / 180.0);
            textBox1.Text = sonuc.ToString();
        }


        private void button11_Click(object sender, EventArgs e)
        {
            // tan(x)
            x = double.Parse(textBox1.Text);
            islem = 't';
            label1.Text = "Tan(" + x.ToString() + islem + ")";
            //arctanın verdiği radyan cinsinde açıyı 
            sonuc = Math.Tan(Math.PI * x / 180.0);
            textBox1.Text = sonuc.ToString();
        }


        private void button12_Click(object sender, EventArgs e)
        {
            // atan(x)
            x = double.Parse(textBox1.Text);
            islem = 'a';
            label1.Text = "Arctan(" + x.ToString() + islem + ")";
            //açıyı radyana çevirlerek sin hesapla
            // dereceye çevir
            sonuc = Math.Atan(x);
            textBox1.Text = sonuc.ToString();
        }
        #endregion
        #region yardımcı metotlar
        private void textBox1_Click(object sender, EventArgs e)
        {
            // metin kutusuna tıklayınca içini boşaltsın
            textBox1.Clear();
        }
        // Formdaki numara tuşlarını txtbxa aktaralım 

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }
        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }
        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }
        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }
        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }
        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }
        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }
        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }
        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }
        private void button23_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }
        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }
        #endregion

        
                private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
                {
                    // Metin kutusunda bir tuşa basıldı
                    // Eğer bu tuş:
                    char tus = e.KeyChar;
                    if (tus == ' ')
                    {
                        //   tuşuna basıldığında buton1 click çağıralım 
                        button1_Click(new object(), new EventArgs());
                        e.Handled = true; // olay işlendi demeniz gerekiyor.
                    }
                    else if (tus == '-')
                    {
                        // - tuşuna basıldığında buton2 click çağıralım 
                        button2_Click(new object(), new EventArgs());
                        e.Handled = true;
                    }
                    else if (tus == '*')
                    {
                        button3_Click(new object(), new EventArgs());
                        e.Handled = true;
                    }
                    else if (tus == '/')
                    {
                        button4_Click(new object(), new EventArgs());
                        e.Handled = true;
                    }
                    if (tus == (char)13)
                    {
                        // enter a basıldıysa  = e basıldı çağır
                        button25_Click(new object(), new EventArgs());
                        e.Handled = true;
                    }

          }
    }
}
