using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH_BM_DA
{
    internal class CongDanEmtity
    {
        public int CongDanId { get; set; } // congdan_id
        public string HoTen { get; set; }  // ho_ten
        public DateTime NgaySinh { get; set; } // ngay_sinh
        public string GioiTinh { get; set; } // gioi_tinh (Nam hoặc Nữ)
        public string DienThoai { get; set; } // dien_thoai
        public string Email { get; set; } // email
        public int? HoKhauId { get; set; } // hokhau_id (nullable)
        public int? GiayPhepId { get; set; } // giayphep_id (nullable)
        public string DiaChi { get; set; } // diachi
    }
}
