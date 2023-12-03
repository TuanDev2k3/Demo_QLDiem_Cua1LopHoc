using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_DiemHS.Data;
using QL_DiemHS.Models;

namespace QL_DiemHS.Controllers
{
	public class TongKetController : Controller
	{
		private readonly ApplicationDbContext _db;
		public TongKetController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Home()
		{
			IEnumerable<HocSinh> dsHocSinh = _db.HocSinh.ToList();
			return View(dsHocSinh);
		}

		public IActionResult Details(int mahs)
		{
			var hocsinh = _db.HocSinh.Find(mahs);
			var dsMonHoc = _db.DiemSo.Include("MonHoc").Where(x => x.HocSinh.MaHS == mahs).ToList();
			ViewBag.DsMonHoc = dsMonHoc;
			ViewBag.HocSinh = hocsinh;

			// Tinh diem TongKet va XepLoai
			double TongTB = 0;
			for (int i = 0; i < dsMonHoc.Count;i++)
			{
				TongTB += dsMonHoc[i].DiemTrungBinh;
			}
			TongTB = Math.Round(TongTB / dsMonHoc.Count, 1);
			if (TongTB >= 8.5) { ViewBag.XepLoai = "Giỏi"; }
			else if (TongTB >= 7.5) { ViewBag.XepLoai = "Khá"; }
			else if (TongTB >= 6.5) { ViewBag.XepLoai = "Trung bình"; }
			else  if (TongTB >= 4) { ViewBag.XepLoai = "Yếu"; }
			else { ViewBag.XepLoai = "Học lại"; }
			ViewBag.TongTB = TongTB;
			return View();
		}
	}
}
