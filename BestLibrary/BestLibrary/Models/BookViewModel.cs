using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLibrary.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public int BookСipher { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public DateTime PrintDate { get; set; }
        public int CountBook { get; set; }
    }
}