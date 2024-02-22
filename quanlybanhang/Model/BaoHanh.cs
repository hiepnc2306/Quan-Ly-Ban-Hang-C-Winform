using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
    internal class BaoHanh
    {
        public string code { set; get; }
        public string customerCode { set; get; }
        public string productCode { set; get; }
        public string startDate { set; get; }
        public string endDate { set; get; }
        public int number {  set; get; }
        public string appointmentDate {  set; get; }
        public BaoHanh() { }
        public BaoHanh(string code, string customerCode, string productCode, string startDate, string endDate, int number, string appointmentDate)
        {
            this.code = code;
            this.customerCode = customerCode;
            this.productCode = productCode;
            this.startDate = startDate;
            this.endDate = endDate;
            this.number = number;
            this.appointmentDate = appointmentDate;
        }
    }
}
