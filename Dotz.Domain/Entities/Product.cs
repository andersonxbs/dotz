﻿using Dotz.Domain.Entities.Abstractions;

namespace Dotz.Domain.Entities
{
    public class Product : EntityBase<long>
    {
        public string Title { get; set; }
        public int Points { get; set; }
        public int Quantity { get; set; }
    }
}
