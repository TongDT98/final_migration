using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("tbl_users")]
    public class tbl_users
    {
        public string atr_users_agb_cond_rev { get; set; }
        public string atr_users_agb_terms_rev { get; set; }
        public string atr_users_city { get; set; }
        public string atr_users_companyid { get; set; }
        public string atr_users_email { get; set; }
        public string atr_users_firstname { get; set; }
        public string atr_users_langconstants { get; set; }
        public string atr_users_language { get; set; }
        public string atr_users_lastname { get; set; }
        public string atr_users_mobilenumber { get; set; }
        public string atr_users_password { get; set; }
        public string atr_users_phonenumber { get; set; }
        public string atr_users_position { get; set; }
        public string atr_users_post_code { get; set; }
        public string atr_users_role { get; set; }
        public string atr_users_sex { get; set; }
        public string atr_users_street_name { get; set; }
        public string atr_users_street_number { get; set; }
        public DateTime? atr_users_accept_date { get; set; }
        public DateTime? atr_users_creationtime { get; set; }
        public int? atr_user_agb_cond_id { get; set; }
        public int? atr_user_agb_terms_id { get; set; }
        public int? atr_users_billomat_id { get; set; }
        public int? atr_users_country_id { get; set; }
        public int? atr_users_id { get; set; }
        public int? atr_users_role_id { get; set; }
        public int? atr_users_status { get; set; }
        [Key]
        public int? id { get; set; }
    }
}
