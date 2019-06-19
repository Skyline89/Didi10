using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Didi10Rugby.Models.Accounts
{
    public class Login
    {
        [Required(ErrorMessage = "შეავსეთ ელ.პოსტის ველი")]
        public string Email { set; get; }
        [Required(ErrorMessage = "შეავსეთ პაროლის ველი")]
        public string Password { set; get; }

    }
}