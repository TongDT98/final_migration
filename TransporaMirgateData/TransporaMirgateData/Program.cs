using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using TransporaMirgateData.DataFrom;
using TransporaMirgateData.DataTo.Model;
using TransporaMirgateData.DataTo;

namespace TransporaMirgateData
{
    class Program
    {
        private static bool _isEmailReal = true;
        private static string _email = "ngoctien.wo@gmail.com";
        //private static PhoneNumberResult ReplacePhoneNumber(this string Phone)
        //{
        //    var phoneresult = Phone.Replace(" ", "");
        //    var phonecode = "";
        //    var phonenumber = "";

        //    if (!string.IsNullOrEmpty(Phone))
        //    {
        //        if (Phone.Contains("+"))
        //        {
        //            phonecode = "+41";
        //            phonenumber = phoneresult.Substring(3, phoneresult.Length - 3);
        //        }
        //        else
        //        {
        //            if (phoneresult.Length > 10 && phoneresult.Substring(0, 4).Equals("0041"))
        //            {
        //                phonecode = "+41";
        //                phonenumber = phoneresult;
        //            }
        //            if (phoneresult.Length < 10 && phoneresult.Substring(0, 1).Equals("0"))
        //            {
        //                phonecode = "+41";
        //                phonenumber = phoneresult.Substring(1, phoneresult.Length - 1);
        //            }
        //        }
        //    }


        //    return new PhoneNumberResult
        //    {
        //        PhoneCode = phonecode,
        //        PhoneNumber = phonenumber
        //    };
        //}


