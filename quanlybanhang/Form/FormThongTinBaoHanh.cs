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

namespace quanlybanhang
{
    public partial class FormThongTinBaoHanh : Form
    {
        TextBox[] tbArr;
        DateTimePicker[] dtpArr;
        List<BaoHanh> list = new List<BaoHanh>();
        BaoHanhRepo repo;
        public FormThongTinBaoHanh()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FormThongTinBaoHanh_Load(object sender, EventArgs e)
        {
            tbArr = new TextBox[] { txtCode, txtCusCode, txtProdCode, txtNumber };
            dtpArr = new DateTimePicker[] { dtStartDate, dtEndDate, dtAppointmentDate };
            try
            {
                list = repo.getAll();
                dgvList.Columns["Code"].DataPropertyName = "code";
                dgvList.Columns["CusCode"].DataPropertyName = "customerCode";
                dgvList.Columns["ProdCode"].DataPropertyName = "productCode";
                dgvList.Columns["StartDate"].DataPropertyName = "startDate";
                dgvList.Columns["EndDate"].DataPropertyName = "endDate";
                dgvList.Columns["Number"].DataPropertyName = "number";
                dgvList.Columns["AppointmentDate"].DataPropertyName = "appointmentDate";
                dgvList.DataSource = list;
            } catch (Exception) { }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in tbArr)
            {
                tb.Enabled = true;
            }
            foreach (DateTimePicker dateTimePicker in dtpArr)
            {
                dateTimePicker.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in tbArr)
            {
                tb.Enabled = false;
                tb.ResetText();
            }
            foreach (DateTimePicker dateTimePicker in dtpArr)
            {
                dateTimePicker.Enabled = false;
                dateTimePicker.ResetText();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        [Obsolete]
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
                BaoHanh check = repo.getByCode(txtCode.Text);
                if (check != null)
                {
                    MessageBox.Show("Phiếu bảo hành đã tồn tại");
                }
                else
                {
                    BaoHanh ncc = new BaoHanh(txtCode.Text, txtCusCode.Text, txtProdCode.Text, dtStartDate.Text, 
                        dtEndDate.Text, Int32.Parse(txtNumber.Text), dtAppointmentDate.Text);
                    repo.create(ncc);
                    FormThongTinBaoHanh_Load(sender, e);
                    btnCancel_Click(sender, e);
                    MessageBox.Show("Lưu thành công");
                }
            }

        }

        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCode.Text = dgvList.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCusCode.Text = dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtProdCode.Text = dgvList.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtStartDate.Text = dgvList.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtEndDate.Text = dgvList.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNumber.Text = dgvList.Rows[e.RowIndex].Cells[5].Value.ToString();
                dtAppointmentDate.Text = dgvList.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception)
            {

            }
        }

        [Obsolete]
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
                BaoHanh check = repo.getByCode(txtCode.Text);
                if (check == null)
                {
                    MessageBox.Show("Phiếu bảo hành không tồn tại");
                }
                else
                {
                    BaoHanh bh = new BaoHanh(txtCode.Text, txtCusCode.Text, txtProdCode.Text, dtStartDate.Text,
                        dtEndDate.Text, Int32.Parse(txtNumber.Text), dtAppointmentDate.Text);
                    repo.update(bh);
                    FormThongTinBaoHanh_Load(sender, e);
                    btnCancel_Click(sender, e);
                    MessageBox.Show("Lưu thành công");
                }
            }
        }

        [Obsolete]
        private void btnDelete_Click(object sender, EventArgs e)
        {
            BaoHanh check = repo.getByCode(txtCode.Text);
            if (check == null)
            {
                MessageBox.Show("Phiếu bảo hành không tồn tại");
            }
            else
            {
                repo.delete(check.code);
            }
        }
    }
}
