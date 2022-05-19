using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("Countries")]
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string CountryCodeISO2 { get; set; }
        public string CountryCodeISO3 { get; set; }
        public string Phone { get; set; }
        public int LanguageId { get; set; }
        public decimal StandardFees { get; set; }
        public decimal MaximumFees { get; set; }
        public string LanguageCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
        public string TimeZone { get; set; }
        public string TimeZoneName { get; set; }
        public string Continent { get; set; }
        public string FlagImage { get; set; }
        public bool InvoicePayment { get; set; } = false;
        public bool CreditCardPayment { get; set; } = false;
        public bool PayPalPayment { get; set; } = false;
        public int CountryManagerId { get; set; }
        public string NameTranslationJson { get; set; }
        
    }
}
