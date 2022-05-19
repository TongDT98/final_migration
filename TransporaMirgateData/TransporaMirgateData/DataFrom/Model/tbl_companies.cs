using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_companies")]
    public class tbl_companies
    {

        public string atr_companies_city { get; set; }
        public string atr_companies_country { get; set; }
        public string atr_companies_division { get; set; }
        public string atr_companies_email { get; set; }
        public string atr_companies_faxnumber { get; set; }
        public string atr_companies_imagedata { get; set; }
        public string atr_companies_imagetype { get; set; }
        public string atr_companies_langcode { get; set; }
        public string atr_companies_language { get; set; }
        public string atr_companies_name { get; set; }
        public string atr_companies_phonenumber { get; set; }
        public string atr_companies_postcode { get; set; }
        public string atr_companies_streetname { get; set; }
        public string atr_companies_streetnumber { get; set; }
        public string atr_companies_timezone { get; set; }
        public string atr_companies_uidnumber { get; set; }
        public string atr_companies_url { get; set; }
        public int atr_companies_countryID { get; set; }
        public int atr_companies_division_id { get; set; }
        public DateTime? atr_companies_creation { get; set; }
        public int? atr_companies_billomat_id { get; set; }
        [Key]
        public int atr_companies_id { get; set; }
        public int? atr_companies_role { get; set; }
        public int? atr_companies_status { get; set; }
    }
}
