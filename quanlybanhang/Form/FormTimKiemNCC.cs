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
        BaoHanhRepo repo = new BaoHanhRepo();
        INhaCungCapRepo nccRepo = new NhaCungCapRepo();
        IHoaDonRepo hdRepo = new HoaDonRepo();
        List<NhaCungCap> nhaCungCaps;
        List<BaoHanh> baoHanhs;
        Constant constant = new Constant();
        public FormTimKiemNCC()
        {
            InitializeComponent();
        }

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
        }

        private void FormTimKiemNCC_Load(object sender, EventArgs e)
        {
            searchNCC();
            searchWarranty();
        }
    }
}
