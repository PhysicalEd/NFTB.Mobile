using System;
using NFTB.Mobile.Contracts;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerEditor : IContentPage<PlayerEditorModel>
    {
        public PlayerEditor(PlayerSummary player)
        {
            InitializeComponent();
            this.BindingContext = new PlayerEditorModel(this, player);
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
        public void OnEditContextAction(object sender, EventArgs e)
        {
        }

    }
}
