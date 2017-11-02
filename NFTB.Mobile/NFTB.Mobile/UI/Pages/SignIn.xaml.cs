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
    public partial class SignIn:  IContentPage<TermListModel>
    {
        public SignIn()
        {
            InitializeComponent();
            this.BindingContext = new SignInModel(this);
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
        public void OnEditContextAction(object sender, EventArgs e)
        {
        }
    }
}
