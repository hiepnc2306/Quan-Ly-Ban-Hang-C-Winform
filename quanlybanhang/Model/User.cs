using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
    class User
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User() { }
        public User(int id, string code)
        {
            this.Id = id;
            this.Code = code;
        }
        public User(int id, string code, string username, string password)
        {
            this.Id = id;
            this.Code = code;
            this.UserName = username;
            this.Password = password;
        }
    }
}
