using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
     class NhaCungCap
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Sdt { get; set; }
        public NhaCungCap() { }
        public NhaCungCap(int id, string code, string name, string address, string sdt)
        {
            Id = id;
            Code = code;
            Name = name;    
            Address = address;
            Sdt = sdt;
        }
        public NhaCungCap(string code, string name, string address, string sdt)
        {
            Code= code;
            Name = name;
            Address = address;
            Sdt = sdt;
        }

    }
}
