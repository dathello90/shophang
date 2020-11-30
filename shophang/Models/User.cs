using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shophang.Models
{
    public class User:IdentityUser<int>
    {

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        [Display(Name ="Địa chỉ")]
        public string Address { get; set; }
        
        public bool Status { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
