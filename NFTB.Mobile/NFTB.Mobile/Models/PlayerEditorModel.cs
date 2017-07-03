using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Logic.DataManagers;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    class PlayerEditorModel : BaseModel
    {
        public PlayerSummary Player { get; set; }


        public ICommand OnSavePlayer
        {
            get { return new Command(async () => await this.SavePlayer()); }
        }

        public PlayerEditorModel(ContentPage ui, PlayerSummary player) : base(ui)
        {
            this.Player = player;

        }

        public async Task Cancel()
        {
            await this.UI.Navigation.PopAsync();
        }

        public async Task SavePlayer()
        {
            var playerMgr = new PlayerManager();
        }

    }
}
