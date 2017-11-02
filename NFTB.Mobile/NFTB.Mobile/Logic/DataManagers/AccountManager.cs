using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Data.Entities;

namespace NFTB.Mobile.Logic.DataManagers
{
    public class AccountManager
    {
        public async Task<LoginSummary> Register(RegistrationSummary registrationSummary)
        {
            BaseAPI< LoginSummary> api = new BaseAPI<LoginSummary>();
            api.RelativeUrl = "account/register";
            var result = await api.PostAsync(registrationSummary);
            return result;
        }

        public async Task<Token> Login(LoginSummary loginSummary)
        {
            BaseAPI<Token> api = new BaseAPI<Token>();
            api.RelativeUrl = "account/signin";
            try
            {
                var result = await api.PostAsync(loginSummary);
                return result;

            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

    }
}
