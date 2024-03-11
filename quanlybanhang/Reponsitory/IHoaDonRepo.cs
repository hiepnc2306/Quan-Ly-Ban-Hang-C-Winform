using quanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Reponsitory
{
    internal interface IHoaDonRepo : IBaseRepo<HoaDon>
    {
        List<HoaDon> getByType(string type);
        HoaDon getByCodeAndType(string code, string type);
        List<HoaDon> getByTypeAndLinkCode(string type, string linkCode);
        List<HoaDon> getByTypeAndProdCode(string type, string prodCode);
        List<HoaDon> getByTypeAndProdCodeAndLinkCode(string type, string prodCode, string linkCode);

    }

    class HoaDonRepo : IHoaDonRepo
    {
        Connection connection = new Connection();
        public void create(HoaDon o)
        {
            OleDbConnection conn = connection.conn();
            conn.Open();
            String query = "insert into hoa_don (code , link_code, product_code, quantity, price, date, type) " +
                " values (@ma, @malink, @masp, @soluong, @gia, @ngay, @loai)";
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                command.Parameters.AddWithValue("@ma", o.code);
                command.Parameters.AddWithValue("@malink", o.linkCode);
                command.Parameters.AddWithValue("@masp", o.prodCode);
                command.Parameters.AddWithValue("@soluong", o.number);
                command.Parameters.AddWithValue("@gia", o.price);
                command.Parameters.AddWithValue("@ngay", o.date);
                command.Parameters.AddWithValue("@loai", o.type);
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            };
            conn.Close();
        }

        public void delete(string id)
        {
            OleDbConnection conn = connection.conn();
            conn.Open();
            String query = "delete from hoa_don where code = @code";
            OleDbCommand command = new OleDbCommand(query, conn);
            command.Parameters.Add("@warranty_code", id);
            OleDbDataReader reader = command.ExecuteReader();
            conn.Close();
        }

        public HoaDon get(int id)
        {
            throw new NotImplementedException();
        }

        public List<HoaDon> getAll()
        {
            OleDbConnection conn = connection.conn();
            conn.Open();
            List<HoaDon> list = new List<HoaDon>();
            String query = "select * from hoa_don";
            OleDbCommand command = new OleDbCommand(query, conn);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                HoaDon hoaDon = new HoaDon(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()
                    , reader[3].ToString(), Int32.Parse(reader[4].ToString()),
                    Int64.Parse(reader[5].ToString()), DateTime.Parse(reader[6].ToString()),
                    reader[7].ToString());
                list.Add(hoaDon);
            }
            conn.Close();
            return list;
        }

        public HoaDon getByCode(string code)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "select * from hoa_don where code = @code";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@code", code);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                HoaDon hoaDon = new HoaDon(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()
                        , reader[3].ToString(), Int32.Parse(reader[4].ToString()),
                        Int64.Parse(reader[5].ToString()), DateTime.Parse(reader[6].ToString()),
                        reader[7].ToString());
                conn.Close();
                return hoaDon;
            } catch(Exception ex) { return null; }
            
        }

        public HoaDon getByCodeAndType(string code, string type)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "select * from hoa_don where code = @code and type = @type";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@code", code);
                command.Parameters.Add("@type", type);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                HoaDon hoaDon = new HoaDon(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()
                        , reader[3].ToString(), Int32.Parse(reader[4].ToString()),
                        Int64.Parse(reader[5].ToString()), DateTime.Parse(reader[6].ToString()),
                        reader[7].ToString());
                conn.Close();
                return hoaDon;
            } catch(Exception ex) { return null; }
            
        }

        public List<HoaDon> getByType(string type)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                List<HoaDon> list = new List<HoaDon>();
                String query = "select * from hoa_don where type = @type";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@type", type);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hoaDon = new HoaDon(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()
                        , reader[3].ToString(), Int32.Parse(reader[4].ToString()),
                        Int64.Parse(reader[5].ToString()), DateTime.Parse(reader[6].ToString()),
                        reader[7].ToString());
                    list.Add(hoaDon);
                }
                conn.Close();
                return list;
            } catch(Exception ex) { return null; }
            
        }

        public List<HoaDon> getByTypeAndLinkCode(string type, string linkCode)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                List<HoaDon> list = new List<HoaDon>();
                String query = "select * from hoa_don where type = @type and link_code = @link";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@type", type);
                command.Parameters.Add("@link", linkCode);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hoaDon = new HoaDon(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()
                        , reader[3].ToString(), Int32.Parse(reader[4].ToString()),
                        Int64.Parse(reader[5].ToString()), DateTime.Parse(reader[6].ToString()),
                        reader[7].ToString());
                    list.Add(hoaDon);
                }
                conn.Close();
                return list;
            }
            catch (Exception ex) { return null; }
        }

        public List<HoaDon> getByTypeAndProdCode(string type, string prodCode)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                List<HoaDon> list = new List<HoaDon>();
                String query = "select * from hoa_don where type = @type and product_code = @prod";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@type", type);
                command.Parameters.Add("@prod", prodCode);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hoaDon = new HoaDon(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()
                        , reader[3].ToString(), Int32.Parse(reader[4].ToString()),
                        Int64.Parse(reader[5].ToString()), DateTime.Parse(reader[6].ToString()),
                        reader[7].ToString());
                    list.Add(hoaDon);
                }
                conn.Close();
                return list;
            }
            catch (Exception ex) { return null; }
        }

        public List<HoaDon> getByTypeAndProdCodeAndLinkCode(string type, string prodCode, string linkCode)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                List<HoaDon> list = new List<HoaDon>();
                String query = "select * from hoa_don where type = @type and product_code = @prod and link_code = @link";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@type", type);
                command.Parameters.Add("@prod", prodCode);
                command.Parameters.Add("@link", linkCode);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    HoaDon hoaDon = new HoaDon(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()
                        , reader[3].ToString(), Int32.Parse(reader[4].ToString()),
                        Int64.Parse(reader[5].ToString()), DateTime.Parse(reader[6].ToString()),
                        reader[7].ToString());
                    list.Add(hoaDon);
                }
                conn.Close();
                return list;
            }
            catch (Exception ex) { return null; }
        }

        public void update(HoaDon o)
        {
            OleDbConnection conn = connection.conn();
            conn.Open();
            String query = "update hoa_don set code = @ma, link_code = @malink, " +
                " product_code = @masp, quantity = @soluong, price = @gia, " +
                "date = @ngay, type = @type where id = @id ";
            using (OleDbCommand command = new OleDbCommand(query, conn))
            {
                command.Parameters.AddWithValue("@ma", o.code);
                command.Parameters.AddWithValue("@malink", o.linkCode);
                command.Parameters.AddWithValue("@masp", o.prodCode);
                command.Parameters.AddWithValue("@soluong", o.number);
                command.Parameters.AddWithValue("@gia", o.price);
                command.Parameters.AddWithValue("@ngay", o.date);
                command.Parameters.AddWithValue("@loai", o.type);
                command.Parameters.AddWithValue("@id", o.id);
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
            };
            conn.Close();
        }
    }
}
