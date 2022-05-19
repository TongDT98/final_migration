using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_tenders")]
    public class tbl_tenders
    {
        public string atr_tenders_bid_currency { get; set; }
        public string atr_tenders_companyid { get; set; }
        public string atr_tenders_deliverydate { get; set; }
        public string atr_tenders_deliverytime { get; set; }
        public string atr_tenders_email { get; set; }
        public string atr_tenders_enddate { get; set; }
        public string atr_tenders_endtime { get; set; }
        public string atr_tenders_fname { get; set; }
        public string atr_tenders_fromcity { get; set; }
        public string atr_tenders_fromcompany { get; set; }
        public string atr_tenders_fromcontact_fname { get; set; }
        public string atr_tenders_fromcontact_lname { get; set; }
        public string atr_tenders_fromcontactemail { get; set; }
        public string atr_tenders_fromcontactnumber { get; set; }
        public string atr_tenders_fromcountry { get; set; }
        public string atr_tenders_fromlocation { get; set; }
        public string atr_tenders_frommobilenumber { get; set; }
        public string atr_tenders_frompostcode { get; set; }
        public string atr_tenders_fromstreet { get; set; }
        public string atr_tenders_fromstreetnumber { get; set; }
        public string atr_tenders_height { get; set; }
        public string atr_tenders_internal_ref { get; set; }
        public string atr_tenders_length { get; set; }
        public string atr_tenders_lname { get; set; }
        public string atr_tenders_machinesid { get; set; }
        public string atr_tenders_mobile { get; set; }
        public string atr_tenders_phone { get; set; }
        public string atr_tenders_pickupdate { get; set; }
        public string atr_tenders_pickuptime { get; set; }
        public string atr_tenders_startdate { get; set; }
        public string atr_tenders_starttime { get; set; }
        public string atr_tenders_tocity { get; set; }
        public string atr_tenders_tocompany { get; set; }
        public string atr_tenders_tocontact_fname { get; set; }
        public string atr_tenders_tocontact_lname { get; set; }
        public string atr_tenders_tocontactemail { get; set; }
        public string atr_tenders_tocontactnumber { get; set; }
        public string atr_tenders_tocountry { get; set; }
        public string atr_tenders_tolocation { get; set; }
        public string atr_tenders_tomobilenumber { get; set; }
        public string atr_tenders_topostcode { get; set; }
        public string atr_tenders_tostreet { get; set; }
        public string atr_tenders_tostreetnumber { get; set; }
        public string atr_tenders_userid { get; set; }
        public string atr_tenders_weight { get; set; }
        public string atr_tenders_width { get; set; }
        public DateTime? atr_tender_win_timestamp { get; set; }
        public DateTime? atr_tenders_creation { get; set; }
        public int? atr_tenders_comment_id { get; set; }
        public int? atr_tenders_fromlocation_id { get; set; }
        [Key]
        public int? atr_tenders_id { get; set; }
        public int? atr_tenders_state_id { get; set; }
        public int? atr_tenders_tolocation_id { get; set; }
        public int? atr_tenders_winner_companyid { get; set; }
        public double? atr_tenders_bid_amount { get; set; }
        public bool? atr_tenders_close { get; set; }
    }
}
