using Dotz.Domain.Entities.Abstractions;
using Dotz.Domain.Services;
using Dotz.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotz.Domain.Entities
{
    public class Order : EntityBase<long>
    {
        public int TotalPoints { get; set; }

        public virtual ICollection<OrderItem> Items { get; internal set; } = new List<OrderItem>();

        public virtual Delivery Delivery { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public void SetItems(ICollection<OrderItem> items)
        {
            Items = items;

            TotalPoints = Items.Sum(d => d.Points);

            Delivery = new Delivery
            {
                DueDate = DeliveryServices.EstimateDueDateForAddress(User.Address),
                Address = DeliveryAddress.FromEntity(User.Address)
            };
        }
    }
}