        static void Main(string[] args)
        {

            // MigrateCompany();
            // MigrateLocations();
            //  MigrateUser();

            // MigrateBrands();

            // MigrateProductFamily();



            // MigrateMachines();

            //MigrateTender();

            //MigrateDocuments();
            // Small_fix();
            //  fix_image();
            // TenderLoads();
            // fix_image_user();
            // UpdateLocation();
            // Fix_Location();
            aff();
           




            Console.WriteLine("CompanyRegistration table");

            //using (var dbfrom = new TransporaDBFromContext())
            //{
            //    TransporaDBContext context = new TransporaDBContext();

            //    var languageList = context.Languages.ToList();

            //    //context.CompanyRegistrations.RemoveRange(context.CompanyRegistrations.ToList());
            //    //context.SaveChanges();

            //    var usersList = context.Users.ToList();
            //    var tblBids = dbfrom.TblNewregistrations.ToList();
            //    foreach (var item in tblBids)
            //    {
            //        var division = new List<int>();
            //        if(item.companydivision.HasValue && item.companydivision > 0)
            //        {
            //            division.Add((int)item.companydivision);
            //        }
            //          var user = usersList.FirstOrDefault(x => x.Id == item.creator_id);
            //          var language = languageList.FirstOrDefault(x => x.Name.ToLower().Equals(item.language.ToLower()) || x.NativeName.ToLower().Equals(item.language.ToLower()));

            //        var tenderBid = new CompanyRegistration()
            //        {
            //            CompanyName = item.company,
            //            FirstName = item.fname,
            //            LastName = item.lname,
            //            UpdatedDate = DateTime.Now,
            //            CreatedDate = DateTime.Now,
            //            StreetName = item.street_name,
            //            StreetNumber = item.street_number,
            //            CityCode = item.post_code,
            //            CountryId = item.country_id.Value,
            //            CompanyStatusId = 3,
            //            CompanyRoleId = 1,
            //            CityName = item.city,
            //            Email = _isEmailReal ? item.email : _email,
            //            CompanyEmail = _isEmailReal ? item.email : _email,
            //            // Email = item.email,
            //            // CompanyEmail = item.email,
            //            MarketSegmentIds = !division.Any() ? JsonConvert.SerializeObject(new List<int>()) : JsonConvert.SerializeObject(division),
            //            LanguageId = language?.Id ?? 1

            //        };

            //        context.CompanyRegistrations.Add(tenderBid);

            //        context.SaveChanges();

            //    }

            //    Console.WriteLine("CompanyRegistration - Done");

            //}


            Console.ReadKey();

        }
        private static void aff()
        {
            using (var dbfrom = new TransporaDBFromContext())
            {
                
                TransporaDBContext context = new TransporaDBContext();
                var ListLocation = context.Locations.ToList();
                foreach (var l in ListLocation)
                {
                    var address = new Address
                    {
                        AddressName = l.LocationName,
                        AddressSreetNumber = l.LocationStreetNumber,
                        AddressStreetName = l.LocationStreetName,
                        City = l.CityName,
                        CityCode = l.CityCode,
                        CompanyId = l.CompanyId,
                        CountryId = l.CountryId,
                        Email = l.Email,
                        IsLocation = true,
                        LocationId = l.Id,

                    };
                    context.Addresses.Add(address);
                    context.SaveChanges();
                }
            }
        }
        private static void Fix_Location()
        {
            using (var dbfrom = new TransporaDBFromContext())
            {
                TransporaDBContext context = new TransporaDBContext();
                var dem = 0;
                var ListTenderLoads1 = context.TenderLoads.Where(x => x.TenderId < 20).ToList();
                var listfright = dbfrom.TblFreight.ToList();
                var listold = dbfrom.TblTenders.ToList();
                var listtender = context.Tenders.ToList();
                foreach (var item in ListTenderLoads1)
                {
                    var tendernew = listtender.FirstOrDefault(x => x.Id == item.TenderId);
                    var tender = listold.FirstOrDefault(x => x.atr_tenders_id == item.Id);
                    var addressFrom = context.Addresses.FirstOrDefault(x =>
                           x.AddressStreetName == tender.atr_tenders_fromstreet
                           && x.AddressSreetNumber == tender.atr_tenders_fromstreetnumber
                           && x.CityCode == tender.atr_tenders_frompostcode
                           && x.City == tender.atr_tenders_fromcity
                           && x.AddressName == tender.atr_tenders_fromcompany
                           && x.CompanyId == tendernew.CompanyId


                       );
                    if (addressFrom == null)
                    {
                        var addf = context.Addresses.Add(new Address()
                        {
                            AddressName = tender.atr_tenders_fromcompany,
                            AddressSreetNumber = tender.atr_tenders_fromstreetnumber,
                            AddressStreetName = tender.atr_tenders_fromstreet,
                            CreatedBy = "system",
                            UpdatedBy = "system",
                            UpdatedDate = DateTime.UtcNow,
                            CreatedDate = DateTime.UtcNow,
                            IsDelete = false,
                            IsActive = true,
                            CompanyId = tendernew.CompanyId,
                            City = tender.atr_tenders_fromcity,
                            CityCode = tender.atr_tenders_frompostcode,

                            IsDefault = false,
                            CountryId = 1,


                        });
                        context.SaveChanges();
                        addressFrom = addf.Entity;

                    }
                    item.PickUpAddressId = addressFrom.Id;


                    var addressTo = context.Addresses.FirstOrDefault(x =>
                        x.AddressStreetName == tender.atr_tenders_tostreet
                        && x.AddressSreetNumber == tender.atr_tenders_tostreetnumber
                        && x.CityCode == tender.atr_tenders_topostcode
                        && x.City == tender.atr_tenders_tocity
                           && x.AddressName == tender.atr_tenders_tocompany
                           && x.CompanyId == tendernew.CompanyId

                    );
                    if (addressTo == null)
                    {
                        var addf = context.Addresses.Add(new Address()
                        {
                            AddressName = tender.atr_tenders_tocompany,
                            AddressSreetNumber = tender.atr_tenders_tostreetnumber,
                            AddressStreetName = tender.atr_tenders_tostreet,
                            CreatedBy = "system",
                            UpdatedBy = "system",
                            UpdatedDate = DateTime.UtcNow,
                            CreatedDate = DateTime.UtcNow,
                            IsDelete = false,
                            IsActive = true,
                            CompanyId = tendernew.CompanyId,
                            City = tender.atr_tenders_tocity,
                            CityCode = tender.atr_tenders_topostcode,
                            IsDefault = false,
                            CountryId = 1,


                        });
                        context.SaveChanges();
                        addressTo = addf.Entity;

                    }
                    item.DeliveryAddressId = addressTo.Id;
                    context.TenderLoads.Update(item);
                    context.SaveChanges();



                }
                var ListTenderLoad2 = context.TenderLoads.Where(x => x.TenderId > 16).ToList();
                foreach(var item in ListTenderLoad2)
                {
                    var tendernew = listtender.FirstOrDefault(x => x.Id == item.TenderId);
                    var fright = listfright.FirstOrDefault(x => x.atr_freight_tenderid == item.TenderId && x.atr_freight_machinesid == item.LoadId);
                    var addressFrom = context.Addresses.FirstOrDefault(x =>
                           x.AddressStreetName == fright.atr_freight_fromstreet
                           && x.AddressSreetNumber == fright.atr_freight_fromstreetnumber
                           && x.CityCode == fright.atr_freight_frompostcode
                           && x.City == fright.atr_freight_fromcity
                           && x.AddressName == fright.atr_freight_fromcompany
                           && x.CompanyId == tendernew.CompanyId


                       );
                    if (addressFrom == null)
                    {
                        var addf = context.Addresses.Add(new Address()
                        {
                            AddressName = fright.atr_freight_fromcompany,
                            AddressSreetNumber = fright.atr_freight_fromstreetnumber,
                            AddressStreetName = fright.atr_freight_fromstreet,
                            CreatedBy = "system",
                            UpdatedBy = "system",
                            UpdatedDate = DateTime.UtcNow,
                            CreatedDate = DateTime.UtcNow,
                            IsDelete = false,
                            IsActive = true,
                            CompanyId = tendernew.CompanyId,
                            City = fright.atr_freight_fromcity,
                            CityCode = fright.atr_freight_frompostcode,

                            IsDefault = false,
                            CountryId = 1,


                        });
                        context.SaveChanges();
                        addressFrom = addf.Entity;

                    }
                    item.PickUpAddressId = addressFrom.Id;


                    var addressTo = context.Addresses.FirstOrDefault(x =>
                        x.AddressStreetName == fright.atr_freight_tostreet
                        && x.AddressSreetNumber == fright.atr_freight_tostreetnumber
                        && x.CityCode == fright.atr_freight_topostcode
                        && x.City == fright.atr_freight_tocity
                           && x.AddressName == fright.atr_freight_tocompany
                           && x.CompanyId == tendernew.CompanyId

                    );
                    if (addressTo == null)
                    {
                        var addf = context.Addresses.Add(new Address()
                        {
                            AddressName = fright.atr_freight_tocompany,
                            AddressSreetNumber = fright.atr_freight_tostreetnumber,
                            AddressStreetName = fright.atr_freight_tostreet,
                            CreatedBy = "system",
                            UpdatedBy = "system",
                            UpdatedDate = DateTime.UtcNow,
                            CreatedDate = DateTime.UtcNow,
                            IsDelete = false,
                            IsActive = true,
                            CompanyId = tendernew.CompanyId,
                            City = fright.atr_freight_tocity,
                            CityCode = fright.atr_freight_topostcode,
                            IsDefault = false,
                            CountryId = 1,


                        });
                        context.SaveChanges();
                        addressTo = addf.Entity;

                    }
                    item.DeliveryAddressId = addressTo.Id;
                    context.TenderLoads.Update(item);
                    context.SaveChanges();


                }

            }
        }
       private static void UpdateLocation()
        {
            using (var dbfrom = new TransporaDBFromContext())
            {
                TransporaDBContext context = new TransporaDBContext();
                var ListLocation = context.Locations.ToList();
                var ListAddress = context.Addresses.ToList();
                var ListTender = dbfrom.TblTenders.Where(x => x.atr_tenders_id <= 16).ToList();
                var ListFright = dbfrom.TblFreight.Where(x=>x.atr_freight_companyid != 163).ToList();
                foreach(var item in ListFright)
                {
                    var addressfrom = ListAddress.Where(x => x.City.Equals(item.atr_freight_fromcity)
                        && x.CityCode.Equals(item.atr_freight_frompostcode)
                        && x.AddressSreetNumber.Equals(item.atr_freight_fromstreetnumber)
                        && x.AddressStreetName.Equals(item.atr_freight_fromstreet)
                        && x.CompanyId == item.atr_freight_companyid).FirstOrDefault();
                    if(addressfrom != null)
                    {
                        addressfrom.AddressName = item.atr_freight_fromcompany;
                        context.Addresses.Update(addressfrom);
                    }
                    var addressto = ListAddress.Where(x => x.City.Equals(item.atr_freight_tocity)
                       && x.CityCode.Equals(item.atr_freight_topostcode)
                       && x.AddressSreetNumber.Equals(item.atr_freight_tostreetnumber)
                       && x.AddressStreetName.Equals(item.atr_freight_tostreet)
                       && x.CompanyId == item.atr_freight_companyid).FirstOrDefault();
                    if (addressto != null)
                    {
                        addressto.AddressName = item.atr_freight_tocompany;
                        context.Addresses.Update(addressto);
                    }
                }
                foreach(var t in ListTender)
                {
                    var addressfrom = ListAddress.Where(x => x.City.Equals(t.atr_tenders_fromcity)
                        && x.CityCode.Equals(t.atr_tenders_frompostcode)
                        && x.AddressSreetNumber.Equals(t.atr_tenders_fromstreetnumber)
                        && x.AddressStreetName.Equals(t.atr_tenders_fromstreet)).FirstOrDefault();
                       
                    if (addressfrom != null)
                    {
                        addressfrom.AddressName = t.atr_tenders_fromcompany;
                        context.Addresses.Update(addressfrom);
                    }
                    var addressto = ListAddress.Where(x => x.City.Equals(t.atr_tenders_tocity)
                       && x.CityCode.Equals(t.atr_tenders_topostcode)
                       && x.AddressSreetNumber.Equals(t.atr_tenders_tostreetnumber)
                       && x.AddressStreetName.Equals(t.atr_tenders_tostreet)
                      ).FirstOrDefault();
                    if (addressto != null)
                    {
                        addressto.AddressName = t.atr_tenders_tocompany;
                        context.Addresses.Update(addressto);
                    }
                }
                foreach(var l in ListLocation)
                {
                    var address = new Address
                    {
                        AddressName = l.LocationName,
                        AddressSreetNumber = l.LocationStreetNumber,
                        AddressStreetName = l.LocationStreetName,
                        City = l.CityName,
                        CityCode = l.CityCode,
                        CompanyId = l.CompanyId,
                        CountryId = l.CountryId,
                        Email = l.Email,
                        IsLocation = true,
                        LocationId = l.Id,

                    };
                    context.Addresses.Add(address);
                    context.SaveChanges();
                }
            }
        }
        private static void fix_image_user()
        {
            using (var dbfrom = new TransporaDBFromContext())
            {
                TransporaDBContext context = new TransporaDBContext();
                var ListUser = context.Users.ToList();
                var ListUserTo = context.Users.ToList();
                var ListLocation = context.Locations.ToList();
                var ListLoad = context.Loads.ToList();
                var ListCompany = context.Companies.ToList();

                var companyurl = "http://210.245.85.229:9967/Images/CompanyLogo/";
                var userurl = "http://210.245.85.229:9967/Images/AvatarUsers/";
                var loadurl = "http://210.245.85.229:9967/Images/Loads/";
              
                context.SaveChanges();
                foreach (var u in ListUser)
                {
                u.Image =   $"{userurl}{u.Id}.png";
                   // u.Image = JsonConvert.SerializeObject(image);
                }
                context.Users.UpdateRange(ListUser);
                context.SaveChanges();
                foreach (var l in ListLoad)
                {
                   var img = $"{loadurl}{l.Id}.png";
                   var List = new List<string>();
                    List.Add(img);
                    l.ImageUrls = JsonConvert.SerializeObject(List);
                }
                context.Loads.UpdateRange(ListLoad);
                context.SaveChanges();



            }
            Console.WriteLine("Migrate image - Done");

        }
        private static void fix_image()
        {
            using (var dbfrom = new TransporaDBFromContext())
            {
                TransporaDBContext context = new TransporaDBContext();
                var ListUser = context.Users.Where(x=>x.Id > 80 ).ToList();
                var ListUserTo = context.Users.ToList();
                var ListLocation = context.Locations.ToList();
                var ListLoad = context.Loads.ToList();
                var ListCompany = context.Companies.Where(x=>x.Id > 80).ToList();

                var companyurl = "http://210.245.85.229:9967/Images/CompanyLogo/";
                var userurl = "http://210.245.85.229:9967/Images/AvatarUsers/";
                var loadurl = "http://210.245.85.229:9967/Images/Loads/";
                foreach (var c in ListCompany)
                {
                    c.Image = $"{companyurl}{c.Id}.png";
                }
                context.Companies.UpdateRange(ListCompany);
                context.SaveChanges();
                foreach(var u in ListUser)
                {
                  u.Image = $"{userurl}{u.Id}.png";
                    
                }
                context.Users.UpdateRange(ListUser);
                context.SaveChanges();
                foreach(var l in ListLoad)
                {
                    var img = $"{loadurl}{l.Id}.png";
                    var List = new List<string>();
                    List.Add(img);
                    l.ImageUrls = JsonConvert.SerializeObject(List);
                }
                context.Loads.UpdateRange(ListLoad);
                context.SaveChanges();
              
            }
            Console.WriteLine("Migrate image - Done");

        }
        private static void TenderLoads()
        {
            using (var dbfrom = new TransporaDBFromContext())
            {
                TransporaDBContext context = new TransporaDBContext();
                var listattachment = dbfrom.Tbl_Attachments.ToList();
                var listtracker = dbfrom.TblTrackers.Where(x=>x.atr_trackers_companyid != 163).ToList();
                var listcomment = dbfrom.Tbl_Comments.ToList();
                var ListTenderLoad1 = context.TenderLoads.Where(x=>x.TenderId > 16).ToList();
                var ListTenderLoad2 = context.TenderLoads.Where(x=>x.TenderId <= 16).ToList();
                var listmachine = dbfrom.TblMachines.ToList();
                var listfright = dbfrom.TblFreight.ToList();
                var tender = dbfrom.TblTenders.Where(x => x.atr_tenders_id < 20).ToList();
                var documenturl = "http://210.245.85.229:9967/Documents/TenderLoads/";
                foreach (var item in ListTenderLoad1)
                {
                    var tracker = listtracker.FirstOrDefault(x => x.atr_trackers_tenderid == item.TenderId && x.atr_trackers_machineid == item.LoadId);
                    var comment = listcomment.FirstOrDefault(x => x.atr_comments_id == tracker?.atr_trackers_commentsid);
                    var attachment = listattachment.Where(x => x.atr_attachments_id == tracker?.atr_trackers_attachmentid).ToList();
                    var filename = new List<FileName>();
                    if(attachment.Count() > 0)
                    {
                        foreach(var a in attachment)
                        {
                            var name = new FileName
                            {
                                Name = a.atr_attachments_name,
                                Url = $"{documenturl}{a.atr_attachments_name}"

                            };
                            filename.Add(name);
                            
                        }
                    }
                    item.LoadNotes = comment?.atr_comments_text;
                    item.Documents = JsonConvert.SerializeObject(filename);

                }
                context.TenderLoads.UpdateRange(ListTenderLoad1);
                context.SaveChanges();
                foreach(var l in ListTenderLoad2)
                {
                    var tenders = dbfrom.TblTenders.FirstOrDefault(x => x.atr_tenders_id == l.TenderId);
                   // var attachment = listattachment.Where(x => x.atr_attachments_id == tenders?.atr_tenders_comment_id).ToList();
                    var comment = listcomment.FirstOrDefault(x => x.atr_comments_id == tenders?.atr_tenders_comment_id);
                    var filename = new List<FileName>();
                  
                    l.LoadNotes = comment?.atr_comments_text;
                    l.Documents = JsonConvert.SerializeObject(filename);
                }
                context.TenderLoads.UpdateRange(ListTenderLoad2);
                context.SaveChanges();
            }
        }
        private static void Small_fix()
        {
            using (var dbfrom = new TransporaDBFromContext())
            {
                TransporaDBContext context = new TransporaDBContext();
                var ListCompany = context.Companies.Where(x=>x.Id >= 100).ToList();
                var listUSer = context.Users.ToList();
                var listLocation = context.Locations.ToList();
                var listcontact = context.Contacts.ToList();
                foreach(var item in ListCompany)
                {
                    var location = listLocation.FirstOrDefault(x => x.CompanyId == item.Id && x.LocationType == 1);
                    var tusers = listUSer.Where(x => x.CompanyId == item.Id);
                    if(location != null)
                    {
                        foreach(var u in tusers)
                        {
                            u.LocationId = location.Id;
                        }
                        context.Users.UpdateRange(tusers);
                        context.SaveChanges();
                        
                    }
                    if (!string.IsNullOrEmpty(item.PhoneNumber))
                    {
                        item.PhoneNumber = ReplacePhoneNumber1.FixPhone(item.PhoneNumber);
                        context.Companies.UpdateRange(item);
                        context.SaveChanges();
                    }
                    
                   
                }
              foreach(var u in listUSer)
                {
                    if (!string.IsNullOrEmpty(u.PhoneNumber))
                    {
                        u.PhoneNumber = ReplacePhoneNumber1.FixPhone(u.PhoneNumber);
                    }
                    if (!string.IsNullOrEmpty(u.MobileNumber))
                    {
                        u.MobileNumber = ReplacePhoneNumber1.FixPhone(u.MobileNumber);
                    }
                }
                context.Users.UpdateRange(listUSer);
                context.SaveChanges();
                foreach(var c in listcontact)
                {
                    if (!string.IsNullOrEmpty(c.PhoneNumber))
                    {
                        c.PhoneNumber = ReplacePhoneNumber1.FixPhone(c.PhoneNumber);
                    }
                    if (!string.IsNullOrEmpty(c.MobileNumber))
                    {
                        c.MobileNumber = ReplacePhoneNumber1.FixPhone(c.MobileNumber);
                    }
                }
                context.Contacts.UpdateRange(listcontact);
                context.SaveChanges();
                foreach(var l in listLocation)
                {
                    if (!string.IsNullOrEmpty(l.PhoneNumber))
                    {
                        l.PhoneNumber = ReplacePhoneNumber1.FixPhone(l.PhoneNumber);
                    }
                  
                }
                context.Locations.UpdateRange(listLocation);
                context.SaveChanges();

               
            }


         }

