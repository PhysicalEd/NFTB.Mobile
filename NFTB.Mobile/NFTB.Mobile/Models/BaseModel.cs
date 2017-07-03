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

        public virtual async Task OnLoad()
        {
            
        }

        

        




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
