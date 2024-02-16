using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang
{
    class KhachHang
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }

        public KhachHang()
        {

        }
        public KhachHang(string code, string name, string address, string phoneNumber)
        {
            this.code= code;
            this.name= name;
            this.address= address;
            this.phoneNumber= phoneNumber;
        }
        public KhachHang(int id, string code, string name, string address, string phoneNumber)
        {
            this.id= id;
            this.code = code;
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }
    }
}
