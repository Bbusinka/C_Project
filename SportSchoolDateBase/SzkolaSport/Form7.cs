using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace SzkolaSport
{
    public partial class Form7 : Form
    {
        int menu;
        string tel;
        DataBase d = new DataBase();
        public Form7(string t)
        {
            InitializeComponent();
            tel = t;
        }


        private void ReadZaj(DataGridView dgv, IDataRecord record) { 
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), (record.GetDateTime(4)).ToShortTimeString(), (record.GetDateTime(5)).ToShortTimeString());

        }
        private void rozkładZaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 1;
            label2.Text = "Rozkład zajęć";
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Columns.Add("trener", "Trener");
            dataGridView1.Columns.Add("dzien", "Dzień");
            dataGridView1.Columns.Add("p", "Początek");
            dataGridView1.Columns.Add("k", "Koniec");
            dataGridView1.Rows.Clear();
            string search14 = $"CALL RozkladU({tel});";

            MySqlCommand command = new MySqlCommand(search14, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadZaj(dataGridView1, reader);
            }
            reader.Close();
        }
        private void ReadKonkursy(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDateTime(2), record.GetString(3), record.GetString(4));
        }
        private void listaKonkursówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 2;
            label2.Text = "Lista konkursów";
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Columns.Add("data_czas", "Data i godzina");
            dataGridView1.Columns.Add("miejsce", "Miejsce");
            dataGridView1.Columns.Add("typ", "Typ");
            dataGridView1.Rows.Clear();
            string query = $"CALL K();";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadKonkursy(dataGridView1, reader);
            }
            reader.Close();
        }

        private void ReadResult(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetString(0), (record.GetDateTime(1)).ToShortDateString(), record.GetString(2), record.GetString(3), record.GetString(4));
        }

        private void rezultatyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 3;
            label2.Text = "Wyniki udziału w konkursach";
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Columns.Add("data", "Data");
            dataGridView1.Columns.Add("trener", "Trener");
            dataGridView1.Columns.Add("uczen", "Uczeń");
            dataGridView1.Columns.Add("wynik", "Wynik");
            dataGridView1.Rows.Clear();
            string query = $"CALL W();";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadResult(dataGridView1, reader);
            }
            reader.Close();
        }

        private void ReadBadania(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), (record.GetDateTime(1)).ToShortDateString());
        }

        private void listaBadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 4;
            label2.Text = "Moje badania lekarskie";
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("data", "Data");
            dataGridView1.Rows.Clear();
            string query = $"CALL BadanieU({tel});";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadBadania(dataGridView1, reader);
            }
            reader.Close();
        }



        private void dodaćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 form10= new Form10(tel);
            form10.Show();
        }

        private void edytowaćToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9(1, 1,tel);
            form9.Show();
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            label2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (menu) {
                case 1:
                    {
                        dataGridView1.Rows.Clear();
                        string search5 = $"SELECT Zajecia.id, Sekcja.nazwa, CONCAT(Trener.imie,' ', Trener.nazwisko), " +
                            $"Zajecia.dzien, Zajecia.poczatek, Zajecia.koniec FROM Trener INNER JOIN Zajecia ON " +
                            $"Trener.id = Zajecia.id_t INNER JOIN Sekcja ON Sekcja.id = Zajecia.id_s INNER JOIN" +
                            $" Uczniowie ON Sekcja.id = Uczniowie.sekcja WHERE Uczniowie.telefon LIKE {tel} " +
                            $"AND concat(Trener.imie,' ',Trener.nazwisko,' ',Zajecia.dzien) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search5, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadZaj(dataGridView1, reader);
                        }
                        reader.Close();
                        break;
                    }
                case 2:
                    {
                        dataGridView1.Rows.Clear();
                        string search12 = $"select id, nazwa, data_czas, miejsce, typ from konkursy " +
                            $"where concat(id, nazwa,' ',data_czas,' ',miejsce,' ',typ) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search12, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadKonkursy(dataGridView1, reader);
                        }
                        reader.Close();
                        break;
                    }
                case 3: 
                    {
                        dataGridView1.Rows.Clear();
                        string search13 = $"SELECT Konkursy.nazwa, Konkursy.data_czas, CONCAT(Trener.imie,' ', Trener.nazwisko), " +
                        $"CONCAT(uczniowie.imie,' ', uczniowie.nazwisko), Udzial.wynik FROM uczniowie INNER JOIN " +
                        $"Trener INNER JOIN Konkursy INNER JOIN Udzial ON (Konkursy.id = Udzial.id_k)ON " +
                        $"(Trener.id = Udzial.id_t) ON (uczniowie.id = Udzial.id_u)" +
                        $"WHERE concat(konkursy.nazwa,' ', konkursy.data_czas,' ',trener.imie,' ', trener.nazwisko, ' ',uczniowie.imie,' ', uczniowie.nazwisko,' ',udzial.wynik) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search13, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadResult(dataGridView1, reader);
                        }
                        reader.Close();
                        break;
                    }

                case 4:
                    {
                        dataGridView1.Rows.Clear();
                        string search6 = $"SELECT Badanie.id, Badanie.data " +
                        $"FROM Uczniowie INNER JOIN Badanie ON Uczniowie.id = Badanie.uczen WHERE Uczniowie.telefon LIKE '{tel}' AND Badanie.data like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search6, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadBadania(dataGridView1, reader);
                        }
                        reader.Close();
                        break;
                    }
            
            }
        }

        private void usunąćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int idz = int.Parse(dataGridView1[0, index].Value.ToString());
            string delete = $"DELETE FROM Badanie WHERE id = {idz};";

            MySqlCommand command = new MySqlCommand(delete, d.getConnection());
            d.openConnection();
            command.ExecuteNonQuery();


            dataGridView1.Rows.Clear();
            string query = $"CALL BadanieU({tel});";
            MySqlCommand command1 = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                ReadBadania(dataGridView1, reader1);
            }
            reader1.Close();
        }
    }
}
