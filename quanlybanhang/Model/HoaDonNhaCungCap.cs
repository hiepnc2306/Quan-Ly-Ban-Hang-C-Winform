using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
    internal class HoaDonNhaCungCap
    {
        public string code { get; set; }
        public string nccCode { get; set; }
        public DateTime purchaseDate { get; set; }
        public HoaDonNhaCungCap() { }
        public HoaDonNhaCungCap(string code, string nccCode, DateTime purchaseDate)
        {
            this.code = code;
            this.nccCode = nccCode;
            this.purchaseDate = purchaseDate;
        }
    }
}
