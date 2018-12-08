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
        void MakeUser(UserDTO userDto);
        BookDTO GetBook(int? id);
        IEnumerable<BookDTO> GetBooks();
        bool DeleteBook(int id);
        bool AddBook(BookDTO bookDto);
        bool UpdateBook(BookDTO bookDto);
        void Dispose();
    }
}
