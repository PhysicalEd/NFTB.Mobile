using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerList : ContentPage
    {
        public PlayerList()
        {
            InitializeComponent();
            this.BindingContext = new PlayerListModel(this);
        }
    }
}
