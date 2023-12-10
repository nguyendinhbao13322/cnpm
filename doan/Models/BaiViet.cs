using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("BaiViet")]
    public class BaiViet
    {
        [Key]
        public int ID { get; set; }
        public string? TieuDe { get; set; }
        public string? NoiDung { get; set; }
        public string? Anh { get; set; }
        public bool? TrangThai { get; set; }
    }

}