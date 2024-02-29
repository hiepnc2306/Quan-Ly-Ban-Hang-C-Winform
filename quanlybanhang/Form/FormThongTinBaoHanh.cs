using quanlybanhang.Model;
using quanlybanhang.Reponsitory;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace quanlybanhang
{
    public partial class FormThongTinBaoHanh : Form
    {
        TextBox[] tbArr;
        DateTimePicker[] dtpArr;
        List<BaoHanh> list = new List<BaoHanh>();
        IBaoHanhRepo baoHanhRepo = new BaoHanhRepo();
        public FormThongTinBaoHanh()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FormThongTinBaoHanh_Load(object sender, EventArgs e)
        {
            tbArr = new TextBox[] { txtCode, txtCheckCode, txtNumber };
            dtpArr = new DateTimePicker[] { dtStartDate, dtEndDate, dtAppointmentDate };
            try
            {
                list = baoHanhRepo.getAll();
                dgvList.Columns["Code"].DataPropertyName = "code";
                dgvList.Columns["CheckCode"].DataPropertyName = "checkCode";
                dgvList.Columns["StartDate"].DataPropertyName = "startDate";
                dgvList.Columns["EndDate"].DataPropertyName = "endDate";
                dgvList.Columns["Number"].DataPropertyName = "number";
                dgvList.Columns["AppointmentDate"].DataPropertyName = "appointmentDate";
                dgvList.Columns["id"].DataPropertyName = "code";
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
                BaoHanh check = baoHanhRepo.getByCode(txtCode.Text);
                if (check != null)
                {
                    MessageBox.Show("Phiếu bảo hành đã tồn tại");
                }
                else
                {
                    BaoHanh ncc = new BaoHanh(txtCode.Text, txtCheckCode.Text, dtStartDate.Value, 
                        dtEndDate.Value, Int32.Parse(txtNumber.Text), dtAppointmentDate.Value);
                    baoHanhRepo.create(ncc);
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
                txtCode.Text = dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCheckCode.Text = dgvList.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtStartDate.Text = dgvList.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtEndDate.Text = dgvList.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtNumber.Text = dgvList.Rows[e.RowIndex].Cells[5].Value.ToString();
                dtAppointmentDate.Text = dgvList.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception)
            {

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
                BaoHanh check = baoHanhRepo.getByCode(txtCode.Text);
                if (check == null)
                {
                    MessageBox.Show("Phiếu bảo hành không tồn tại");
                }
                else
                {
                    try
                    {
                        BaoHanh bh = new BaoHanh(check.id, txtCode.Text, txtCheckCode.Text, dtStartDate.Value,
                        dtEndDate.Value, Int32.Parse(txtNumber.Text), dtAppointmentDate.Value);
                        baoHanhRepo.update(bh);
                        FormThongTinBaoHanh_Load(sender, e);
                        btnCancel_Click(sender, e);
                        MessageBox.Show("Lưu thành công");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Có lỗi xảy ra");
                    }
                }
            }
        }

         
        private void btnDelete_Click(object sender, EventArgs e)
        {
            BaoHanh check = baoHanhRepo.getByCode(txtCode.Text);
            if (check == null)
            {
                MessageBox.Show("Phiếu bảo hành không tồn tại");
            }
            else
            {
                baoHanhRepo.delete(check.code);
            }
        }
    }
}
