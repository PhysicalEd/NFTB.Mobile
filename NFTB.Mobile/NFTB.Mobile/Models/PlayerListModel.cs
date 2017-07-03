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

    class PlayerListModel : BaseModel
    {
        public ObservableCollection<PlayerSummary> _PlayerList { get; set; }
        public ObservableCollection<PlayerSummary> PlayerList { get; set; } = new ObservableCollection<PlayerSummary>();

        public ObservableCollection<string> _TestList { get; set; }
        public ObservableCollection<string> TestList { get; set; } = new ObservableCollection<string>();

        public ICommand OnGetPlayers
        {
            get { return new Command(async () => await this.GetPlayers()); }
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

        public PlayerListModel(ContentPage ui) : base(ui)
        {
            var test = this.GetPlayers();
            this.TestList.Add("Test1");
            this.TestList.Add("Test2");
            this.TestList.Add("Test3");
            
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
            var playerList = await playerManager.GetPlayers();
            foreach (var player in playerList) this.PlayerList.Add(player);
            this.IsBusy = false;
        }

        //public async Task GetTermPlayers()
        //{
        //    this.PlayerList.Clear();
        //    var playerManager = new PlayerManager();
        //    var playerList = await playerManager.GetPlayers();
        //    foreach (var player in playerList) this.PlayerList.Add(player);
        //    this.IsBusy = false;
        //}


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
            //await this.GetPlayers();
            //var test = 3;
            var newPage = new PlayerList();

            await this.UI.Navigation.PushAsync(newPage);
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
