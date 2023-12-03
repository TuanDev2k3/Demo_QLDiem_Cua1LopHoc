using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_DiemHS.Data;
using QL_DiemHS.Models;

namespace QL_DiemHS.Controllers
{
    public class MonHocController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MonHocController(ApplicationDbContext db)
        {
            _db = db;
        }
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Mon(int monId)
        {
            var mon = _db.MonHoc.Find(monId);
            var dsHocsinh = _db.DiemSo.Include("HocSinh").Where(x => x.MonHoc.MaMon == monId).ToList();
            ViewBag.DSHocSinh = dsHocsinh;
            ViewBag.Mon = mon;
            return View();
        }

        [HttpGet]
        public IActionResult Add_Student(int id)
        {
            ViewBag.ID = id;
            return View();
        }
        [HttpPost]
        public IActionResult Add_Student(DiemSo diemso)
        {
            var hocsinh = _db.HocSinh.Find(diemso.MaHS);
			var diem = _db.DiemSo.Find(diemso.MaMon, diemso.MaHS);
            if (hocsinh == null || diem != null)
			{
				return RedirectToAction("Mon", new { monId = diemso.MaMon });
			}
			diemso.Diem15p = 0;
			diemso.Diem1t = 0;
			diemso.DiemGk = 0;
			diemso.DiemCk = 0;
			diemso.DiemTrungBinh = 0;
			_db.DiemSo.Add(diemso);
			_db.SaveChanges();
			return RedirectToAction("Mon", new { monId = diemso.MaMon });
		}
		[HttpGet]
		public IActionResult NhapDiem(int monId, int mahs)
		{
			var diemso = _db.DiemSo.Find(monId, mahs);
			diemso.HocSinh = _db.HocSinh.Find(mahs);
			if (diemso == null)
			{
				// Xử lý trường hợp không tìm thấy bản ghi
				return NotFound();
			}
			
			return View(diemso);
		}

		
		[HttpPost]
		public IActionResult NhapDiem(DiemSo diemso)
		{
			diemso.DiemTrungBinh = Math.Round(((diemso.Diem15p + diemso.Diem1t)/2.0*0.5) + (diemso.DiemGk*0.2) + (diemso.DiemCk*0.3), 1);
			_db.DiemSo.Update(diemso);
			_db.SaveChanges();

			// Nếu dữ liệu không hợp lệ, hiển thị lại form với thông báo lỗi
			return RedirectToAction("Mon", new { monId = diemso.MaMon });
		}

		//==== Xoa
		public IActionResult Delete(int monId, int mahs)
		{
			DiemSo diemso = _db.DiemSo.Find(monId, mahs);
			_db.DiemSo.Remove(diemso);
			_db.SaveChanges();
			return RedirectToAction("Mon", new { monId });
		}

	}
}
