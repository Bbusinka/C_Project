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
    public partial class Form10 : Form
    {
        string tel;
        Student student = new Student();
        public Form10(string telefon)
        {
            InitializeComponent();
            tel = telefon;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text;
            if (textBox1.Text != "") {
                string query = $"CALL addB ({tel},'{data}');";
                MySqlCommand command = new MySqlCommand(query, student.getConnection());
                student.openConnection();
                command.ExecuteNonQuery();
                MessageBox.Show("Nowe dane dodane do tabeli.");
                textBox1.Text = "";

            }
            else { MessageBox.Show("Podaj wszystkie dane!!!"); }
        }
    }
}
