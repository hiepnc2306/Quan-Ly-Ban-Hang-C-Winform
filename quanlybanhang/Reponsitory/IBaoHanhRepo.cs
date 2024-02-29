

using quanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace quanlybanhang.Reponsitory
{
    interface IBaoHanhRepo
    {
        void create(BaoHanh bh);
        void update(BaoHanh bh);
        void delete(string id);
        List<BaoHanh> getAll();
        BaoHanh get(int id);
        BaoHanh getByCode(string code);
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
                String query = "insert into thong_tin_bao_hanh (warranty_code , check_code, created, closed, times, appointed) values (@mabh, @mahdb, @ngaybd, @ngaykt, @solan, @ngayhen)";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@mabh", bh.code);
                command.Parameters.Add("@mahdb", bh.checkCode);
                command.Parameters.Add("@ngaybd", bh.startDate.ToString("MM/dd/yyyy"));
                command.Parameters.Add("@ngaykt", bh.endDate.ToString("MM/dd/yyyy"));
                command.Parameters.Add("@solan", bh.number);
                command.Parameters.Add("@ngayhen", bh.appointmentDate.ToString("MM/dd/yyyy"));
                OleDbDataReader reader = command.ExecuteReader();
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
            String mabh = bh.code;
            String mahdb = bh.checkCode;
            DateTime ngaybd = bh.startDate;
            DateTime ngaykt = bh.endDate;
            int solan = bh.number;
            DateTime ngayhen = bh.appointmentDate;
            int id = bh.id;
            String query = $"update mat_hang set warranty_code = {mabh},check_code = {mahdb}, " +
                "created = #{ngaybd}#, closed = #{ngaykt}#, times = #{solan}#, appointed = #{ngayhen}# where id = #{id}# ";
            OleDbCommand command = new OleDbCommand(query, conn);
            OleDbDataReader reader = command.ExecuteReader();
            conn.Close();
        }
    }
}
