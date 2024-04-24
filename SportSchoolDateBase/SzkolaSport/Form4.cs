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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SzkolaSport
{
    
    public partial class Form4 : Form
    {
        int s;
        int idz;
        DataBase d = new DataBase();
        public Form4(int s, int idz)
        {
            InitializeComponent();
            this.s = s;
            this.idz = idz;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            if (s == 1)
            {
                button1.Visible = true;
                button2.Visible = false;
                string query = $"select nazwa from sekcja";
                MySqlCommand command = new MySqlCommand(query, d.getConnection());
                d.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReadSekcja(comboBox1, reader);
                }
                reader.Close();

                string query1 = $"select CONCAT(trener.imie,' ', trener.nazwisko) from trener";
                MySqlCommand command1 = new MySqlCommand(query1, d.getConnection());
                d.openConnection();
                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    ReadTrener(comboBox2, reader1);
                }
                reader1.Close();


            }
            if (s == 2)
            {
                button2.Visible = true;
                button1.Visible = false;
                label1.Text = "Edytowanie";
                string query = $"SELECT Sekcja.nazwa FROM Trener INNER JOIN Sekcja INNER JOIN " +
                    $"Zajecia ON Sekcja.id = Zajecia.id_s ON Trener.id = Zajecia.id_t WHERE Zajecia.id={idz}; ";
                MySqlCommand command = new MySqlCommand(query, d.getConnection());
                d.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReadSekcja1(comboBox1, reader);
                }
                reader.Close();

                string query1 = $"SELECT concat(Trener.imie,' ',Trener.nazwisko) FROM Trener INNER JOIN Sekcja INNER JOIN " +
                    $"Zajecia ON Sekcja.id = Zajecia.id_s ON Trener.id = Zajecia.id_t WHERE Zajecia.id={idz};";
                MySqlCommand command1 = new MySqlCommand(query1, d.getConnection());
                d.openConnection();
                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    ReadTrener1(comboBox2, reader1);
                }
                reader1.Close();

                string query2 = $"SELECT Zajecia.dzien FROM Trener INNER JOIN Sekcja INNER JOIN " +
                    $"Zajecia ON Sekcja.id = Zajecia.id_s ON Trener.id = Zajecia.id_t WHERE Zajecia.id={idz};";
                MySqlCommand command2 = new MySqlCommand(query2, d.getConnection());
                d.openConnection();
                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    ReadDzien(textBox3, reader2);
                }
                reader2.Close();

                string query3 = $"SELECT Zajecia.poczatek FROM Trener INNER JOIN Sekcja INNER JOIN " +
                    $"Zajecia ON Sekcja.id = Zajecia.id_s ON Trener.id = Zajecia.id_t WHERE Zajecia.id={idz};";
                MySqlCommand command3 = new MySqlCommand(query3, d.getConnection());
                d.openConnection();
                MySqlDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    ReadP(textBox1, reader3);
                }
                reader3.Close();

                string query4 = $"SELECT Zajecia.koniec FROM Trener INNER JOIN Sekcja INNER JOIN " +
                    $"Zajecia ON Sekcja.id = Zajecia.id_s ON Trener.id = Zajecia.id_t WHERE Zajecia.id={idz};";
                MySqlCommand command4 = new MySqlCommand(query4, d.getConnection());
                d.openConnection();
                MySqlDataReader reader4 = command4.ExecuteReader();
                while (reader4.Read())
                {
                    ReadK(textBox2, reader4);
                }
                reader4.Close();

                string query5 = $"select CONCAT(trener.imie,' ', trener.nazwisko) from trener";
                MySqlCommand command5 = new MySqlCommand(query5, d.getConnection());
                d.openConnection();
                MySqlDataReader reader5 = command5.ExecuteReader();
                while (reader5.Read())
                {
                    ReadTrener(comboBox2, reader5);
                }
                reader5.Close();

                string query6 = $"select sekcja.nazwa from Sekcja";
                MySqlCommand command6 = new MySqlCommand(query6, d.getConnection());
                d.openConnection();
                MySqlDataReader reader6 = command6.ExecuteReader();
                while (reader6.Read())
                {
                    ReadTrener(comboBox1, reader6);
                }
                reader6.Close();


            }
            

        }

        private void ReadSekcja(System.Windows.Forms.ComboBox c, IDataRecord record)
        {
            c.Items.Add(record.GetString(0));
        }

        private void ReadSekcja1(System.Windows.Forms.ComboBox c, IDataRecord record)
        {
            c.Text = record.GetString(0);
        }

        private void ReadTrener(System.Windows.Forms.ComboBox c, IDataRecord record)
        {
            c.Items.Add(record.GetString(0));
        }

        private void ReadTrener1(System.Windows.Forms.ComboBox c, IDataRecord record)
        {
            c.Text = record.GetString(0);
        }

        private void ReadDzien(System.Windows.Forms.TextBox t, IDataRecord record)
        {
            t.Text = record.GetString(0);
        }

        private void ReadP(System.Windows.Forms.TextBox t, IDataRecord record)
        {
            t.Text = (record.GetDateTime(0)).ToShortTimeString();
        }

        private void ReadK(System.Windows.Forms.TextBox t, IDataRecord record)
        {
            t.Text = (record.GetDateTime(0)).ToShortTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = comboBox1.Text;
            string t = comboBox2.Text;
            string dz = textBox3.Text;
            string p = "2023-11-11 "+textBox1.Text+":00";
            string k = "2023-11-11 "+textBox2.Text+":00";
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || textBox1.Text == "" || textBox2.Text == ""||textBox3.Text=="")
            {
                MessageBox.Show("Podaj wszystkie dane!!!");
            }
            else {
                string query = $"CALL addZ ('{s}','{t}','{dz}','{p}','{k}');";
                MySqlCommand command = new MySqlCommand(query, d.getConnection());
                d.openConnection();
                command.ExecuteNonQuery();
                MessageBox.Show("Nowe dane dodane do tabeli.");
                comboBox1.SelectedIndex= -1;
                comboBox2.SelectedIndex= -1;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = comboBox1.Text;
            string t = comboBox2.Text;
            string dz = textBox3.Text;
            string p = "2023-11-11 " + textBox1.Text + ":00";
            string k = "2023-11-11 " + textBox2.Text + ":00";
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Podaj wszystkie dane!!!");
            }
            else
            {
                string query = $"CALL updateZ ('{s}','{t}','{dz}','{p}','{k}','{idz}');";
                MySqlCommand command = new MySqlCommand(query, d.getConnection());
                d.openConnection();
                command.ExecuteNonQuery();
                MessageBox.Show("Zaktualizowane dane.");
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
    }
}
