using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerEditor : ContentPage
    {
        public PlayerEditor()
        {
            InitializeComponent();
            this.BindingContext = new PlayerListModel(this);
        }
    }
}
