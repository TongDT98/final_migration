using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_machines")]
    public class tbl_machines
    {
        public string atr_machines_companyid { get; set; }
        public string atr_machines_height { get; set; }
        public string atr_machines_imagetype { get; set; }
        public string atr_machines_inventory { get; set; }
        public string atr_machines_length { get; set; }
        public string atr_machines_manufacturer { get; set; }
        public string atr_machines_name { get; set; }
        public string atr_machines_numberplate { get; set; }
        public string atr_machines_serialnumber { get; set; }
        public string atr_machines_weight { get; set; }
        public string atr_machines_width { get; set; }
        public string atr_type_name { get; set; }
        public DateTime? atr_machines_tender_enddt { get; set; }
        public DateTime? atr_machines_tender_startdt { get; set; }
        public DateTime? atr_machines_creation { get; set; }
        public int? atr_brand_id { get; set; }
        public int? atr_family_id { get; set; }
        public int atr_machines_status { get; set; }
        [Key]
        public int? atr_machines_id { get; set; }
        public int? atr_machines_tender_state { get; set; }
        public int? atr_machines_tenderid { get; set; }
    }
}
