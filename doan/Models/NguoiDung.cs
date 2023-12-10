using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        public int ID { get; set; }
        public string? HoTen { get; set; }
        public string? TaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public string? SoDienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string? Email { get; set; }
        public bool Admin { get; set; }
        public bool? TrangThai { get; set; }
    }

}