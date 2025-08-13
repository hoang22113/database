using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagementSystem.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = userName.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (username == "admin" && password == "admin")
            {
                // Mở form AdminDashboard
                MainDashboard dashboard = new MainDashboard();
                dashboard.Show();

                // Ẩn form hiện tại (form đăng nhập)
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
