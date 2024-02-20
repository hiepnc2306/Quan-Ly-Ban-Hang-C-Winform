﻿using quanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlybanhang.Reponsitory
{
    internal interface IMatHangRepo
    {
        void create(MatHang mh);
        void update(MatHang mh);
        void delete(int id);
        List<MatHang> getAll();
        MatHang get(int id);
        MatHang getByCode(String code);
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
                String query = "insert into mat_hang (product_code, product_name) values (@ma, @ten)";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@ma", mh.Code);
                command.Parameters.Add("@ten", mh.Name);
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
                        , reader[2].ToString());
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
                        , reader[2].ToString());
                conn.Close();
                return matHang;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void update(MatHang mh)
        {
            try
            {
                OleDbConnection conn = connection.conn();
                conn.Open();
                String query = "update mat_hang set product_code = @ma, product_name = @ten where id = @id";
                OleDbCommand command = new OleDbCommand(query, conn);
                command.Parameters.Add("@ma", mh.Code);
                command.Parameters.Add("@ten", mh.Name);
                command.Parameters.Add("@id", mh.Id);
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