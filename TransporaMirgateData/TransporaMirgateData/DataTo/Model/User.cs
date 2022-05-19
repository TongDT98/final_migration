using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("AspNetUsers")]
    public class User
    {
        [Key]

        public int Id { get; set; }
        public string Salutation { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int EmailConfirmed { get; set; }
        public int PhoneNumberConfirmed { get; set; }
        public int TwoFactorEnabled { get; set; }
        public int LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string FirstName { get; set; }   
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int? LocationId { get; set; }
        public string PhoneNumberCountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumberCountryCode { get; set; }
        public string MobileNumber { get; set; }
        public string LanguageName { get; set; }
        public int? LanguageId { get; set; }
        public string JobTitle { get; set; }
        public string Address { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? CompanyId { get; set; }
        public string ResetToken { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDefault { get; set; }
        public int? TwoFactorAuthenticator_Id { get; set; }
        public bool IsChangePasswordDefault { get; set; } = false;
        //public bool IsLoginMd5 { get; set; } = false;
        //public string Md5Hash { get; set; }
    }
}
