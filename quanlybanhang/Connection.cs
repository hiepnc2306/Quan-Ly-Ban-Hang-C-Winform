using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlybanhang
{
    class Connection
    {
        String DBPath = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=D:\AccessDB\quan_ly_ban_hang.mdb;" +
                @"User Id=;Password=;";
        public Connection()
        {
            
        }

        public OleDbConnection conn()
        {
            return new OleDbConnection(DBPath);
        }

        public void connect(OleDbConnection cnn)
        {
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void disConnect(OleDbConnection cnn)
        {
            try
            {
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot close connection!");
            }
        }
    }
}
