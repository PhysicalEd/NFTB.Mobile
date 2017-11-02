using System;
using System.Collections.Generic;
using System.Linq;

namespace NFTB.Mobile.Data.Entities
{
    public class Token
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public DateTime WhenTokenExpires { get; set; }

    }
}
