using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
    public class Statistics
    {
        public string ProdName { get; set; }
        public int Inp {  get; set; }
        public int Outp {  get; set; }
        public int Redun { get; set; }

        public Statistics() { }
        public Statistics(string prodName, int inp, int @out, int redun)
        {
            ProdName = prodName;
            Inp = inp;
            Outp = @out;
            Redun = redun;
        }
    }
}
