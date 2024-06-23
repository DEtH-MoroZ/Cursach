using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Классы_в_C_
{
    public partial class FormRegistration : Form
    {
        public static string connectString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
        private OleDbConnection myConnection;
        public string query;
        public string queryMax;
        public FormRegistration()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            this.Close();
            formLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text && textBox2.Text != "")
            {
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();
                queryMax = "Select MAX(id_пользователя) FROM Users";
                OleDbCommand max = new OleDbCommand(queryMax, myConnection);
                int maxIndex = Convert.ToInt32(max.ExecuteScalar().ToString());

                maxIndex++;
                query = "INSERT INTO Users (id_пользователя, Логин, Пароль, Админ) " + "VALUES (" + maxIndex + ", '" + textBox1.Text + "', " + "'" + textBox2.Text + "'," + "false" + ")";

                OleDbCommand cmd = new OleDbCommand(query, myConnection);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"Успешная регистрацияя, {textBox1.Text}");

                FormLogin formlogin = new FormLogin();
                this.Hide();
                formlogin.Show();
            }

            else MessageBox.Show("Пароли не совпадают");
        }
    }
}
