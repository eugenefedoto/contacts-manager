using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManagerV3.Models
{
    public class GroupViewModel
    {
        // List of groups a contact can be a part of  
        [Display(Name = "Groups")]
        public List<SelectListItem> Groups { set; get; }
    }
}
