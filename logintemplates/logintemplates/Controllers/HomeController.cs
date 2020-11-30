using logintemplates.Models;
using logintemplates.Models.viewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace logintemplates.Controllers
{
    public class HomeController : Controller
    {
        IsmtdbEntities db = new IsmtdbEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            return View();
        }
            public ActionResult ProductList(string search, int? page, int id = 0)
        {

            if (id != 0)
            {

                return View(db.tblproducts.Where(p => p.CategoryId == id).ToList().ToPagedList(page ?? 1, 4));
            }
            else
            {
                if (search != "")
                {
                    return View(db.tblproducts.Where(x => x.ProductName.Contains(search) || x.ProductName.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 4));
                }
                else
                {
                    return View(db.tblproducts.ToList().ToPagedList(page ?? 1, 4));
                }

            }

        }
        public ActionResult ViewItem(int id)
        {
            return PartialView("_ViewItem", db.tblproducts.Find(id));
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserViewModel uv)
        {
            tblUser tbl = db.tblUsers.Where(u => u.UserName == uv.Username).FirstOrDefault();
            if (tbl != null)
            {
                return Json(new { success = false, message = "User Already Register" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                tblUser tb = new tblUser();
                tb.UserName = uv.Username;
                tb.Password = uv.Password;
                db.tblUsers.Add(tb);
                db.SaveChanges();

                UserRole ud = new UserRole();
                ud.Userid = tb.Userid;
                ud.UserRoleId = 2;
                db.UserRoles.Add(ud);
                db.SaveChanges();
                return Json(new { success = true, message = "User Register Successfully" }, JsonRequestBehavior.AllowGet);
                
            }
        }

        }
    }