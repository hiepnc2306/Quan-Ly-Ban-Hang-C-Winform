using quanlybanhang.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Reponsitory
{
    interface IUserRepo
    {
        User checkLogin(string username, string password, OleDbConnection con);
        UserInfo getInfomation(string code);
    }
    class UserRepo : IUserRepo
    {
        Connection connection = new Connection();

        public User checkLogin(string username, string password, OleDbConnection con)
        {
            String query = "select * from tbl_user where user_name = ? and password = ?";
            OleDbCommand command = new OleDbCommand(query, con);
            try
            {
                command.Parameters.Add("@p1", username);
                command.Parameters.Add("@p2", password);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                return new User(Int32.Parse(reader[0].ToString()), reader[1].ToString());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        UserInfo IUserRepo.getInfomation(string code)
        {
            throw new NotImplementedException();
        }
    }
}
