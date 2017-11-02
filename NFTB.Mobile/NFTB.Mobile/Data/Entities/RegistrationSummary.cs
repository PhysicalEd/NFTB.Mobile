using System;
using System.Collections.Generic;
using System.Linq;

namespace NFTB.Mobile.Data.Entities
{
    public class RegistrationSummary
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
