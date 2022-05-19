using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("Tenders")]
    public class Tender : BaseEntity
    {
        /// <summary>
        /// Global / Private
        /// </summary>
        public int TenderTypeId { get; set; }
        public int TenderStatusId { get; set; }
        /// <summary>
        /// Only have value in case Private Tender
        /// </summary>
        public int? ReceiverGroupId { get; set; }
        /// <summary>
        /// All invite email, seperated by ','
        /// </summary>
        public string InviteEmails { get; set; }
        /// <summary>
        /// Company making tender
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Auto-generate based on Id
        /// </summary>
        public string TransportNo { get; set; }
        /// <summary>
        /// Auto-generate?
        /// </summary>
        public string InternalReferenceNumber { get; set; }
        /// <summary>
        /// Tender Start Time
        /// </summary>
        public DateTime? TenderStartDate { get; set; }
        /// <summary>
        /// Tender End Time
        /// </summary>
        public DateTime? TenderEndDate { get; set; }
        public string WithdrawnReason { get; set; }
        public string WithdrawnReasonCode { get; set; }
        public bool IsSendEmailToAssignReInform { get; set; } = false;
        public int? TransportCompanyId { get; set; } = null;
        public bool IsTendererConfirmComplete { get; set; } = false;
        public bool IsTransporterConfirmComplete { get; set; } = false;
        public DateTime? ExecutionDate { get; set; }
        public DateTime? TendererConfirmDate { get; set; }
        public DateTime? TransporterConfirmDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreatorEmail { get; set; }
      
    }
}
