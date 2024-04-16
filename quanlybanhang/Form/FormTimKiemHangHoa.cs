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
    public partial class FormTimKiemHangHoa : Form
    {
        List<FilterProd> filterProds = new List<FilterProd>();
        BaoHanhRepo baoHanhRepo = new BaoHanhRepo();
        IHoaDonRepo hoaDonRepo = new HoaDonRepo();
        IKhachHangRepo khachHangRepo = new KhachHangRepo();
        IMatHangRepo matHangRepo = new MatHangRepo();
        Constant constant = new Constant();
        public FormTimKiemHangHoa()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormTimKiemHangHoa_Load(object sender, EventArgs e)
        {
            filterProds = new List<FilterProd>();
            List<BaoHanh> baoHanhs = baoHanhRepo.getAll();
            baoHanhs.ForEach(x =>
            {
                HoaDon hoaDon = hoaDonRepo.getByCodeAndType(x.checkCode, constant.sales());
                if (hoaDon != null)
                {
                    MatHang matHang = matHangRepo.getByCode(hoaDon.prodCode);
                    KhachHang khachHang = khachHangRepo.getByCode(hoaDon.linkCode);
                    if (matHang != null && khachHang != null)
                    {
                        FilterProd filterProd = new FilterProd(x.code, khachHang.name, matHang.Name, x.startDate, x.endDate, x.number, x.appointmentDate);
                        filterProds.Add(filterProd);    
                    }
                } 
            });
            List<FilterProd> load = new List<FilterProd>(filterProds);
            dataGridView1.Columns["Warranty"].DataPropertyName = "Warranty";
            dataGridView1.Columns["CusName"].DataPropertyName = "CusName";
            dataGridView1.Columns["ProdName"].DataPropertyName = "ProdName";
            dataGridView1.Columns["StartDate"].DataPropertyName = "StartDate";
            dataGridView1.Columns["EndDate"].DataPropertyName = "EndDate";
            dataGridView1.Columns["Number"].DataPropertyName = "Number";
            dataGridView1.Columns["Date"].DataPropertyName = "Date";
            dataGridView1.DataSource = load;
            txbNumber.Text = load.Count.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List <FilterProd> filters = new List<FilterProd>();
            if (rdbID.Checked)
            {
                filters = searchByCode(txbID.Text);

            } else if (rdbName.Checked)
            {
                filters = searchByName(txbName.Text);
            }
            else
            {
                filters = filterProds;
            }
            dataGridView1.Columns["Warranty"].DataPropertyName = "Warranty";
            dataGridView1.Columns["CusName"].DataPropertyName = "CusName";
            dataGridView1.Columns["ProdName"].DataPropertyName = "ProdName";
            dataGridView1.Columns["StartDate"].DataPropertyName = "StartDate";
            dataGridView1.Columns["EndDate"].DataPropertyName = "EndDate";
            dataGridView1.Columns["Number"].DataPropertyName = "Number";
            dataGridView1.Columns["Date"].DataPropertyName = "Date";
            dataGridView1.DataSource = filters;
            txbNumber.Text = filters.Count.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rdbID_CheckedChanged(object sender, EventArgs e)
        {
            txbID.Enabled = true;
            txbName.Enabled = false;
        }

        private void rdbName_CheckedChanged(object sender, EventArgs e)
        {
            txbID.Enabled = false;
            txbName.Enabled = true;
        }

        private List<FilterProd> searchByCode(string name)
        {
            List<FilterProd> searched = new List<FilterProd>();
            filterProds.ForEach(x =>
            {
                if (checker(x.ProdName.ToLower().Trim(' '), name.ToLower())) searched.Add(x);
            });
            return searched;
        }

        private List<FilterProd> searchByName(string name)
        {
            List<FilterProd> searched = new List<FilterProd>();
            filterProds.ForEach(x =>
            {
                if (checker(x.CusName.ToLower().Trim(' '), name.ToLower())) searched.Add(x);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
