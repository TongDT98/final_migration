using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_families")]
    public class tbl_families
    {
        public string atr_family_products_deutsch { get; set; }
        public string atr_family_products_english { get; set; }
        public string atr_family_products_french { get; set; }
        public string atr_family_products_italian { get; set; }
        public string atr_family_products_spanish { get; set; }
        [Key]
        public int atr_family_products_id { get; set; }
    }
}
