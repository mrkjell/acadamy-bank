using System;

namespace bank
{
    public class Person
    {
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string SocialSecurityNumber { get; set; }
        public string PhoneNumber { get; set; }
         public string Fullname 
         { 
             get {
                 return FirstName + " " + LastName;
             }
         }


    }
}