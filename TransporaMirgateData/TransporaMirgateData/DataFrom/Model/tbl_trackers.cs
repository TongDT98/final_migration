using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_trackers")]

    public class tbl_trackers
    {
        [Key]
        public int atr_trackers_id { get; set; }
        public int atr_trackers_machineid { get; set; }
        public int atr_trackers_tenderid { get; set; }
        public int atr_trackers_attachmentid { get; set; }
        public int atr_trackers_freightid { get; set; }
        public int atr_trackers_commentsid { get; set; }
        public int atr_trackers_companyid { get; set; }
        public int atr_trackers_userid { get; set; }
        public int atr_trackers_transports_catid { get; set; }
        public DateTime atr_trackers_datetime { get; set; }
    }
}
