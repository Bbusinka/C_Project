using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace SzkolaSport
{
    public partial class Form6 : Form
    {
        DataBase d = new DataBase();
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string n = textBox1.Text;
            string d_c = textBox2.Text;
            string m = textBox3.Text;
            string t = textBox4.Text;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Podaj wszystkie dane!!!");
            }
            else
            {
                string query = $"insert into konkursy (nazwa, data_czas, miejsce, typ)  VALUES ('{n}','{d_c}','{m}','{t}');";
                MySqlCommand command = new MySqlCommand(query, d.getConnection());
                d.openConnection();
                command.ExecuteNonQuery();
                MessageBox.Show("Nowe dane dodane do tabeli.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
    }
}
