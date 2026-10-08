using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InputDataUsingHtmlHelper.Views
{
    public class LogIn
    {
        [Required(ErrorMessage = " Enter the UserName")]
        [StringLength(20, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [Display(Name ="Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string ImagePath{ get; set; }

        }

}
