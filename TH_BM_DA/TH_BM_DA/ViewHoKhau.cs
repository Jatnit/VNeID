using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TH_BM_DA
{
    public partial class ViewHoKhau : Form
    {

      

        public ViewHoKhau()
        {
            InitializeComponent();
            LoadHoKhauData();
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

        private void btn_backk_Click(object sender, EventArgs e)
        {
            ViewMain viewmain = new ViewMain();

            // Ẩn form hiện tại
            this.Hide();
            this.Close();

            // Hiển thị form mới
            viewmain.ShowDialog();
        }

        private void ViewHoKhau_Load(object sender, EventArgs e)
        {

        }

        private void dgvHK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxTP_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBoxQ_TextChanged(object sender, EventArgs e)
        {
            FilterData();
        }

        private void textBoxP_TextChanged(object sender, EventArgs e)
        {
            FilterData();

        }

        private void dateTimePickerNgayTao_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxT_TextChanged(object sender, EventArgs e)
        {

        }
        private void FilterData()
        {
            try
            {
                StringBuilder queryBuilder = new StringBuilder("SELECT * FROM HoKhau WHERE 1=1");

                // Thêm điều kiện chỉ khi TextBox có dữ liệu
                if (!string.IsNullOrWhiteSpace(textBoxTP.Text))
                {
                    queryBuilder.Append(" AND LOWER(thanh_pho) LIKE '%' || :ThanhPho || '%'");
                }
                if (!string.IsNullOrWhiteSpace(textBoxQ.Text))
                {
                    queryBuilder.Append(" AND LOWER(quan) LIKE '%' || :Quan || '%'");
                }
                if (!string.IsNullOrWhiteSpace(textBoxP.Text))
                {
                    queryBuilder.Append(" AND LOWER(phuong) LIKE '%' || :Phuong || '%'");
                }

                // Kết nối và thực thi câu truy vấn
                using (var connection = Database.Get_Connect())
                {
                    using (var command = new OracleCommand(queryBuilder.ToString(), connection))
                    {
                        // Gắn tham số vào câu lệnh SQL
                        if (!string.IsNullOrWhiteSpace(textBoxTP.Text))
                        {
                            command.Parameters.Add(":ThanhPho", textBoxTP.Text.ToLower());
                        }
                        if (!string.IsNullOrWhiteSpace(textBoxQ.Text))
                        {
                            command.Parameters.Add(":Quan", textBoxQ.Text.ToLower());
                        }
                        if (!string.IsNullOrWhiteSpace(textBoxP.Text))
                        {
                            command.Parameters.Add(":Phuong", textBoxP.Text.ToLower());
                        }

                        // Lấy dữ liệu và hiển thị trên DataGridView
                        using (var adapter = new OracleDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dgvHK.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadHoKhauData()
        {
            try
            {
                string query = "SELECT * FROM HoKhau";

                using (var connection = Database.Get_Connect())
                {
                    using (var command = new OracleCommand(query, connection))
                    {
                        using (var adapter = new OracleDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dgvHK.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        
    }
}
