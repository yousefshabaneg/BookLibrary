using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryProject_.Models
{
    public class Contact
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(2000)]
        [Required]
        public string Message { get; set; }
    }
}