using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManagerV3.Models
{
    /// <summary>
    /// I need this ViewModel so I have a way of storing the list box's values.
    /// In the controller, I will pass everything correctly into the Model.
    /// </summary>
    public class CreateContactViewModel : Contact
    {
        // Selected options in the list box
        public IEnumerable<string> SelectedGroups { get; set; }
    }
}
