using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_freight")]
    public class tbl_freight
    {
        [Key]
        public int atr_freight_id { get; set; }
        public DateTime atr_freight_creation { get; set; }
        public int atr_freight_userid { get; set; }
        public int atr_freight_companyid {get;set;}
        public int atr_freight_tenderid { get; set; }
        public int atr_freight_machinesid { get; set; }
       public string atr_freight_pickupdate { get; set; }
      public string  atr_freight_pickuptime { get; set; }
       public string atr_freight_fromcompany { get; set; }
      public string  atr_freight_fromlocation { get; set; }
        public string atr_freight_fromstreet { get; set; }
        public string atr_freight_fromstreetnumber { get; set; }
        public string atr_freight_frompostcode { get; set; }
        public string atr_freight_fromcity { get; set; }
        public string atr_freight_fromcountry { get; set; }
        public string atr_freight_fromcontact_fname { get; set; }
        public string atr_freight_fromcontact_lname { get; set; }
        public string atr_freight_fromcontactemail { get; set; }
        public string atr_freight_fromcontactnumber { get; set; }
        public string atr_freight_frommobilenumber { get; set; }
        public string atr_freight_deliverydate { get; set; }
        public string atr_freight_deliverytime { get; set; }
        public string atr_freight_tocompany { get; set; }
        public string atr_freight_tolocation { get; set; }
        public string atr_freight_tostreet { get; set; }
        public string atr_freight_tostreetnumber { get; set; }
        public string atr_freight_topostcode { get; set; }
        public string atr_freight_tocity { get; set; }
        public string atr_freight_tocountry { get; set; }
        public string atr_freight_tocontact_fname { get; set; }
        public string atr_freight_tocontact_lname { get; set; }
        public string atr_freight_tocontactemail { get; set; }
        public string atr_freight_tocontactnumber { get; set; }
        public string atr_freight_tomobilenumber { get; set; }
        public int atr_freight_comment_id { get; set; }
        public int atr_freight_attachmentid { get; set; }
    }
}
