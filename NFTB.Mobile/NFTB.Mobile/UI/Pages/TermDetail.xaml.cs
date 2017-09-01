using System.Threading.Tasks;
using NFTB.Mobile.Contracts;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermDetail: IContentPage<TermDetailModel>
    {
        public TermDetail(TermSummary term)
        {
            InitializeComponent();
            this.BindingContext = new TermDetailModel(this, term);
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
    }
}
