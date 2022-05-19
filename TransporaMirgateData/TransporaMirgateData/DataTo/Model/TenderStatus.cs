using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("TenderStatus")]
    public class TenderStatus
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameTranslationJson { get; set; }
    }
}
