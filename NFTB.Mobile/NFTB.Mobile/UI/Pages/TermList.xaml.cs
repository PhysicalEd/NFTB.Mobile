using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermList : ContentPage
    {
        public TermList()
        {
            InitializeComponent();
            this.BindingContext = new PlayerListModel(this);
        }
    }
}
