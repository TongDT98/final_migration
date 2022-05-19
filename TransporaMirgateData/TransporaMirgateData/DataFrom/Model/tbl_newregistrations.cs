using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_newregistrations")]
    public class tbl_newregistrations
    {
        public string city { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string fname { get; set; }
        public string keycode { get; set; }
        public string language { get; set; }
        public string lname { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string post_code { get; set; }
        public string street_name { get; set; }
        public string street_number { get; set; }
        public DateTime? enrolldate { get; set; }
        public int? company_id { get; set; }
        public int? companydivision { get; set; }
        public int? country_id { get; set; }
        public int? creator_id { get; set; }
        [Key]
        public int? id { get; set; }
        public int? newuserid { get; set; }
        public int? roleid { get; set; }
        public int? status { get; set; }
    }
}
