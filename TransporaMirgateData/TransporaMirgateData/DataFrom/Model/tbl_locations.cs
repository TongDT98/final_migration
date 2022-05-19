using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_locations")]
    public class tbl_locations
    {
        public string atr_locations_city { get; set; }
        public string atr_locations_name { get; set; }
        public string atr_locations_companyid { get; set; }
        public int atr_locations_creatorid { get; set; }
       // public string atr_locations_country { get; set; }
        public int atr_locations_countryid { get; set; }
        public string atr_locations_email { get; set; }
       // public string atr_locations_faxnumber { get; set; }
        public string atr_locations_contactfname { get; set; }
        public string atr_locations_contactlname { get; set; }
        public string atr_locations_phonenumber { get; set; }
        public string atr_locations_postcode { get; set; }
        public string atr_locations_streetname { get; set; }
        public string atr_locations_streetnumber { get; set; }
        public DateTime tbl_locations_created_at { get; set; }
        public DateTime tbl_locations_updated_at { get; set; }
        [Key]
        public int? atr_locations_id { get; set; }
    }
}
