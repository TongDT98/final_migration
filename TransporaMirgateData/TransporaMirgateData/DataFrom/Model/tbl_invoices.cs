using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_invoices")]
    public class tbl_invoices
    {
        public string atr_invoices_address { get; set; }
        public string atr_invoices_customfield { get; set; }
        public string atr_invoices_doctype { get; set; }
        public string atr_invoices_intro { get; set; }
        public string atr_invoices_invoice_number { get; set; }
        public string atr_invoices_label { get; set; }
        public string atr_invoices_net_gross { get; set; }
        public string atr_invoices_note { get; set; }
        public string atr_invoices_payment_types { get; set; }
        public string atr_invoices_reduction { get; set; }
        public string atr_invoices_supply_date_type { get; set; }
        public string atr_invoices_title { get; set; }
        public DateTime? atr_invoices_created { get; set; }
        public DateTime? atr_invoices_updated { get; set; }
        public string atr_invoices_currency_code { get; set; }
        public string atr_invoices_status { get; set; }
        public int? atr_invoices_client_id { get; set; }
        public int? atr_invoices_confirmation_id { get; set; }
        public int? atr_invoices_contact_id { get; set; }
        public int? atr_invoices_discount_days { get; set; }
        public int? atr_invoices_due_days { get; set; }
        public int? atr_invoices_id { get; set; }
        public int? atr_invoices_invoice_id { get; set; }
        public int? atr_invoices_number { get; set; }
        public int? atr_invoices_number_length { get; set; }
        public int? atr_invoices_number_pre { get; set; }
        public int? atr_invoices_offer_id { get; set; }
        public int? atr_invoices_recurring_id { get; set; }
        public int? atr_invoices_taxes_id { get; set; }
        public int? atr_invoices_tbl_tenders_id { get; set; }
        public int? atr_invoices_template_id { get; set; }
        [Key]
        public int? id { get; set; }
        public double? atr_invoices_discount_amount { get; set; }
        public double? atr_invoices_discount_rate { get; set; }
        public double? atr_invoices_open_amount { get; set; }
        public double? atr_invoices_paid_amount { get; set; }
        public double? atr_invoices_quote { get; set; }
        public double? atr_invoices_total_gross { get; set; }
        public double? atr_invoices_total_gross_unreduced { get; set; }
        public double? atr_invoices_total_net { get; set; }
        public double? atr_invoices_total_net_unreduced { get; set; }
        public double? atr_invoices_total_reduction { get; set; }
        public DateTime? atr_invoices_date { get; set; }
        public DateTime? atr_invoices_discount_date { get; set; }
        public DateTime? atr_invoices_due_date { get; set; }
        public DateTime? atr_invoices_supply_date { get; set; }
    }
}
