using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logintemplates.Models
{
    public static class ItemDB
    {

        public static List<tblproduct> GetAllSpecialItem()
        {
            using (var context = new IsmtdbEntities())
            {
                return context.tblproducts.OrderByDescending(e => e.ProductId).Where(s => s.IsSpecial == true).Take(4).ToList();
            }
        }
        public static List<tblproduct> GetAllItems()
        {
            using (var context = new IsmtdbEntities())
            {
                return context.tblproducts.Take(4).ToList();
            }
        }
    }
}