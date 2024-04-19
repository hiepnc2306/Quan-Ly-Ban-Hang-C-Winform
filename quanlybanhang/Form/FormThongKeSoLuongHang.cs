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
        IMatHangRepo matHangRepo = new MatHangRepo();
        List<Statistics> listStatistics = new List<Statistics>();
        List<HoaDon> hoaDons = new List<HoaDon>();
        Constant constant = new Constant();

        public FormThongKeSoLuongHang()
        {
            InitializeComponent();
        }

        private void FormThongKeSoLuongHang_Load(object sender, EventArgs e)
        {
            hoaDons = new List<HoaDon>();
            hoaDons = repo.getAll();
            listStatistics = new List<Statistics>();
            List<MatHang> matHang = matHangRepo.getAll();
            matHang.ForEach(x =>
            {
                int inp = 0;
                int outp = 0;
                List<HoaDon> purchases = repo.getByTypeAndProdCode(constant.purchase(), x.Code);
                List<HoaDon> sales = repo.getByTypeAndProdCode(constant.sales(), x.Code);
                if (purchases.Count > 0) { purchases.ForEach(p => { inp += p.number; }); };
                if (sales.Count > 0) { sales.ForEach(p => { outp += p.number; }); };
                Statistics statistics = new Statistics(x.Name, inp, outp, inp - outp);
                listStatistics.Add(statistics);
            });
            List<Statistics> statistics1 = new List<Statistics>(listStatistics);
            dataGridView1.Columns["ProdName"].DataPropertyName = "ProdName";
            dataGridView1.Columns["Inp"].DataPropertyName = "Inp";
            dataGridView1.Columns["Outp"].DataPropertyName = "Outp";
            dataGridView1.Columns["Redun"].DataPropertyName = "Redun";
            dataGridView1.DataSource = statistics1;
            txb.Text = statistics1.Count.ToString();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            search();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            search();
        }

        public void search()
        {
            listStatistics = new List<Statistics>();
            List<MatHang> matHang = matHangRepo.getAll();
            matHang.ForEach(x =>
            {
                int inp = 0;
                int outp = 0;
                hoaDons.ForEach(p =>
                {
                    if (p.date.CompareTo(dtpFrom.Value) >= 0
                    && p.date.CompareTo(dtpTo.Value) <= 0
                    && p.type.Equals(constant.purchase())
                    && p.prodCode.Equals(x.Code))
                    {
                        inp += p.number;
                    } 
                    else if (p.date.CompareTo(dtpFrom.Value) >= 0
                    && p.date.CompareTo(dtpTo.Value) <= 0
                    && p.type.Equals(constant.sales())
                    && p.prodCode.Equals(x.Code)) 
                    { 
                        outp += p.number;
                    }
                });
                Statistics statistics = new Statistics(x.Name, inp, outp, inp - outp);
                listStatistics.Add(statistics);
            });
            List<Statistics> statistics1 = new List<Statistics>(listStatistics);
            dataGridView1.Columns["ProdName"].DataPropertyName = "ProdName";
            dataGridView1.Columns["Inp"].DataPropertyName = "Inp";
            dataGridView1.Columns["Outp"].DataPropertyName = "Outp";
            dataGridView1.Columns["Redun"].DataPropertyName = "Redun";
            dataGridView1.DataSource = statistics1;
            txb.Text = statistics1.Count.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
