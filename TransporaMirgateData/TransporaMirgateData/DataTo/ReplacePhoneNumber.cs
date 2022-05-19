using System;
using System.Collections.Generic;
using System.Text;
using TransporaMirgateData.DataTo.Model;

namespace TransporaMirgateData.DataTo
{
   public static class ReplacePhoneNumber1
    {
        public static PhoneNumberResult ReplacePhoneNumber(this string Phone)
        {
            ;
            var phonecode = "";
            var phonenumber = "";

            if (!string.IsNullOrEmpty(Phone))
            {
                var phoneresult = Phone;
                if (Phone.Contains("+"))
                {
                    phonecode = "+41";
                    phonenumber = phoneresult.Substring(3, phoneresult.Length - 3);
                }
                else
                {
                  if(phoneresult.Substring(0, 1).Equals("0") && phoneresult.Substring(0, 4).Equals("0041"))
                    {
                        phonecode = "+41";
                        phonenumber = phoneresult.Substring(4, phoneresult.Length - 4);
                    }
                   else if (phoneresult.Substring(0, 1).Equals("0"))
                    {
                        phonecode = "+41";
                        phonenumber = phoneresult.Substring(1, phoneresult.Length - 1);
                    }
                    else
                    {
                        phonecode = "+41";
                        phonenumber = phoneresult;
                    }
                    
                }
            }


            return new PhoneNumberResult
            {
                PhoneCode = phonecode,
                PhoneNumber = phonenumber
            };
        }
        public static string FixPhone(this string phone)
        {
            var phoneresult = phone;
            if (phoneresult.Substring(0, 1).Equals("0") && phoneresult.Substring(0, 4).Equals("0041"))
            {
              
                phoneresult = phoneresult.Substring(4, phoneresult.Length - 4);
            }
             if (phoneresult.Substring(0, 1).Equals("0"))
            {

                phoneresult = phoneresult.Substring(1, phoneresult.Length - 1);
            }
            return phoneresult;
        }
    }
}
