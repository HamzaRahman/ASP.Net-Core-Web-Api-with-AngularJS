using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_AngularJS.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Your Full Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only Letters Allowed")]
        public string Name { get; set; }

        
        [Required(ErrorMessage = "Please Enter Your Mobile No")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Only Numbers Allowed")]
        public string PhoneNumber { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
