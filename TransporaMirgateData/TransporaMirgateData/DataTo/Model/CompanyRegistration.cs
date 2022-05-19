using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("CompanyRegistration")]
    public class CompanyRegistration
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string CityCode { get; set; }
        [Required]
        public string CityName { get; set; }
        public string MarketSegmentIds { get; set; }
        public int CountryId { get; set; }
        [Required]
        public string Email { get; set; }
        public string CompanyEmail { get; set; }
        public string Salutation { get; set; }
        public string CompanyPhoneNumberCountryCode { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string BusinessPhoneNumberCountryCode { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string MobilePhoneNumberCountryCode { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public int LanguageId { get; set; }
        public string Website { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdateBy { get; set; }
        public string Image { get; set; }
        public string UIDNumber { get; set; }
        public int CompanyRoleId { get; set; }
        public int CompanyStatusId { get; set; }
        public string VerifyToken { get; set; }
       
    }


}
