using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{
    //View của 4 bảng HoaDon, HoaDonChiTiet, NguoiDung, SanPham
    [Table("HoaDonAdmin")]
    public class HoaDonAdmin
    {
        [Key]
        public int IDHoaDon { get; set; }
        public int TrangThai { get; set; }
        public int IDNguoiDung { get; set; }
        public DateTime NgayDat { get; set; }
        public string? TinNhan { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public string? TenNguoiNhan { get; set; }
        public string? HoTen { get; set; }
        public string? TenSanPham { get; set; }
        public string? Anh { get; set; }
        public int IDSanPham { get; set; }
        public long Gia { get; set; }
        public int SoLuong { get; set; }
    }

}