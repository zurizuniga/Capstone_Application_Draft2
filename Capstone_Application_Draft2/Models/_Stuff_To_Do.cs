using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone_Application_Draft2.Models
{
    [MetadataType(typeof(Stuff_to_do_Validation))]
    public partial class Stuff_To_Do
    {

    }

    public class Stuff_to_do_Validation
    {
       [Required]
        public string Todo_Items { get; set; }
        public string Description { get; set; }
    }
}