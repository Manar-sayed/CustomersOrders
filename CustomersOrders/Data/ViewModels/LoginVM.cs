using System.ComponentModel.DataAnnotations;

namespace CustomersOrders.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public string FullName { get; set; }
    }
}
