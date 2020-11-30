using logintemplates.Models;
using logintemplates.Models.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace logintemplates.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ManageProduct()
        {
            return View();
        }
        public JsonResult GetData()
        {
            using (IsmtdbEntities db = new IsmtdbEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                List<ProductViewModel> lstitem = new List<ProductViewModel>();
                var lst = db.tblproducts.Include("tblCategory").ToList();
                foreach (var item in lst)
                {
                    lstitem.Add(new ProductViewModel() { ProductId = item.ProductId, CategoryName = item.tblcategory.CategoryName, ProductName = item.ProductName, UnitPrice = item.UnitPrice, SellingPrice = item.SellingPrice, Photo = item.Photo });
                }
                return Json(new { data = lstitem }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                using (IsmtdbEntities db = new IsmtdbEntities())
                {
                    ViewBag.Categories = db.tblcategories.ToList();
                    ViewBag.Action = "Create New Product";
                    return View(new ProductViewModel());
                }
            }
            else
            {
                using (IsmtdbEntities db = new IsmtdbEntities())
                {
                    ViewBag.Action = "Edit Product";
                    ViewBag.Categories = db.tblcategories.ToList();
                    tblproduct item = db.tblproducts.Where(i => i.ProductId == id).FirstOrDefault();
                    ProductViewModel itemvm = new ProductViewModel();
                    itemvm.ProductId = item.ProductId;
                    itemvm.CategoryId = Convert.ToInt32(item.CategoryId);
                    itemvm.ProductName = item.ProductName;
                    itemvm.UnitPrice = item.UnitPrice;
                    itemvm.SellingPrice = item.SellingPrice;
                    
                    itemvm.Photo = item.Photo;
                    itemvm.IsSpecial = item.IsSpecial;


                    return View(itemvm);
                }
            }
        }

        [HttpPost]

        public ActionResult AddOrEdit(ProductViewModel ivm)
        {
            using (IsmtdbEntities db = new IsmtdbEntities())
            {
                if (ivm.ProductId == 0)
                {
                    tblproduct itm = new tblproduct();

                    itm.CategoryId = Convert.ToInt32(ivm.CategoryId);
                    itm.ProductName = ivm.ProductName;
                    itm.UnitPrice = ivm.UnitPrice;
                    itm.SellingPrice = ivm.SellingPrice;
                    itm.IsSpecial = ivm.IsSpecial;

                    HttpPostedFileBase fup = Request.Files["Photo"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/ProductImages/" + fup.FileName));
                            itm.Photo = fup.FileName;
                        }
                    }



                    db.tblproducts.Add(itm);
                    db.SaveChanges();
                    ViewBag.Message = "Created Successfully";
                }
                else
                {
                    tblproduct itm = db.tblproducts.Where(i => i.ProductId == ivm.ProductId).FirstOrDefault();
                    itm.CategoryId = Convert.ToInt32(ivm.CategoryId);
                    itm.ProductName = ivm.ProductName;
                    itm.UnitPrice = ivm.UnitPrice;
                    itm.SellingPrice = ivm.SellingPrice;
                    itm.IsSpecial = ivm.IsSpecial;
                    HttpPostedFileBase fup = Request.Files["SmallImage"];
                    if (fup != null)
                    {
                        if (fup.FileName != "")
                        {
                            fup.SaveAs(Server.MapPath("~/ProductImages/" + fup.FileName));
                            itm.Photo = fup.FileName;
                        }
                    }



                    db.SaveChanges();
                    ViewBag.Message = "Updated Successfully";

                }
                ViewBag.Categories = db.tblcategories.ToList();
                return View(new ProductViewModel());

            }


        }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            using (IsmtdbEntities db = new IsmtdbEntities())
            {
                tblproduct sm = db.tblproducts.Where(x => x.ProductId == id).FirstOrDefault();
                db.tblproducts.Remove(sm);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
   