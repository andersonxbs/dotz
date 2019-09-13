using System.ComponentModel.DataAnnotations;

namespace Dotz.Api.Models.Address
{
    public class AddressModel
    {
        public long? Id { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Neighborhood { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        public string Complement { get; set; }

        public string Phone { get; set; }
    }
}
