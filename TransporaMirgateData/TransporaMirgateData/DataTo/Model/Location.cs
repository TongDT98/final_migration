using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("Location")]
    public class Location : BaseEntity
    {
        public string LocationName { get; set; }
        public string LocationStreetName { get; set; }
        public string LocationStreetNumber { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public string Website { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
        public string PhoneNumberCountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UIDNumber { get; set; }
        public int LocationType { get; set; }
        public bool IsDefault { get; set; }
        public int LocationAdministratorId { get; set; }
       

    }
}
