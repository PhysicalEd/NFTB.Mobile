using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    public abstract class BaseModel : INotifyPropertyChanged
    {
        protected ContentPage UI;
        public BaseModel(ContentPage ui)
        {
            this.UI = ui;
            this.OnLoad();
        }

        protected virtual async Task OnLoad()
        {
            await UI.DisplayAlert("TEST", "Test", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
