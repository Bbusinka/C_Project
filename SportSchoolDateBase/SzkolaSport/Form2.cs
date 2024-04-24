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
    public partial class Form2 : Form
    {
        DataBase data = new DataBase();
        int status;
        public Form2(int s)
        {
            InitializeComponent();
            status = s;
        }

        private void ReadResult(TextBox a, IDataRecord record) {
            a.Text =  record.GetString(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t = textBox1.Text;
            string p = textBox2.Text;
            if (textBox1.Text!="" && textBox2.Text != "") { 
                switch (status)
                {
                    case 1:
                        {
                            string search1 = $"SELECT concat(telefon, password) FROM Uczniowie " +
                             $"WHERE telefon like '{t}' AND password like '{p}';";
                            MySqlCommand command = new MySqlCommand(search1, data.getConnection());
                            command.ExecuteNonQuery();
                            MySqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                ReadResult(textBox1, reader);
                            }
                            reader.Close();
                            string a = textBox1.Text;
                            textBox1.Text = t;
                            if (a == t + p)
                            {
                                Form7 form7 = new Form7(t);
                                form7.Show();
                                Close();
                            }
                            else { MessageBox.Show("Dane niepoprawne!"); }
                            break;
                        }
                    case 2:
                        { 
                            string search1 = $"SELECT concat(telefon, password) FROM Trener " +
                                $"WHERE telefon like '{t}' AND password like '{p}';";
                            MySqlCommand command = new MySqlCommand(search1, data.getConnection());
                            command.ExecuteNonQuery();
                            data.openConnection();
                            MySqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                ReadResult(textBox1, reader);
                            }
                            reader.Close();
                            string a=textBox1.Text;
                            textBox1.Text= t;
                            if (a == t+p)
                            {   
                                Form8 form8 = new Form8(t);
                                form8.Show();
                                Close();
                            }
                            else { MessageBox.Show("Dane niepoprawne!"); }
                            break;
                        }
                    case 3:
                        {
                        if (textBox1.Text=="admin" && textBox2.Text == "admin") {
                                Form3 form3 = new Form3();
                                form3.Show(); 
                                Close();
                            }
                        
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
                        Form9 form9 = new Form9(status,0,null);
                        form9.Show();
                        Close();
                        break;
                        
                    }
                case 2:
                    {
                        Form9 form9 = new Form9(status, 0, null);
                        form9.Show();
                        Close();
                        break;
                    }
                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            data.openConnection();     
            if (status == 3) { button2.Visible = false; }
            else { button2.Visible = true; }
        }
    }
}
