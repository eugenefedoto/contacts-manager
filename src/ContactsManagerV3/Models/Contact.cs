using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactsManagerV3.Models
{
    /// <summary>
    /// A model for a contact
    /// </summary>
    public class Contact
    {
        // ID needed for database
        public int Id { get; set; }

        public string Key { get; set; }

        // First name field
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        // Last name field
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        // Email address field
        [Required, EmailAddress, Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        // Phone number field
        [Phone, Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        // Birthdate field
        [DataType(DataType.Date), Display(Name = "Birth Date")]
        public string BirthDate { get; set; }

        // Profile Image URL field for uploading a profile picture
        [DataType(DataType.ImageUrl)]
        public string ProfileImagePath { get; set; }

        // Comments field
        [DataType(DataType.MultilineText), Display(Name = "Comments"), MaxLength(2000)]
        public string Comments { get; set; }

        // Contact is an associate
        public bool isAssociate { get; set; }

        // Contact is a colleague
        public bool isColleague { get; set; }

        // Contact is a family
        public bool isFamily { get; set; }
   
        // Contact is a friend
        public bool isFriend { get; set; }

    }


}
