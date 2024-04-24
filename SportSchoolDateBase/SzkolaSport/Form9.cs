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
    public partial class Form9 : Form
    {
        string tel;
        Student student = new Student();
        DataBase dataBase = new DataBase();
        int status;
        int diejstwie;
        public Form9(int s, int d, string t)
        {
            InitializeComponent();
            status = s;
            diejstwie = d;
            tel= t;
        }

        private void ReadSekcja(System.Windows.Forms.ComboBox comboBox, IDataRecord record)
        {
            comboBox.Items.Add(record.GetString(0));
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            switch (status)
            { 
            case 1: {   
                        string i = textBox1.Text;
                        string n = textBox2.Text;
                        string t = textBox3.Text;
                        string p = textBox4.Text;
                        string d = textBox5.Text;
                        string s = comboBox1.Text;
                        string u = t + p;
                        if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.SelectedIndex != -1)
                        {
                            string query1 = $"call addS('{s}','{u}','{i}','{n}','{t}','{p}','{d}');";
                            MySqlCommand command1 = new MySqlCommand(query1, dataBase.getConnection());
                            dataBase.openConnection();
                            command1.ExecuteNonQuery();
                            MessageBox.Show("Nowe dane dodane do tabeli.");
                            comboBox1.SelectedIndex = -1;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            Form7 form7 = new Form7(t);
                            form7.Show();
                            Close();

                        }
                        else { MessageBox.Show("Podaj wszystkie dane!"); }
                        break;
                    }
            case 2: {
                        string i = textBox1.Text;
                        string n = textBox2.Text;
                        string t = textBox3.Text;
                        string p = textBox4.Text;
                        string u = t + p;
                        if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                        {
                            string query1 = $"call addT'{u}','{i}','{n}','{t}','{p}');";
                            MySqlCommand command1 = new MySqlCommand(query1, dataBase.getConnection());
                            dataBase.openConnection();
                            command1.ExecuteNonQuery();
                            MessageBox.Show("Nowe dane dodane do tabeli.");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            Form8 form8 = new Form8(t);
                            form8.Show();
                            Close();
                        }
                        else { MessageBox.Show("Podaj wszystkie dane!"); }
                        
                        break;
                    }
            }
        }

        private void ReadName(System.Windows.Forms.TextBox t, IDataRecord record) {
            t.Text = record.GetString(0);
        }
        private void ReadNazwisko(System.Windows.Forms.TextBox t, IDataRecord record)
        {
            t.Text = record.GetString(0);
        }
       
        private void ReadData(System.Windows.Forms.TextBox t, IDataRecord record)
        {
            t.Text = record.GetString(0);
        }
        
        private void ReadPass(System.Windows.Forms.TextBox t, IDataRecord record)
        {
            t.Text = record.GetString(0);
        }
        private void ReadSekcja1(System.Windows.Forms.ComboBox comboBox, IDataRecord record)
        {
            comboBox.Text = record.GetString(0);
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            if (diejstwie == 1 && status == 1) {
                label1.Text = "Edytowanie";
                button2.Visible = true;
                button1.Visible = false;
                label5.Visible = true;
                label6.Visible = true;
                textBox5.Visible = true;
                comboBox1.Visible = true;

                
                string query6 = $"select nazwa from sekcja";
                MySqlCommand command6 = new MySqlCommand(query6, student.getConnection());
                student.openConnection();
                MySqlDataReader reader6 = command6.ExecuteReader();
                while (reader6.Read())
                {
                    ReadSekcja(comboBox1, reader6);
                }
                reader6.Close();

                string query = $"Select FindUName({tel});";
                MySqlCommand command = new MySqlCommand(query, dataBase.getConnection());
                dataBase.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReadName(textBox1, reader);
                }
                reader.Close();



                string query1 = $"select FindULName({tel});";
                MySqlCommand command1 = new MySqlCommand(query1, dataBase.getConnection());
                dataBase.openConnection();
                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    ReadNazwisko(textBox2, reader1);
                }
                reader1.Close();


                textBox3.Text = tel;


                string query3 = $"select FindUPass({tel});";
                MySqlCommand command3 = new MySqlCommand(query3, dataBase.getConnection());
                dataBase.openConnection();
                MySqlDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    ReadPass(textBox4, reader3);
                }
                reader3.Close();


                string query4 = $"select FindUBD({tel});";
                MySqlCommand command4 = new MySqlCommand(query4, dataBase.getConnection());
                dataBase.openConnection();
                MySqlDataReader reader4 = command4.ExecuteReader();
                while (reader4.Read())
                {
                    ReadData(textBox5, reader4);
                }
                reader4.Close();


                string query5 = $"select FindUS({tel});";
                MySqlCommand command5 = new MySqlCommand(query5, dataBase.getConnection());
                dataBase.openConnection();
                MySqlDataReader reader5 = command5.ExecuteReader();
                while (reader5.Read())
                {
                    ReadSekcja1(comboBox1, reader5);
                }
                reader5.Close();
            }
            if (diejstwie == 1 && status == 2) {
                label1.Text = "Edytowanie";
                button2.Visible = true;
                button1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                textBox5.Visible = false;
                comboBox1.Visible = false;

                string query = $"Select FindTName({tel});";
                MySqlCommand command = new MySqlCommand(query, dataBase.getConnection());
                dataBase.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReadName(textBox1, reader);
                }
                reader.Close();



                string query1 = $"select FindTLName({tel});";
                MySqlCommand command1 = new MySqlCommand(query1, dataBase.getConnection());
                dataBase.openConnection();
                MySqlDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    ReadNazwisko(textBox2, reader1);
                }
                reader1.Close();


                textBox3.Text = tel;


                string query3 = $"select FindTPass({tel});";
                MySqlCommand command3 = new MySqlCommand(query3, dataBase.getConnection());
                dataBase.openConnection();
                MySqlDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    ReadPass(textBox4, reader3);
                }
                reader3.Close();

            }
            if(diejstwie==0)
            {
                label1.Text = "Rejestracja";
                button2.Visible = false;
                button1.Visible = true;
                switch (status)
                {
                    case 1:
                        {
                            label5.Visible = true;
                            label6.Visible = true;
                            textBox5.Visible = true;
                            comboBox1.Visible = true;
                            string query = $"select nazwa from sekcja";
                            MySqlCommand command = new MySqlCommand(query, student.getConnection());
                            student.openConnection();
                            MySqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                ReadSekcja(comboBox1, reader);
                            }
                            reader.Close();
                            break;
                        }
                    case 2:
                        {
                            label5.Visible = false;
                            label6.Visible = false;
                            textBox5.Visible = false;
                            comboBox1.Visible = false;

                            break;
                        }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (status)
            {
                case 1:
                    {

                        string i = textBox1.Text;
                        string n = textBox2.Text;
                        string t = textBox3.Text;
                        string p = textBox4.Text;
                        string d = textBox5.Text;
                        string s = comboBox1.Text;
                        string u = t + p;
                        if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.SelectedIndex != -1)
                        {
                            string query1 = $"call updateS('{s}','{u}','{i}','{n}','{t}','{p}','{d}','{tel}');";
                            MySqlCommand command1 = new MySqlCommand(query1, dataBase.getConnection());
                            dataBase.openConnection();
                            command1.ExecuteNonQuery();
                            MessageBox.Show("Zaktualizowane dane.");
                            comboBox1.SelectedIndex = -1;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            Form2 form2 = new Form2(1);
                            form2.Show();
                            Close();
                        }
                        else { MessageBox.Show("Podaj wszystkie dane!"); }
                        break;
                    }
                case 2:
                    {
                        string i = textBox1.Text;
                        string n = textBox2.Text;
                        string t = textBox3.Text;
                        string p = textBox4.Text;
                        string u = t + p;
                        if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                        {
                            string query1 = $"call updateT('{u}','{i}','{n}','{t}','{p}','{tel}');";
                            MySqlCommand command1 = new MySqlCommand(query1, dataBase.getConnection());
                            dataBase.openConnection();
                            command1.ExecuteNonQuery();
                            MessageBox.Show("Zaktualizowane dane.");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            Form2 form2 = new Form2(2);
                            form2.Show();
                            Close();
                        }
                        else { MessageBox.Show("Podaj wszystkie dane!"); }

                        break;
                    }
            }
        }
    }
}
