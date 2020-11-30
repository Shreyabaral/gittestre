using logintemplates.Models;
using logintemplates.Models.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace logintemplates.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult ManageCategory()
        {
            return View();
        }

        public JsonResult GetData()
        {
            using (IsmtdbEntities db = new IsmtdbEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                List<CategoryViewModel> lst = new List<CategoryViewModel>();
                var catList = db.tblcategories.ToList();
                foreach (var item in catList)
                {
                    lst.Add(new CategoryViewModel() { CategoryId = item.CategoryId, CategoryName = item.CategoryName });
                }
                return Json(new { data = lst }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (IsmtdbEntities db = new IsmtdbEntities())
                {
                    ViewBag.Action = "New Category";
                    return View(new CategoryViewModel());
                }
            }
            else
            {
                using (IsmtdbEntities db = new IsmtdbEntities())
                {
                    CategoryViewModel sub = new CategoryViewModel();
                    var menu = db.tblcategories.Where(x => x.CategoryId == id).FirstOrDefault();
                    sub.CategoryId = menu.CategoryId;
                    sub.CategoryName = menu.CategoryName;
                    ViewBag.Action = "Edit Category";
                    return View(sub);
                }
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(CategoryViewModel sm)
        {
            using (IsmtdbEntities db = new IsmtdbEntities())
            {
                if (sm.CategoryId == 0)
                {
                    tblcategory tb = new tblcategory();
                    tb.CategoryName = sm.CategoryName;
                    db.tblcategories.Add(tb);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    tblcategory tbm = db.tblcategories.Where(m => m.CategoryId == sm.CategoryId).FirstOrDefault();
                    tbm.CategoryName = sm.CategoryName;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (IsmtdbEntities db = new IsmtdbEntities())
            {
                tblcategory sm = db.tblcategories.Where(x => x.CategoryId == id).FirstOrDefault();
                db.tblcategories.Remove(sm);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}