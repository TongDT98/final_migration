using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("TenderBids")]
    public class TenderBid : BaseEntity
    {
        public int TenderId { get; set; }

        /// <summary>
        /// Company making Bid <br></br>
        /// Must be different from Company making Tender
        /// </summary>
        public int BidCompanyId { get; set; }

        public decimal TransportPrice { get; set; }
        public decimal TransportPermit { get; set; }
        public decimal LegalFees { get; set; }
        public decimal SuccessFees { get; set; }
        public decimal Total { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }
        public bool IsOfferSelected { get; set; } = false;
        public string BidderEmail { get; set; }
        [ForeignKey("TenderId")] public virtual Tender Tender { get; set; }
        [ForeignKey("BidCompanyId")] public virtual Company BidCompany { get; set; }
    }
}