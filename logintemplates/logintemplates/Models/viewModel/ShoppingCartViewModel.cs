using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logintemplates.Models.viewModel
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}