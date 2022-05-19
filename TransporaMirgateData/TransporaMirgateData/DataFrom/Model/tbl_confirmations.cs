using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{

    [Table("tbl_confirmations")]
    public class tbl_confirmations
    {
        public string atr_confirmations_address { get; set; }
        public string atr_confirmations_confirmation_number { get; set; }
        public string atr_confirmations_currency_code { get; set; }
        public string atr_confirmations_intro { get; set; }
        public string atr_confirmations_label { get; set; }
        public string atr_confirmations_note { get; set; }
        public string atr_confirmations_number_pre { get; set; }
        public string atr_confirmations_status { get; set; }
        public string atr_confirmations_title { get; set; }
        public DateTime? atr_confirmations_created { get; set; }
        public DateTime? atr_confirmations_updated { get; set; }
        public int? atr_confirmations_bids_id { get; set; }
        public int? atr_confirmations_client_id { get; set; }
        public int? atr_confirmations_contact_id { get; set; }
        public int? atr_confirmations_customfield { get; set; }
        public int? atr_confirmations_id { get; set; }
        public int? atr_confirmations_invoice_id { get; set; }
        public int? atr_confirmations_number { get; set; }
        public int? atr_confirmations_number_length { get; set; }
        public int? atr_confirmations_offer_id { get; set; }
        public int? atr_confirmations_taxes_id { get; set; }
        public int? atr_confirmations_template_id { get; set; }
        public int? atr_confirmations_tenders_id { get; set; }
        [Key]
        public int? id { get; set; }
        public double? atr_confirmations_net_gross { get; set; }
        public double? atr_confirmations_reduction { get; set; }
        public double? atr_confirmations_total_gross { get; set; }
        public double? atr_confirmations_total_gross_unreduced { get; set; }
        public double? atr_confirmations_total_net { get; set; }
        public double? atr_confirmations_total_net_unreduced { get; set; }
        public double? atr_confirmations_total_reduction { get; set; }
        public DateTime? atr_confirmations_date { get; set; }
    }
}
