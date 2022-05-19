using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_comments")]
    public class tbl_comments
    {
       [Key]
        public int atr_comments_id { get; set; }
        public string atr_comments_text { get; set; }
    }
}
