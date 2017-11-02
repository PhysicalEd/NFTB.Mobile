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

    class RegistrationModel : BaseModel
    {
        public RegistrationSummary Registration { get; set; } = new RegistrationSummary();
        public ICommand OnRegister
        {
            get { return new Command(async () => await this.Register()); }
        }
        public RegistrationModel(IContentPage ui) : base(ui)
        {
            
        }

        public async Task Register()
        {
            var accountMgr = new AccountManager();
            await accountMgr.Register(this.Registration);
        }
    }
}
