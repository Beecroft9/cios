using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIOS.Models
{
    public class EmailVer
    {
        [DisplayName("Please Enter Your Email")]
        //[RegularExpression("\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}\b", ErrorMessage = "Invalid Email Format")]
        public string email { get; set; }
    }
}