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
    public partial class Login : Form
    {
        private Database dbConnector;
        public Login()
        {
            InitializeComponent();
            btnLO.Visible = false;
            txtPW.PasswordChar = '*';
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
           
        }
        bool check_Textbox(string user, string pass)
        {
            if (string.IsNullOrWhiteSpace(user)) 
            {
                MessageBox.Show("Chưa điền thông tin UserName");
                txtU.Focus();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(pass)) 
            {
                MessageBox.Show("Chưa điền thông tin Password");
                txtPW.Focus();
                return false;
            }
            return true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string user = txtU.Text.Trim(); 
            string pass = txtPW.Text.Trim(); 

            
            if (check_Textbox(user, pass))
            {
                
                Database.Set_Database(Database.Host, Database.Port, Database.Sid, user, pass);

                if (Database.Connect())
                {
                    OracleConnection c = Database.Get_Connect(); 
                    MessageBox.Show("Đăng nhập thành công");
                    ViewMain viewmain = new ViewMain();

                    // Ẩn form hiện tại
                    this.Hide();

                    // Hiển thị form mới
                    viewmain.ShowDialog();


                    
                    btnLO.Visible = true;
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
        }

        private void btnLO_Click(object sender, EventArgs e)
        {
            if (Database.Conn != null && Database.Conn.State == ConnectionState.Open)
            {
                Database.Conn.Close();
                MessageBox.Show("Đã đóng kết nối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnLO.Visible = false;
            }
            else
            {
                MessageBox.Show("Không có kết nối nào để đóng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