        //private static void MigrateBrands()
        //{
        //    Console.WriteLine("Migrate Brand table");



        //    using (var dbfrom = new TransporaDBFromContext())
        //    {
        //        TransporaDBContext context = new TransporaDBContext();

        //        var listBrand = context.Brands.ToList();
        //        //context.Brands.RemoveRange(listBrand);
        //        //context.SaveChanges();


        //        var countryData = dbfrom.TblBrands.ToList();
        //        if (listBrand.Any())
        //        {
        //            var ids = listBrand.Select(x => x.Id).ToList();
        //            countryData = countryData.Where(x => !ids.Contains(x.atr_manufacterers_id)).ToList();
        //        }
        //        foreach (var item in countryData)
        //        {
        //            context.Brands.Add(new Brand()
        //            {
        //                Id = item.atr_manufacterers_id,
        //                IsActive = true,
        //                IsDelete = false,
        //                Name = item.atr_manufacterers_name,
        //                CreatedDate = item.atr_manufacterers_creation,
        //                UpdatedDate = item.atr_manufacterers_creation,
        //                CreatedBy = "system",
        //                UpdatedBy = "system"
        //            });
        //        }

        //        context.SaveChanges();
        //    }

        //    Console.WriteLine("Migrate Brand table - Done");

        //}
        private static void MigrateDocuments()
        {
            Console.WriteLine("TenderBid table");

            using (var dbfrom = new TransporaDBFromContext())
            {
                TransporaDBContext context = new TransporaDBContext();

                var languageList = context.Languages.ToList();

                //context.TenderBids.RemoveRange(context.TenderBids.ToList());
                //context.SaveChanges();

                var usersList = context.Users.ToList();
                var tblBids = dbfrom.TblBids.Where(x=>x.atr_bids_companyid != "164").ToList();
                var listTender = dbfrom.TblTenders.Where(x=>x.atr_tenders_companyid != "163").ToList();
                var listInvoice = dbfrom.TblInvoices.ToList();
                foreach (var item in tblBids)
                {

                    var user = usersList.FirstOrDefault(x => x.Id == item.atr_bids_userid);

                    var tenderBid = new TenderBid()
                    {
                        Id = item.atr_bids_id.Value,
                        TenderId = Int32.Parse(item.atr_bids_tendersid),
                        Total = item.atr_bids_amount == null ? 0 : (decimal)item.atr_bids_amount,
                        TransportPrice = item.atr_bids_amount == null ? 0 : (decimal)item.atr_bids_amount,
                        TransportPermit = 0,
                        LegalFees = 0,
                        SuccessFees = 0,
                        CreatedBy = user?.FullName,
                        UpdatedBy = user?.FullName,
                        UpdatedDate = item.atr_bids_update,
                        CreatedDate = item.atr_bids_creation.Value,
                        // BidderEmail = item.atr_bids_email,
                        BidderEmail = _isEmailReal ? item.atr_bids_email : _email,
                        IsDelete = false,
                        IsActive = true,
                        Currency = item.atr_bids_currency,
                        BidCompanyId = int.Parse(item.atr_bids_companyid),
                        IsOfferSelected = item.atr_bids_status == null ? false : item.atr_bids_status.Equals("Bid Winner"),

                    };

                    context.TenderBids.Add(tenderBid);
                    context.SaveChanges();
                    if (!string.IsNullOrEmpty(item.atr_bids_status) && item.atr_bids_status.Equals("Bid Winner"))
                    {
                        // create invoice for tender creator
                        var tenderid = int.Parse(item.atr_bids_tendersid);
                        var tender = listTender.FirstOrDefault(x => x.atr_tenders_id == tenderid);
                        var createorCompanyId = Int32.Parse(tender?.atr_tenders_companyid);
                        var invoicecreator = listInvoice.FirstOrDefault(x => x.atr_invoices_id == item.atr_bids_billomat_invoice_cid);
                        var invoicebider = listInvoice.FirstOrDefault(x => x.atr_invoices_id == item.atr_bids_billomat_invoice_id);
                        if(invoicecreator == null && item.atr_bids_billomat_invoice_cid == 12861006)
                        {
                            invoicecreator = invoicebider;
                            invoicecreator.atr_invoices_invoice_number = "INV: 00000270";
                        }
                        var listDocuments = new List<Document>()
                        {
                            new Document
                            {
                                TenderId = Int32.Parse(item.atr_bids_tendersid),
                                DocumentTypeId = 1,
                                BillomatId = (int)item.atr_bids_billomat_confirmation_cid.Value,
                                IsConstructor = true,
                                CompanyId = createorCompanyId,
                                BillomatType = "CONFIRMATION",
                                BillomatNo = "ORC:",
                                Status = "DRAFT",
                                IsActive = true,
                               CreatedDate = (DateTime)item.atr_bids_creation,

                            },
                               new Document
                                {
                                    TenderId = tenderid,
                                    DocumentTypeId = 2,
                                    BillomatType = "DELIVERY_NOTE",
                                    BillomatId = (int)item.atr_bids_billomat_deliverynote_cid,
                                    BillomatNo = "DEC:",
                                    CompanyId = createorCompanyId,
                                    IsConstructor = true,
                                    Status =  "DRAFT",
                                    IsActive = true,
                                     CreatedDate = (DateTime)item.atr_bids_creation,
                                },
                                new Document
                                {
                                    TenderId = tenderid,
                                    DocumentTypeId = 3,
                                    BillomatType = "INVOICE",
                                    BillomatId = (int)item.atr_bids_billomat_invoice_cid.Value,
                                    BillomatNo = invoicecreator?.atr_invoices_invoice_number,
                                    CompanyId = createorCompanyId,
                                    IsConstructor = true,
                                    Amount =  (decimal)invoicecreator?.atr_invoices_total_gross,
                                     Currency = invoicecreator?.atr_invoices_currency_code,
                                     DueDate = invoicecreator?.atr_invoices_due_date,
                                     InvoiceDate = invoicecreator?.atr_invoices_date,
                                     IsActive = true,
                                      CreatedDate = (DateTime)item.atr_bids_creation,
                                      Status = invoicecreator.atr_invoices_status,

                                },
                                new Document
                                {
                                    TenderId = tenderid,
                                    DocumentTypeId = 1,
                                    BillomatType ="CONFIRMATION",
                                    BillomatId = (int)item.atr_bids_billomat_confirmation_id,
                                    BillomatNo ="ORC:",
                                    CompanyId = int.Parse(item.atr_bids_companyid),
                                    Status = "DRAFT",
                                    IsConstructor = false,
                                    IsActive = false,
                                     CreatedDate = (DateTime)item.atr_bids_creation,

                                },
                                new Document
                                {
                                    TenderId = tenderid,
                                    DocumentTypeId = 2,
                                    BillomatType = "DELIVERY_NOTE",
                                    BillomatId = (int)item.atr_bids_billomat_deliverynote_id,
                                    BillomatNo = "DEC:",
                                    CompanyId = int.Parse(item.atr_bids_companyid),
                                    IsConstructor = false,
                                    Status =  "DRAFT",
                                    IsActive = true,
                                     CreatedDate = (DateTime)item.atr_bids_creation,
                                },
                                new Document
                                {
                                    TenderId = tenderid,
                                    DocumentTypeId = 3,
                                    BillomatType = "INVOICE",
                                    BillomatId = (int)item.atr_bids_billomat_invoice_id.Value,
                                    BillomatNo = invoicebider?.atr_invoices_invoice_number,
                                    CompanyId = int.Parse(item.atr_bids_companyid),
                                    IsConstructor = false,
                                    Amount =  (decimal)invoicebider?.atr_invoices_total_gross,
                                     Currency = invoicebider?.atr_invoices_currency_code,
                                     DueDate = invoicebider?.atr_invoices_due_date,
                                     InvoiceDate = invoicebider?.atr_invoices_date,
                                     IsActive = true,
                                     CreatedDate = (DateTime)invoicebider?.atr_invoices_created,
                                     Status = invoicebider?.atr_invoices_status,
                                }

                        };
                        context.Documents.AddRange(listDocuments);
                    }


                    context.SaveChanges();

                }

                Console.WriteLine("TenderBid - Done");

                //    Console.WriteLine("Document");

                //    context.Documents.RemoveRange(context.Documents.ToList());
                //    context.SaveChanges();

                //    foreach (var item in dbfrom.TblInvoices)
                //    {
                //        var bid = tblBids.FirstOrDefault(x => x.atr_bids_billomat_invoice_id.Equals(item.atr_invoices_id) || x.atr_bids_billomat_invoice_cid.Equals(item.atr_invoices_id));

                //        if (bid == null) continue;

                //        context.Documents.Add(new Document()
                //        {
                //            Id = item.id.Value,
                //            CreatedDate = item.atr_invoices_created.Value,
                //            UpdatedDate = item.atr_invoices_updated,
                //            IsDelete = false,
                //            IsActive = true,
                //            TenderId = int.Parse(bid.atr_bids_tendersid),
                //            CompanyId = int.Parse(bid.atr_bids_companyid),
                //            BillomatId = bid.atr_bids_billomat_id == null ? bid.atr_bids_billomat_cid == null ? 0 : bid.atr_bids_billomat_cid.Value : bid.atr_bids_billomat_id.Value,
                //            Status = item.atr_invoices_status,
                //            DocumentTypeId = 3,
                //            BillomatNo = item.atr_invoices_invoice_number,
                //            BillomatType = "INVOICE",
                //            Currency = item.atr_invoices_currency_code,
                //            DueDate = item.atr_invoices_due_date,
                //            InvoiceDate = item.atr_invoices_date,
                //            Amount = (decimal)item.atr_invoices_total_gross
                //        });
                //    }
                //    context.SaveChanges();

                //    Console.WriteLine("Document - Done");

                //    foreach (var item in dbfrom.TblConfirmations)
                //    {
                //        var bid = tblBids.FirstOrDefault(x => x.atr_bids_billomat_confirmation_id.Equals(item.atr_confirmations_id) || x.atr_bids_billomat_confirmation_cid.Equals(item.atr_confirmations_id));

                //        if (bid == null) continue;

                //        context.Documents.Add(new Document()
                //        {
                //            //Id = item.id.Value,
                //            CreatedDate = item.atr_confirmations_created.Value,
                //            UpdatedDate = item.atr_confirmations_updated,
                //            IsDelete = false,
                //            IsActive = true,
                //            TenderId = int.Parse(bid.atr_bids_tendersid),
                //            CompanyId = int.Parse(bid.atr_bids_companyid),
                //            BillomatId = bid.atr_bids_billomat_id == null ? bid.atr_bids_billomat_cid == null ? 0 : bid.atr_bids_billomat_cid.Value : bid.atr_bids_billomat_id.Value,
                //            Status = item.atr_confirmations_status,
                //            DocumentTypeId = 1,
                //            BillomatNo = item.atr_confirmations_confirmation_number,
                //            BillomatType = "CONFIRMATION",
                //            Currency = item.atr_confirmations_currency_code,
                //            //DueDate = item.atr_confirmations_date,
                //            InvoiceDate = item.atr_confirmations_date,
                //            Amount = (decimal)item.atr_confirmations_total_gross
                //        });
                //    }
                //    context.SaveChanges();

                //    Console.WriteLine("Document - Done");

            }


        }

