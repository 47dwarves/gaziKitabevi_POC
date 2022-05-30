using MetroSet_UI.Forms;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Proje
{
    public partial class anaSayfa : MetroSetForm
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

        Form1 form1 = new Form1();

        public anaSayfa()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string FileName1 = "tarihce.txt";
            string path1 = Path.Combine(Environment.CurrentDirectory, FileName1);
            TextReader reader = new StreamReader(path1);
            richTextBox1.Text = reader.ReadToEnd();
            reader.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Degerler.urunAdi = "Bilgisayar Ağları\nve Açık Sistem Mimarisi";
            Degerler.urunFiyati = 12.75;
            form1.Show();
            this.Hide();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Degerler.urunAdi = "Bilgisayar Haberleşme Teknolojisi";
            Degerler.urunFiyati = 60.00;
            form1.Show();
            this.Hide();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Degerler.urunAdi = "Yazılım Mühendisliğinde\nModern Yaklaşımlar";
            Degerler.urunFiyati = 46.75;
            form1.Show();
            this.Hide();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            Degerler.urunAdi = "OpenCV ve Python ile Görüntü İşleme";
            Degerler.urunFiyati = 140.40;
            form1.Show();
            this.Hide();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Degerler.urunAdi = "x86 Tabanlı Mikroişlemci\nMimarisi ve Assembly Dili";
            Degerler.urunFiyati = 121.50;
            form1.Show();
            this.Hide();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            Degerler.urunAdi = "Python Soru Çözüm Kitabı";
            Degerler.urunFiyati = 55.25;
            form1.Show();
            this.Hide();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            Degerler.urunAdi = "Git ve GitHub Kullanımı";
            Degerler.urunFiyati = 42.40;
            form1.Show();
            this.Hide();
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            Degerler.urunAdi = "Yapay Zeka Algoritmaları\nve Programlama";
            Degerler.urunFiyati = 99.00;
            form1.Show();
            this.Hide();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            Degerler.urunAdi = "Çözümlü Diferansiyel\nDenklemler Problemleri";
            Degerler.urunFiyati = 59.50;
            form1.Show();
            this.Hide();
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            Degerler.urunAdi = "Programlamayı C ile Öğreniyorum";
            Degerler.urunFiyati = 94.50;
            form1.Show();
            this.Hide();
        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            Degerler.urunAdi = "İşlemsel Yükselteçler\nve Devre Deneyleri";
            Degerler.urunFiyati = 47.56;
            form1.Show();
            this.Hide();
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Hoşgeldin, "+Degerler.userID,"Kullanıcı Bilgisi");
        }
    }
}
