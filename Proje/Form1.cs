using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroSet_UI.Forms;
using System.Runtime.InteropServices;
using System.IO;
using static System.Windows.Forms.FileDialog;

namespace Proje
{
    public partial class Form1 : MetroSetForm
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double fiyat = Math.Round((Degerler.urunFiyati / 100)*92,2);
            double kdv = Math.Round((Degerler.urunFiyati / 100) *8,2);
            double sonDeger = Degerler.urunFiyati;
            label3.Text = fiyat.ToString() + " TL";
            label4.Text = kdv.ToString() + " TL";
            label6.Text = sonDeger.ToString() + " TL";
            label11.Text = Degerler.urunAdi;
            checkBox1.Text = "Önbilgirendirme formunu \nokudum ve kabul ediyorum.";
            checkBox2.Text = "Mesafeli Satış Sözleşmesini\nokudum ve kabul ediyorum.";

            string FileName1 = "kullaniciSoz.txt";
            string path1 = Path.Combine(Environment.CurrentDirectory, FileName1);
            TextReader reader = new StreamReader(path1);
            richTextBox1.Text = reader.ReadToEnd();
            reader.Close();

            string FileName2 = "mesafeliSatisSoz.txt";
            string path2 = Path.Combine(Environment.CurrentDirectory, FileName2);
            TextReader reader2 = new StreamReader(path2);
            richTextBox2.Text = reader2.ReadToEnd();
            reader2.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                anaSayfa anasayfa = new anaSayfa();
                MessageBox.Show("Siparişiniz işleme alınmıştır.\nEn kısa süre içerisinde e-kitabınız\nsize mail yoluyla iletilecektir.","Sipariş Onayı");
                anasayfa.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Sitemizden alışveriş yapabilmek için\nsözleşmeleri onaylamanız gerekmektedir.");
        }
    }
}
