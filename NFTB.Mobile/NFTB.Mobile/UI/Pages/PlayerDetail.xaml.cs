using System;
using Newtonsoft.Json.Converters;
using NFTB.Mobile.Contracts;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerDetail : IContentPage<PlayerListModel>
    {
        public PlayerDetail()
        {
            InitializeComponent();
            var bindingContext = new PlayerListModel(this);
            this.BindingContext = bindingContext;
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }

        public void OnEditContextAction(object sender, EventArgs e)
        {
        }

    }
}
