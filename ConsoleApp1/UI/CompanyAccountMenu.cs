using SXX_account_creation.Interfaces;
using SXX_account_creation.Models;

namespace SXX_account_creation.UI
{
    internal class CompanyAccountMenu
    {
        private readonly ICompanyAccountService _service;

        public CompanyAccountMenu(ICompanyAccountService service)
        {
            _service = service;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n1. Register company account");
                Console.WriteLine("2. Log in");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Register();
                        break;

                    case "2":
                        Login();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void Register()
        {
            Console.Write("Enter company name: ");
            string companyName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter organisation number: ");
            string organisationNumber = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter email (also used for login): ");
            string email = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter contact first name: ");
            string contactFirstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter contact last name: ");
            string contactLastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter password: ");
            string password = Console.ReadLine() ?? string.Empty;

            var customer = new CompanyCustomer
            {
                CompanyName = companyName,
                OrganisationNumber = organisationNumber,
                Email = email,
                PhoneNumber = phoneNumber,
                ContactFirstName = contactFirstName,
                ContactLastName = contactLastName
            };

            try
            {
                _service.Register(customer, email, password);
                Console.WriteLine("Company account registered successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Login()
        {
            Console.Write("Enter email: ");
            string email = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter password: ");
            string password = Console.ReadLine() ?? string.Empty;

            var account = _service.Login(email, password);

            if (account == null)
            {
                Console.WriteLine("Invalid email or password.");
                return;
            }

            var customer = _service.GetCompanyCustomer(account.CompanyCustomerId);

            if (customer == null)
            {
                Console.WriteLine(
                    "The company linked to this account could not be found.");
                return;
            }

            Console.WriteLine($"Welcome, {customer.CompanyName}!");
        }
    }
}
