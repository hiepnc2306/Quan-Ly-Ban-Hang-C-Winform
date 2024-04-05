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
<<<<<<< HEAD
        List<NhaCungCap> listNCC;
        INhaCungCapRepo NCCRepo = new NhaCungCapRepo();
=======
        BaoHanhRepo repo = new BaoHanhRepo();
        INhaCungCapRepo nccRepo = new NhaCungCapRepo();
        IHoaDonRepo hdRepo = new HoaDonRepo();
        List<NhaCungCap> nhaCungCaps;
        List<BaoHanh> baoHanhs;
        Constant constant = new Constant();
>>>>>>> 94670ca40f13c843cef558067aef2d911265db39
        public FormTimKiemNCC()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
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
=======
        public void searchNCC()
        {
            if (rdbID.Checked)
            {
                nhaCungCaps = nccRepo.searchByCode(txtId.Text);
            }
            else if (rdbID.Checked)
            {
                nhaCungCaps = nccRepo.searchByName(txtNCC.Text);
            }
            else
            {
                nhaCungCaps = nccRepo.getAll();
            }
        }

        public void searchWarranty()
        {
            List<String> nccCode = new List<String>();
            nhaCungCaps.ForEach(ncc =>
            {
                nccCode.Add(ncc.Code);
            });
            List<BaoHanh> list = repo.getAll();
            list.ForEach(bh =>
            {
                HoaDon hoaDon = hdRepo.getByCodeAndType(bh.checkCode, constant.sales());
                if (hoaDon != null && nccCode.Contains(hoaDon.linkCode))
                {
                    baoHanhs.Add(bh);
                }
            });
>>>>>>> 94670ca40f13c843cef558067aef2d911265db39
        }

        private void FormTimKiemNCC_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
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
=======
            searchNCC();
            searchWarranty();
>>>>>>> 94670ca40f13c843cef558067aef2d911265db39
        }
    }
}
