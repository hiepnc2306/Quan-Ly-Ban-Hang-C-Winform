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
    internal interface IKhachHangRepo : IBaseRepo<KhachHang>
    {
        void delete(int id);
    }

    class KhachHangRepo : IKhachHangRepo
    {
        Connection connection = new Connection();
        public void create(KhachHang khachHang)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "insert into khach_hang (customer_code, customer_name, address, sdt) values (@ma, @ten, @daichi, @sdt)";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@ma", khachHang.code);
                command.Parameters.Add("@ten", khachHang.name);
                command.Parameters.Add("@diachi", khachHang.address);
                command.Parameters.Add("@sdt", khachHang.phoneNumber);
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
                String query = "delete from khach_hang where id = @id";
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

        public KhachHang get(int id)
        {
            throw new NotImplementedException();
        }

        public List<KhachHang> getAll()
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                List<KhachHang> list = new List<KhachHang>();
                String query = "select * from khach_hang";
                OleDbCommand command = new OleDbCommand(query, conn);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    KhachHang khach = new KhachHang(Int32.Parse(reader[0].ToString()), reader[1].ToString()
                        , reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                    list.Add(khach);
                }
                conn.Close();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public KhachHang getByCode(string code)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "select * from khach_hang where customer_code = @code";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@code", code);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                KhachHang kh = new KhachHang(Int32.Parse(reader[0].ToString()), reader[1].ToString()
                        , reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                conn.Close();
                return kh;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void update(KhachHang khachHang)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "update khach_hang set customer_code = @ma, customer_name = @ten, address = @daichi, sdt = @sdt where id = @id";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@ma", khachHang.code);
                command.Parameters.Add("@ten", khachHang.name);
                command.Parameters.Add("@diachi", khachHang.address);
                command.Parameters.Add("@sdt", khachHang.phoneNumber);
                command.Parameters.Add("@id", khachHang.id);
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
