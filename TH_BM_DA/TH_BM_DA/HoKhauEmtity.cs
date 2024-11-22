using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH_BM_DA
{
    class HoKhauEmtity
    {
        public int HoKhauId { get; set; } // hokhau_id
        public string DiaChi { get; set; } // dia_chi
        public string Phuong { get; set; } // phuong
        public string Quan { get; set; } // quan
        public string ThanhPho { get; set; } // thanh_pho
        public string Tinh { get; set; } // tinh
        public DateTime NgayTao { get; set; } // ngay_tao

        // Phương thức để hiển thị thông tin Hộ Khẩu
        public override string ToString()
        {
            return $"Hộ khẩu ID: {HoKhauId}, Địa chỉ: {DiaChi}, Phường: {Phuong}, Quận: {Quan}, Tỉnh: {Tinh}, Ngày Tạo: {NgayTao:yyyy-MM-dd}";
        }
    }
}
