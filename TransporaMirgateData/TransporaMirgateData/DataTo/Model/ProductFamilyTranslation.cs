using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("ProductFamilyTranslation")]
    public class ProductFamilyTranslation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductFamilyId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageCode { get; set; }
        public string Translation { get; set; }
        [ForeignKey("ProductFamilyId")]
        public virtual ProductFamily ProductFamily { get; set; }
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; }
    }
}
