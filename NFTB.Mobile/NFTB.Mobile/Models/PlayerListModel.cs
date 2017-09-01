using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Common.Extensions;
using NFTB.Mobile.Contracts;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Logic.DataManagers;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    public class PlayerListModel : BaseModel
    {
        public ObservableCollection<PlayerSummary> _PlayerList { get; set; } = new ObservableCollection<PlayerSummary>();
        public ObservableCollection<PlayerSummary> PlayerList { get { return this._PlayerList; } set
            {
                this._PlayerList = value;
            } }

        public ICommand OnGetPlayers
        {
            get { return new Command(async () => await this.GetPlayers()); }
        }

        public ICommand OnEditPlayer
        {
            get { return new Command(async () => await this.EditPlayer()); }
        }

        public Picker FilterPicker { get; set; }

        private bool _IsBusy { get; set; }

        public bool IsBusy
        {
            get { return this._IsBusy; }
            set
            {
                if (this._IsBusy == value) return;
                this._IsBusy = value;
                OnPropertyChanged();
            }
        }

        public PlayerSummary _SelectedPlayer { get; set; }
        public PlayerSummary SelectedPlayer
        {
            get { return this._SelectedPlayer ?? new PlayerSummary(); }
            set
            {
                this._SelectedPlayer = value;
                if (this._SelectedPlayer != null) this.EditPlayer();
            }
        }

        public PlayerListModel(IContentPage ui) : base(ui)
        {
        }

        protected override async Task OnAppearing()
        {
            this.SelectedPlayer = null;
        }

        //public async Task<List<PersonResult>> GetPeople()
        //{
        //    BaseAPI<PersonResult> api = new BaseAPI<PersonResult>();
        //    var result = await api.GetAsync();
        //    return result;
        //}

        public async Task GetPlayers()
        {
            this.PlayerList.Clear();
            var playerManager = new PlayerManager();
            // ED TODO
            var playerList = await playerManager.GetPlayers(null);
            foreach (var player in playerList) this.PlayerList.Add(player);
            this.IsBusy = false;
        }

        public async Task EditPlayer()
        {
            var playerEditorPage = new PlayerEditor(this.SelectedPlayer);
            await this.GoToPage(playerEditorPage);
            playerEditorPage.Model().PlayerSaved = async (player) =>
            {
                await this.ClosePage();
                this.PlayerList.Add(player);
            };
        }

        public ICommand OnChange
        {
            get { return new Command(async () => await this.Change()); }
        }


        public ICommand OnPop
        {
            get { return new Command(async () => await this.Pop()); }
        }

        public ICommand OnFilterTapped
        {
            get { return new Command(async () => await this.ShowFilters()); }
        }

        public async Task Pop()
        {
            var newPage = new PlayerList();
            await this.GoToPage(newPage);
        }

        public async Task Change()
        {
        }

        public async Task ShowFilters()
        {
            this.FilterPicker.Focus();
        }


    }
}
