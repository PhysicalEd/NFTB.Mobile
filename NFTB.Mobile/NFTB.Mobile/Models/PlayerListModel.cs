using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Logic.DataManagers;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    class PlayerListModel : BaseModel
    {
        public ObservableCollection<Person> _PlayerList { get; set; }
        public ObservableCollection<Person> PlayerList { get; set; } = new ObservableCollection<Person>();
        public string _Test { get; set; }
        public string Test
        {
            get
            {
                return this._Test;
            }
            set
            {
                _Test = value;
                OnPropertyChanged();
            }
        }

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
        }

        //public async Task<List<PersonResult>> GetPeople()
        //{
        //    BaseAPI<PersonResult> api = new BaseAPI<PersonResult>();
        //    var result = await api.GetAsync();
        //    return result;
        //}

        public async Task GetPlayers()
        {
            var personManager = new PersonManager();
            var playerList = await personManager.GetPlayers();
            //var playerList = new List<Person>()
            //{
            //    new Person()
            //    {
            //        FirstName = "Ed",
            //        LastName = "Ong"
            //    }
            //};
            foreach (var player in playerList) this.PlayerList.Add(player);
        }


        public ICommand OnChange
        {
            get { return new Command(async () => await this.Change()); }
        }

        public ICommand OnPop
        {
            get { return new Command(async () => await this.Pop()); }
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
            this.Test = "I HAVE CHANGED FROM THE BUTTON";
            await this.UI.DisplayAlert("YOHOO", "Yeah", "OK");
        }


    }
}
