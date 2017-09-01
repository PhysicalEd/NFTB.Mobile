using System.Threading.Tasks;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NFTB.Mobile.Contracts;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermList:  IContentPage<TermListModel>
    {
        public TermList()
        {
            InitializeComponent();
            this.BindingContext = new TermListModel(this);
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.TermListView.SelectedItem = null;
        }

    }
}
