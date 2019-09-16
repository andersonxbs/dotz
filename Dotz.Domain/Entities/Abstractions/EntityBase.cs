using System;

namespace Dotz.Domain.Entities.Abstractions
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}
