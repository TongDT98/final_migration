using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_bids")]
    public class tbl_bids
    {
        public string atr_bids_companyid { get; set; }
        public string atr_bids_currency { get; set; }
        public string atr_bids_email { get; set; }
        public string atr_bids_status { get; set; }
        public string atr_bids_tendersid { get; set; }
        public DateTime? atr_bids_update { get; set; }
        public DateTime? atr_bids_creation { get; set; }
        public int? atr_bids_billomat_cid { get; set; }
        public int? atr_bids_billomat_confirmation_cid { get; set; }
        public int? atr_bids_billomat_confirmation_id { get; set; }
        public int? atr_bids_billomat_deliverynote_cid { get; set; }
        public int? atr_bids_billomat_deliverynote_id { get; set; }
        public int? atr_bids_billomat_id { get; set; }
        public int? atr_bids_billomat_invoice_cid { get; set; }
        public int? atr_bids_billomat_invoice_id { get; set; }
        [Key]
        public int? atr_bids_id { get; set; }
        public int? atr_bids_notification { get; set; }
        public int? atr_bids_userid { get; set; }
        public double? atr_bids_amount { get; set; }
        public double? atr_bids_brokeragefee { get; set; }
    }
}
