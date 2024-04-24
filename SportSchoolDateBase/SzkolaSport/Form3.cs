using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Serialization;
using MySqlConnector;
using System.IO;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace SzkolaSport
{
    public partial class Form3 : Form
    {
        DataBase d = new DataBase();
        int menu = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void ReadUS(DataGridView dgv, IDataRecord record) {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2));
        }

        private void sekcjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Sekcje i uczniowie";
            menu = 8;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("uczen", "Uczeń");
            dataGridView1.Columns.Add("sekcja", "Sekcja");
            dataGridView1.Rows.Clear();
            string query = $"CALL US(); ";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadUS(dataGridView1, reader);
            }
            reader.Close();

        }
        private void ReadDzien(DataGridView dgv, IDataRecord record)
        {

            dgv.Rows.Add(record.GetString(0), record.GetString(1), (record.GetDateTime(2)).ToShortTimeString(), (record.GetDateTime(3)).ToShortTimeString());
        }

        private void poniedziałekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Rozkład zajęć na poniedziałek";
            menu = 1;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Columns.Add("trener", "Trener");
            dataGridView1.Columns.Add("p", "Początek");
            dataGridView1.Columns.Add("k", "Koniec");
            dataGridView1.Rows.Clear();
            string query = $"CALL DzienZ('Poniedzialek');";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadDzien(dataGridView1, reader);
            }
            reader.Close();
        }

        private void wtorekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Rozkład zajęć na wtorek";
            menu = 2;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Columns.Add("trener", "Trener");
            dataGridView1.Columns.Add("p", "Początek");
            dataGridView1.Columns.Add("k", "Koniec");
            dataGridView1.Rows.Clear();
            string query = $"CALL DzienZ('Wtorek');";
               
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadDzien(dataGridView1, reader);
            }
            reader.Close();
        }

        private void środaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Rozkład zajęć na środę";
            menu = 3;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Columns.Add("trener", "Trener");
            dataGridView1.Columns.Add("p", "Początek");
            dataGridView1.Columns.Add("k", "Koniec");
            dataGridView1.Rows.Clear();
            string query = $"CALL DzienZ('Sroda');";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadDzien(dataGridView1, reader);
            }
            reader.Close();
        }

        private void czwartekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Rozkład zajęć na czwartek";
            menu = 4;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Columns.Add("trener", "Trener");
            dataGridView1.Columns.Add("p", "Początek");
            dataGridView1.Columns.Add("k", "Koniec");
            dataGridView1.Rows.Clear();
            string query = $"CALL DzienZ('Czwartek');";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadDzien(dataGridView1, reader);
            }
            reader.Close();
        }

        private void piątekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Rozkład zajęć na piątek";
            menu = 5;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Columns.Add("trener", "Trener");
            dataGridView1.Columns.Add("p", "Początek");
            dataGridView1.Columns.Add("k", "Koniec");
            dataGridView1.Rows.Clear();
            string query = $"CALL DzienZ('Piatek');";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadDzien(dataGridView1, reader);
            }
            reader.Close();
        }

        private void ReadBadanie(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), (record.GetDateTime(2)).ToShortDateString());
        }

    private void badanieLekarskieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Badanie lekarskie";
            menu = 6;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("uczen", "Uczeń");
            dataGridView1.Columns.Add("data", "Data");
            dataGridView1.Rows.Clear();
            string query = $"CALL B();";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadBadanie(dataGridView1, reader);
            }
            reader.Close();
        }

        private void UU(DataGridView dgv, IDataRecord record) {
            dgv.Rows.Add(record.GetString(0), record.GetString(1), (record.GetDateTime(2)).ToShortDateString(), record.GetString(3));
        }

        private void udziałWKonkursieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Udział w konkursach uczniów";
            menu = 7;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("uczen", "Uczeń");
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Columns.Add("data", "Data");
            dataGridView1.Columns.Add("wynik", "Wynik");
            dataGridView1.Rows.Clear();
            string query = $"CALL UU();";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UU(dataGridView1, reader);
            }
            reader.Close();
        }

        private void ReadPraca(DataGridView dgv, IDataRecord record) {
            dgv.Rows.Add(record.GetString(0), record.GetString(1), record.GetString(2), (record.GetDateTime(3)).ToShortTimeString(), (record.GetDateTime(4)).ToShortTimeString());
        }

        private void godzinyPracyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Godziny pracy trenerów";
            menu = 9;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("trener", "Trener");
            dataGridView1.Columns.Add("sekcja", "Sekcja");
            dataGridView1.Columns.Add("dzien", "Dzień");
            dataGridView1.Columns.Add("p", "Początek");
            dataGridView1.Columns.Add("k", "Koniec");
            dataGridView1.Rows.Clear();
            string query = $"SELECT CONCAT(trener.imie,' ', trener.nazwisko),Sekcja.nazwa," +
                $" Zajecia.dzien, Zajecia.poczatek, Zajecia.koniec FROM Trener INNER JOIN" +
                $" Sekcja INNER JOIN Zajecia ON (Sekcja.id = Zajecia.id_s) ON (Trener.id = Zajecia.id_t);";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadPraca(dataGridView1, reader);
            }
            reader.Close();
        }

        private void udziałWKonkursachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Udział w konkursach trenerów";
            menu = 10;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("uczen", "Trener");
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Columns.Add("data", "Data");
            dataGridView1.Columns.Add("wynik", "Wynik");
            dataGridView1.Rows.Clear();
            string query = $"CALL UT();";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UU(dataGridView1, reader);
            }
            reader.Close();
        }

        private void wyjścieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReadSekcja(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1));
        }

        private void ReadKonkursy(DataGridView dgv, IDataRecord record) {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDateTime(2), record.GetString(3), record.GetString(4));
        }
        private void listaKonkursówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Lista konkursów";
            DostupKonkursy();
            ZapretSekcja();
            ZapretT();
            ZapretU();
            ZapretZajecia();
            menu = 12;
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

        private void ReadResult(DataGridView dgv, IDataRecord record) {
            dgv.Rows.Add(record.GetString(0), (record.GetDateTime(1)).ToShortDateString(), record.GetString(2), record.GetString(3), record.GetString(4));
        }

        private void rezultatyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZapretKonkursy();
            ZapretSekcja();
            ZapretT();
            ZapretU();
            ZapretZajecia();
            label2.Text = "Wyniki udziału w konkursach";
            menu = 13;
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

        private void usunąćToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int idz = int.Parse(dataGridView1[0, index].Value.ToString());
            string delete = $"call deleteU({idz});";
            MySqlCommand command = new MySqlCommand(delete, d.getConnection());
            d.openConnection();
            command.ExecuteNonQuery();
            dataGridView1.Rows.Clear();
            string query = $"CALL U();";
            MySqlCommand command1 = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                ReadU(dataGridView1, reader);
            }
            reader.Close();
        }

        private void edytowaćToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dodaćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int idz = int.Parse(dataGridView1[0, index].Value.ToString());
            Form4 f4 = new Form4(1,idz);
            f4.Show();
        }

        private void listaSekcjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Sekcje";
            ZapretKonkursy();
            DostupSekcja();
            ZapretT();
            ZapretU();
            ZapretZajecia();
            menu = 11;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Rows.Clear();
            string query = $"call S();";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSekcja(dataGridView1, reader);
            }
            reader.Close();
        }

        //wyszukiwanie----------------------------------------------------------------------------------------------------------
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            switch (menu) {
                case 1: {
                        dataGridView1.Rows.Clear();
                        string search1 = $"SELECT Sekcja.nazwa, CONCAT(Trener.imie,' ', Trener.nazwisko), " +
                        $"Zajecia.poczatek, Zajecia.koniec FROM Trener INNER JOIN Sekcja INNER JOIN " +
                        $"Zajecia ON Sekcja.id = Zajecia.id_s ON Trener.id = Zajecia.id_t " +
                        $"WHERE Zajecia.dzien = 'Poniedzialek' AND concat(Sekcja.nazwa,' ',Trener.imie,' '," +
                        $"Trener.nazwisko) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search1, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadDzien(dataGridView1, reader);
                        }
                        reader.Close();
                        break; }
                case 2: {
                        dataGridView1.Rows.Clear();
                        string search2 = $"SELECT Sekcja.nazwa, CONCAT(Trener.imie,' ', Trener.nazwisko), " +
                       $"Zajecia.poczatek, Zajecia.koniec FROM Trener INNER JOIN Sekcja INNER JOIN " +
                       $"Zajecia ON Sekcja.id = Zajecia.id_s ON Trener.id = Zajecia.id_t " +
                       $"WHERE Zajecia.dzien = 'Wtorek' AND concat(Sekcja.nazwa,' ',Trener.imie,' '," +
                       $"Trener.nazwisko) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search2, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadDzien(dataGridView1, reader);
                        }
                        reader.Close();
                        break; }
                case 3: {
                        dataGridView1.Rows.Clear();
                        string search3 = $"SELECT Sekcja.nazwa, CONCAT(Trener.imie,' ', Trener.nazwisko), " +
                       $"Zajecia.poczatek, Zajecia.koniec FROM Trener INNER JOIN Sekcja INNER JOIN " +
                       $"Zajecia ON Sekcja.id = Zajecia.id_s ON Trener.id = Zajecia.id_t " +
                       $"WHERE Zajecia.dzien = 'Sroda' AND concat(Sekcja.nazwa,' ',Trener.imie,' '," +
                       $"Trener.nazwisko) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search3, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadDzien(dataGridView1, reader);
                        }
                        reader.Close();
                        break; }
                case 4: {
                        dataGridView1.Rows.Clear();
                        string search4 = $"SELECT Sekcja.nazwa, CONCAT(Trener.imie,' ', Trener.nazwisko), " +
                       $"Zajecia.poczatek, Zajecia.koniec FROM Trener INNER JOIN Sekcja INNER JOIN " +
                       $"Zajecia ON Sekcja.id = Zajecia.id_s ON Trener.id = Zajecia.id_t " +
                       $"WHERE Zajecia.dzien = 'Czwartek' AND concat(Sekcja.nazwa,' ',Trener.imie,' '," +
                       $"Trener.nazwisko) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search4, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadDzien(dataGridView1, reader);
                        }
                        reader.Close();
                        break; }
                case 5: {
                        dataGridView1.Rows.Clear();
                        string search5 = $"SELECT Sekcja.nazwa, CONCAT(Trener.imie,' ', Trener.nazwisko), " +
                       $"Zajecia.poczatek, Zajecia.koniec FROM Trener INNER JOIN Sekcja INNER JOIN " +
                       $"Zajecia ON Sekcja.id = Zajecia.id_s ON Trener.id = Zajecia.id_t " +
                       $"WHERE Zajecia.dzien = 'Piatek' AND concat(Sekcja.nazwa,' ',Trener.imie,' '," +
                       $"Trener.nazwisko) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search5, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadDzien(dataGridView1, reader);
                        }
                        reader.Close();
                        break; }
                case 6: {
                        dataGridView1.Rows.Clear();
                        string search6 = $"SELECT Badanie.id, CONCAT(Uczniowie.imie,' ', Uczniowie.nazwisko), Badanie.data " +
                        $"FROM Uczniowie INNER JOIN Badanie ON Uczniowie.id = Badanie.uczen WHERE concat(Badanie.id,' ',Uczniowie.imie," +
                        $"' ',Uczniowie.nazwisko,' ',Badanie.data) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search6, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadBadanie(dataGridView1, reader);
                        }
                        reader.Close();
                        break; }
                case 7: {
                        dataGridView1.Rows.Clear();
                        string search7 = $"SELECT CONCAT(uczniowie.imie,' ', uczniowie.nazwisko), Konkursy.nazwa, " +
                        $"Konkursy.data_czas, Udzial.wynik FROM Uczniowie INNER JOIN Konkursy " +
                        $"INNER JOIN Udzial ON (Konkursy.id = Udzial.id_k) ON (Uczniowie.id = Udzial.id_u) " +
                        $"WHERE concat(uczniowie.imie,' ',uczniowie.nazwisko,' ',konkursy.nazwa,' ',konkursy.data_czas,' ', udzial.wynik) like '%"+textBox1.Text+"%';";
                        MySqlCommand command = new MySqlCommand(search7, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            UU(dataGridView1, reader);
                        }
                        reader.Close();
                        break; }
                case 8: {
                        dataGridView1.Rows.Clear();
                        string search8 = $"SELECT uczniowie.id, CONCAT(uczniowie.imie,' ', uczniowie.nazwisko), " +
                        $"Sekcja.nazwa FROM Sekcja INNER JOIN uczniowie ON(Sekcja.id = uczniowie.sekcja)" +
                        $"WHERE concat(uczniowie.id,' ',uczniowie.imie,' ',uczniowie.nazwisko,' ',sekcja.nazwa) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search8, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadUS(dataGridView1, reader);
                        }
                        reader.Close();
                        break; }
                case 9: {
                        dataGridView1.Rows.Clear();
                        string search9 = $"SELECT CONCAT(trener.imie,' ', trener.nazwisko),Sekcja.nazwa," +
                        $" Zajecia.dzien, Zajecia.poczatek, Zajecia.koniec FROM Trener INNER JOIN" +
                        $" Sekcja INNER JOIN Zajecia ON (Sekcja.id = Zajecia.id_s) ON (Trener.id = Zajecia.id_t)" +
                        $" WHERE concat (trener.imie, ' ', trener.nazwisko,' ', sekcja.nazwa,' ', zajecia.dzien) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search9, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadPraca(dataGridView1, reader);
                        }
                        reader.Close();
                        break; }
                case 10:
                    {
                        dataGridView1.Rows.Clear();
                        string search10 = $"SELECT CONCAT(trener.imie,' ', trener.nazwisko), Konkursy.nazwa, " +
                        $"Konkursy.data_czas, Udzial.wynik FROM Trener INNER JOIN Konkursy " +
                        $"INNER JOIN Udzial ON (Konkursy.id = Udzial.id_k) ON (Trener.id = Udzial.id_t) " +
                        $"WHERE concat(trener.imie,' ',trener.nazwisko,' ',konkursy.nazwa,' ',konkursy.data_czas,' ', udzial.wynik) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search10, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            UU(dataGridView1, reader);
                        }
                        reader.Close();
                        break;
                    }
                case 11:
                    {
                        dataGridView1.Rows.Clear();
                        string search11 = $"select * from sekcja where concat(id,' ', nazwa) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search11, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadSekcja(dataGridView1, reader);
                        }
                        reader.Close();
                        break;
                    }
                case 12:
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
                case 13:
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
                case 14:
                    {
                        dataGridView1.Rows.Clear();
                        string search14 = $"SELECT Zajecia.id, Sekcja.nazwa, CONCAT(Trener.imie,' ', Trener.nazwisko), Zajecia.dzien," +
                       $"Zajecia.poczatek, Zajecia.koniec FROM Trener INNER JOIN Sekcja INNER JOIN " +
                       $"Zajecia ON Sekcja.id = Zajecia.id_s ON Trener.id = Zajecia.id_t " +
                       $"WHERE concat(Zajecia.id, Sekcja.nazwa,' ',Trener.imie,' '," +
                       $"Trener.nazwisko,' ',Zajecia.dzien) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search14, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadZaj(dataGridView1, reader);
                        }
                        reader.Close();
                        break;
                    }
                case 15:
                    {
                        dataGridView1.Rows.Clear();
                        string search15 = $"SELECT id, imie, nazwisko, telefon, data_urodz FROM Uczniowie " +
                            $"WHERE concat(id,' ',imie,' ',nazwisko,' ',telefon,' ',data_urodz) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search15, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadU(dataGridView1, reader);
                        }
                        reader.Close();
                        break;
                    }
                case 16:
                    {
                        dataGridView1.Rows.Clear();
                        string search16 = $"SELECT id, imie, nazwisko, telefon FROM Trener " +
                         $"WHERE concat(id,' ',imie,' ',nazwisko,' ',telefon) like '%" + textBox1.Text + "%';";
                        MySqlCommand command = new MySqlCommand(search16, d.getConnection());
                        d.openConnection();
                        MySqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            ReadT(dataGridView1, reader);
                        }
                        reader.Close();
                        break;
                    }


            }
        }

        private void usunąćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int idz = int.Parse(dataGridView1[0,index].Value.ToString());
            string delete = $"CALL deleteZ({idz});";
            
            MySqlCommand command = new MySqlCommand(delete, d.getConnection());
            d.openConnection();
            command.ExecuteNonQuery();
            dataGridView1.Rows.Clear();
            string query = $"CALL Rozklad();";
            MySqlCommand command1 = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                ReadZaj(dataGridView1, reader1);
            }
            reader1.Close();

        }
        private void ReadZaj(DataGridView dgv, IDataRecord record) {
            dgv.Rows.Add(record.GetInt32(0),record.GetString(1), record.GetString(2), record.GetString(3), (record.GetDateTime(4)).ToShortTimeString(), (record.GetDateTime(5)).ToShortTimeString());
        }

        private void listaZajęćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Rozkład zajęć";
            ZapretKonkursy();
            ZapretSekcja();
            ZapretT();
            ZapretU();
            DostupZajecia();
            menu = 14;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("nazwa", "Nazwa");
            dataGridView1.Columns.Add("trener", "Trener");
            dataGridView1.Columns.Add("dzien", "Dzień");
            dataGridView1.Columns.Add("p", "Początek");
            dataGridView1.Columns.Add("k", "Koniec");
            dataGridView1.Rows.Clear();
            string query = $"CALL Rozklad();";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadZaj(dataGridView1, reader);
            }
            reader.Close();
        }

        private void edytowaćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int idz = int.Parse(dataGridView1[0, index].Value.ToString());
            Form4 f4 = new Form4(2, idz);
            f4.Show();

        }

        private void ReadU(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2),record.GetString(3),(record.GetDateTime(4)).ToShortDateString());
        }
        private void ReadT(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2),record.GetString(3));
        }

        private void listaUczniowieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Lista uczniowie";
            ZapretKonkursy();
            ZapretSekcja();
            ZapretT();
            DostupU();
            ZapretZajecia();
            menu = 15;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("imie", "Imię");
            dataGridView1.Columns.Add("nazwisko", "Nazwisko");
            dataGridView1.Columns.Add("telefon", "Telefon");
            dataGridView1.Columns.Add("d", "Data urodzenia");
            dataGridView1.Rows.Clear();
            string query = $"CALL U();";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadU(dataGridView1, reader);
            }
            reader.Close();
        }

        private void listaTrenerówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Text = "Lista trenerów";
            ZapretKonkursy();
            ZapretSekcja();
            DostupT();
            ZapretU();
            ZapretZajecia();
            menu = 16;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("imie", "Imię");
            dataGridView1.Columns.Add("nazwisko", "Nazwisko");
            dataGridView1.Columns.Add("telefon", "Telefon");
            dataGridView1.Rows.Clear();
            string query = $"CALL T();";
            MySqlCommand command = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadT(dataGridView1, reader);
            }
            reader.Close();
        }

        private void ZapretZajecia() { 
        dodaćToolStripMenuItem.Enabled = false;
        edytowaćToolStripMenuItem.Enabled = false;
        usunąćToolStripMenuItem.Enabled = false;
        }

        private void DostupZajecia() {
        dodaćToolStripMenuItem.Enabled = true;
        edytowaćToolStripMenuItem.Enabled = true;
        usunąćToolStripMenuItem.Enabled = true;
        }

        private void ZapretU() { 
        usunąćToolStripMenuItem1.Enabled = false;
        }
        private void DostupU()
        {
        usunąćToolStripMenuItem1.Enabled = true;
        }

        private void ZapretT() {
            edytowaćToolStripMenuItem2.Enabled = false;
        }
        private void DostupT()
        {
            edytowaćToolStripMenuItem2.Enabled = true;
        }

        private void ZapretSekcja()
        {
            dodaćToolStripMenuItem1.Enabled = false; 
            usunąćToolStripMenuItem2.Enabled = false;
        }
        private void DostupSekcja()
        {
            dodaćToolStripMenuItem1.Enabled = true;
            usunąćToolStripMenuItem2.Enabled = true;
        }
        private void ZapretKonkursy()
        {
            dodaćToolStripMenuItem2.Enabled = false;
            edytowaćToolStripMenuItem3.Enabled = false;
            usunąćToolStripMenuItem3.Enabled = false;
        }
        private void DostupKonkursy()
        {
            dodaćToolStripMenuItem2.Enabled = true;
            edytowaćToolStripMenuItem3.Enabled = true;
            usunąćToolStripMenuItem3.Enabled = true;
        }
        

        private void Form3_Load(object sender, EventArgs e)
        {
            ZapretKonkursy();
            ZapretSekcja();
            ZapretT();
            ZapretU();
            ZapretZajecia();
            label2.Text = "";

        }

        private void edytowaćToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int idz = int.Parse(dataGridView1[0, index].Value.ToString());
            string delete = $"call deleteT({idz});";
            MySqlCommand command = new MySqlCommand(delete, d.getConnection());
            d.openConnection();
            command.ExecuteNonQuery();
            dataGridView1.Rows.Clear();
            string query = $"CALL T();";
            MySqlCommand command1 = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                ReadT(dataGridView1, reader);
            }
            reader.Close();
        }

        private void usunąćToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int idz = int.Parse(dataGridView1[0, index].Value.ToString());
            string delete = $"call deleteK({idz});"; 
            MySqlCommand command = new MySqlCommand(delete, d.getConnection());
            d.openConnection();
            command.ExecuteNonQuery();
            for (int i = 0; i < dataGridView1.RowCount-1; i++) { 
            int j = int.Parse(dataGridView1[0, i].Value.ToString()); 
                if (j == idz) { 
                    MessageBox.Show("Nie możesz usunąć konkursu, w którym są już wyniki!");
                }
            }
            dataGridView1.Rows.Clear();
            string query = $"CALL K();";
            MySqlCommand command1 = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                ReadKonkursy(dataGridView1, reader);
            }
            reader.Close();

        }

        private void usunąćToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int idz = int.Parse(dataGridView1[0, index].Value.ToString());
            string delete = $"call deleteS({idz});";
            MySqlCommand command = new MySqlCommand(delete, d.getConnection());
            d.openConnection();
            command.ExecuteNonQuery();
            for (int i = 0; i < dataGridView1.RowCount-1; i++) { 
            int j = int.Parse(dataGridView1[0, i].Value.ToString());
              if (j == idz) {
            MessageBox.Show("Nie możesz usunąć sekcji, w jakiej są zajęcia lub do której zapisane uczniowie!");
            }
            }
            dataGridView1.Rows.Clear();
            string query = $"CALL S();";
            MySqlCommand command1 = new MySqlCommand(query, d.getConnection());
            d.openConnection();
            MySqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                ReadSekcja(dataGridView1, reader);
            }
            reader.Close();
        }

        private void dodaćToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void dodaćToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }
    }
}
