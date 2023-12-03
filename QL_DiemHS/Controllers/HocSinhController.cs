using Microsoft.AspNetCore.Mvc;
using QL_DiemHS.Data;
using QL_DiemHS.Models;

namespace QL_DiemHS.Controllers
{
	public class HocSinhController : Controller
	{
		private readonly ApplicationDbContext _db;
		public HocSinhController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Home()
		{
			IEnumerable<HocSinh> hocsinh = _db.HocSinh.ToList();
			return View(hocsinh);
		}
		[HttpGet]
		public IActionResult Create_HocSinh()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create_HocSinh(HocSinh hocsinh)
		{
			if (ModelState.IsValid)
			{
				_db.HocSinh.Add(hocsinh);
				_db.SaveChanges();
				return RedirectToAction("Home");
			}
			return View();
		}

		[HttpGet]
		public IActionResult Edit_HocSinh(int mahs)
		{
			if (mahs == 0)
			{
				return NotFound();
			}
			var hocsinh = _db.HocSinh.Find(mahs);
			return View(hocsinh);
		}
		[HttpPost]
		public IActionResult Edit_HocSinh(HocSinh hocsinh)
		{
			if (ModelState.IsValid)
			{
				_db.HocSinh.Update(hocsinh);
				_db.SaveChanges();
				return RedirectToAction("Home");
			}
			return View();
		}

		
		public IActionResult Detele(int mahs)
		{
			var hocsinh = _db.HocSinh.Find(mahs);
			_db.HocSinh.Remove(hocsinh);
			_db.SaveChanges();
			return RedirectToAction("Home"); 
		}
	}
}
