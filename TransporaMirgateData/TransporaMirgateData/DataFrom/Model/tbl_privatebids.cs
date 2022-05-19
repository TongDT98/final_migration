using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_privatebids")]
    public class tbl_privatebids
    {
        [Key]
        public int atr_privatebids_id { get; set; }
       public int atr_privatebids_tenderid { get; set; }
        public int atr_privatebids_contactlistid { get; set; }
        public int atr_privatebids_companyid { get; set; }
        public int atr_privatebids_biduserid { get; set; }
        public string atr_privatebids_biduser_email { get; set; }
        public int atr_privatebids_creatorid { get; set; }
        public int atr_privatebids_creatorcompanyid { get; set; }
        public DateTime atr_privatebids_createdt { get; set; }
    }
}
