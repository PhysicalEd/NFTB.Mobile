using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    class PlayerListModel : BaseModel //, INotifyPropertyChanged
    {
        public ObservableCollection<string> _PlayerList { get; set; }
        public ObservableCollection<string> PlayerList { get; set; } = new ObservableCollection<string>();
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

        public PlayerListModel(ContentPage ui) : base(ui)
        {
            var test = this.GetPeople();
        }

        //public async Task<List<PersonResult>> GetPeople()
        //{
        //    BaseAPI<PersonResult> api = new BaseAPI<PersonResult>();
        //    var result = await api.GetAsync();
        //    return result;
        //}

        public async Task<List<Person>> GetPeople()
        {
            BaseAPI<Person> api = new BaseAPI<Person>();
            var result = await api.GetAsync();
            return result;
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
            await this.GetPeople();
            var test = 3;
        }

        public async Task Change()
        {
            this.Test = "I HAVE CHANGED FROM THE BUTTON";
            await this.UI.DisplayAlert("YOHOO", "Yeah", "OK");
        }


    }
}
