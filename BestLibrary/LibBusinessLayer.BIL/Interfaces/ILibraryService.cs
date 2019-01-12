using LibBusinessLayer.BIL.DTO;
using System.Collections.Generic;

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
