using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_attachments")]
    public class tbl_attachments
    {
        [Key]
       public int atr_attachments_id { get; set; }
     public int atr_attachments_machineid { get; set; }
       public int atr_attachments_tenderid { get; set; }
       public string  atr_attachments_name { get; set; }
       public string atr_attachments_title { get; set; }
      

 public int atr_attachments_userid { get; set; }
 public int  atr_attachments_companyid { get; set; }
    }
}
