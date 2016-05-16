using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactsManager.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required, DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required, DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required, DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DataType(DataType.PhoneNumber), DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date), DisplayName("Birth Date")]
        public string BirthDate { get; set; }
        [DataType(DataType.ImageUrl)]
        public string PicturePath { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
        public bool Family { get; set; }
        public bool Friend { get; set; }
        public bool Colleague { get; set; }
        public bool Associate { get; set; }
    }
}