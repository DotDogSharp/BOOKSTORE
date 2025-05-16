using System;
using MVCBookStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBookStore.Controllers
{
    public class BookStoreController : Controller
    {
        // Use DbContext to manage database 
        QLBANSACHEntities1 database = new QLBANSACHEntities1();

        private List<SACH> LaySachMoi(int soluong)
        {
            // Sắp xếp sách theo ngày cập nhật giảm dần, lấy đúng số lượng sách cần 
            // Chuyển qua dạng danh sách kết quả đạt được 
            return database.SACHes.OrderByDescending(sach => sach.Ngaycapnhat).Take(soluong).ToList();
        }

        // GET: BookStore 
        public ActionResult Index()
        {
            // Giả sử cần lấy 5 quyển sách mới cập nhật 
            var dsSachMoi = LaySachMoi(5);
            return View(dsSachMoi);
        }
        public ActionResult LayChuDe()
        {
            var dsChuDe = database.CHUDEs.ToList();
            return PartialView(dsChuDe);
        }
        public ActionResult LayNhaXuatBan()
        {
            var dsNhaXB = database.NHAXUATBANs.ToList();
            return PartialView(dsNhaXB);
        }

    }
}