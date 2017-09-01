using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Contracts;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Logic.DataManagers;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    class PlayerEditorModel : BaseModel
    {
        public PlayerSummary Player { get; set; }

        public Action<PlayerSummary> PlayerSaved = (player) => { };

        public ICommand OnSavePlayer
        {
            get { return new Command(async () => await this.SavePlayer()); }
        }

        public PlayerEditorModel(IContentPage ui, PlayerSummary player) : base(ui)
        {
            //if (player == null) this.Player = new PlayerSummary();
            this.Player = player;

        }

        public async Task Cancel()
        {
            await this.ClosePage();
        }

        public async Task SavePlayer()
        {
            var playerMgr = new PlayerManager();
            var player = await playerMgr.SavePlayer(this.Player);
            this.PlayerSaved(player);
        }

    }
}
