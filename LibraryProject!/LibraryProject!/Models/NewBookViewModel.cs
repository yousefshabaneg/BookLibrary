using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryProject_.Models
{
    public class NewBookViewModel
    {
        public IEnumerable<publisher> publshiers { get; set;}
        public Book book { get; set; }
    }
}