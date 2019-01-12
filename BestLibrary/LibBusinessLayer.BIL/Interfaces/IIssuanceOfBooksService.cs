using LibBusinessLayer.BIL.DTO;
using System.Collections.Generic;

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
