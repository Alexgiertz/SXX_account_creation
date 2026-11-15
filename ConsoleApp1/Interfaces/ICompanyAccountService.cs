using SXX_account_creation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SXX_account_creation.Interfaces
{
    internal interface ICompanyAccountService
    {
        CompanyAccount? Login(string loginEmail, string password);
        CompanyAccount Register(CompanyCustomer customer, string loginEmail, string password);
        CompanyCustomer? GetCompanyCustomer(Guid companyCustomerId);
    }
}
