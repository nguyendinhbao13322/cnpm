using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("HoaDonChiTiet")]
    public class HoaDonChiTiet
    {
        [Key]
        public int ID { get; set; }
        public int IDHoaDon { get; set; }
        public int IDSanPham { get; set; }
        public int Gia { get; set; }
        public int SoLuong { get; set; }
    }

}