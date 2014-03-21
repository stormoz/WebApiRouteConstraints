using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RouteConstraints.Models
{
    public class MyViewModel
    {
        [Required]
        public string Name { get; set; }
        public bool Flag { get; set; }
    }
}
