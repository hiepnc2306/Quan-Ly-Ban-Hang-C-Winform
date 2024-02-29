using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
    internal class HoaDon
    {
        public int id {  get; set; }
        public string code { get; set; }
        public string prodCode { get; set; }
        public string supplierCode { get; set; }
        public int number { get; set; }
        public long price { get; set; }
        public DateTime date { get; set; }
        public string type { get; set; }

        public HoaDon() { }
        public HoaDon(int id, string code, string prodCode, string supplierCode, int number, long price, DateTime date, string type)
        {
            this.id = id;
            this.code = code;
            this.prodCode = prodCode;
            this.supplierCode = supplierCode;
            this.number = number;
            this.price = price;
            this.date = date;
            this.type = type;
        }

        public HoaDon(string code, string prodCode, string supplierCode, int number, long price, DateTime date, string type)
        {
            this.code = code;
            this.prodCode = prodCode;
            this.supplierCode = supplierCode;
            this.number = number;
            this.price = price;
            this.date = date;
            this.type = type;
        }
    }
}
