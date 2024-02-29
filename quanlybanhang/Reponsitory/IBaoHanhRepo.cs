

using quanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace quanlybanhang.Reponsitory
{
    interface IBaoHanhRepo : IBaseRepo<BaoHanh>
    {

    }
    class BaoHanhRepo : IBaoHanhRepo
    {
        Connection connection = new Connection();


        public void create(BaoHanh bh)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "insert into thong_tin_bao_hanh (warranty_code , hdb_code, created, closed, times, appointed) values (@mabh, @mahdb, @ngaybd, @ngaykt, @solan, @ngayhen)";
                using (OleDbCommand command = new OleDbCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@mabh", bh.code);
                    command.Parameters.AddWithValue("@mahdb", bh.checkCode);
                    command.Parameters.AddWithValue("@ngaybd", bh.startDate);
                    command.Parameters.AddWithValue("@ngaykt", bh.endDate);
                    command.Parameters.AddWithValue("@solan", bh.number);
                    command.Parameters.AddWithValue("@ngayhen", bh.appointmentDate);
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowsAffected} row(s) inserted.");
                };
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }


        public void delete(string id)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "delete from thong_tin_bao_hanh where warranty_code = @code";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@warranty_code", id);
                OleDbDataReader reader = command.ExecuteReader();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        public BaoHanh get(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<BaoHanh> getAll()
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                List<BaoHanh> list = new List<BaoHanh>();
                String query = "select * from thong_tin_bao_hanh";
                OleDbCommand command = new OleDbCommand(query, conn);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BaoHanh baoHanh = new BaoHanh(Int32.Parse(reader[0].ToString()), reader[1].ToString()
                        , reader[2].ToString(), DateTime.Parse(reader[3].ToString()),
                        DateTime.Parse(reader[4].ToString()), Int32.Parse(reader[5].ToString()),
                        DateTime.Parse(reader[6].ToString()));
                    list.Add(baoHanh);
                }
                conn.Close();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public BaoHanh getByCode(string code)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "select * from thong_tin_bao_hanh where warranty_code = @code";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@code", code);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                BaoHanh baoHanh = new BaoHanh(Int32.Parse(reader[0].ToString()), reader[1].ToString()
                        , reader[2].ToString(), DateTime.Parse(reader[3].ToString()),
                        DateTime.Parse(reader[4].ToString()), Int32.Parse(reader[5].ToString()),
                        DateTime.Parse(reader[6].ToString()));
                conn.Close();
                return baoHanh;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public void update(BaoHanh bh)
        {
            OleDbConnection conn = connection.conn();
            conn.Open();
            String query = "update thong_tin_bao_hanh set warranty_code = @mabh, hdb_code = @mahdb, " +
                " created = @ngaybd, closed = @ngaykt, times = @solan, appointed = @ngayhen where id = @id ";
            using (OleDbCommand command = new OleDbCommand(query, conn) ) {
                command.Parameters.AddWithValue("@mabh", bh.code);
                command.Parameters.AddWithValue("@mahdb", bh.checkCode);
                command.Parameters.AddWithValue("@ngaybd",bh.startDate);
                command.Parameters.AddWithValue("@ngaykt",bh.endDate);
                command.Parameters.AddWithValue("@solan", bh.number);
                command.Parameters.AddWithValue("@ngayhen", bh.appointmentDate);
                command.Parameters.AddWithValue("@id", bh.id);
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            };
            conn.Close();
        }
    }
}
