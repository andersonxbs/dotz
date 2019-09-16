using Dotz.Domain.Entities.Abstractions;

namespace Dotz.Domain.Entities
{
    public class OrderItem : EntityBase<long>
    {
        public virtual Order Order { get; set; }

        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public int UnityPoints { get; set; }

        public int Points => Quantity * UnityPoints;
    }
}
