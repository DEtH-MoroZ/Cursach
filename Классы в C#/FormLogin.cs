using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Классы_в_C_
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FormRegistration formRegistration = new FormRegistration();
            this.Hide();
            formRegistration.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string admin = "admin";
            string adminPass = "admin";

            var log = Convert.ToString(textBox1.Text);

            var pas = Convert.ToString(textBox2.Text);


            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);


            OleDbCommand MyOleDbComm2 = new OleDbCommand();
            dbConnection.Open();

            MyOleDbComm2.CommandText = "Select логин from Users " +
                                       " Where Users.Логин='" + textBox1.Text + "'";
            MyOleDbComm2.Connection = dbConnection;

            var result = MyOleDbComm2.ExecuteScalar();

            dbConnection.Close();

            OleDbCommand MyOleDbComm1 = new OleDbCommand();
            dbConnection.Open();

            MyOleDbComm1.CommandText = "Select пароль from Users " +
                                       " Where Users.Пароль='" + textBox2.Text + "'";
            MyOleDbComm1.Connection = dbConnection;

            var result1 = MyOleDbComm1.ExecuteScalar();

            dbConnection.Close();

            if (log == admin && pas == adminPass)
            {
                Class1.admin++;
                FormGlav formGGlav = new FormGlav();
                formGGlav.Show();
                this.Hide();
            }
            else if (result == null && result1 == null || result == null || result1 == null)
            {
                MessageBox.Show("Данные введены не верно!");
            }
            else
            {
                FormGlav formGGlav = new FormGlav();
                formGGlav.Show();
                this.Hide();
            }
        }
    }
}
