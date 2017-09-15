using System;
using System.Threading.Tasks;
using NFTB.Mobile.Common.Extensions;
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
        public void OnEditContextAction(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            this.TermListView.SelectedItem = mi.CommandParameter;
        }
    }
}
