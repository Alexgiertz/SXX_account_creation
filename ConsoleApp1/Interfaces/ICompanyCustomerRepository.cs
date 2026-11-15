using SXX_account_creation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SXX_account_creation.Interfaces
{
    internal interface ICompanyCustomerRepository
    {
        void Add(CompanyCustomer customer);
        CompanyCustomer? GetById(Guid id);
        CompanyCustomer? GetByOrganisationNumber(string organisationNumber);
        CompanyCustomer? GetByEmail(string email);
        CompanyCustomer? GetByPhoneNumber(string phoneNumber);
    }
}
