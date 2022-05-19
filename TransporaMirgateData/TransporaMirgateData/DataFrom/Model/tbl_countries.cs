using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    public class tbl_countries
    {
        public string atr_countries_code { get; set; }
        public string atr_countries_name { get; set; }
        public string atr_countries_continent { get; set; }
        public string atr_countries_langcode { get; set; }
        public string atr_countries_currency_name { get; set; }
        public string atr_countries_currency_sign { get; set; }
        public string atr_countries_currency_isocode { get; set; }
        public bool atr_countries_active { get; set; }
        [Key]
        public int? atr_countries_id { get; set; }
    }
}
