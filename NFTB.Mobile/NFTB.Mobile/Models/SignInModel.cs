using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Logic.DataManagers;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;
using NFTB.Mobile.Contracts;

namespace NFTB.Mobile.Models
{

    class SignInModel : BaseModel
    {
        public LoginSummary LoginSummary { get; set; } = new LoginSummary();
        public Token TokenSummary { get; set; } = new Token();

        public ICommand OnLogin
        {
            get { return new Command(async () => await this.Login()); }
        }
        public SignInModel(IContentPage ui) : base(ui)
        {
            
        }

        public async Task Login()
        {
            var accountMgr = new AccountManager();
            var token = await accountMgr.Login(this.LoginSummary);
            this.TokenSummary = token;
            
            // Just a quick test
            var personMgr = new PlayerManager();
            await personMgr.GetPeople();

        }
    }
}
