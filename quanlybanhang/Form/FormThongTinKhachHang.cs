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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace quanlybanhang
{
    public partial class FormThongTinKhachHang : Form
    {
        TextBox[] tbArr;
        List<KhachHang> list;
        KhachHangRepo repo = new KhachHangRepo();
        public FormThongTinKhachHang()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in tbArr)
            {
                tb.Enabled = true;
            }
        }

        private void txbAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormThongTinKhachHang_Load(object sender, EventArgs e)
        {
            tbArr = new TextBox[] { txbID, txbname, txbAddress, txbPhoneNumber };
            list = repo.getAll();
            dataGridView1.Columns["Id"].DataPropertyName = "Id";
            dataGridView1.Columns["Code"].DataPropertyName = "Code";
            dataGridView1.Columns["CName"].DataPropertyName = "Name";
            dataGridView1.Columns["Address"].DataPropertyName = "Address";
            dataGridView1.Columns["Sdt"].DataPropertyName = "PhoneNumber";
            dataGridView1.DataSource = list;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in tbArr)
            {
                tb.Enabled = false;
                tb.ResetText();
            }
        }

        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txbID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txbname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txbAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txbPhoneNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            } catch { }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid = true;
            foreach (TextBox tb in tbArr)
            {
                if (tb.Text == null || tb.Text.Equals(""))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                    tb.Focus();
                    valid = false;
                    break;
                }
            }
            if (valid)
            {
                KhachHang check = repo.getByCode(txbID.Text);
                if (check != null)
                {
                    MessageBox.Show("Khách hàng đã tồn tại");
                }
                else
                {
                    KhachHang ncc = new KhachHang(txbID.Text, txbname.Text, txbAddress.Text, txbPhoneNumber.Text);
                    repo.create(ncc);
                    FormThongTinKhachHang_Load(sender, e);
                    btnCancel_Click(sender, e);
                    MessageBox.Show("Lưu thành công");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool valid = true;
            foreach (TextBox tb in tbArr)
            {
                if (tb.Text == null || tb.Text.Equals(""))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                    tb.Focus();
                    valid = false;
                    break;
                }
            }
            if (valid)
            {
                KhachHang check = repo.getByCode(txbID.Text);
                if (check == null)
                {
                    MessageBox.Show("Khách hàng không tồn tại");
                }
                else
                {
                    KhachHang ncc = new KhachHang(check.id, txbID.Text, txbname.Text, txbAddress.Text, txbPhoneNumber.Text);
                    repo.update(ncc);
                    FormThongTinKhachHang_Load(sender, e);
                    btnCancel_Click(sender, e);
                    MessageBox.Show("Sửa thành công");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            KhachHang check = repo.getByCode(txbID.Text);
            if (check == null)
            {
                MessageBox.Show("Khách hàng không tồn tại");
            }
            else
            {
                repo.delete(check.id);
                FormThongTinKhachHang_Load(sender, e);
                btnCancel_Click(sender, e);
                MessageBox.Show("Xóa thành công");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
