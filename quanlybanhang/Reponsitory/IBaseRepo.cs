using quanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlybanhang.Reponsitory
{
    internal interface IBaseRepo<Obj>
    {
        void createOrUpdate(String query);
        void delete(int id);
        OleDbDataReader get(String query, OleDbConnection conn);
    }

    class BaseRepo<Obj> : IBaseRepo<Obj>
    {
        Connection connection = new Connection();
        public void createOrUpdate(String query)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                //String query = "insert into nha_cung_cap (code, name, address, sdt) values (?, ?, ?, ?)";
                OleDbCommand command = new OleDbCommand(query, conn);
                OleDbDataReader reader = command.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public OleDbDataReader get(string query, OleDbConnection conn)
        {
            try
            {
                //OleDbConnection conn = connection.conn();
                //conn.Open();
                //List<NhaCungCap> list = new List<NhaCungCap>();
                //String query = "select * from nha_cung_cap";
                OleDbCommand command = new OleDbCommand(query, conn);
                OleDbDataReader reader = command.ExecuteReader();
                //while (reader.Read())
                //{
                //    NhaCungCap nhaCungCap = new NhaCungCap(Int32.Parse(reader[0].ToString()), reader[1].ToString()
                //        , reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                //    list.Add(nhaCungCap);
                //}
                //conn.Close();
                return reader;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
