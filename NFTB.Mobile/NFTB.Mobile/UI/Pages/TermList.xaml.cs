using System.Threading.Tasks;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermList
    {
        public TermList()
        {
            InitializeComponent();
            this.BindingContext = new TermListModel(this);
        }

        private void TermListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.TermListView.SelectedItem = null;
        }

    }
}
