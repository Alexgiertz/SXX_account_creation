using SXX_account_creation.Interfaces;
using SXX_account_creation.Models;

namespace SXX_account_creation.Service
{
    internal class CompanyAccountService : ICompanyAccountService
    {
        private readonly ICompanyAccountRepository _accountRepository;
        private readonly ICompanyCustomerRepository _customerRepository;

        public CompanyAccountService(ICompanyAccountRepository accountRepository, ICompanyCustomerRepository customerRepository)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }

        private static bool IsValidEmail(string email)
        {
            return System.Net.Mail.MailAddress.TryCreate(email, out var address)
                && address.Address == email;
        }

        public CompanyAccount Register(CompanyCustomer customer, string loginEmail, string password)
        {
            if (string.IsNullOrWhiteSpace(customer.CompanyName))
                throw new ArgumentException("Company name is required.");

            if (string.IsNullOrWhiteSpace(customer.OrganisationNumber))
                throw new ArgumentException("Organisation number is required.");

            if (string.IsNullOrWhiteSpace(customer.Email))
                throw new ArgumentException("Email is required.");

            if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
                throw new ArgumentException("Phone number is required.");

            if (string.IsNullOrWhiteSpace(customer.ContactFirstName))
                throw new ArgumentException("Contact first name is required.");

            if (string.IsNullOrWhiteSpace(customer.ContactLastName))
                throw new ArgumentException("Contact last name is required.");

            if (string.IsNullOrWhiteSpace(loginEmail))
                throw new ArgumentException("Login email is required.");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required.");

            customer.CompanyName = customer.CompanyName.Trim();
            customer.OrganisationNumber = customer.OrganisationNumber.Trim();
            customer.Email = customer.Email.Trim();
            if (!IsValidEmail(customer.Email))
            {
                throw new ArgumentException("Enter a valid company email address.");
            }

            if (!IsValidEmail(loginEmail))
            {
                throw new ArgumentException("Enter a valid login email address.");
            }
            customer.PhoneNumber = customer.PhoneNumber.Trim();
            customer.ContactFirstName = customer.ContactFirstName.Trim();
            customer.ContactLastName = customer.ContactLastName.Trim();
            loginEmail = loginEmail.Trim();

            if (_customerRepository.GetByOrganisationNumber(
                customer.OrganisationNumber) != null)
            {
                throw new ArgumentException(
                    "A company with this organisation number already exists.");
            }

            if (_accountRepository.GetByEmail(loginEmail) != null)
            {
                throw new ArgumentException(
                    "An account with this email already exists.");
            }

            var account = new CompanyAccount
            {
                CompanyCustomerId = customer.Id,
                LoginEmail = loginEmail,
                Password = password
            };

            _customerRepository.Add(customer);
            _accountRepository.Add(account);

            return account;
        }

        public CompanyAccount? Login(string loginEmail, string password)
        {
            if (string.IsNullOrWhiteSpace(loginEmail) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            loginEmail = loginEmail.Trim();
            if (!IsValidEmail(loginEmail))
            {
                return null;
            }
            var account = _accountRepository.GetByEmail(loginEmail);
            if (account != null && account.Password == password)
            {
                return account;
            }
            return null;
        }

        public CompanyCustomer? GetCompanyCustomer(Guid companyCustomerId)
        {
            return _customerRepository.GetById(companyCustomerId);
        }
    }
}
