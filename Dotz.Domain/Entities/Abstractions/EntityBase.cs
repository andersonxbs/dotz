using System;

namespace Dotz.Domain.Entities.Abstractions
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime? DeletedAt { get; set; } = new DateTime();
    }
}
