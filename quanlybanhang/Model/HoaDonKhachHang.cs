using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
    internal class HoaDonKhachHang
    {
        public string code { get; set; }
        public string cusCode { get; set; }
        public DateTime saleDate { get; set; }
        public HoaDonKhachHang() { }
        public HoaDonKhachHang(string code, string cusCode, DateTime saleDate)
        {
            this.code = code;
            this.cusCode = cusCode;
            this.saleDate = saleDate;
        }
    }
}
