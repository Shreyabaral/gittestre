using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logintemplates.Models
{
    public class MyMenu
    {
        public static List<tblcategory> GetMenus()
        {
            using (var context = new IsmtdbEntities())
            {
                return context.tblcategories.ToList();
            }
        }
      
    }
}