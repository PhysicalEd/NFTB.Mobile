using System.Threading.Tasks;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermDetails
    {
        public TermDetails(TermSummary term)
        {
            InitializeComponent();
            this.BindingContext = new TermDetailModel(this, term);
        }
    }
}
