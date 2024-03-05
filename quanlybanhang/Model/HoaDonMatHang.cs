using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
    internal class HoaDonMatHang
    {
        public string code { get; set; }
        public string prodCode { get; set; }
        public int number { get; set; }
        public long price { get; set; }
        public HoaDonMatHang() { }
        public HoaDonMatHang(string code, string prodCode, int number, long price)
        {
            this.code = code;
            this.prodCode = prodCode;
            this.number = number;
            this.price = price;
        }
    }
}
