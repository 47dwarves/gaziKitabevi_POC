using MetroSet_UI.Forms;
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
using System.Data.OleDb;

namespace Proje
{
    public partial class Form3 : MetroSetForm
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

        public Form3()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;
            connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=dbUsers.accdb");
            command = new OleDbCommand();
            connection.Open();
            command.Connection = connection;

            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
                MessageBox.Show("Lütfen bilgilerinizi eksiksiz giriniz!");
            else
            {
                string register = "INSERT INTO kullanici VALUES ('" + userName + "','" + password + "')";
                command = new OleDbCommand(register, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Kaydınız yapılmıştır, giriş ekranından giriş yapabilirsiniz.");
            }
            connection.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
