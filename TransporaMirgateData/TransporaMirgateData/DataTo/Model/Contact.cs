using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("Contact")]
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public string Email { get; set; }
        public string PhoneNumberCountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumberCountryCode { get; set; }
        public string MobileNumber { get; set; }
        public int LanguageId { get; set; }
        public int CompanyId { get; set; }
        public string JobTitle { get; set; }
        public int RoleId { get; set; }
        public string Image { get; set; }
        public int LocationId { get; set; }
        public bool IsEmployee { get; set; } = false;
        public int? EmployeeId { get; set; }


        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
    }
}
