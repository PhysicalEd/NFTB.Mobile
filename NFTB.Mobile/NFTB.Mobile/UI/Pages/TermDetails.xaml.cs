using System.Threading.Tasks;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermDetails
    {
        public TermDetails()
        {
            InitializeComponent();
            this.BindingContext = new TermListModel(this);
        }
    }
}
