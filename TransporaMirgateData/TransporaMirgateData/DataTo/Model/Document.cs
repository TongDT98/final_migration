using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    public class Document : BaseEntity
    {
        public int DocumentTypeId { get; set; }
        public int TenderId { get; set; }
        public int CompanyId { get; set; }
        public bool IsConstructor { get; set; }
        public int BillomatId { get; set; }
        public string BillomatNo { get; set; }
        public string BillomatType { get; set; }
        public string Status { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
  
    }
}

