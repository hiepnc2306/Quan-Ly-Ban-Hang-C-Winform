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
    public partial class FormTimKiemNCC : Form
    {
        List<NhaCungCap> listNCC;
        INhaCungCapRepo NCCRepo = new NhaCungCapRepo();
        public FormTimKiemNCC()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdbID.Checked)
            {
                listNCC = NCCRepo.FindByCode(txbID.Text);
            } 
            else if (rdbName.Checked)
            {
                listNCC = NCCRepo.FindByName(txbName.Text);
            } else
            {
                listNCC = NCCRepo.getAll();
            }
            dgvNCC.Columns["id"].DataPropertyName = "id";
            dgvNCC.Columns["Code"].DataPropertyName = "Code";
            dgvNCC.Columns["NCCName"].DataPropertyName = "Name";
            dgvNCC.Columns["Address"].DataPropertyName = "Address";
            dgvNCC.Columns["Sdt"].DataPropertyName = "Sdt";
            dgvNCC.DataSource = listNCC;
            txbNumber.Text = listNCC.Count.ToString();
        }

        private void FormTimKiemNCC_Load(object sender, EventArgs e)
        {
            listNCC = NCCRepo.getAll();
            dgvNCC.Columns["id"].DataPropertyName = "id";
            dgvNCC.Columns["Code"].DataPropertyName = "Code";
            dgvNCC.Columns["NCCName"].DataPropertyName = "Name";
            dgvNCC.Columns["Address"].DataPropertyName = "Address";
            dgvNCC.Columns["Sdt"].DataPropertyName = "Sdt";
            dgvNCC.DataSource = listNCC;
        }

        private void rdbID_CheckedChanged(object sender, EventArgs e)
        {
            txbID.Enabled = true;
            txbName.Enabled = false;
        }

        private void rdbName_CheckedChanged(object sender, EventArgs e)
        {
            txbName.Enabled = true;
            txbID.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
