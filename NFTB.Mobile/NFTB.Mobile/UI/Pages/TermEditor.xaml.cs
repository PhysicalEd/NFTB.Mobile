using NFTB.Mobile.Contracts;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermEditor : IContentPage<TermEditorModel>
    {
        public TermEditor(TermSummary term)
        {
            InitializeComponent();
            this.BindingContext = new TermEditorModel(this, term);
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
    }
}
