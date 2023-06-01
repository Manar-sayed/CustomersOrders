using System.ComponentModel.DataAnnotations;

namespace CustomersOrders.Data.Base
{
    public interface IEntitybase
    {
        [Key]
        public int ID { get; set; }
    }
}
