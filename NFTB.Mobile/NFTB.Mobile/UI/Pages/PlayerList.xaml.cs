using Newtonsoft.Json.Converters;
using NFTB.Mobile.Contracts;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerList : IContentPage<PlayerListModel>
    {
        public PlayerList()
        {
            InitializeComponent();
            var bindingContext = new PlayerListModel(this);
            this.BindingContext = bindingContext;
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.PlayerListView.SelectedItem = null;
        }

    }
}
