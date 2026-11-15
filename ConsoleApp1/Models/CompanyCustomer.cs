using System;
using System.Collections.Generic;
using System.Text;

namespace SXX_account_creation.Models
{
    internal class CompanyCustomer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CompanyName { get; set; } = string.Empty;
        public string OrganisationNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string ContactFirstName { get; set; } = string.Empty;
        public string ContactLastName { get; set; } = string.Empty;
    }
}
