using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("ProductFamilies")]
    public class ProductFamily : BaseEntity
    {
        [NotMapped]
        public string Name { get; set; }
        public ICollection<ProductFamilyTranslation> ProductFamilyTranslations { get; set; }
    }
}
