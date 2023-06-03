using System.ComponentModel.DataAnnotations;

namespace CustomersOrders.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        [MinLength(3,ErrorMessage ="Full name must be more than 3 letters...")]
        public string ?FullName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
        public string ?EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ?Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ?ConfirmPassword { get; set; }
    }
}
