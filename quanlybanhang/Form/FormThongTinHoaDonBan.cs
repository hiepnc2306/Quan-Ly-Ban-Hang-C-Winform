using quanlybanhang.Model;
using quanlybanhang.Reponsitory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace quanlybanhang
{
    public partial class FormThongTinHoaDonBan : Form
    {
        List<HoaDon> list;
        HoaDonRepo repo = new HoaDonRepo();
        IKhachHangRepo khRepo = new KhachHangRepo();
        IMatHangRepo mhRepo = new MatHangRepo();
        Constant constant = new Constant();
        List<HoaDonKhachHang> hoaDonKhachHangs = new List<HoaDonKhachHang>();
        List<HoaDonMatHang> hoaDonMatHangs = new List<HoaDonMatHang>();
        public FormThongTinHoaDonBan()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FormThongTinHoaDonBan_Load(object sender, EventArgs e)
        {
            try
            {
                cbbProd.Items.Clear();
                cbbCus.Items.Clear();
                List<MatHang> products = mhRepo.getAll();
                List<KhachHang> customers = khRepo.getAll();
                list = repo.getByType(constant.sales());
                products.ForEach(p => { cbbProd.Items.Add(p.Code); });
                customers.ForEach(p => cbbCus.Items.Add(p.code));
                cbbCus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbCus.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbbProd.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbProd.AutoCompleteSource = AutoCompleteSource.ListItems;
                mapDGVCus();
                mapDGVProd();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            txtInvoiceCode.Enabled = true;
            txtPrice.Enabled = true;
            txtNumber.Enabled = true;
            dtpDate.Enabled = true;
        }

        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtInvoiceCode.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbbCus.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpDate.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void mapDGVCus()
        {
            HashSet<string> itemsCus = new HashSet<string>();
            foreach (HoaDon hoadon in list)
            {
                HoaDonKhachHang hoaDonKhach = new HoaDonKhachHang(hoadon.code, hoadon.linkCode, hoadon.date);
                hoaDonKhachHangs.Add(hoaDonKhach);
            }
            dataGridView1.Columns["InvoiceCode"].DataPropertyName = "code";
            dataGridView1.Columns["CustomerCode"].DataPropertyName = "cusCode";
            dataGridView1.Columns["SaleDate"].DataPropertyName = "saleDate";
            dataGridView1.DataSource = hoaDonKhachHangs;
            foreach (string code in itemsCus) { cbbCus.Items.Add(code); }
        }
        private void mapDGVProd()
        {
            HashSet<string> itemsProd = new HashSet<string>();
            foreach (HoaDon hoadon in list)
            {
                HoaDonMatHang hoaDonMatHang = new HoaDonMatHang(hoadon.code, hoadon.prodCode, hoadon.number, hoadon.price);
                hoaDonMatHangs.Add(hoaDonMatHang);
            }
            dataGridView2.Columns["InvCode"].DataPropertyName = "code";
            dataGridView2.Columns["ProdCode"].DataPropertyName = "prodCode";
            dataGridView2.Columns["Number"].DataPropertyName = "number";
            dataGridView2.Columns["Price"].DataPropertyName = "price";
            dataGridView2.DataSource = hoaDonMatHangs;
            foreach (string code in itemsProd) { cbbProd.Items.Add(code); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtInvoiceCode.Enabled = false;
            txtPrice.Enabled = false;
            txtNumber.Enabled = false;
            dtpDate.Enabled = false;
            FormThongTinHoaDonBan_Load(sender, e);
        }

        private void mhCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string code = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbbProd.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNumber.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
