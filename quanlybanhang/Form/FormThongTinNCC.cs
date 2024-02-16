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
    public partial class FormThongTinNCC : Form
    {
        TextBox[] tbArr;
        List<NhaCungCap> listNCC;
        NhaCungCapRepo NCCRepo = new NhaCungCapRepo();

        public FormThongTinNCC()
        {
            InitializeComponent();
        }
        private void FormThongTinNCC_Load(object sender, EventArgs e)
        {
            tbArr = new TextBox[] { txbID, txbName, txbAddress, txbPhoneNumber };
            listNCC = NCCRepo.getAll();
            dataGridView1.Columns["id"].DataPropertyName = "id";
            dataGridView1.Columns["Code"].DataPropertyName= "Code";
            dataGridView1.Columns["NCCName"].DataPropertyName = "Name";
            dataGridView1.Columns["Address"].DataPropertyName = "Address";
            dataGridView1.Columns["Sdt"].DataPropertyName = "Sdt";
            dataGridView1.DataSource= listNCC;
            
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            for (int i =0; i < tbArr.Length; i++)
            {
                tbArr[i].Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in tbArr)
            {
                tb.ResetText();
                tb.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid = true;
            foreach (TextBox tb in tbArr) {
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
                NhaCungCap check = NCCRepo.getByCode(txbID.Text);
                if (check != null)
                {
                    MessageBox.Show("Nhà cung cấp đã tồn tại");
                }
                else
                {
                    NhaCungCap ncc = new NhaCungCap(txbID.Text, txbName.Text, txbAddress.Text, txbPhoneNumber.Text);
                    NCCRepo.create(ncc);
                    FormThongTinNCC_Load(sender, e);
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
                NhaCungCap check = NCCRepo.getByCode(txbID.Text);
                if (check == null)
                {
                    MessageBox.Show("Nhà cung cấp không tồn tại");
                }
                else
                {
                    NhaCungCap ncc = new NhaCungCap(check.Id, txbID.Text, txbName.Text, txbAddress.Text, txbPhoneNumber.Text);
                    NCCRepo.update(ncc);
                    FormThongTinNCC_Load(sender, e);
                    btnCancel_Click(sender, e);
                    MessageBox.Show("Sửa thành công");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txbID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txbName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txbAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txbPhoneNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            NhaCungCap check = NCCRepo.getByCode(txbID.Text);
            if (check == null)
            {
                MessageBox.Show("Nhà cung cấp không tồn tại");
            }
            else
            {
                NCCRepo.delete(check.Id);
                FormThongTinNCC_Load(sender, e);
                btnCancel_Click(sender, e);
                MessageBox.Show("Xóa thành công");
            }
        }

        private void txbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự đang được nhập có phải là số hay không
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Hủy bỏ thao tác nhập
            }
        }
    }
}
