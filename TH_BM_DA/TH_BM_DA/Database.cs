using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace TH_BM_DA
{
    class Database
    {
        public static OracleConnection Conn;
        public static string Host = "192.168.1.7"; // Host mặc định
        public static string Port = "1521";        // Port mặc định
        public static string Sid = "minh";         // SID mặc định
        public static string User;
        public static string Password;

        // Chỉ nhận user và password từ người dùng
        public static void Set_Database(string host, string port, string sid, string user, string pass)
        {
            Database.Host = host;
            Database.Port = port;
            Database.Sid = sid;
            Database.User = user;
            Database.Password = pass;
        }

        public static bool Connect()
        {
            // Kiểm tra và thiết lập giá trị mặc định nếu Host, Port hoặc Sid chưa có giá trị
            if (string.IsNullOrEmpty(Host))
            {
                Host = "192.168.1.7"; // Host mặc định
            }
            if (string.IsNullOrEmpty(Port))
            {
                Port = "1521"; // Port mặc định
            }
            if (string.IsNullOrEmpty(Sid))
            {
                Sid = "minh"; // SID mặc định
            }

            string connsys = "";

            try
            {
                if (User.ToUpper().Equals("SYS"))
                {
                    connsys = ";DBA Privilege=SYSDBA;";
                }

                // Tạo chuỗi kết nối với các giá trị đã thiết lập
                string connString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = "
                                    + Host + ")(PORT = " + Port + "))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = "
                                    + Sid + ")));User ID=" + User + "; Password = " + Password + connsys;

                Conn = new OracleConnection();
                Conn.ConnectionString = connString;
                Conn.Open();

                return true;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi không thể kết nối
                Console.WriteLine("Lỗi kết nối: " + ex.Message);
                return false;
            }
        }
        public static OracleConnection Get_Connect()
        {
            if (Conn == null)
            {
                Connect();
            }
            return Conn;
        }
        
    }
}
