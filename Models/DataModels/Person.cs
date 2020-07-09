using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainIT.Models.DataModels
{
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName { get { return string.Format("{0} {1} ", FirstName, LastName); } }

        //CName = Contact Name with Phonenumbers attached !
        public string CName { get { return string.Format("{0} {1} ", FullName, Ssn); } }

        [Display(Name = "Streetaddress")]
        public string StreetAddress { get; set; }

        [Display(Name = "Postalcode")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Address")]
        public string Address { get { return string.Format("{0} {1} {2}", StreetAddress, ZipCode, City); } }

        [Display(Name = "SSN")]
        public string Ssn { get; set; }

        [Display(Name = "Phone 1")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber1 { get; set; }

        [Display(Name = "Phone 2")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber2 { get; set; }

        [Display(Name = "Phone #")]
        public string PhoneNumbers { get { return string.Format("{0} {1} ", PhoneNumber1, PhoneNumber2); } }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //Person Category, Status and Type.
    }
}
