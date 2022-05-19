using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("TenderLoads")]
    public class TenderLoad
    {
        [Key]
        public int Id { get; set; }
        public int FreightCategoryId { get; set; }
        public int TenderId { get; set; }
        public int LoadId { get; set; }
        /// <summary>
        /// Loads pick up date
        /// </summary>
        public DateTime PickUpDate { get; set; }
        public int PickUpAddressId { get; set; }
        public int PickUpContactId { get; set; }
        /// <summary>
        /// Loads delivery date
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        public int DeliveryAddressId { get; set; }
        public int DeliveryContactId { get; set; }
        public string LoadNotes { get; set; }
        /// <summary>
        /// List of UploadFile in json
        /// </summary>
        public string Documents { get; set; }

        [ForeignKey("TenderId")]
        public virtual Tender Tender { get; set; }

        [ForeignKey("LoadId")]
        public virtual Load Load { get; set; }

        [ForeignKey("PickUpAddressId")]
        public virtual Address PickUpAddress { get; set; }

        [ForeignKey("PickUpContactId")]
        public virtual Contact PickUpContact { get; set; }

        [ForeignKey("DeliveryAddressId")]
        public virtual Address DeliveryAddress { get; set; }

        [ForeignKey("DeliveryContactId")]
        public virtual Contact DeliveryContact { get; set; }
    }
}
