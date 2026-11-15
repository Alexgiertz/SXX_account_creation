using SXX_account_creation.Interfaces;
using SXX_account_creation.Models;

namespace SXX_account_creation.Repository
{
    internal class InMemoryCompanyCustomerRepository: ICompanyCustomerRepository
    {
        public void Add(CompanyCustomer customer)
        {
            _customers.Add(customer);
        }
        public CompanyCustomer? GetById(Guid id)
        {
            return _customers.FirstOrDefault(customer => customer.Id == id);
        }

        public CompanyCustomer? GetByOrganisationNumber(string organisationNumber)
        {
            return _customers.FirstOrDefault(
                customer => customer.OrganisationNumber == organisationNumber);
        }

        public CompanyCustomer? GetByEmail(string email)
        {
            return _customers.FirstOrDefault(
                customer => string.Equals(
                    customer.Email, email, StringComparison.OrdinalIgnoreCase));
        }

        public CompanyCustomer? GetByPhoneNumber(string phoneNumber)
        {
            return _customers.FirstOrDefault(
                customer => customer.PhoneNumber == phoneNumber);
        }

        private readonly List<CompanyCustomer> _customers = new();
    }
}
