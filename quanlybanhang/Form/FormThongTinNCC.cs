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
        List<List<string>> listData;
        List<NhaCungCap> listNCC;
        Connection connection = new Connection();
        NhaCungCapRepo NCCRepo = new NhaCungCapRepo();

        public FormThongTinNCC()
        {
            InitializeComponent();
        }
        private void FormThongTinNCC_Load(object sender, EventArgs e)
        {
            tbArr = new TextBox[] { txbAddress, txbID, txbName, txbPhoneNumber };
            listNCC = NCCRepo.getAll();
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
                if (tbArr[i] == null || tbArr[i].Text.Equals(" "))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin");
                    tbArr[i].Focus();
                }
            }
            NhaCungCap ncc = new NhaCungCap(txbID.Text, txbName.Text, txbAddress.Text, txbPhoneNumber.Text);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tbArr.Length; i++)
            {
                tbArr[i].Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var save = new SaveFileDialog() { Filter = "|*.csv", FileName = "hien" })
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (var sw = new StreamWriter(save.FileName))
                    {
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            sw.Write(dataGridView1.Rows[i].Cells[0].Value.ToString() + ",");
                            sw.Write(dataGridView1.Rows[i].Cells[1].Value.ToString() + ",");
                            sw.Write(dataGridView1.Rows[i].Cells[2].Value.ToString() + ",");
                            sw.Write(dataGridView1.Rows[i].Cells[3].Value.ToString() + ",");
                            sw.WriteLine();
                        }
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txbID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txbName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txbAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txbPhoneNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