        private static void MigrateTender()
        {
            Console.WriteLine("Tender table");

            using (var dbfrom = new TransporaDBFromContext())
            {
                TransporaDBContext context = new TransporaDBContext();
                var listTender = dbfrom.TblTenders.Where(x=>x.atr_tenders_companyid != "163").ToList();

                var languageList = context.Languages.ToList();
                var countryList = context.Countries.ToList();
                var statusList = context.TenderStatus.ToList();
                var listTenderBid = dbfrom.TblBids.ToList();
                var listprivateTender = dbfrom.TblPrivatebids.Where(x=>x.atr_privatebids_companyid != 164).ToList();
                var listTracker = dbfrom.TblTrackers.ToList();
                var listFright = dbfrom.TblFreight.ToList();


                //context.Tenders.RemoveRange(context.Tenders.ToList());
                //context.SaveChanges();
                //context.Addresses.RemoveRange(context.Addresses.ToList());
                //context.SaveChanges();

                var usersList = context.Users.ToList();

                foreach (var item in listTender)
                {
                    var statusId = item.atr_tenders_state_id switch
                    {
                        1 => 1,
                        2 => 3,
                        3 => 2,
                        4 => 4,
                        5 => 5,
                        6 => 6,
                        7 => 7,
                        8 => 10,
                        _ => 0
                    };
                    int? bidcompanyid = null;
                    var istransportclose = false;
                    var istenderclose = false;
                    if (item.atr_tenders_state_id == 7 || item.atr_tenders_state_id == 6)
                    {
                        var win = listTenderBid.Where(x => x.atr_bids_tendersid.Equals(item.atr_tenders_id.ToString()) && x.atr_bids_status == "Bid Winner").Select(x => x.atr_bids_companyid).FirstOrDefault();
                        bidcompanyid = int.Parse(win);
                        istenderclose = true;
                        istransportclose = true;

                    }
                    var tendertype = 1;
                    var isprivate = listprivateTender.Any(x => x.atr_privatebids_tenderid == item.atr_tenders_id);
                    if (isprivate)
                    {
                        tendertype = 2;
                    }

                    var user = usersList.FirstOrDefault(x => item.atr_tenders_userid.Equals(x.Id.ToString()));

                    var tender = new Tender()
                    {
                        TenderTypeId = tendertype,
                        TenderStatusId = statusId,
                        Id = item.atr_tenders_id.Value,
                        CompanyId = Int32.Parse(item.atr_tenders_companyid),
                        //#00000001
                        TransportNo = string.Format("#{0:D8}", item.atr_tenders_id),
                        //#INT-00000001
                        // InternalReferenceNumber = string.Format("#INT-{0:D8}", item.atr_tenders_id),
                        InternalReferenceNumber = item.atr_tenders_internal_ref,
                        //TenderStartDate = ,
                        //TenderEndDate = DateTime.ParseExact($"{item.atr_tenders_enddate} {item.atr_tenders_endtime}", "dd.MM.yyyy hh:mm:ss tt", CultureInfo.InvariantCulture),
                        //TransporterConfirmDate = DateTime.ParseExact($"{item.atr_tenders_deliverydate} {item.atr_tenders_deliverytime}", "dd.MM.yyyy hh:mm tt", CultureInfo.InvariantCulture),
                        //WithdrawnReason = 
                        //WithdrawnReasonCode 
                        CreatedBy = user?.FullName,
                        UpdatedBy = user?.FullName,
                        CreatedDate =
                            item.atr_tenders_creation == null ? DateTime.Now : item.atr_tenders_creation.Value,
                        UpdatedDate = DateTime.Now,
                        IsTendererConfirmComplete = istenderclose,
                        IsTransporterConfirmComplete = istransportclose,
                        TransportCompanyId = bidcompanyid,

                        IsDelete = false,
                        IsActive = true,
                        ExecutionDate = item.atr_tender_win_timestamp,
                        CreatorEmail = _isEmailReal ? item.atr_tenders_email : _email,
                        //ExecutionDate = 

                    };
                    if (item.atr_tenders_endtime.Length > 9)
                    {
                        tender.TenderEndDate =
                            DateTime.ParseExact($"{item.atr_tenders_enddate} {item.atr_tenders_endtime}",
                                "dd.MM.yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        tender.TenderEndDate =
                            DateTime.ParseExact($"{item.atr_tenders_enddate} {item.atr_tenders_endtime}",
                                "dd.MM.yyyy hh:mm tt", CultureInfo.InvariantCulture);
                    }


                    if (item.atr_tenders_starttime.Length > 9)
                    {
                        tender.TenderStartDate =
                            DateTime.ParseExact($"{item.atr_tenders_startdate} {item.atr_tenders_starttime}",
                                "dd.MM.yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        tender.TenderStartDate =
                            DateTime.ParseExact($"{item.atr_tenders_startdate} {item.atr_tenders_starttime}",
                                "dd.MM.yyyy hh:mm tt", CultureInfo.InvariantCulture);
                    }

                    context.Tenders.Add(tender);
                    // get tender load vẻison 1
                    if (item.atr_tenders_id <= 16)
                    {
                        var fromContachcheck = context.Contacts.FirstOrDefault(x =>
                            x.FirstName == item.atr_tenders_fromcontact_fname &&
                            x.LastName == item.atr_tenders_fromcontact_lname &&
                            x.Email == item.atr_tenders_fromcontactemail
                        );
                        if (fromContachcheck != null && string.IsNullOrEmpty(fromContachcheck.PhoneNumber))
                        {
                            fromContachcheck.PhoneNumber = ReplacePhoneNumber1.ReplacePhoneNumber(item.atr_tenders_fromcontactnumber).PhoneNumber;
                            fromContachcheck.PhoneNumberCountryCode = ReplacePhoneNumber1.ReplacePhoneNumber(item.atr_tenders_fromcontactnumber).PhoneCode;
                            context.Contacts.Update(fromContachcheck);
                            context.SaveChanges();
                        }
                        if (fromContachcheck == null)
                        {
                           
                            var phonecode = "";
                            var phonenumber = "";

                            if (!string.IsNullOrEmpty(item.atr_tenders_fromcontactnumber))
                            {
                                // var phoneresult = item.atr_tenders_fromcontactnumber.Replace(" ", "");
                                var phoneresult = item.atr_tenders_fromcontactnumber;
                                if (phoneresult.Contains("+"))
                                {
                                    phonecode = "+41";
                                    phonenumber = phoneresult.Substring(3, phoneresult.Length - 3);
                                }
                                else
                                {
                                    //if (phoneresult.Length > 10 && phoneresult.Substring(0, 4).Equals("0041"))
                                    //{
                                    //    phonecode = "+41";
                                    //    phonenumber = phoneresult;
                                    //}
                                    if (phoneresult.Substring(0, 1).Equals("0"))
                                    {
                                        phonecode = "+41";
                                        phonenumber = phoneresult.Substring(1, phoneresult.Length - 1);
                                    }
                                }
                            }
                          var fromcontact = context.Contacts.Add(new Contact()
                            {
                                CreatedBy = "system",
                                UpdatedBy = "system",
                                UpdatedDate = DateTime.Now,
                                CreatedDate = DateTime.Now,
                                IsDelete = false,
                                IsActive = true,
                                CompanyId = Int32.Parse(item.atr_tenders_companyid),
                                Email = _isEmailReal ? item.atr_tenders_fromcontactemail : _email,
                                FirstName = item.atr_tenders_fromcontact_fname,
                                LastName = item.atr_tenders_fromcontact_lname,
                                PhoneNumber =phonenumber,
                                PhoneNumberCountryCode = phonecode,
                                LanguageId = 1,

                            });
                            context.SaveChanges();
                            fromContachcheck = fromcontact.Entity;
                          
                        }

                       


                        var toContachcheck = context.Contacts.FirstOrDefault(x =>
                            x.FirstName == item.atr_tenders_tocontact_fname &&
                            x.LastName == item.atr_tenders_tocontact_lname &&
                            x.Email == item.atr_tenders_tocontactemail
                        );
                        if (toContachcheck != null && string.IsNullOrEmpty(toContachcheck.PhoneNumber))
                        {
                            toContachcheck.PhoneNumber = ReplacePhoneNumber1.ReplacePhoneNumber(item.atr_tenders_tocontactnumber).PhoneNumber;
                            toContachcheck.PhoneNumberCountryCode = ReplacePhoneNumber1.ReplacePhoneNumber(item.atr_tenders_tocontactnumber).PhoneCode;
                            context.Contacts.Update(toContachcheck);
                            context.SaveChanges();
                        }
                        if (toContachcheck == null)
                        {
                            var phonecode1 = "";
                            var phonenumber1 = "";

                            if (!string.IsNullOrEmpty(item.atr_tenders_tocontactnumber))
                            {
                                //var phoneresult = item.atr_tenders_fromcontactnumber.Replace(" ", "");
                                var phoneresult = item.atr_tenders_fromcontactnumber;
                                if (phoneresult.Contains("+"))
                                {
                                    phonecode1 = "+41";
                                    phonenumber1 = phoneresult.Substring(3, phoneresult.Length - 3);
                                }
                                else
                                {
                                    //if (phoneresult.Length > 10 && phoneresult.Substring(0, 4).Equals("0041"))
                                    //{
                                    //    phonecode1 = "+41";
                                    //    phonenumber1 = phoneresult;
                                    //}
                                    if (phoneresult.Substring(0, 1).Equals("0"))
                                    {
                                        phonecode1 = "+41";
                                        phonenumber1 = phoneresult.Substring(1, phoneresult.Length - 1);
                                    }
                                }
                            }

                            var toContact = context.Contacts.Add(new Contact()
                            {
                                CreatedBy = "system",
                                UpdatedBy = "system",
                                UpdatedDate = DateTime.Now,
                                CreatedDate = DateTime.Now,
                                IsDelete = false,
                                IsActive = true,
                                CompanyId = Int32.Parse(item.atr_tenders_companyid),
                                Email = _isEmailReal ? item.atr_tenders_tocontactemail : _email,
                                FirstName = item.atr_tenders_tocontact_fname,
                                LastName = item.atr_tenders_tocontact_lname,
                                PhoneNumber = phonenumber1,
                                PhoneNumberCountryCode = phonecode1,
                                LanguageId = 1,
                            });
                            context.SaveChanges();
                            toContachcheck = toContact.Entity;
                           
                        }

                        var addressFrom = context.Addresses.FirstOrDefault(x =>
                            x.AddressStreetName == item.atr_tenders_fromstreet
                            && x.AddressSreetNumber == item.atr_tenders_fromstreetnumber
                            && x.CityCode == item.atr_tenders_frompostcode
                            && x.City == item.atr_tenders_fromcity

                        );
                        if (addressFrom == null)
                        {
                            var addf = context.Addresses.Add(new Address()
                            {
                                AddressSreetNumber = item.atr_tenders_fromstreetnumber,
                                AddressStreetName = item.atr_tenders_fromstreet,
                                CreatedBy = "system",
                                UpdatedBy = "system",
                                UpdatedDate = DateTime.Now,
                                CreatedDate = DateTime.Now,
                                IsDelete = false,
                                IsActive = true,
                                CompanyId = Int32.Parse(item.atr_tenders_companyid),
                                City = item.atr_tenders_fromcity,
                                CityCode = item.atr_tenders_frompostcode,

                                IsDefault = false,
                                CountryId = 1,


                            });
                            context.SaveChanges();
                            addressFrom = addf.Entity;
                           
                        }
                      

                        var addressTo = context.Addresses.FirstOrDefault(x =>
                            x.AddressStreetName == item.atr_tenders_tostreet
                            && x.AddressSreetNumber == item.atr_tenders_tostreetnumber
                            && x.CityCode == item.atr_tenders_topostcode
                            && x.City == item.atr_tenders_tocity

                        );
                        if (addressTo == null)
                        {
                            var addf = context.Addresses.Add(new Address()
                            {
                                AddressSreetNumber = item.atr_tenders_tostreetnumber,
                                AddressStreetName = item.atr_tenders_tostreet,
                                CreatedBy = "system",
                                UpdatedBy = "system",
                                UpdatedDate = DateTime.UtcNow,
                                CreatedDate = DateTime.UtcNow,
                                IsDelete = false,
                                IsActive = true,
                                CompanyId = Int32.Parse(item.atr_tenders_companyid),
                                City = item.atr_tenders_tocity,
                                CityCode = item.atr_tenders_topostcode,
                                IsDefault = false,
                                CountryId = 1,


                            });
                            context.SaveChanges();
                            addressTo = addf.Entity;
                            
                        }


                      

                        var check = context.TenderLoads.Add(new TenderLoad()
                        {
                            TenderId = tender.Id,
                            PickUpContactId = fromContachcheck.Id,
                            DeliveryContactId = toContachcheck.Id,
                            LoadId = Int32.Parse(item.atr_tenders_machinesid),
                            FreightCategoryId = 1,
                            PickUpAddressId = addressFrom.Id,
                            DeliveryAddressId = addressTo.Id,
                            DeliveryDate = DateTime.ParseExact($"{item.atr_tenders_deliverydate} {item.atr_tenders_deliverytime}", "dd.MM.yyyy hh:mm tt", CultureInfo.InvariantCulture),
                            PickUpDate = DateTime.ParseExact($"{item.atr_tenders_pickupdate} {item.atr_tenders_pickuptime}", "dd.MM.yyyy hh:mm tt", CultureInfo.InvariantCulture),
                        });
                        context.SaveChanges();
                    }
                    /// get data véion 1
                   if(item.atr_tenders_id > 16)
                    {

                        var listtransport = listFright.Where(x => x.atr_freight_tenderid == item.atr_tenders_id).ToList();
                        foreach (var transport in listtransport)
                        {
                            var fromContachcheck1 = context.Contacts.FirstOrDefault(x =>
                                x.FirstName.Equals(transport.atr_freight_fromcontact_fname) &&
                                x.LastName.Equals(transport.atr_freight_fromcontact_lname) &&
                                x.Email.Equals(transport.atr_freight_fromcontactemail)
                            );
                            if(fromContachcheck1 !=null && string.IsNullOrEmpty(fromContachcheck1.PhoneNumber))
                            {
                               fromContachcheck1.PhoneNumber =  ReplacePhoneNumber1.ReplacePhoneNumber(transport.atr_freight_fromcontactnumber).PhoneNumber;
                                fromContachcheck1.PhoneNumberCountryCode = ReplacePhoneNumber1.ReplacePhoneNumber(transport.atr_freight_fromcontactnumber).PhoneCode;
                                context.Contacts.Update(fromContachcheck1);
                                context.SaveChanges();
                            }
                            if (fromContachcheck1 == null)
                            {
                                var phonecode1 = "";
                                var phonenumber1 = "";

                                if (!string.IsNullOrEmpty(transport.atr_freight_fromcontactnumber))
                                {
                                   // var phoneresult = transport.atr_freight_fromcontactnumber.Replace(" ", "");
                                    var phoneresult = transport.atr_freight_fromcontactnumber;
                                    if (phoneresult.Contains("+"))
                                    {
                                        phonecode1 = "+41";
                                        phonenumber1 = phoneresult.Substring(3, phoneresult.Length - 3);
                                    }
                                    else
                                    {
                                       
                                        if ( phoneresult.Substring(0, 1).Equals("0"))
                                        {
                                            phonecode1 = "+41";
                                            phonenumber1 = phoneresult.Substring(1, phoneresult.Length - 1);
                                        }
                                    }
                                }
                                var fromcontact = context.Contacts.Add(new Contact()
                                {
                                    CreatedBy = "system",
                                    UpdatedBy = "system",
                                    UpdatedDate = DateTime.Now,
                                    CreatedDate = DateTime.Now,
                                    IsDelete = false,
                                    IsActive = true,

                                    CompanyId = Int32.Parse(item.atr_tenders_companyid),
                                    Email = _isEmailReal ? transport?.atr_freight_fromcontactemail : _email,
                                    FirstName = transport.atr_freight_fromcontact_fname,
                                    LastName = transport.atr_freight_fromcontact_lname,
                                  PhoneNumber =phonenumber1,
                                  PhoneNumberCountryCode = phonecode1,
                                   // PhoneNumber = DataTo.ReplacePhoneNumber1.ReplacePhoneNumber(transport.atr_freight_fromcontactnumber).PhoneNumber,
                                   // PhoneNumberCountryCode = ReplacePhoneNumber1.ReplacePhoneNumber(transport.atr_freight_fromcontactnumber).PhoneCode,
                                    LanguageId = 1,

                                });
                                context.SaveChanges();
                                fromContachcheck1 = fromcontact.Entity;
                               
                            }

                           


                            var toContachcheck1 = context.Contacts.FirstOrDefault(x =>
                                x.FirstName.Equals(transport.atr_freight_tocontact_fname) &&
                                x.LastName.Equals(transport.atr_freight_tocontact_lname) &&
                                x.Email.Equals(transport.atr_freight_tocontactemail)
                            );
                            if (toContachcheck1 != null && string.IsNullOrEmpty(toContachcheck1.PhoneNumber))
                            {
                                toContachcheck1.PhoneNumber = ReplacePhoneNumber1.ReplacePhoneNumber(transport.atr_freight_tocontactnumber).PhoneNumber;
                                toContachcheck1.PhoneNumberCountryCode = ReplacePhoneNumber1.ReplacePhoneNumber(transport.atr_freight_tocontactnumber).PhoneCode;
                                context.Contacts.Update(toContachcheck1);
                                context.SaveChanges();
                            }
                            if (toContachcheck1 == null)
                            {
                                var phonecode1 = "";
                                var phonenumber1 = "";

                                if (!string.IsNullOrEmpty(transport.atr_freight_tocontactnumber))
                                {
                                    var phoneresult = transport.atr_freight_tocontactnumber;
                                    if (phoneresult.Contains("+"))
                                    {
                                        phonecode1 = "+41";
                                        phonenumber1 = phoneresult.Substring(3, phoneresult.Length - 3);
                                    }
                                    else
                                    {
                                        
                                        if (phoneresult.Substring(0, 1).Equals("0"))
                                        {
                                            phonecode1 = "+41";
                                            phonenumber1 = phoneresult.Substring(1, phoneresult.Length - 1);
                                        }
                                    }
                                }
                                var toContact1 = context.Contacts.Add(new Contact()
                                {
                                    CreatedBy = "system",
                                    UpdatedBy = "system",
                                    UpdatedDate = DateTime.Now,
                                    CreatedDate = DateTime.Now,
                                    IsDelete = false,
                                    IsActive = true,
                                    CompanyId = Int32.Parse(item.atr_tenders_companyid),
                                    Email = _isEmailReal ? transport?.atr_freight_tocontactemail : _email,
                                    FirstName = transport?.atr_freight_tocontact_fname,
                                    LastName = transport?.atr_freight_tocontact_lname,
                                   // MobileNumber = ReplacePhoneNumber1.ReplacePhoneNumber(transport?.atr_freight_tomobilenumber).PhoneNumber,
                                   // MobileNumberCountryCode = ReplacePhoneNumber1.ReplacePhoneNumber(transport?.atr_freight_tomobilenumber).PhoneCode,
                                   // PhoneNumber = ReplacePhoneNumber1.ReplacePhoneNumber(transport?.atr_freight_tocontactnumber).PhoneNumber,
                                   // PhoneNumberCountryCode = ReplacePhoneNumber1.ReplacePhoneNumber(transport.atr_freight_tocontactnumber).PhoneCode,
                                   PhoneNumber = phonenumber1,
                                   PhoneNumberCountryCode = phonecode1,
                                    LanguageId = 1,
                                });
                                toContachcheck1 = toContact1.Entity;
                                context.SaveChanges();
                            }

                            var addressFrom1 = context.Addresses.FirstOrDefault(x =>
                                x.AddressStreetName.Equals(transport.atr_freight_fromstreet)
                                && x.AddressSreetNumber.Equals(transport.atr_freight_fromstreetnumber)
                                && x.CityCode.Equals(transport.atr_freight_frompostcode)
                                && x.City.Equals(transport.atr_freight_fromcity)

                            );
                            if (addressFrom1 == null)
                            {
                                var addf1 = context.Addresses.Add(new Address()
                                {
                                    AddressSreetNumber = transport.atr_freight_fromstreetnumber,
                                    AddressStreetName = transport.atr_freight_fromstreet,
                                    CreatedBy = "system",
                                    UpdatedBy = "system",
                                    UpdatedDate = DateTime.Now,
                                    CreatedDate = DateTime.Now,
                                    IsDelete = false,
                                    IsActive = true,
                                    CompanyId = Int32.Parse(item.atr_tenders_companyid),
                                    City = transport.atr_freight_fromcity,
                                    CityCode = transport.atr_freight_frompostcode,
                                    IsDefault = false,
                                    CountryId = 1,


                                });
                                addressFrom1 = addf1.Entity;
                                context.SaveChanges();
                            }
                          
                           

                            var addressTo1 = context.Addresses.FirstOrDefault(x =>
                                x.AddressStreetName.Equals(transport.atr_freight_tostreet)
                                && x.AddressSreetNumber.Equals(transport.atr_freight_tostreetnumber)
                                && x.City.Equals(transport.atr_freight_tocity)
                                && x.CityCode.Equals(transport.atr_freight_topostcode)

                            );
                            if (addressTo1 == null)
                            {
                                var addf1 = context.Addresses.Add(new Address()
                                {
                                    AddressSreetNumber = transport.atr_freight_tostreetnumber,


                                    AddressStreetName = transport.atr_freight_tostreet,
                                    CreatedBy = "system",
                                    UpdatedBy = "system",
                                    UpdatedDate = DateTime.UtcNow,
                                    CreatedDate = DateTime.UtcNow,
                                    IsDelete = false,
                                    IsActive = true,
                                    CompanyId = Int32.Parse(item.atr_tenders_companyid),
                                    City = transport.atr_freight_tocity,
                                    CityCode = transport.atr_freight_topostcode,
                                    IsDefault = false,
                                    CountryId = 1,


                                });
                                addressTo1 = addf1.Entity;
                                context.SaveChanges();
                            }
                          

                            var check = context.TenderLoads.Add(new TenderLoad()
                            {
                                TenderId = tender.Id,
                                PickUpContactId = fromContachcheck1.Id,
                                DeliveryContactId = toContachcheck1.Id,
                                LoadId = transport.atr_freight_machinesid,
                                FreightCategoryId = 1,
                                PickUpAddressId = addressFrom1.Id,
                                DeliveryAddressId = addressTo1.Id,
                                DeliveryDate = DateTime.ParseExact($"{transport.atr_freight_deliverydate} {transport.atr_freight_deliverytime}", "dd.MM.yyyy hh:mm tt", CultureInfo.InvariantCulture),
                                PickUpDate = DateTime.ParseExact($"{transport.atr_freight_pickupdate} {transport.atr_freight_pickuptime}", "dd.MM.yyyy hh:mm tt", CultureInfo.InvariantCulture),
                            });
                            context.SaveChanges();
                        }
                    }

                }



            }

            Console.WriteLine("Tender - Done");



        }


        private static void MigrateMachines()
        {

            Console.WriteLine("Machines table // Load");

            using (var dbfrom = new TransporaDBFromContext())
            {
                TransporaDBContext context = new TransporaDBContext();
                var listcompany = dbfrom.TblCompanies.Select(x => x.atr_companies_id).ToList();
                var listloadcurrent = context.Loads.ToList().Select(x=>x.Id);
                var listload = dbfrom.TblMachines.Where(x => x.atr_machines_companyid != "163" && x.atr_machines_companyid != "164" && !listloadcurrent.Contains((int)x.atr_machines_id)).ToList();
                

                //context.Loads.RemoveRange(context.Loads.ToList());
                //context.SaveChanges();

                foreach (var item in listload)
                {


                    context.Loads.Add(new Load()
                    {
                        Id = item.atr_machines_id.Value,
                        BrandId = item.atr_brand_id ?? 0,
                        ProductFamilyId = item.atr_family_id ?? 0,
                        CompanyId = Int32.Parse(item.atr_machines_companyid),
                        FreightCategoryId = 1,
                        Length = decimal.Parse(item.atr_machines_length),
                        Weight = decimal.Parse(item.atr_machines_weight),
                        Width = decimal.Parse(item.atr_machines_width),
                        Height = decimal.Parse(item.atr_machines_height),
                        CreatedBy = "system",
                        UpdatedBy = "system",
                        IsDelete = false,
                        IsActive = true,
                        UpdatedDate = DateTime.Now,
                        CreatedDate = item.atr_machines_creation.Value,
                        InventoryNo = item.atr_machines_inventory,
                        Plate = item.atr_machines_numberplate,
                        SerialNo = item.atr_machines_serialnumber,
                        Type = item.atr_type_name,
                        //ImageUrls = 

                    });
                }

                context.SaveChanges();
            }

            Console.WriteLine("Machines table // Load - Done");


        }



        //private static void MigrateProductFamily()
        //{
        //    Console.WriteLine("Family table // ProductFamily");

        //    using (var dbfrom = new TransporaDBFromContext())
        //    {
        //        TransporaDBContext context = new TransporaDBContext();

        //        context.ProductFamilyTranslations.RemoveRange(context.ProductFamilyTranslations.ToList());
        //        context.SaveChanges();

        //        var listBrand = context.ProductFamilies.ToList();
        //        context.ProductFamilies.RemoveRange(listBrand);
        //        context.SaveChanges();


        //        foreach (var item in dbfrom.TblFamilies)
        //        {

        //            var pro = new ProductFamily()
        //            {
        //                Id = item.atr_family_products_id,
        //                CreatedBy = "system",
        //                UpdatedBy = "system",
        //                CreatedDate = DateTime.Now,
        //                UpdatedDate = DateTime.Now
        //            };

        //            context.ProductFamilies.Add(pro);
        //            context.SaveChanges();

        //            context.ProductFamilyTranslations.Add(new ProductFamilyTranslation()
        //            {
        //                Translation = item.atr_family_products_english,
        //                LanguageCode = "en",
        //                LanguageId = 1,
        //                ProductFamilyId = pro.Id,
        //            });
        //            context.ProductFamilyTranslations.Add(new ProductFamilyTranslation()
        //            {
        //                Translation = item.atr_family_products_deutsch,
        //                LanguageCode = "de",
        //                LanguageId = 2,
        //                ProductFamilyId = pro.Id,
        //            });
        //            context.ProductFamilyTranslations.Add(new ProductFamilyTranslation()
        //            {
        //                Translation = item.atr_family_products_french,
        //                LanguageCode = "fr",
        //                LanguageId = 3,
        //                ProductFamilyId = pro.Id,
        //            });
        //            context.ProductFamilyTranslations.Add(new ProductFamilyTranslation()
        //            {
        //                Translation = item.atr_family_products_italian,
        //                LanguageCode = "it",
        //                LanguageId = 4,
        //                ProductFamilyId = pro.Id,
        //            });
        //            context.SaveChanges();
        //        }

        //    }

        //    Console.WriteLine("Family table // ProductFamily - Done");

        //}
        //private static void MigrateCompany()
        //{
        //    Console.WriteLine("Company table");

        //    using (var dbfrom = new TransporaDBFromContext())
        //    {
        //        TransporaDBContext context = new TransporaDBContext();

        //        //context.Companies.RemoveRange(context.Companies.ToList());
        //        //context.SaveChanges();

        //        var languageList = context.Languages.ToList();
        //        var countryList = context.Countries.ToList();
        //        var listregistration = dbfrom.TblNewregistrations.ToList();
        //        var lilstuser = dbfrom.TblUsers.ToList();
        //        var listlocation = context.Locations.ToList();
        //        var listlocationids = listlocation.Select(x => x.Id).ToList();


        //        foreach (var item in dbfrom.TblCompanies)


        //        {
        //            var languagecode = "";
        //            if(item.atr_companies_language.ToLower() == "deutsch")
        //            {
        //                languagecode = "de";
        //            }
        //            if (item.atr_companies_language.ToLower() == "english")
        //            {
        //                languagecode = "en";
        //            }
        //            if (item.atr_companies_language.ToLower() == "french")
        //            {
        //                languagecode = "fr";
        //            }
        //            if (item.atr_companies_language.ToLower() == "italian")
        //            {
        //                languagecode = "it";
        //            }
        //            //  var divisionid = listregistration.Where(x => x.company_id == item.atr_companies_id).Select(x => x.companydivision).FirstOrDefault();
        //            var divisionid = item.atr_companies_division_id;

        //            var lang = languageList.FirstOrDefault(x =>
        //                x.Code.ToLower().Equals(languagecode));

        //            if (lang == null)
        //            {
        //                //lang code is null. =>  check theo tên
        //                lang = languageList.FirstOrDefault(x =>
        //                    x.Code.ToLower().Equals("de"));
        //            }
        //            //var division_item = item.atr_companies_division.ToLower();
        //            //if(division_item == "construction company" || division_item == "bauunternehmen" || division_item == "entreprise de construction" || division_item == "impresa di costruzioni")
        //            //{
        //            //    divisionid = 1;
        //            //}
        //            //else if(division_item == "construction machinery dealer" || division_item == "baumaschinenhändler" || division_item == "concessionnaire de machines de construc" || division_item == "rivenditore di macchine da costr")
        //            //{
        //            //    divisionid = 2;
        //            //}
        //            //else if (division_item == "construction machinery rental" || division_item == "baumaschinenvermieter" || division_item == "location de machines de construc" || division_item == "noleggio di macchinari per l'edi")
        //            //{
        //            //    divisionid = 3;
        //            //}
        //            //else if (division_item == "forwarding company" || division_item == "speditionsunternehmen" || division_item == "société de transport" || division_item == "società di spedizione")
        //            //{
        //            //    divisionid = 4;
        //            //}



        //            var country = countryList.FirstOrDefault(x => x.Name.Equals(item.atr_companies_country));
        //            if (country == null)
        //            {
        //                Console.WriteLine("Country is null: " + item.atr_companies_country);
        //                continue;
        //            }
        //            var division = new List<int>();
        //            if (divisionid <8)
        //            {
        //                division.Add((int)divisionid);
        //            }
        //            //if (item.atr_companies_id == 1)
        //            //{
        //            //    Console.WriteLine("Ignore Id: 1");
        //            //    continue;
        //            //}
        //            var phonecode = "";
        //            var phonenumber = "";
        //            var phone = item.atr_companies_phonenumber;
        //            if (!string.IsNullOrEmpty(phone))
        //            {
        //                if (item.atr_companies_phonenumber.Contains("+"))
        //                {
        //                    phonecode = "+41";
        //                    phonenumber = phone.Substring(3, phone.Length-3);
        //                }
        //                else
        //                {
        //                    phonecode = "+41";
        //                    phonenumber = phone;
        //                }
        //            }

        //            var roleId = item.atr_companies_role switch
        //            {
        //                1 => 4,
        //                4 => 3,
        //                3 => 2,
        //                _ => 3
        //            };


        //            context.Companies.Add(new Company()
        //            {
        //                Id = item.atr_companies_id,
        //                CompanyName = item.atr_companies_name,
        //                Image = item.atr_companies_imagedata,
        //                Email = _isEmailReal ? item.atr_companies_email : _email,
        //                PhoneNumberCountryCode = phonecode,
        //                PhoneNumber = phonenumber,
        //                CreatedDate = item.atr_companies_creation.HasValue ? item.atr_companies_creation.Value : DateTime.Now,
        //                UpdatedDate = DateTime.Now,
        //                //CreatedBy = 
        //                CompanyStreetName = item.atr_companies_streetname,
        //                CompanyStreetNumber = item.atr_companies_streetnumber,
        //                CityName = item.atr_companies_city,
        //                CityCode = item.atr_companies_postcode,
        //                UIDNumber = item.atr_companies_uidnumber,
        //                BillomatClientId = ( item.atr_companies_billomat_id.HasValue  && item.atr_companies_billomat_id > 0) ? item.atr_companies_billomat_id.Value : 0 ,
        //                IsDelete = false,
        //                Website = item.atr_companies_url,
        //                MarketSegmentIds = !division.Any() ? JsonConvert.SerializeObject(new List<int>()) : JsonConvert.SerializeObject(division),
        //                CompanyStatusId = 1,//fix
        //              //  CompanyRoleId = roleId, //fix
        //                 CompanyRoleId = item.atr_companies_id == 1 ? 4 : 1,
        //                LanguageId = lang?.Id,
        //                CountryId = country.Id,
        //            });


        //        }
        //        //context.Companies.Add(new Company()
        //        //{
        //        //    Id = 163,
        //        //    IsDelete = false,
        //        //    CompanyName = "Erne AG",
        //        //    CountryId = 1,
        //        //    CompanyRoleId = 1,
        //        //    CompanyStatusId = 1
        //        //});
        //        //context.Companies.Add(new Company()
        //        //{
        //        //    Id = 164,
        //        //    IsDelete = false,
        //        //    CompanyName = "Hand AG",
        //        //    CountryId = 1,
        //        //    CompanyRoleId = 1,
        //        //    CompanyStatusId = 1
        //        //});
        //        //context.Companies.Add(new Company()
        //        //{
        //        //    Id = 165,
        //        //    IsDelete = false,
        //        //    CompanyName = "HOLZ drive",
        //        //    CountryId = 1,
        //        //    CompanyRoleId = 1,
        //        //    CompanyStatusId = 1
        //        //}); context.Companies.Add(new Company()
        //        //{
        //        //    Id = 166,
        //        //    IsDelete = false,
        //        //    CompanyName = "Baustelle Hand",
        //        //    CountryId = 1,
        //        //    CompanyRoleId = 1,
        //        //    CompanyStatusId = 1
        //        //});




        //        context.SaveChanges();
        //    }

        //    Console.WriteLine("Company - Done");



        //}
        //private static void MigrateLocations()
        //{
        //    Console.WriteLine("location table // location");

        //    using (var dbfrom = new TransporaDBFromContext())
        //    {
        //        TransporaDBContext context = new TransporaDBContext();

        //        //context.Locations.RemoveRange(context.Locations.ToList());
        //        //context.SaveChanges();

        //        var listuser = dbfrom.TblUsers.ToList();
        //        var languageList = context.Languages.ToList();
        //        var countryList = context.Countries.ToList();
        //        var ListCompany = context.Companies.ToList();


        //        foreach (var item in dbfrom.TblLocations)
        //        {
        //            var user = listuser.FirstOrDefault(x => x.atr_users_id == item.atr_locations_creatorid);
        //            //var country = countryList.FirstOrDefault(x => x.Name.ToLower().StartsWith(item.atr_locations_countryid.ToLower()));

        //            //if (country == null)
        //            //{
        //            //    if (item.atr_locations_countryid.Equals("Schweiz"))
        //            //    {
        //            //        country = countryList.FirstOrDefault(x => x.Name.StartsWith("Switzerland"));
        //            //    }
        //            //}

        //            //if (country == null)
        //            //{
        //            //    Console.WriteLine("Khong the insert ban ghi co country la: " + item.atr_locations_countryId);
        //            //    continue;
        //            //}
        //            var phonecode = "";
        //            var phonenumber = "";
        //            var phone = item.atr_locations_phonenumber;
        //            if (!string.IsNullOrEmpty(phone))
        //            {
        //                if (phone.Contains("+"))
        //                {
        //                    phonecode = "+41";
        //                    phonenumber = phone.Substring(3, phone.Length - 3);
        //                }
        //                else
        //                {
        //                    phonecode = "+41";
        //                    phonenumber = phone;
        //                }
        //            }

        //            context.Locations.Add(new Location()
        //            {
        //                LocationName = item.atr_locations_name,
        //                LocationStreetName = item.atr_locations_streetname,
        //                LocationStreetNumber = item.atr_locations_streetnumber,
        //                CityName = item.atr_locations_city,
        //                CityCode = item.atr_locations_postcode,
        //                //Website = item.
        //                CompanyId = Int32.Parse(item.atr_locations_companyid),
        //                // CompanyId = 1,
        //                CountryId = 1,
        //                CreatedBy = user != null ? user.atr_users_email : "system",
        //                CreatedDate = item.tbl_locations_created_at,
        //                // UpdatedBy = "",
        //                UpdatedDate = item.tbl_locations_updated_at,
        //                LocationType = 2,
        //                Id = item.atr_locations_id.Value,
        //                IsActive = true,
        //                IsDelete = false,
        //                IsDefault = false,
        //                Email = _isEmailReal ? item.atr_locations_email : _email,
        //                PhoneNumber = phonenumber,
        //                PhoneNumberCountryCode = phonecode,

        //            });
        //        }
        //        context.SaveChanges();
        //        var listlocation = context.Locations.ToList();

        //        foreach (var item in ListCompany)
        //        {

        //            if (listlocation.Where(x => x.CompanyId == item.Id).Count() > 0)
        //            {
        //                var update = listlocation.FirstOrDefault( x =>x.CompanyId == item.Id && x.LocationName.Equals(item.CompanyName));
        //                if (update != null)
        //                {
        //                    update.LocationType = 1;
        //                    context.Locations.Update(update);
        //                }
        //                else
        //                {
        //                    var first = listlocation.FirstOrDefault(x=>x.CompanyId == item.Id);
        //                    first.LocationType = 1;
        //                    context.Locations.Update(first);
        //                }
        //            }
        //            else if (listlocation.Where(x => x.CompanyId == item.Id).Count() == 0)
        //            {
        //                context.Locations.Add(new Location()
        //                {

        //                    LocationName = item.CompanyName,
        //                    LocationStreetName = item.CompanyStreetName,
        //                    LocationStreetNumber = item.CompanyStreetNumber,
        //                    CityName = item.CityName,
        //                    CityCode = item.CityCode,
        //                    //Website = item.
        //                    //CompanyId = Int32.Parse(item.atr_locations_companyid),
        //                    CompanyId = item.Id,
        //                    CountryId = item.CountryId,
        //                    CreatedBy = "system",
        //                    CreatedDate = DateTime.UtcNow,
        //                    UpdatedBy = "system",
        //                    UpdatedDate = DateTime.UtcNow,
        //                    IsActive = true,
        //                    IsDelete = false,
        //                    LocationType = 1,
        //                    IsDefault = false,
        //                    Email = _isEmailReal ? item.Email : _email,
        //                    PhoneNumber = item.PhoneNumber,
        //                    PhoneNumberCountryCode = item.PhoneNumberCountryCode,
        //                });
        //            }
        //        }

        //        context.SaveChanges();
        //    }

        //    Console.WriteLine("location table // location - Done");

        //}

        //private static void MigrateUser()
        //{
        //    Console.WriteLine("User Table");
        //    using (var dbfrom = new TransporaDBFromContext())
        //    {
        //        TransporaDBContext context = new TransporaDBContext();

        //        var languageList = context.Languages.ToList();


        //        var dataUsers = dbfrom.Users.ToList();
        //        var listuser = dbfrom.TblUsers.ToList();
        //        var listuserdefault = dataUsers.GroupBy(x => x.company_id).Select(x=>x.FirstOrDefault()).ToList();
        //        var listlocation = context.Locations.ToList();
        //        var listcompany = context.Companies.ToList();
        //        var listusernotcompany = from i in dataUsers
        //                                 join j in listcompany
        //                                 on i.company_id equals j.Id
        //                                 select(i.id);
        //        var list = listuser.Where(x => listusernotcompany.Contains(x.id)).ToList();
        //        foreach (var item in list)
        //        {

        //            var lang = languageList.FirstOrDefault(x =>
        //                item.atr_users_langconstants.ToLower().StartsWith(x.Code.ToLower()));

        //            var user = dataUsers.FirstOrDefault(x => x.id == item.atr_users_id);
        //            var phonecode = "";
        //            var phonenumber = "";
        //            var phone = item.atr_users_phonenumber;
        //            if (!string.IsNullOrEmpty(phone))
        //            {
        //                if (phone.Contains("+"))
        //                {
        //                    phonecode = "+41";
        //                    phonenumber = phone.Substring(3, phone.Length-3);
        //                }
        //                else
        //                {
        //                    phonecode = "+41";
        //                    phonenumber = phone;
        //                }
        //            }
        //            var mobilecode = "";
        //            var mobilenumber = "";
        //            var mobile = item.atr_users_mobilenumber;
        //            if (!string.IsNullOrEmpty(mobile))
        //            {
        //                if (mobile.Contains("+"))
        //                {
        //                    mobilecode = "+41";
        //                    mobilenumber = mobile.Substring(3, mobile.Length -3);
        //                }
        //                else
        //                {
        //                    mobilecode = "+41";
        //                    mobilenumber = mobile;
        //                }
        //            }

        //            var roleId = item.atr_users_role_id switch
        //            {
        //                1 => 1,
        //                2 => 2,
        //                11 => 3,
        //                12 => 5,
        //                _ => 5
        //            };

        //            // var id = item.atr_users_id.Value == 1 ? 3 : item.atr_users_id.Value;
        //            var location = listlocation.FirstOrDefault(x => x.CompanyId == user?.company_id && x.LocationType ==1);
        //            var id = item.atr_users_id.Value ;

        //            //var isdefault = false;
        //            //var company = dbfrom.TblCompanies.FirstOrDefault(x => x.atr_companies_id.ToString().Equals(item.atr_users_companyid));
        //            //if(company == null)
        //            //{
        //            //    isdefault = false;
        //            //}
        //            //var userdefault = dbfrom.TblUsers.Where(x => x.atr_users_companyid.Equals(company.atr_companies_id.ToString())).FirstOrDefault();
        //            //if(userdefault != null && userdefault.atr_users_id.Value == id)
        //            //{
        //            //    isdefault = true;
        //            //}
        //            context.Users.Add(new User()
        //            {
        //                Id = id,
        //                LastName = item.atr_users_lastname,
        //                FirstName = item.atr_users_firstname,
        //                FullName = $"{item.atr_users_firstname} {item.atr_users_lastname}",
        //                //LocationId = 
        //                PhoneNumberCountryCode = phonecode,
        //                PhoneNumber = phonenumber,
        //                MobileNumberCountryCode = mobilecode,
        //                MobileNumber = mobilenumber,
        //                LanguageId = lang?.Id,
        //                LanguageName = item.atr_users_language,
        //                //JobTitle = ""
        //                Address = user?.address,
        //                LastLogin = user?.last_login,
        //                CompanyId = user?.company_id,
        //                //Image = 
        //                IsDelete = false,
        //                IsActive = item.atr_users_accept_date != null,
        //                CreatedBy = "",
        //                CreatedDate = user == null ? DateTime.Now : user.created_at.HasValue ? user.created_at.Value : DateTime.Now,
        //                UpdatedDate = user == null ? DateTime.Now : user.updated_at.HasValue ? user.updated_at.Value : DateTime.Now,
        //                IsDefault = listuserdefault.Select(x=>x.id).Contains(id) ? true : false,
        //                UserName = user?.username,
        //                Email = _isEmailReal ? user?.email : _email,
        //                EmailConfirmed = 1,
        //                PhoneNumberConfirmed = 1,
        //                TwoFactorEnabled = 0,
        //                LockoutEnabled = 0,
        //                LocationId = location != null ? location.Id : 0,
        //                IsChangePasswordDefault = false,
        //                AccessFailedCount = 0,
        //                //pass: 123456
        //                PasswordHash = "AQAAAAEAACcQAAAAEEUwc5GJg4Z0ajUdFCMqQkRJ2yeDnY53iIkeWbEqe6KZqT3rsvki7JNqyTH5EdyUGg==",
        //                SecurityStamp = "HSS55WDJXLI2AU32JQMDOPVOZ45QV5AB",
        //                ConcurrencyStamp = "bfc12259-b022-4cfd-b8aa-8064dddc635a"

        //            }) ;
        //            context.SaveChanges();
        //            context.Contacts.Add(new Contact()
        //            {
        //                CreatedBy = "system",
        //                UpdatedBy = "system",
        //                UpdatedDate = DateTime.Now,
        //                CreatedDate = DateTime.Now,
        //                IsDelete = false,
        //                IsActive = true,
        //                CompanyId = (int)user?.company_id,
        //                Email = _isEmailReal ? user?.email : _email,
        //                FirstName = item.atr_users_firstname,
        //                LastName = item.atr_users_lastname,
        //                MobileNumberCountryCode = mobilecode,
        //                MobileNumber = mobilenumber,
        //                PhoneNumberCountryCode = phonecode,
        //                PhoneNumber = phonenumber,
        //                LanguageId = (int)lang?.Id,
        //            });
        //            context.SaveChanges();

        //            context.UserRoles.Add(new UserRole()
        //            {
        //                UserId = id,
        //                RoleId = roleId
        //            });
        //            context.SaveChanges();

        //        }
        //        foreach(var l in listlocation)
        //        {
        //            var userAdmin = dataUsers.FirstOrDefault(x => x.company_id == l.CompanyId && (x.role == 1 || x.role == 11));
        //            l.LocationAdministratorId = userAdmin != null ? (int)userAdmin.id : 0;
        //        }
        //        context.Locations.UpdateRange(listlocation);
        //        context.SaveChanges();

        //    }
        //    Console.WriteLine("User Table: Done");

        //}
    }
   
}
