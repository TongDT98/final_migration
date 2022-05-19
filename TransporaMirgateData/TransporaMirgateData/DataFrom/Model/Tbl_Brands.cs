using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_brands")]
    public class Tbl_Brands
    {
      
        public string atr_manufacterers_city { get; set; }
        public string atr_manufacterers_country { get; set; }
        public string atr_manufacterers_email { get; set; }
        public string atr_manufacterers_faxnumber { get; set; }
        public string atr_manufacterers_imagetype { get; set; }
        public string atr_manufacterers_language { get; set; }
        public string atr_manufacterers_name { get; set; }
        public string atr_manufacterers_phonenumber { get; set; }
        public string atr_manufacterers_postcode { get; set; }
        public string atr_manufacterers_streetname { get; set; }
        public string atr_manufacterers_streetnumber { get; set; }
        public string atr_manufacterers_url { get; set; }
        public DateTime atr_manufacterers_creation { get; set; }
        [Key]
        public int atr_manufacterers_id { get; set; }
    }
}
