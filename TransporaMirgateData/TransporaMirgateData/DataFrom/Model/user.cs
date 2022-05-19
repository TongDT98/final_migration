using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataFrom.Model
{
    [Table("users")]
    public class users
    {
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? last_login { get; set; }
        
        public DateTime? updated_at { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string reset_token { get; set; }
        public string username { get; set; }
        public int? company_id { get; set; }
        public int? creator_id { get; set; }
        public int? id { get; set; }
        public int? role { get; set; }
    }
}
