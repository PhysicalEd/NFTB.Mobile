using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    public abstract class BaseModel : INotifyPropertyChanged
    {
        protected ContentPage UI;

        protected BaseModel(ContentPage ui)
        {
            this.UI = ui;
            this.OnLoad();
        }

        public virtual bool IsModalPage => false;

        protected virtual async Task OnLoad()
        {
            //await UI.DisplayAlert("TEST", "Test", "OK");
        }

        //protected virtual async Task OnAppearing()
        //{
        //    await UI.OnAppearing();
        //}




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
