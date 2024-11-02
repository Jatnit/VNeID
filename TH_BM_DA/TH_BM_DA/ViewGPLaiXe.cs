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
    public partial class ViewGPLaiXe : Form
    {
        public ViewGPLaiXe()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            ViewMain viewmain = new ViewMain();

            // Ẩn form hiện tại
            this.Hide();
            this.Close();

            // Hiển thị form mới
            viewmain.ShowDialog();
        }
    }
}
