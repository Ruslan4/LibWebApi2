using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBusinessLayer.BIL.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) - special model for data transfer (Book).
    /// </summary>
    public class BookDto
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
