using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
    public class FilterSuplier
    {
        public string NCCCode { get; set; }
        public string NCCName { get; set; }
        public string ProdName { get; set;}
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public FilterSuplier() { }
        public FilterSuplier(string nCCCode, string nCCName, string prodName, int number, DateTime date)
        {
            NCCCode = nCCCode;
            NCCName = nCCName;
            ProdName = prodName;
            Number = number;
            Date = date;
        }
    }
}
