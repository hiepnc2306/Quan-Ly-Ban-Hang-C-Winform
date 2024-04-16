using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
    public class FilterProd
    {
        public string Warranty { get; set; }
        public string CusName { get; set; }
        public string ProdName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public FilterProd() { }
        public FilterProd(string warranty, string cusName, string prodName, DateTime startDate, DateTime endDate, int number, DateTime date)
        {
            Warranty = warranty;
            CusName = cusName;
            ProdName = prodName;
            StartDate = startDate;
            EndDate = endDate;
            Number = number;
            Date = date;
        }
    }
}
