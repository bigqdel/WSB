using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolkoAndKrzyzyk
{
    public partial class Plansza : Form
    {
        public Plansza()
        {
            InitializeComponent();
            Plansza.B666 = new System.Windows.Forms.Button();
        }

        public int gracz = 2; // tura X gdy rowne 2 
        public int tura = 0; // zliczanie  tur
       //zliczanie wygranych dla obu graczy 
        public int s1 = 0;
        public int s2 = 0;
        public int s3 = 0;

        private void guzikKlik(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "")
            {


                if (gracz % 2 == 0)
                {
                    button.Text = "X";
                    gracz++;
                    tura++;
                }
                else
                {
                    button.Text = "O";
                    gracz++;
                    tura++;
                }
                if (SprawdzWybor()==true)
                {
                    MessageBox.Show("Remis!");
                    s3++;
                    NowaGra();
                }
                if (KtoWygral()==true)
                {
                    if(button.Text=="X")
                    {
                        MessageBox.Show("X Wygrał!!");
                        s1++;
                        NowaGra();
                    }
                    else
                    {
                        MessageBox.Show("O Wygrał !!");
                        s2++;
                        NowaGra();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Plansza_Load_1(object sender, EventArgs e)
        {
            XWygrane.Text = "X: " + s1;
            OWygrane.Text = "O: " + s2;
            Rozdania.Text = "Rozdania: " + s3;
        }

        void NowaGra ()
        {
            gracz = 2;
            tura = 0;
            B00.Text = B01.Text = B02.Text = B10.Text = B11.Text = B12.Text = B20.Text = B21.Text = B22.Text = "";
            XWygrane.Text = "X: " + s1;
            OWygrane.Text = "O: " + s2;
            Rozdania.Text = "Rozdania: " + s3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NowaGra();
        }

        bool SprawdzWybor()
        {
            if ((tura == 9)&&KtoWygral()==false)
                return true;
            else
                return false;
        }
        bool KtoWygral()
        {
            //poziomo
            if ((B00.Text == B01.Text) && (B01.Text == B02.Text) && B00.Text != "")
                return true;
            else if ((B10.Text == B11.Text) && (B11.Text == B12.Text) && B10.Text != "")
                return true;
            else if ((B20.Text == B21.Text) && (B21.Text == B22.Text) && B20.Text != "")
                return true;
            //pionowo
            if ((B00.Text == B10.Text) && (B10.Text == B20.Text) && B00.Text != "")
                return true;
            else if ((B01.Text == B11.Text) && (B11.Text == B21.Text) && B01.Text != "")
                return true;
            else if ((B02.Text == B12.Text) && (B12.Text == B22.Text) && B02.Text != "")
                return true;

            //naskos
            if ((B00.Text == B11.Text) && (B11.Text == B22.Text) && B00.Text != "")
                return true;
            else if ((B02.Text == B11.Text) && (B11.Text == B20.Text) && B02.Text != "")
                return true;
            else 
                return false ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s1 = s2 = tura = 0;
            NowaGra();
        }

         

    }
}
