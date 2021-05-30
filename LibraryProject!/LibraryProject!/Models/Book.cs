using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
namespace LibraryProject_.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage="please enter Author name")]
        public string Author { get; set; }
        [Required(ErrorMessage="Please enter book title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter url image for book")]
        public string Url { get; set; }
        [Required(ErrorMessage="Please enter price for book")]
        public int Price { get; set; }
        public bool avaliable { get; set; }
        public publisher publisher { get; set; }
        public int publisherId { get; set; }
    }
}