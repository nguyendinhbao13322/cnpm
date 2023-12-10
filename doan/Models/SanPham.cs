using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int ID { get; set; }
        public string? TenSanPham { get; set; }
        public string? Anh { get; set; }
        public string? MoTa { get; set; }
        public long Gia { get; set; }
        public int? IDDanhMuc { get; set; }
        public bool? TrangThai { get; set; }
    }

}