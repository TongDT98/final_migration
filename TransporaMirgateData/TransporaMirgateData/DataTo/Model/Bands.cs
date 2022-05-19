using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("Brands")]
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
    }
}
