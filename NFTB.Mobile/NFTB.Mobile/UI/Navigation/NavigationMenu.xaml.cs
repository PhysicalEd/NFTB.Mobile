using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationMenu: NavigationPage
    {
        public NavigationMenu(MasterDetailPage page)
        {
            InitializeComponent();
            this.BindingContext = new NavigationMenu(page);
        }
    }
}
