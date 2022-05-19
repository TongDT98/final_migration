using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_tenderstates")]
    public class tbl_tenderstates
    {
        public string atr_tender_state { get; set; }
        public string atr_tender_state_display { get; set; }
        public string label { get; set; }
        [Key]
        public int? atr_tender_id { get; set; }
        public bool? atr_delete { get; set; }
        public bool? atr_edit { get; set; }
        public bool? atr_view { get; set; }
        public bool? atr_withdraw { get; set; }
    }
}
