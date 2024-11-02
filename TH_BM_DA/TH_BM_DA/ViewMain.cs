using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH_BM_DA
{
    public partial class ViewMain : Form
    {
        public ViewMain()
        {
            InitializeComponent();
            label1.BackColor = System.Drawing.Color.Transparent;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCongDan_Click(object sender, EventArgs e)
        {

        }

        private void btnHoKhau_Click(object sender, EventArgs e)
        {

        }

        private void btnGPLaiXe_Click(object sender, EventArgs e)
        {

        }

        private void btnDsLoaiGP_Click(object sender, EventArgs e)
        {

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            // Ẩn form hiện tại
            this.Close();

            // Hiển thị form mới
            login.ShowDialog();
        }
    }
}
