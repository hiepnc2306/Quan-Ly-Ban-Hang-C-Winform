using quanlybanhang.Model;
using quanlybanhang.Reponsitory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlybanhang
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void llbRegistry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == null || txtUserName.Text.Equals("")
                || txtPassword.Text == null || txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
                if (txtUserName.Text == null || txtUserName.Text.Equals(""))
                {
                    txtUserName.Focus();
                }
                else
                {
                    txtPassword.Focus();
                }
            }
            else
            {
                Connection connection = new Connection();
                OleDbConnection con = connection.conn();
                UserRepo userRepo = new UserRepo();
                con.Open();
                User user = userRepo.checkLogin(txtUserName.Text, txtPassword.Text, con);
                con.Close();
                if (user != null)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    this.FindForm().Hide();
                    Form form = new FormMain();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác");
                }
            }
        }
    }
}
