using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EOTC.Boston.MedhaneAlem.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="User Name is required")]
        public string UserID { get; set; }
        [Required(ErrorMessage="Password is required")]
        [StringLength(30,MinimumLength=6)]
        public string Password { get; set; }
    }
}