using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TransporaMirgateData.DataTo.Model;

namespace TransporaMirgateData.DataFrom
{
    public class TransporaDBContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseMySql("server=localhost;port=3306; database=location_test; user=root; password=050698", ServerVersion.AutoDetect(@"server=localhost;port=3306; database=location_test; user=root; password=050698"));
            optionsBuilder.UseMySql("server=210.245.85.229;port=3316; database=transpora_staging_bk; user=root; password=Thanhbipkeo@123", ServerVersion.AutoDetect(@"server=210.245.85.229;port=3316; database=transpora_staging_bk; user=root; password=Thanhbipkeo@123"));
            // optionsBuilder.UseMySql("server=localhost;port=3306; database=transpora_dev; user=root; password=123456");
        }
            
        public DbSet<Country> Countries { get; set; }
        public DbSet<Brand> Brands { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }   
        public DbSet<Language> Languages { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<TenderStatus> TenderStatus { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<ProductFamilyTranslation> ProductFamilyTranslations { get; set; }
        public DbSet<ProductFamily> ProductFamilies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }   
        public DbSet<TenderLoad> TenderLoads { get; set; }   
        public DbSet<TenderBid> TenderBids { get; set; }   
        public DbSet<Document> Documents { get; set; }   
        public DbSet<CompanyRegistration> CompanyRegistrations { get; set; }   
        public DbSet<UserRole> UserRoles { get; set; }   

                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder); 
        }

    }
}
