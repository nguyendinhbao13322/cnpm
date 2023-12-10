using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using doan.Models;
using doan.Utilities;

namespace doan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CuaHang(int? iddanhmuc)
        {
            var sp= _context.SanPhams.ToList();
            ViewBag.TenDanhMuc = "Tất cả";

            if (iddanhmuc != null)
            {
                sp = _context.SanPhams.Where(x => x.IDDanhMuc == iddanhmuc).ToList();
                ViewBag.TenDanhMuc = _context.DanhMucs.Find(iddanhmuc).TenDanhMuc;
            }

            ViewBag.dsdm = _context.DanhMucs.ToList();

            return View(sp);
        }

        public IActionResult ChiTietSanPham(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var sp = _context.SanPhams.Find(id);
            if (sp == null)
            {
                return NotFound();
            }

            return View(sp);
        }

        public IActionResult DSBaiViet()
        {
            var dsBaiViet = _context.BaiViets.ToList();
            return View(dsBaiViet);
        }

        public IActionResult BaiVietChiTiet(int id)
        {
            var baiviet = _context.BaiViets.Find(id);
            if (baiviet == null)
            {
                return NotFound();
            }
            return View(baiviet);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult HienThiDangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult XuLyDangKy(NguoiDung nd)
        {
            nd.Admin = false;
            nd.TrangThai = true;
            nd.MatKhau = Functions.MD5Password(nd.MatKhau);
            _context.NguoiDungs.Add(nd);
            _context.SaveChanges();
            TempData["msg"] = "Đăng ký thành công.";
            return RedirectToAction("HienThiDangNhap");
        }

        public IActionResult HienThiDangNhap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult XuLyDangNhap(NguoiDung nd)
        {
            string password = Functions.MD5Password(nd.MatKhau);
            var nguoiDung = _context.NguoiDungs.Where(nd1 => nd1.TaiKhoan == nd.TaiKhoan && nd1.MatKhau == password)
                            .FirstOrDefault();

            if (nguoiDung == null)
            {
                TempData["msg"] = "Tài khoản hoặc mật khẩu không chính xác.";
                return RedirectToAction("HienThiDangNhap");
            }

            Functions._UserID = nguoiDung.ID;
            Functions._UserName = nguoiDung.HoTen ?? "";

            return RedirectToAction("Index");
        }

        public IActionResult DangXuat()
        {
            Functions._UserID = 0;
            Functions._UserName = String.Empty;
            return RedirectToAction("HienThiDangNhap");
        }

        public IActionResult GioHang()
        {
            if (!Functions.IsLogin())
            {
                TempData["msg"] = "Vui lòng đăng nhập để sử dụng tính năng này.";
                return RedirectToAction("HienThiDangNhap");
            }

            var gioHang = _context.gioHangChiTiets.Where(gh => gh.IDNguoiDung == Functions._UserID).ToList();
            return View(gioHang);
        }
        [HttpPost]
        public IActionResult ThemVaoGioHang(int idSanPham, int soLuong)
        {
            if (!Functions.IsLogin())
            {
                TempData["msg"] = "Vui lòng đăng nhập để sử dụng tính năng này.";
                return RedirectToAction("HienThiDangNhap");
            }

            var sanpham = _context.SanPhams.Find(idSanPham);

            if (sanpham == null)
            {
                return NotFound();
            }

            var sanphamTrongGiohang = _context.GioHangs.Where(gh => gh.IDSanPham == idSanPham && gh.IDNguoiDung == Functions._UserID).FirstOrDefault();
            if (sanphamTrongGiohang == null)
            {
                var spTrongGio = new GioHang();
                spTrongGio.IDSanPham = idSanPham;
                spTrongGio.IDNguoiDung = Functions._UserID;
                spTrongGio.SoLuong = soLuong;
                spTrongGio.Gia = sanpham.Gia;
                _context.GioHangs.Add(spTrongGio);
                _context.SaveChanges();
            }
            else
            {
                sanphamTrongGiohang.SoLuong += soLuong;
                _context.GioHangs.Update(sanphamTrongGiohang);
                _context.SaveChanges();
            }

            return RedirectToAction("GioHang");
        }

        public IActionResult XacNhanDatHang(string TenNguoiNhan, string SoDienThoai, string DiaChi, string? TinNhan)
        {
            if (!Functions.IsLogin())
            {
                TempData["msg"] = "Vui lòng đăng nhập để sử dụng tính năng này.";
                return RedirectToAction("HienThiDangNhap");
            }

            var hoadon = new HoaDon();
            hoadon.IDNguoiDung = Functions._UserID;
            hoadon.NgayDat = DateTime.Now;
            hoadon.TenNguoiNhan = TenNguoiNhan;
            hoadon.SoDienThoai = SoDienThoai;
            hoadon.DiaChi = DiaChi;
            hoadon.TrangThai = 0;
            hoadon.TinNhan = TinNhan ?? "";

            _context.HoaDons.Add(hoadon);
            _context.SaveChanges();

            var productInCart = _context.GioHangs.Where(c => c.IDNguoiDung == Functions._UserID).ToList();
            foreach (var item in productInCart)
            {
                var orderDetail = new HoaDonChiTiet();
                orderDetail.IDHoaDon = hoadon.ID;
                orderDetail.IDSanPham = item.IDSanPham;
                orderDetail.SoLuong = (int)item.SoLuong;
                orderDetail.Gia = (int)item.Gia;
                _context.HoaDonChiTiets.Add(orderDetail);
                _context.SaveChanges();

                _context.GioHangs.Remove(item);
                _context.SaveChanges();
            }

            TempData["msgdathang"] = "Đặt hàng thành công";
            return RedirectToAction("GioHang");
        }

        public IActionResult QuanLyDonHang()
        {
            if (!Functions.IsLogin())
            {
                TempData["msg"] = "Yêu cầu đăng nhập để sử dụng chức năng này!";
                return RedirectToAction("HienThiDangNhap");
            }

            var DSHoaDon = _context.hoaDonAdmins
                            .Where(x => x.IDNguoiDung == Functions._UserID)
                            .ToList();
            return View(DSHoaDon);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}