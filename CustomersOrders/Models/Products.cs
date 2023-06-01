using CustomersOrders.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersOrders.Models
{
    public class Products: IEntitybase
    {
        [Key]
        public int ID { get; set; }


        [Required(ErrorMessage = "Full Name is required ")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Full Name must be in 5,100 characters...")]
        public String? Name { get; set; }
        [Required(ErrorMessage ="Price is required")]
        [Range(0,9999999999999999.99, ErrorMessage = "Price must be between 0 and 9999999999999999.99.")]
        public decimal Price { get; set; }

        [ForeignKey("CustomerID")]
        public int CustomerID { get; set; }
        public Customers ?Customer { get; set; }



    }
}
