using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibBusinessLayer.BIL.DTO;

namespace LibBusinessLayer.BIL.Interfaces
{
    public interface IIssuanceOfBooksService
    {
        IssuanceOfBooksDto GetIssuance(int? id);
        IEnumerable<IssuanceOfBooksDto> GetIssuances();
        bool ReturnIssuance(int id);
        bool CreateIssuance(IssuanceOfBooksDto issuanceOfBooksDto);
        void Dispose();
    }
}
