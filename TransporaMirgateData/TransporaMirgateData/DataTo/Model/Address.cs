using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("Address")]
    public class Address : BaseEntity
    {
        public string AddressName { get; set; }
        public string AddressStreetName { get; set; }
        public string AddressSreetNumber { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactName { get; set; }
        public int CountryId { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public string PhoneNumberCountryCode { get; set; }
        public bool IsDefault { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsLocation { get; set; } = false;
        public int? LocationId { get; set; }

    }
}
