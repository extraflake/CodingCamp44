using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingCamp44.ViewModels
{
    public class ChangePasswordVM
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }

        [Compare("NewPassword"), Required]
        public string ConfirmPassword { get; set; }
    }
}
