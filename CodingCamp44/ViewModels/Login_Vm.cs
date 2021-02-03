using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.ViewModels
{
    public class Login_VM
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
