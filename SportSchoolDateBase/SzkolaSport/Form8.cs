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
    public partial class Form8 : Form
    {
        DataBase d = new DataBase();
        int menu;
        string tel;
        Trener trener = new Trener();
        public Form8(string t)
        {
            InitializeComponent();
            tel = t;
        }

        private void ReadPraca(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetString(0),  record.GetString(1), (record.GetDateTime(2)).ToShortTimeString(), (record.GetDateTime(3)).ToShortTimeString());
        }

        

        private void rozkładZajęćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 1;
            label2.Text = "Rozkład zajęć";
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("sekcja", "Sekcja");
            dataGridView1.Columns.Add("dzien", "Dzień");
            dataGridView1.Columns.Add("p", "Początek");
            dataGridView1.Columns.Add("k", "Koniec");
            dataGridView1.Rows.Clear();
            string query = $"SELECT Sekcja.nazwa, Zajecia.dzien, Zajecia.poczatek, Zajecia.koniec FROM Trener INNER JOIN" +
                $" Sekcja INNER JOIN Zajecia ON (Sekcja.id = Zajecia.id_s) ON (Trener.id = Zajecia.id_t) WHERE Trener.telefon LIKE {tel};";
            MySqlCommand command = new MySqlCommand(query, trener.getConnection());
            trener.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadPraca(dataGridView1, reader);
            }
            reader.Close();
    }

        private void ReadU(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3));
        }

        private void uczniowieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu= 2;
            label2.Text = "Uczniowie";
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("imie", "Imię Nazwisko");
            dataGridView1.Columns.Add("sekcja", "Sekcja");
            dataGridView1.Columns.Add("telefon", "Telefon");
            dataGridView1.Rows.Clear();
            string query = $"CALL U();";
            MySqlCommand command = new MySqlCommand(query, trener.getConnection());
            trener.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadU(dataGridView1, reader);
            }
            reader.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            label2.Text = "";
        }

        private void ReadKonkursy(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDateTime(2), record.GetString(3), record.GetString(4));
        }

        private void listaKonkursówToolStripMenuItem_Click(object sender, EventArgs e)
        { 
                menu = 3;
                label2.Text = "Lista konkursów";
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("id", "id");
                dataGridView1.Columns.Add("nazwa", "Nazwa");
                dataGridView1.Columns.Add("data_czas", "Data i godzina");
                dataGridView1.Columns.Add("miejsce", "Miejsce");
                dataGridView1.Columns.Add("typ", "Typ");
                dataGridView1.Rows.Clear();
                string query = $"CALL K();";
                MySqlCommand command = new MySqlCommand(query, trener.getConnection());
                trener.openConnection();
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

        private void ReadResult1(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), (record.GetDateTime(2)).ToShortDateString(), record.GetString(3), record.GetString(4), record.GetString(5));
        }

        private void wynikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
                menu = 4;
                label2.Text = "Wyniki udziału w konkursach";
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("nazwa", "Nazwa");
                dataGridView1.Columns.Add("data", "Data");
                dataGridView1.Columns.Add("trener", "Trener");
                dataGridView1.Columns.Add("uczen", "Uczeń");
                dataGridView1.Columns.Add("wynik", "Wynik");
                dataGridView1.Rows.Clear();
                string query = $"CALL W();";
                MySqlCommand command = new MySqlCommand(query, trener.getConnection());
                trener.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReadResult(dataGridView1, reader);
                }
                reader.Close();
            
        }

        private void dodaćUdziałToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int idz = int.Parse(dataGridView1[0, index].Value.ToString());
            Form11 form11= new Form11(1,tel,idz);
            form11.Show();
        }

        private void edytowaćToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9(2, 1, tel);
            form9.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (menu)
            {
                case 1:
                    {
                        dataGridView1.Rows.Clear();
                        string search5 = $"SELECT Sekcja.nazwa, Zajecia.dzien, Zajecia.poczatek, Zajecia.koniec FROM Trener INNER JOIN" +
                        $" Sekcja INNER JOIN Zajecia ON (Sekcja.id = Zajecia.id_s) ON (Trener.id = Zajecia.id_t) WHERE Trener.telefon LIKE {tel} " +
                        $"AND concat(Zajecia.dzien,' ',Sekcja.nazwa) LIKE '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search5, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadPraca(dataGridView1, reader);
                        }
                        reader.Close();
                        break;
                    }
                case 2:
                    {
                        dataGridView1.Rows.Clear();
                        string search13 = $"SELECT uczniowie.id, CONCAT(uczniowie.imie,' ', uczniowie.nazwisko), " +
                        $"Sekcja.nazwa, Uczniowie.telefon FROM Sekcja INNER JOIN uczniowie ON(Sekcja.id = uczniowie.sekcja)" +
                        $"WHERE concat(uczniowie.id,' ',uczniowie.imie,' ',uczniowie.nazwisko,' ',sekcja.nazwa,' ', uczniowie.telefon) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search13, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadU(dataGridView1, reader);
                        }
                        reader.Close();
                        break;
                    }
                case 3:
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

                case 4:
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

            }
        }

        private void edytowaćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int idz = int.Parse(dataGridView1[0, index].Value.ToString());
            Form11 form11 = new Form11(2,tel,idz);
            form11.Show();
        }

        private void udiałToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 5;
            label2.Text = "Wyniki udziału w konkursach";
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Columns.Add("data", "Data");
            dataGridView1.Columns.Add("trener", "Trener");
            dataGridView1.Columns.Add("uczen", "Uczeń");
            dataGridView1.Columns.Add("wynik", "Wynik");
            dataGridView1.Rows.Clear();
            string query = $"SELECT Udzial.id, Konkursy.nazwa, Konkursy.data_czas, " +
                $"CONCAT(Trener.imie,' ', Trener.nazwisko), " +
                $"CONCAT(uczniowie.imie,' ', uczniowie.nazwisko), " +
                $"Udzial.wynik FROM uczniowie INNER JOIN Trener INNER JOIN Konkursy " +
                $"INNER JOIN Udzial ON Konkursy.id = Udzial.id_k ON Trener.id = Udzial.id_t ON uczniowie.id = Udzial.id_u " +
                $"WHERE Trener.telefon LIKE {tel};";
            MySqlCommand command = new MySqlCommand(query, trener.getConnection());
            trener.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadResult1(dataGridView1, reader);
            }
            reader.Close();
        }
    }
}
