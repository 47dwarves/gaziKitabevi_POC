using MetroSet_UI.Forms;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace Proje
{
    public partial class Form2 : MetroSetForm
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

        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataReader dataReader;

        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userid = textBox1.Text;
            string pword = textBox2.Text;
            connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=dbUsers.accdb");
            command = new OleDbCommand();
            connection.Open();
            command.Connection = connection;

            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("Lütfen bilgilerinizi eksiksiz giriniz!");
            }
            else
            {
                command.CommandText = "SELECT * FROM kullanici where kullaniciAdi='" + textBox1.Text + "' AND sifre='" + textBox2.Text + "'";
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    Degerler.userID = userid;
                    anaSayfa anasayfa = new anaSayfa();
                    anasayfa.Show();
                    Form2 form2 = new Form2();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                }

                connection.Close();
            }
        }

                

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
