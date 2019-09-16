using Dotz.Domain.Enumerators;
using Dotz.Domain.ValueObjects;
using System;

namespace Dotz.Api.Models.Order
{
    public class DeliveryModel
    {
        public DeliveryAddress Address { get; set; }
        public DateTime DueDate { get; set; }
        public DeliveryStatus Status { get; set; }
    }
}
