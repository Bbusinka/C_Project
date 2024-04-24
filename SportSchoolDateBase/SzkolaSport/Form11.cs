using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySqlConnector;

namespace SzkolaSport
{
    public partial class Form11 : Form
    {
        int status;
        int idz;
        Trener trener = new Trener();
        DataBase d = new DataBase();
        string tel;
        public Form11(int s, string t,int id)
        {
            InitializeComponent();
            status= s;
            tel = t;
            idz = id;
        }

        private void ReadKonkurs(System.Windows.Forms.ComboBox c, IDataRecord record)
        {
            c.Items.Add(record.GetString(0));
        }

        private void ReadU(System.Windows.Forms.ComboBox c, IDataRecord record)
        {
            c.Items.Add(record.GetString(0));
        }
        private void ReadU1(System.Windows.Forms.ComboBox c, IDataRecord record)
        {
            c.Text = record.GetString(0);
        }

        private void ReadW(System.Windows.Forms.TextBox t, IDataRecord record) { 
            t.Text = record.GetString(0);
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            if (status == 1)
            {
                button1.Visible= true;
                button2.Visible= false;
                string query = $"select nazwa from konkursy;";
                MySqlCommand command = new MySqlCommand(query, trener.getConnection());
                trener.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReadKonkurs(comboBox1, reader);
                }
                reader.Close();

                string query1 = $"select concat(imie,' ',nazwisko) from uczniowie;";
                MySqlCommand command1 = new MySqlCommand(query1, trener.getConnection());
                trener.openConnection();
                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    ReadU(comboBox2, reader1);
                }
                reader1.Close();


            }
            if (status == 2)
            {
                button2.Visible = true;
                button1.Visible = false;
                label1.Text = "Edytowanie";
                string query = $"select nazwa from konkursy;";
                MySqlCommand command = new MySqlCommand(query, trener.getConnection());
                trener.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReadKonkurs(comboBox1, reader);
                }
                reader.Close();

                string query1 = $"Select FindKonkurs({tel},{idz});";
                MySqlCommand command1 = new MySqlCommand(query1, d.getConnection());
                d.openConnection();
                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    ReadU1(comboBox1, reader1);
                }
                reader1.Close();

                string query2 = $"Select FindUczen({tel},{idz});";
                MySqlCommand command2 = new MySqlCommand(query2, d.getConnection());
                d.openConnection();
                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    ReadU1(comboBox2, reader2);
                }
                reader2.Close();

                string query3 = $"select concat(imie,' ',nazwisko) from uczniowie;";
                MySqlCommand command3 = new MySqlCommand(query3, trener.getConnection());
                trener.openConnection();
                MySqlDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    ReadU(comboBox2, reader3);
                }
                reader3.Close();

                string query4 = $"Select FindWynik({tel},{idz});";
                MySqlCommand command4 = new MySqlCommand(query4, d.getConnection());
                d.openConnection();
                MySqlDataReader reader4 = command4.ExecuteReader();
                while (reader4.Read())
                {
                    ReadW(textBox3, reader4);
                }
                reader4.Close();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = comboBox1.Text;
            string b = comboBox2.Text;
            string w = textBox3.Text;
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Podaj wszystkie dane!!!");
            }
            else
            {
                string query = $"CALL UpdateUdzial ('{a}','{b}','{tel}','{w}',{idz});";
                MySqlCommand command = new MySqlCommand(query, trener.getConnection());
                trener.openConnection();
                command.ExecuteNonQuery();
                MessageBox.Show("Zaktualizowane dane.");
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox3.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = comboBox1.Text;
            string b = comboBox2.Text;
            string w = textBox3.Text;
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Podaj wszystkie dane!!!");
            }
            else
            {
                string query = $"CALL addK ('{a}','{b}','{tel}','{w}');";
                MySqlCommand command = new MySqlCommand(query, trener.getConnection());
                trener.openConnection();
                command.ExecuteNonQuery();
                MessageBox.Show("Nowe dane dodane do tabeli.");
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox3.Text = "";
            }
        }
    }
}
