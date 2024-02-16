using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
    class MatHang
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public MatHang() { }
        public MatHang(int id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
        public MatHang(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
