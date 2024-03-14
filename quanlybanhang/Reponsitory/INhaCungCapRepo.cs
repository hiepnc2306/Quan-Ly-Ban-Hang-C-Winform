using quanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml.Linq;

namespace quanlybanhang.Reponsitory
{
    interface INhaCungCapRepo : IBaseRepo<NhaCungCap>
    {
        void delete(int id);
        List<NhaCungCap> searchByCode(string code);
        List<NhaCungCap> searchByName(string name);
    }
    class NhaCungCapRepo : INhaCungCapRepo
    {
        Connection connection = new Connection();

        [Obsolete]
        public void create(NhaCungCap ncc)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "insert into nha_cung_cap (supplier_code, supplier_name, address, sdt) values (@ma, @ten, @daichi, @sdt)";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@ma", ncc.Code);
                command.Parameters.Add("@ten", ncc.Name);
                command.Parameters.Add("@diachi", ncc.Address);
                command.Parameters.Add("@sdt", ncc.Sdt);
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
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "delete from nha_cung_cap where id = @id";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@id", id);
                OleDbDataReader reader = command.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        public void delete(string id)
        {
            throw new NotImplementedException();
        }

        public NhaCungCap get(int id)
        {
            throw new NotImplementedException();
        }

        public List<NhaCungCap> getAll()
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                List<NhaCungCap> list = new List<NhaCungCap>();
                String query = "select * from nha_cung_cap";
                OleDbCommand command = new OleDbCommand(query, conn);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhaCungCap nhaCungCap = new NhaCungCap(Int32.Parse(reader[0].ToString()), reader[1].ToString()
                        , reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                    list.Add(nhaCungCap);
                }
                conn.Close();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public NhaCungCap getByCode(string code)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "select * from nha_cung_cap where supplier_code = @code";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@code", code);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                NhaCungCap nhaCungCap = new NhaCungCap(Int32.Parse(reader[0].ToString()), reader[1].ToString()
                        , reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                conn.Close();
                return nhaCungCap;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<NhaCungCap> searchByCode(string code)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                List<NhaCungCap> list = new List<NhaCungCap>();
                String query = "select * from nha_cung_cap where code like concat('%', @code, '%')";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@code", code);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhaCungCap nhaCungCap = new NhaCungCap(Int32.Parse(reader[0].ToString()), reader[1].ToString()
                        , reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                    list.Add(nhaCungCap);
                }
                conn.Close();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<NhaCungCap> searchByName(string name)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                List<NhaCungCap> list = new List<NhaCungCap>();
                String query = "select * from nha_cung_cap where name like concat('%', @name, '%')";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@name", name);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhaCungCap nhaCungCap = new NhaCungCap(Int32.Parse(reader[0].ToString()), reader[1].ToString()
                        , reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                    list.Add(nhaCungCap);
                }
                conn.Close();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void update(NhaCungCap ncc)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "update nha_cung_cap set supplier_code = @ma, supplier_name = @ten, address = @daichi, sdt = @sdt where id = @id";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@ma", ncc.Code);
                command.Parameters.Add("@ten", ncc.Name);
                command.Parameters.Add("@diachi", ncc.Address);
                command.Parameters.Add("@sdt", ncc.Sdt);
                command.Parameters.Add("@id", ncc.Id);
                OleDbDataReader reader = command.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }
    }
}
