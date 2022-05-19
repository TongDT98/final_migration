using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public int? LanguageId { get; set; }
        public string PhoneNumberCountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CompanyStreetName { get; set; }
        public string CompanyStreetNumber { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public int CompanyStatusId { get; set; }
        public string UIDNumber { get; set; }
        public int? AccountManagerId { get; set; }
        public DateTime? ActiveDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }
        public string MarketSegmentIds { get; set; }
        public string Website { get; set; }
        public Decimal CompanyFees { get; set; }
        public bool Invoice { get; set; }
        public bool Paypal { get; set; }
        public bool CreditCard { get; set; }
        public bool IsDelete { get; set; } = false;
        public int BillomatClientId { get; set; } = 0;
        public bool IsCentralizedEmail { get; set; } = false;
        public string CentralEmailAddress { get; set; }
        public int CompanyRoleId { get; set; }
        
    }
}
