using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlybanhang
{
    public partial class FormMain : Form
    {
        List<Form> listForm = new List<Form>()
        {
           new FormThongTinNCC(),
           new FormThongTinMatHang(),
           new FormThongTinKhachHang(),
           new FromCapNhatHoaDonNhap(),
           new FormThongTinHoaDonBan(),
           new FormThongTinBaoHanh(),
           new FormTimKiemHangHoa(),
           new FormTimKiemNCC(),
           new FormTimKiemKhachHang(),
           new FormThongKeSoLuongHang(),
           new FormBaoCaoDoanhThu(),
        };

        public FormMain()
        {
            InitializeComponent();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < listForm.Count; i++)
            {
                listForm[i].Hide();
            }
            listForm[0].TopLevel = false;
            listForm[0].BringToFront();
            listForm[0].Dock = DockStyle.Fill;
            pnlMainDisplay.Controls.Add(listForm[0]);
            listForm[0].Show();
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listForm.Count; i++)
            {
                listForm[i].Hide();
            }
            listForm[1].TopLevel = false;
            listForm[1].BringToFront();
            listForm[1].Dock = DockStyle.Fill;
            pnlMainDisplay.Controls.Add(listForm[1]);
            listForm[1].Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listForm.Count; i++)
            {
                listForm[i].Hide();
            }
            listForm[2].TopLevel = false;
            listForm[2].BringToFront();
            listForm[2].Dock = DockStyle.Fill;
            pnlMainDisplay.Controls.Add(listForm[2]);
            listForm[2].Show();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for( int i =0; i< listForm.Count; i++)
            {
                listForm[i].Hide();
            }
            listForm[3].TopLevel = false;
            listForm[3].BringToFront();
            listForm[3].Dock = DockStyle.Fill;
            pnlMainDisplay.Controls.Add(listForm[3]);
            listForm[3].Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for( int i = 0; i< listForm.Count; i++)
            {
                listForm[i].Hide();
            }
            listForm[4].TopLevel = false;
            listForm[4].BringToFront();
            listForm[4].Dock = DockStyle.Fill;
            pnlMainDisplay.Controls.Add(listForm[4]);
            listForm[4].Show();
        }

        private void bảoHànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for( int i=0; i< listForm.Count; i++)
            {
                listForm[i].Hide();
            }
            listForm[5].TopLevel = false;
            listForm[5].BringToFront();
            listForm[5].Dock = DockStyle.Fill;
            pnlMainDisplay.Controls.Add(listForm[5]);
            listForm[5].Show();
        }

        private void tìmKiếmThôngTinHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listForm.Count; i++)
            {
                listForm[i].Hide();
            }
            listForm[6].TopLevel = false;
            listForm[6].BringToFront();
            listForm[6].Dock = DockStyle.Fill;
            pnlMainDisplay.Controls.Add(listForm[6]);
            listForm[6].Show();
        }

        private void tìmKiếmTheoNCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listForm.Count; i++)
            {
                listForm[i].Hide();
            }
            listForm[7].TopLevel = false;
            listForm[7].BringToFront();
            listForm[7].Dock = DockStyle.Fill;
            pnlMainDisplay.Controls.Add(listForm[7]);
            listForm[7].Show();
        }

        private void tìmKiếmTheoThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listForm.Count; i++)
            {
                listForm[i].Hide();
            }
            listForm[8].TopLevel = false;
            listForm[8].BringToFront();
            listForm[8].Dock = DockStyle.Fill;
            pnlMainDisplay.Controls.Add(listForm[8]);
            listForm[8].Show();
        }

        private void thốngKêSốLượngHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listForm.Count; i++)
            {
                listForm[i].Hide();
            }
            listForm[9].TopLevel = false;
            listForm[9].BringToFront();
            listForm[9].Dock = DockStyle.Fill;
            pnlMainDisplay.Controls.Add(listForm[9]);
            listForm[9].Show();
        }

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listForm.Count; i++)
            {
                listForm[i].Hide();
            }
            listForm[10].TopLevel = false;
            listForm[10].BringToFront();
            listForm[10].Dock = DockStyle.Fill;
            pnlMainDisplay.Controls.Add(listForm[10]);
            listForm[10].Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
