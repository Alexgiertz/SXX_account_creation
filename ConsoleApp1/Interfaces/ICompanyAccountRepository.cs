using SXX_account_creation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SXX_account_creation.Interfaces
{
    internal interface ICompanyAccountRepository
    {
        void Add(CompanyAccount account);
        CompanyAccount? GetById(Guid id);
        CompanyAccount? GetByEmail(string email);
    }
}
