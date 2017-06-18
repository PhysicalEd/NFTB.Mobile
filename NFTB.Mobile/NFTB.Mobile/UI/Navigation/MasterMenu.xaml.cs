using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenu
    {
        public MasterMenu()
        {
            InitializeComponent();
            this.BindingContext = new MasterMenuModel(this);
        }
    }
}
