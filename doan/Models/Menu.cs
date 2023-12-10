using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{

    [Table("Menus")]
    public class Menu
    {
        [Key]
        public int ID { get; set; }
        public string? Ten { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public int ThuTu { get; set; }
        public bool? TrangThai { get; set; }
    }

}