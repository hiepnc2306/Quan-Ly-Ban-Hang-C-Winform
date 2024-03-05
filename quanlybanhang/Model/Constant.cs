using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
    internal class Constant
    {
        private const string PURCHASE = "purchase_invoice";
        private const string SALES = "sales_invoice";
        public string purchase() { return PURCHASE; }
        public string sales() { return SALES; }
    }
}
