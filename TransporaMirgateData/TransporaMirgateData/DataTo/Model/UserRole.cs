using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("AspNetUserRoles")]
    public class UserRole
    {
        [Key]
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
