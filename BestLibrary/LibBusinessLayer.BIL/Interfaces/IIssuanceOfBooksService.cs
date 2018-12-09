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
        IssuanceOfBooksDTO GetIssuance(int? id);
        IEnumerable<IssuanceOfBooksDTO> GetIssuances();
        bool ReturnIssuance(int id);
        bool AddIssuance(IssuanceOfBooksDTO issuanceOfBooksDTO);
        void Dispose();
    }
}
