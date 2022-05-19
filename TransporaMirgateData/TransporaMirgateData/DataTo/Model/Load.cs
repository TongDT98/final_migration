using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransporaMirgateData.DataTo.Model
{
    [Table("Loads")]
    public class Load : BaseEntity
    {
        public int BrandId { get; set; }
        public int ProductFamilyId { get; set; }
        public int CompanyId { get; set; }
        public int? FreightCategoryId { get; set; }
        //public int VehicleTypeId { get; set; }
        public string ImageUrls { get; set; }
        public decimal Length { get; set; } = 0;
        public decimal Width { get; set; } = 0;
        public decimal Height { get; set; } = 0;
        public decimal Weight { get; set; } = 0;
        public string Type { get; set; }
        public string InventoryNo { get; set; }
        public string SerialNo { get; set; }
        public string Plate { get; set; }
    }
}
