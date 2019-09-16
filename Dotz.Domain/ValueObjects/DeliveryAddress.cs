using Dotz.Domain.Entities;

namespace Dotz.Domain.ValueObjects
{
    public class DeliveryAddress
    {
        public long DeliveryId { get; set; }
        public string ContactName { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Complement { get; set; }
        public string Phone { get; set; }

        public static DeliveryAddress FromEntity(Address address)
        {
            return new DeliveryAddress
            {
                ContactName = address.ContactName,
                PostalCode = address.PostalCode,
                State = address.State,
                City = address.City,
                Neighborhood = address.Neighborhood,
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber,
                Complement = address.Complement,
                Phone = address.Phone
            };
        }
    }
}
