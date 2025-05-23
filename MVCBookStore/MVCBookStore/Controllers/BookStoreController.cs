﻿using System;
using MVCBookStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

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
        public ActionResult Index(int? page)
        {
            //Tạo biến cho biết số sách mỗi trang
            int pageSize = 5;
            //Tạo biến số trang
            int pageNum = (page ?? 1);

            //Giả sử cần lấy 15 quyển sách mới cập nhật
            var dsSachMoi = LaySachMoi(15);
            return View(dsSachMoi.ToPagedList(pageNum, pageSize ));
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
        public ActionResult SPTheoChuDe(int id)
        {
            //Lấy các sách theo mã chủ đề được chọn
            var dsSachTheoChuDe = database.SACHes.Where(sach => sach.MaCD == id).ToList();

            //Trả về View để render các sách trên
            //(tái sử dụng View Index ở trên, truyền vào danh sách)
            return View("Index", dsSachTheoChuDe);
        }
        public ActionResult SPTheoNXB(int id)
        {
            var dsSachNXB = database.SACHes.Where(sach => sach.MaNXB == id).ToList();

            //Trả về View để render các sách trên
            //(tái sừ dụng View Index ở trên, truyền vào danh sách)
            return View("Index", dsSachNXB);
        }

        public ActionResult Details(int id)
        {
            //Lấy sách có mã tương ứng
            var sach = database.SACHes.FirstOrDefault(s => s.Masach == id);
            return View(sach);
        }
    }
}