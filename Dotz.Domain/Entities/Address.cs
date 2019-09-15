using Dotz.Domain.Entities.Abstractions;

namespace Dotz.Domain.Entities
{
    public class Address : EntityBase<long>
    {
        public string ContactName { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Complement { get; set; }
        public string Phone { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
