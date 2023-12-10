using Microsoft.EntityFrameworkCore;
using doan.Areas.Admin.Models;
using doan.Models;

namespace doan.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<BaiViet> BaiViets { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<GioHangChiTiet> gioHangChiTiets { get; set; }
        public DbSet<HoaDonAdmin> hoaDonAdmins { get; set; }
    }
}
