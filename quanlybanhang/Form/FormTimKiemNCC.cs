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
        List<FilterSuplier> listResult = new List<FilterSuplier>();
        INhaCungCapRepo NCCRepo = new NhaCungCapRepo();
        IHoaDonRepo hoaDonRepo = new HoaDonRepo();
        IMatHangRepo matHangRepo = new MatHangRepo();
        Constant constant = new Constant();

        public FormTimKiemNCC()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<FilterSuplier> filter = new List<FilterSuplier>();
            if (rdbID.Checked)
            {
                filter = searchByCode(txbID.Text);
                dgvNCC.Columns["id"].DataPropertyName = "id";
                dgvNCC.Columns["Code"].DataPropertyName = "Code";
                dgvNCC.Columns["NCCName"].DataPropertyName = "Name";
                dgvNCC.Columns["Address"].DataPropertyName = "Address";
                dgvNCC.Columns["Sdt"].DataPropertyName = "Sdt";
                dgvNCC.DataSource = filter;
                txbNumber.Text = filter.Count.ToString();
            }
            else if (rdbName.Checked)
            {
                filter = searchByName(txbName.Text);
                dgvNCC.Columns["id"].DataPropertyName = "id";
                dgvNCC.Columns["Code"].DataPropertyName = "Code";
                dgvNCC.Columns["NCCName"].DataPropertyName = "Name";
                dgvNCC.Columns["Address"].DataPropertyName = "Address";
                dgvNCC.Columns["Sdt"].DataPropertyName = "Sdt";
                dgvNCC.DataSource = filter;
                txbNumber.Text = filter.Count.ToString();
            }
            else
            {
                FormTimKiemNCC_Load(sender, e);
            }
        }

        private void FormTimKiemNCC_Load(object sender, EventArgs e)
        {
            List<HoaDon> hoaDons = hoaDonRepo.getByType(constant.purchase());
            hoaDons.ForEach(x=> {
                NhaCungCap nhaCungCap = NCCRepo.getByCode(x.linkCode);
                MatHang matHang = matHangRepo.getByCode(x.prodCode);
                FilterSuplier filterSuplier = new FilterSuplier(nhaCungCap.Code, nhaCungCap.Name, matHang.Name, x.number, x.date);
                listResult.Add(filterSuplier);
            });
            List<FilterSuplier> load = new List<FilterSuplier>(listResult);
            dgvNCC.Columns["NCCCode"].DataPropertyName = "NCCCode";
            dgvNCC.Columns["NCCName"].DataPropertyName = "NCCName";
            dgvNCC.Columns["ProdName"].DataPropertyName = "ProdName";
            dgvNCC.Columns["Number"].DataPropertyName = "Number";
            dgvNCC.Columns["Date"].DataPropertyName = "Date";
            dgvNCC.DataSource = load;
            txbNumber.Text = load.Count.ToString();
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

        private List<FilterSuplier> searchByCode(string code)
        {
            List<FilterSuplier> searched = new List<FilterSuplier>();
            listResult.ForEach(x =>
            {
                if (checker(x.NCCCode.ToLower().Trim(' '), code.ToLower())) searched.Add(x);
            });
            return searched;
        }

        private List<FilterSuplier> searchByName(string name)
        {
            List<FilterSuplier> searched = new List<FilterSuplier>();
            listResult.ForEach(x =>
            {
                if (checker(x.NCCName.ToLower().Trim(' '), name.ToLower().Trim(' '))) searched.Add(x);
            });
            return searched;
        }

        private bool checker(string str, string check)
        {
            for (int i = 0; i < str.Length - check.Length; i++)
            {
                string c = str.Substring(i, check.Length + i - 1);
                if (c.Equals(check)) return true;
            }
            return false;
        }
    }
}
