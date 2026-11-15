using SXX_account_creation.Repository;
using SXX_account_creation.Service;
using SXX_account_creation.UI;

namespace SXX_account_creation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var accountRepository = new InMemoryCompanyAccountRepository();
            var customerRepository = new InMemoryCompanyCustomerRepository();

            var service = new CompanyAccountService(
                accountRepository,
                customerRepository);

            var menu = new CompanyAccountMenu(service);
            menu.Run();
        }
    }
}