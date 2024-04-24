using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySqlConnector;

namespace SzkolaSport
{
    public partial class Form5 : Form
    {
        DataBase d = new DataBase();
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            
            if (textBox1.Text == "")
            {
                MessageBox.Show("Podaj wszystkie dane!!!");
            }
            else
            {
                string query = $"insert into sekcja(nazwa)  VALUES ('{s}');";
                MySqlCommand command = new MySqlCommand(query, d.getConnection());
                d.openConnection();
                command.ExecuteNonQuery();
                MessageBox.Show("Nowe dane dodane do tabeli.");
                textBox1.Text = "";
            }
        }
    }
}
