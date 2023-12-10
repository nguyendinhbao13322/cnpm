using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("AdminMenu")]
    public class AdminMenu
    {
        [Key]
        public int AdminMenuID { get; set; }
        public string? TenMenu { get; set; }
        public int MenuCha { get; set; }
        public int CapDo { get; set; }
        public string? AreaName { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public int ThuTu { get; set; }
        public bool? TrangThai { get; set; }
        public string? TenTat { get; set; }
    }

}