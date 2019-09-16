using System.ComponentModel.DataAnnotations;

namespace Dotz.Api.Models.Order
{
    public class OrderItemInputModel
    {
        [Required]
        public long ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
