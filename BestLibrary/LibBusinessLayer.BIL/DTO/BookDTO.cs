using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBusinessLayer.BIL.DTO
{
    //Data Transfer Object (DTO) - специальная модель для передачи данных.
    public class BookDTO
    {
        public int BookID { get; set; }
        public int BookСipher { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public DateTime PrintDate { get; set; }
        public int CountBook { get; set; }
    }
}
