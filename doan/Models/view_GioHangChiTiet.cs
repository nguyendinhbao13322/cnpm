using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("view_GioHangChiTiet")]
    public class GioHangChiTiet
    {
        [Key]
        public int IDSanPham { get; set; }
        public int? SoLuong { get; set; }
        public long Gia { get; set; }
        public int IDNguoiDung { get; set; }
        public string? TenSanPham { get; set; }
        public string? Anh { get; set; }
        public string? HoTen { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
    }

}