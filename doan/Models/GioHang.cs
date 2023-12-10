using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("GioHang")]
    public class GioHang
    {
        [Key]
        public int ID { get; set; }
        public int IDSanPham { get; set; }
        public int? SoLuong { get; set; }
        public long Gia { get; set; }
        public int IDNguoiDung { get; set; }
    }

}