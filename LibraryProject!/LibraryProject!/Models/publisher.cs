using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject_.Models
{
    public class publisher
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please Enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }
    }
}