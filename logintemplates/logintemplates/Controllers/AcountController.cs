using logintemplates.Models;
using logintemplates.Models.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace logintemplates.Controllers
{
    public class AcountController : Controller
    {
        IsmtdbEntities _db = new IsmtdbEntities();
        // GET: Acount
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel l, string ReturnUrl = "")
        {
            using (IsmtdbEntities db = new IsmtdbEntities())
            {
                var users = db.tblUsers.Where(a => a.UserName == l.UserName && a.Password == l.Password).FirstOrDefault();
                if (users != null)
                {
                    
                    Session.Add("username", users.UserName);
                    FormsAuthentication.SetAuthCookie(l.UserName, true);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        Session.Add("userid", users.Userid);
                        if (users.UserRoles.Where(r => r.RoleId == 1).FirstOrDefault() != null)
                        {
                            return RedirectToAction("DashBoard", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }


                    }
                }
                else
                {

                    ModelState.AddModelError("", "Invalid User");

                }
            }
            return View();


        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Acount");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ChangePassword()
        {



            return View();
        }
        [HttpPost]

        public ActionResult ChangePassword(ChangePasswordViewModel ch)
        {
            int userid = Convert.ToInt32(Session["userid"].ToString());

            tblUser us = _db.tblUsers.Where(u => u.Userid == userid && u.Password == ch.OldPassword).FirstOrDefault();
            if (us != null)
            {
                us.Password = ch.NewPassword;
                _db.SaveChanges();

            }
            else
            {
                ViewBag.Message = "Wrong Old Password";
            }
            return Json(new { success = true, message = "Password Changed Successfully" }, JsonRequestBehavior.AllowGet);
        }

    }


}