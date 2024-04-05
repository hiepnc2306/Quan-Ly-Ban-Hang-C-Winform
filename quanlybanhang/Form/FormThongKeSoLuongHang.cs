using quanlybanhang.Model;
using quanlybanhang.Reponsitory;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace quanlybanhang
{
    public partial class FormThongKeSoLuongHang : Form
    {
        IHoaDonRepo repo = new HoaDonRepo();
        List<HoaDon> hoaDons;
        public FormThongKeSoLuongHang()
        {
            InitializeComponent();
        }

        public void SearchInvoice(string type, DateTime startDate, DateTime endDate)
        {
            List<HoaDon> res = new List<HoaDon>();
            hoaDons = repo.getAll();
            if (type != null || !type.Equals(""))
            {
                hoaDons.ForEach(d =>
                {
                    if (d.type.Equals(type) && (d.date.CompareTo(startDate) > -1) && (d.date.CompareTo(endDate) < 1))
                    { res.Add(d); }
                });
            }
            else { res = hoaDons; }
            hoaDons = res;
        }

        private void FormThongKeSoLuongHang_Load(object sender, EventArgs e)
        {
            //SearchInvoice();
        }
    }
}
