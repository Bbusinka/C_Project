using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace SzkolaSport
{
    internal class DataBase
    {
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1; port=3306;uid=admin;pwd=admin;database=sport_school");

        public void openConnection() {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void closeConnection() {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }

        }

        public MySqlConnection getConnection() { 
            return conn;
        }
        
    }
}
