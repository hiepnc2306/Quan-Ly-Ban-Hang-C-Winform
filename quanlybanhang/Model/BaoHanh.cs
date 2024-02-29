using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlybanhang.Model
{
    internal class BaoHanh
    {
        public int id { get; set; }
        public string code { set; get; }
        public string checkCode { set; get; }
        public DateTime startDate { set; get; }
        public DateTime endDate { set; get; }
        public int number {  set; get; }
        public DateTime appointmentDate {  set; get; }
        public BaoHanh() { }
        public BaoHanh(string code, string checkCode, DateTime startDate, DateTime endDate, int number, DateTime appointmentDate)
        {
            this.code = code;
            this.checkCode = checkCode;
            this.startDate = startDate;
            this.endDate = endDate;
            this.number = number;
            this.appointmentDate = appointmentDate;
        }
        public BaoHanh(int id, string code, string checkCode, DateTime startDate, DateTime endDate, int number, DateTime appointmentDate)
        {
            this.id = id;
            this.code = code;
            this.checkCode = checkCode;
            this.startDate = startDate;
            this.endDate = endDate;
            this.number = number;
            this.appointmentDate = appointmentDate;
        }
    }
}
