using SXX_account_creation.Interfaces;
using SXX_account_creation.Models;

namespace SXX_account_creation.Repository
{
    internal class InMemoryCompanyAccountRepository
        : ICompanyAccountRepository
    {
        private readonly List<CompanyAccount> _accounts = new();

        public void Add(CompanyAccount account)
        {
            _accounts.Add(account);
        }

        public CompanyAccount? GetById(Guid id)
        {
            return _accounts.FirstOrDefault(account => account.Id == id);
        }

        public CompanyAccount? GetByEmail(string email)
        {
            return _accounts.FirstOrDefault(
                account => string.Equals(
                    account.LoginEmail,
                    email,
                    StringComparison.OrdinalIgnoreCase));
        }
    }
}
