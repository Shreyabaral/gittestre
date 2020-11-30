using logintemplates.Models;
using logintemplates.Models.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace logintemplates.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageAccountController : Controller
    {
       
       
            // GET: AdminUser
             IsmtdbEntities _db = new IsmtdbEntities();
            public ActionResult ManageUser()
            {
                return View();
            }
            public JsonResult GetData()
            {
                using (IsmtdbEntities db = new IsmtdbEntities())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    List<UserViewModel> lstitem = new List<UserViewModel>();
                    var lst = db.tblUsers.ToList();
                    foreach (var item in lst)
                    {
                        lstitem.Add(new UserViewModel() { UserId = item.Userid, Username = item.UserName });
                    }
                    return Json(new { data = lstitem }, JsonRequestBehavior.AllowGet);
                }
            }
            public ActionResult AddOrEdit()
            {
                return View();
            }
            [HttpPost]

            public ActionResult AddOrEdit(UserViewModel uv)
            {
                tblUser tb = new tblUser();
                tb.UserName = uv.Username;
                tb.Password = uv.Password;

               
                _db.tblUsers.Add(tb);
                _db.SaveChanges();

                UserRole ud = new UserRole();
                ud.Userid = tb.Userid;
                ud.UserRoleId = 1;
                _db.UserRoles.Add(ud);
                _db.SaveChanges();
                ViewBag.Message = "User Created Successfully";


                return View();
            }
            [HttpPost]

            public ActionResult Delete(int id)
            {
                using (IsmtdbEntities db = new IsmtdbEntities())
                {
                    tblUser sm = db.tblUsers.Where(x => x.Userid == id).FirstOrDefault();
                    db.tblUsers.Remove(sm);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }