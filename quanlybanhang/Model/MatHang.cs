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
        public long SalePrice { get; set; }
        public long PurchasePrice { get; set; }
        public int Quantity { get; set; }

        public MatHang() { }
        public MatHang(int id, string code, string name, long SalePrice , long PurchasePrice, int Quantity)
        {
            Id = id;
            Code = code;
            Name = name;
            this.SalePrice = SalePrice;
            this.PurchasePrice = PurchasePrice;
            this.Quantity = Quantity;
        }
        public MatHang(string code, string name, long SalePrice, long PurchasePrice, int Quantity)
        {
            Code = code;
            Name = name;
            this.SalePrice = SalePrice;
            this.PurchasePrice = PurchasePrice;
            this.Quantity = Quantity;
        }
    }
}
