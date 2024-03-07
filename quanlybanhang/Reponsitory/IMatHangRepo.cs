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
    internal interface IMatHangRepo : IBaseRepo<MatHang>
    {
        void delete(int id);
    }
    class MatHangRepo : IMatHangRepo
    {
        Connection connection = new Connection();

        [Obsolete]
        public void create(MatHang mh)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "insert into mat_hang (product_code, product_name, sale_price, purchase_price) values (@ma, @ten, @sale, @purchase)";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@ma", mh.Code);
                command.Parameters.Add("@ten", mh.Name);
                command.Parameters.Add("@sale", mh.SalePrice);
                command.Parameters.Add("@purchase", mh.PurchasePrice);
                OleDbDataReader reader = command.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        [Obsolete]
        public void delete(int id)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "delete from mat_hang where id = @id";
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

        public MatHang get(int id)
        {
            throw new NotImplementedException();
        }

        public List<MatHang> getAll()
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                List<MatHang> list = new List<MatHang>();
                String query = "select * from mat_hang";
                OleDbCommand command = new OleDbCommand(query, conn);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MatHang matHang = new MatHang(Int32.Parse(reader[0].ToString()), reader[1].ToString()
                        , reader[2].ToString(), Int64.Parse(reader[3].ToString()), Int64.Parse(reader[4].ToString()));
                    list.Add(matHang);
                }
                conn.Close();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public MatHang getByCode(string code)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "select * from mat_hang where product_code = @code";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@code", code);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                MatHang matHang = new MatHang(Int32.Parse(reader[0].ToString()), reader[1].ToString()
                        , reader[2].ToString(), Int64.Parse(reader[3].ToString()), Int64.Parse(reader[4].ToString()));
                conn.Close();
                return matHang;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [Obsolete]
        public void update(MatHang mh)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "update mat_hang set product_code = @ma, product_name = @ten " +
                    " sale_price = @sale, purchase_price = @purchase where id = @id";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@ma", mh.Code);
                command.Parameters.Add("@ten", mh.Name);
                command.Parameters.Add("@id", mh.Id);
                command.Parameters.Add("@sale", mh.SalePrice);
                command.Parameters.Add("@purchase", mh.PurchasePrice);
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
