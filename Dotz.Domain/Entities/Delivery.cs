using Dotz.Domain.Entities.Abstractions;
using Dotz.Domain.Enumerators;
using Dotz.Domain.ValueObjects;
using System;

namespace Dotz.Domain.Entities
{
    public class Delivery : EntityBase<long>
    {
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual DeliveryAddress Address { get; set; }
        public DateTime DueDate { get; set; }
        public DeliveryStatus Status { get; set; } = DeliveryStatus.Processing;
    }
}
