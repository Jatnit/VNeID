﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TH_BM_DA
{
    public partial class ViewCongDan : Form
    {

        public ViewCongDan()
        {
           InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            comboBoxPhai.Items.Add("Nam");
            comboBoxPhai.Items.Add("Nữ");
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

        private void ViewCongDan_Load(object sender, EventArgs e)
        {
            LoadCongDanData();
        }

        private void LoadCongDanData()
        {
            try
            {
                string query = "SELECT congdan_id, ho_ten, ngay_sinh, gioi_tinh, dien_thoai, email, hokhau_id, giayphep_id, diachi FROM CongDan";
                // Sử dụng kết nối từ class Database
                OracleConnection conn = Database.Get_Connect();
                if (conn == null || conn.State != ConnectionState.Open)
                {
                    MessageBox.Show("Kết nối cơ sở dữ liệu chưa sẵn sàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Gán dữ liệu vào DataGridView
                        dataGridView1.DataSource = dataTable;

                        // Hiển thị thông báo về số lượng dòng
                        int rowCount = dataGridView1.Rows.Count;
                        MessageBox.Show($"Có {rowCount} dòng dữ liệu được tải.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // Kiểm tra nếu người dùng nhấn vào dòng hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán dữ liệu từ DataGridView vào các điều khiển
                textBoxName.Text = row.Cells["ho_ten"].Value?.ToString();
                dateTimePickerNgaySinh.Value = row.Cells["ngay_sinh"].Value != DBNull.Value
                    ? Convert.ToDateTime(row.Cells["ngay_sinh"].Value)
                    : DateTime.Now; // Giá trị mặc định nếu null
                comboBoxPhai.SelectedItem = row.Cells["gioi_tinh"].Value?.ToString();
                textBoxSDT.Text = row.Cells["dien_thoai"].Value?.ToString();
                textBoxEmail.Text = row.Cells["email"].Value?.ToString();
                textBoxSoHoKhau.Text = row.Cells["hokhau_id"].Value?.ToString();
                textBoxSoGiayPhep.Text = row.Cells["giayphep_id"].Value?.ToString();
                textBoxDiaChi.Text = row.Cells["diachi"].Value?.ToString();
            }
        }
    }
}
