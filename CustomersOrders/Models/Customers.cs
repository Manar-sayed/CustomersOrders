using CustomersOrders.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace CustomersOrders.Models
{
    public class Customers:IEntitybase
    {
        [Key]
        public int ID { get; set; }
        

        [Required(ErrorMessage ="Full Name is required ")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Full Name must be in 5,100 characters...")]
        public String ?FullName { get; set; }


        [Required(ErrorMessage ="Mobile Number is required"),RegularExpression(@"^01[0125][0-9]{8}$",ErrorMessage ="Invalid Mobile Number Formate")]
        public String ?Mobile { get; set; }


        [StringLength(250,ErrorMessage = "Address  cannot exceed 250 characters")]
        public String ?Address { get; set; }

        public List<Products> ?Products { get; set; }

    }
}
