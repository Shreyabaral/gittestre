using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logintemplates.Models.viewModel
{
    public class LoginViewModel
    {
        public int Userid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public bool RememberMe { get;  set; }
    }
}