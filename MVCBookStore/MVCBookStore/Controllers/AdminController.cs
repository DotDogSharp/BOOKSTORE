﻿using MVCBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBookStore.Controllers
{
    public class AdminController : Controller
    {
        // Use DbContext to manage database 
        QLBANSACHEntities1 database = new QLBANSACHEntities1();
        // GET: Admin 
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ADMIN admin)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(admin.UserAdmin))
                    ModelState.AddModelError(string.Empty, "User name không được để trống"); 
                if (string.IsNullOrEmpty(admin.PassAdmin))
                    ModelState.AddModelError(string.Empty, "Password không được để trống"); 

                //Kiểm tra có admin này hay chưa 
                var adminDB = database.ADMINs.FirstOrDefault(ad => ad.UserAdmin == admin.UserAdmin && ad.PassAdmin == admin.PassAdmin);
                if (adminDB == null)
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng"); 
                else
                {
                    Session["Admin"] = adminDB;
                    ViewBag.ThongBao = "Đăng nhập admin thành công";
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }
    }
}