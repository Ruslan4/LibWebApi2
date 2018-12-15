using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibBusinessLayer.BIL.DTO;

namespace LibBusinessLayer.BIL.Interfaces
{
    public interface ILibraryService
    {
        BookDto GetBook(int? id);
        IEnumerable<BookDto> GetBooks();
        bool DeleteBook(int id);
        bool AddBook(BookDto bookDto);
        bool UpdateBook(BookDto bookDto);
        void Dispose();
    }
}
