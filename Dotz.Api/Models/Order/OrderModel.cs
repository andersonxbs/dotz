using Dotz.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Dotz.Api.Models.Order
{
    public class OrderModel
    {
        public long Id { get; set; }

        public int TotalPoints { get; set; }

        public ICollection<OrderItemModel> Items { get; internal set; } = new List<OrderItemModel>();

        public DeliveryModel Delivery { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
