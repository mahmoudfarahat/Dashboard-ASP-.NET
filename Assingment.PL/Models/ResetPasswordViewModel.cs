using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assingment.PL.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        [MinLength(6, ErrorMessage = "Miniym Length is 6 chars")]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Password mismatches")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
