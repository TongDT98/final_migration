using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TransporaMirgateData.DataFrom.Model;

namespace TransporaMirgateData.DataFrom
{
    public class TransporaDBFromContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306; database=transpora_product_1205; user=root; password=050698;Convert Zero Datetime=true;", ServerVersion.AutoDetect(@"server=210.245.85.229;port=3316; database=transpora_staging_bk; user=root; password=Thanhbipkeo@123"));
            // optionsBuilder.UseMySql("server=localhost;port=3306; database=transpora_dev; user=root; password=123456");
        }

        public DbSet<Tbl_Brands> TblBrands { get; set; }
        public DbSet<tbl_countries> TblCountries { get; set; }
        public DbSet<users> Users { get; set; }
        public DbSet<tbl_users> TblUsers { get; set; }
        public DbSet<tbl_companies> TblCompanies { get; set; }
        public DbSet<tbl_tenders> TblTenders { get; set; }      
        public DbSet<tbl_tenderstates> TblTenderstates { get; set; }  
        
        public DbSet<tbl_machines> TblMachines { get; set; }  
        public DbSet<tbl_families> TblFamilies { get; set; }    
        public DbSet<tbl_locations> TblLocations { get; set; }  
        public DbSet<tbl_bids> TblBids { get; set; }  
        public DbSet<tbl_invoices> TblInvoices { get; set; }  
        public DbSet<tbl_confirmations> TblConfirmations { get; set; }  
        public DbSet<tbl_newregistrations> TblNewregistrations { get; set; }
        public DbSet<tbl_privatebids> TblPrivatebids { get; set; }
        public DbSet<tbl_trackers> TblTrackers { get; set; }
        public DbSet<tbl_freight> TblFreight { get; set; }
        public DbSet<tbl_attachments> Tbl_Attachments { get; set; }
        public DbSet<tbl_comments> Tbl_Comments { get; set; }

    }
}   
