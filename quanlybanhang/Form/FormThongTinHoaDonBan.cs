 using quanlybanhang.Model;
using quanlybanhang.Reponsitory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlybanhang
{
    public partial class FormThongTinHoaDonBan : Form
    {
        List<HoaDon> list;
        TextBox[] tbArr;
        IHoaDonRepo repo = new HoaDonRepo();
        IKhachHangRepo khRepo = new KhachHangRepo();
        IMatHangRepo mhRepo = new MatHangRepo();
        Constant constant = new Constant();
        List<HoaDonKhachHang> hoaDonKhachHangs = new List<HoaDonKhachHang>();
        List<HoaDonMatHang> hoaDonMatHangs = new List<HoaDonMatHang>();
        public FormThongTinHoaDonBan()
        {
            InitializeComponent();
        }

        public void getListHoaDon()
        {
            if (cbbCus.Text != null && !cbbCus.Text.Equals("") && cbbProdSale.Text != null && !cbbProdSale.Text.Equals(""))
            {
                list = repo.getByTypeAndProdCodeAndLinkCode(constant.sales(), cbbProdSale.Text, cbbCus.Text);
            }
            else if (cbbCus.Text != null && !cbbCus.Text.Equals(""))
            {
                list = repo.getByTypeAndLinkCode(constant.sales(), cbbCus.Text);
            }
            else if (cbbProdSale.Text != null && !cbbProdSale.Text.Equals(""))
            {
                list = repo.getByTypeAndProdCode(constant.sales(), cbbProdSale.Text);
            }
            else
            {
                list = repo.getByType(constant.sales());
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FormThongTinHoaDonBan_Load(object sender, EventArgs e)
        {
            try
            {
                cbbProdSale.Items.Clear();
                cbbCus.Items.Clear();
                List<MatHang> products = mhRepo.getAll();
                List<KhachHang> customers = khRepo.getAll();
                getListHoaDon();
                products.ForEach(p => { cbbProdSale.Items.Add(p.Code); });
                customers.ForEach(p => cbbCus.Items.Add(p.code));
                cbbCus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbCus.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbbProdSale.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbProdSale.AutoCompleteSource = AutoCompleteSource.ListItems;
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
            txtNumber.Enabled = true;
            dtpDate.Enabled = true;
        }

        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtInvoiceCode.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                dtpDate.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                cbbCus.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex) { }
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

            foreach (string code in itemsProd) { cbbProdSale.Items.Add(code); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtInvoiceCode.Enabled = false;
            txtInvoiceCode.ResetText();
            txtPrice.ResetText();
            txtNumber.ResetText();
            dtpDate.ResetText();
            txtPrice.Enabled = false;
            txtNumber.Enabled = false;
            dtpDate.Enabled = false;

            cbbCus.ResetText();
            cbbProdSale.ResetText();

            FormThongTinHoaDonBan_Load(sender, e);

        }

        private void mhCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string code = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbbProdSale.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtNumber.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tbArr = new TextBox[] { txtInvoiceCode, txtNumber };
            ComboBox[] cbbs = new ComboBox[] { cbbCus, cbbProdSale };
            bool check = true;
            foreach (TextBox txb in tbArr)
            {
                if (txb.Text.Equals("") || txb.Text == null)
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                    txb.Focus();
                    check = false;
                    break;
                }
            }
            if (check == true)
            {
                foreach (ComboBox cbb in cbbs)
                {
                    if (cbb.Text == null || cbb.Text.Equals(""))
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin");
                        cbb.Focus();
                        check = false;
                        break;
                    }
                }
                if (check == true)
                {
                    if (dtpDate.Text == null || dtpDate.Text.Equals(""))
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin");
                        dtpDate.Focus();
                        check = false;
                    }
                }
            }
            if (check == true)
            {
                MatHang matHang = mhRepo.getByCode(cbbProdSale.Text);
                KhachHang khachHang = khRepo.getByCode(cbbCus.Text);
                if (matHang == null || khachHang == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin mặt hàng hoặc khách hàng theo mã vừa nhập!");
                }
                else
                {
                    int number = Int32.Parse(txtNumber.Text);
                    long price = matHang.SalePrice * number;
                    HoaDon hoaDon = new HoaDon(txtInvoiceCode.Text, cbbCus.Text, cbbProdSale.Text, number,
                    price, dtpDate.Value, constant.sales());
                    int quantity = matHang.Quantity - number;
                    try
                    {
                        MatHang mh1 = new MatHang(matHang.Id, matHang.Code, matHang.Name, matHang.SalePrice, matHang.SalePrice, quantity);
                        mhRepo.update(mh1);
                        repo.create(hoaDon);
                        MessageBox.Show("Lưu thành công!");
                        btnCancel_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thêm mới hóa đơn bán!");
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tbArr = new TextBox[] { txtInvoiceCode, txtNumber };
            ComboBox[] cbbs = new ComboBox[] { cbbCus, cbbProdSale };
            bool check = true;
            foreach (TextBox txb in tbArr)
            {
                if (txb.Text.Equals("") || txb.Text == null)
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                    txb.Focus();
                    check = false;
                    break;
                }
            }
            if (check == true)
            {
                foreach (ComboBox cbb in cbbs)
                {
                    if (cbb.Text == null || cbb.Text.Equals(""))
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin");
                        cbb.Focus();
                        check = false;
                        break;
                    }
                }
                if (check == true)
                {
                    if (dtpDate.Text == null || dtpDate.Text.Equals(""))
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin");
                        dtpDate.Focus();
                        check = false;
                    }
                }
            }
            if (check == true)
            {
                MatHang matHang = mhRepo.getByCode(cbbProdSale.Text);
                KhachHang khachHang = khRepo.getByCode(cbbCus.Text);
                if (matHang == null || khachHang == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin mặt hàng hoặc khách hàng theo mã vừa nhập!");
                }
                else
                {
                    HoaDon hd = repo.getByCode(txtInvoiceCode.Text);
                    if (hd != null)
                    {
                        int number = Int32.Parse(txtNumber.Text);
                        long price = matHang.SalePrice * number;
                        HoaDon hoaDon = new HoaDon(hd.id, txtInvoiceCode.Text, cbbCus.Text, cbbProdSale.Text, number,
                        price, dtpDate.Value, constant.sales());
                        int quantity = matHang.Quantity - hd.number + number;
                        try
                        {
                            MatHang mh1 = new MatHang(matHang.Id, matHang.Code, matHang.Name, matHang.SalePrice,
                                matHang.SalePrice, quantity);
                            mhRepo.update(mh1);
                            repo.update(hoaDon);
                            MessageBox.Show("Cập nhật thành công!");
                            btnCancel_Click(sender, e);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Có lỗi xảy ra khi cập nhật hóa đơn bán!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn bán!");
                    }

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HoaDon hd = repo.getByCode(txtInvoiceCode.Text);
            if (hd != null)
            {
                try
                {
                    repo.delete(txtInvoiceCode.Text);
                    MessageBox.Show("Xóa thành công!");
                    FormThongTinHoaDonBan_Load(sender, e);
                    btnCancel_Click(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi xảy ra!");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn bán với mã được nhập!");
            }
        }
    }
}
