using Dotz.Domain.Entities.Abstractions;

namespace Dotz.Domain.Entities
{
    public class Account : EntityBase<long>
    {
        public int PointsBalance { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
