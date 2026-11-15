using System;
using System.Collections.Generic;
using System.Text;

namespace SXX_account_creation.Models
{
    internal class CompanyAccount
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CompanyCustomerId { get; set; }
        public string LoginEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
