using Mysqlx.Crud;
using quanlybanhang.Model;
using quanlybanhang.Reponsitory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlybanhang
{
    public partial class FromCapNhatHoaDonNhap : Form
    {
        List<HoaDon> list;
        TextBox[] tbs;
        ComboBox[] cbbs;
        IHoaDonRepo repo = new HoaDonRepo();
        INhaCungCapRepo nccRepo = new NhaCungCapRepo();
        IMatHangRepo mhRepo = new MatHangRepo();
        Constant constant = new Constant();
        List<HoaDonNhaCungCap> hoaDonNhaCungCaps;
        List<HoaDonMatHang> hoaDonMatHangs;
        public FromCapNhatHoaDonNhap()
        {
            InitializeComponent();
        }

        private void mapDGVNCC()
        {
            hoaDonNhaCungCaps = new List<HoaDonNhaCungCap>();
            HashSet<string> itemsCus = new HashSet<string>();
            foreach (HoaDon hoadon in list)
            {
                HoaDonNhaCungCap ncc = new HoaDonNhaCungCap(hoadon.code, hoadon.linkCode, hoadon.date);
                hoaDonNhaCungCaps.Add(ncc);
            }
            dataGridView1.Columns["Invoice"].DataPropertyName = "code";
            dataGridView1.Columns["NCCCode"].DataPropertyName = "nccCode";
            dataGridView1.Columns["Date"].DataPropertyName = "purchaseDate";
            dataGridView1.DataSource = hoaDonNhaCungCaps;
            foreach (string code in itemsCus) { cbbNCC.Items.Add(code); }
        }
        private void mapDGVProd()
        {
            hoaDonMatHangs = new List<HoaDonMatHang>();
            HashSet<string> itemsProd = new HashSet<string>();
            foreach (HoaDon hoadon in list)
            {
                HoaDonMatHang hoaDonMatHang = new HoaDonMatHang(hoadon.code, hoadon.prodCode, hoadon.number, hoadon.price);
                hoaDonMatHangs.Add(hoaDonMatHang);
            }
            dataGridView2.Columns["InvoiceCode"].DataPropertyName = "code";
            dataGridView2.Columns["ProdCode"].DataPropertyName = "prodCode";
            dataGridView2.Columns["Number"].DataPropertyName = "number";
            dataGridView2.Columns["Price"].DataPropertyName = "price";
            dataGridView2.DataSource = hoaDonMatHangs;
            foreach (string code in itemsProd) { cbbProd.Items.Add(code); }
        }

        public void getListHoaDon()
        {
            if (cbbNCC.Text != null && !cbbNCC.Text.Equals("") && cbbProd.Text != null && !cbbProd.Text.Equals("")) {
                list = repo.getByTypeAndProdCodeAndLinkCode(constant.purchase(), cbbProd.Text, cbbNCC.Text);
            }
            else if (cbbNCC.Text != null && !cbbNCC.Text.Equals(""))
            {
                list = repo.getByTypeAndLinkCode(constant.purchase(), cbbNCC.Text);
            }
            else if (cbbProd.Text != null && !cbbProd.Text.Equals(""))
            {
                list = repo.getByTypeAndProdCode(constant.purchase(), cbbProd.Text);
            } else
            {
                list = repo.getByType(constant.purchase());
            }
        }

        private void FromCapNhatHoaDonNhap_Load(object sender, EventArgs e)
        {
            tbs = new TextBox[] { txtInvoiceCode, txtNumber };
            cbbs = new ComboBox[] { cbbNCC, cbbProd };
            cbbProd.Items.Clear();
            cbbNCC.Items.Clear();
            List<MatHang> products = mhRepo.getAll();
            List<NhaCungCap> ncc = nccRepo.getAll();
            getListHoaDon();
            products.ForEach(p => { cbbProd.Items.Add(p.Code); });
            ncc.ForEach(p => cbbNCC.Items.Add(p.Code));
            cbbNCC.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbNCC.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbbProd.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbProd.AutoCompleteSource = AutoCompleteSource.ListItems;
            mapDGVNCC();
            mapDGVProd();

        }

        private void btnInput_Click(object sender, EventArgs e)
        {

            foreach (TextBox txt in tbs)
            {
                txt.Enabled = true;
            }
            foreach (ComboBox cb in cbbs)
            {
                cb.Enabled = true;
            }
            dtpDate.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in tbs)
            {
                txt.ResetText();
                txt.Enabled = false;
            }
            foreach (ComboBox cb in cbbs)
            {
                cb.Enabled = false;
                cb.ResetText();
            }
            dtpDate.Enabled = false;
            dtpDate.ResetText();
            FromCapNhatHoaDonNhap_Load(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            create(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            update(sender, e);
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
                    FromCapNhatHoaDonNhap_Load(sender, e);
                    btnCancel_Click(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi xảy ra!");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn nhập với mã được nhập!");
            }
        }

        private void nccCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtInvoiceCode.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                dtpDate.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                cbbNCC.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void mhCellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string code = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNumber.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbbProd.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void cbbNCC_SelectedValueChanged(object sender, EventArgs e)
        {
            getListHoaDon();
            mapDGVNCC();
            mapDGVProd();
        }

        private void cbbProd_SelectedValueChanged(object sender, EventArgs e)
        {
            getListHoaDon();
            mapDGVNCC();
            mapDGVProd();
        }
        public void create(object sender, EventArgs e)
        {
            bool check = true;
            foreach (TextBox txb in tbs)
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
                MatHang matHang = mhRepo.getByCode(cbbProd.Text);
                NhaCungCap ncc = nccRepo.getByCode(cbbNCC.Text);
                if (matHang == null || ncc == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin mặt hàng hoặc nhà cung cấp theo mã vừa nhập!");
                }
                else
                {
                    HoaDon hd = repo.getByCode(txtInvoiceCode.Text);
                    if (hd == null)
                    {
                        int number = Int32.Parse(txtNumber.Text);
                        long price = matHang.PurchasePrice * number;
                        HoaDon hoaDon = new HoaDon(txtInvoiceCode.Text, cbbNCC.Text, cbbProd.Text, number,
                        price, dtpDate.Value, constant.purchase());
                        int quantity = matHang.Quantity + number;
                        try
                        {
                            MatHang mh1 = new MatHang(matHang.Id, matHang.Code, matHang.Name, matHang.SalePrice, matHang.PurchasePrice, quantity);
                            mhRepo.update(mh1);
                            repo.create(hoaDon);
                            MessageBox.Show("Lưu thành công!");
                            FromCapNhatHoaDonNhap_Load(sender, e);
                            btnCancel_Click(sender, e);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Có lỗi xảy ra khi thêm mới hóa đơn nhập!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hóa đơn nhập đã tồn tại với mã được nhập!");
                    }

                }
            }
        }

        public void update(object sender, EventArgs e)
        {
            bool check = true;
            foreach (TextBox txb in tbs)
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
                MatHang matHang = mhRepo.getByCode(cbbProd.Text);
                NhaCungCap ncc = nccRepo.getByCode(cbbNCC.Text);
                if (matHang == null || ncc == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin mặt hàng hoặc nhà cung cấp theo mã vừa nhập!");
                }
                else
                {
                    HoaDon hd = repo.getByCode(txtInvoiceCode.Text);
                    if (hd != null)
                    {
                        int number = Int32.Parse(txtNumber.Text);
                        long price = matHang.PurchasePrice * number;
                        int quantity = matHang.Quantity - hd.number + number;
                        HoaDon hoaDon = new HoaDon(hd.id, txtInvoiceCode.Text, cbbNCC.Text, cbbProd.Text, number,
                        price, dtpDate.Value, constant.purchase());
                        try
                        {
                            MatHang mh1 = new MatHang(matHang.Id, matHang.Code, matHang.Name, matHang.SalePrice, 
                                matHang.PurchasePrice, quantity);
                            mhRepo.update(mh1);
                            repo.update(hoaDon);
                            MessageBox.Show("Cập nhật thành công!");
                            FromCapNhatHoaDonNhap_Load(sender, e);
                            btnCancel_Click(sender, e);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Có lỗi xảy ra khi cập nhật hóa đơn bán!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn nhập!");
                    }

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
