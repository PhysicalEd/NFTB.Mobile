using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermEditor : ContentPage
    {
        public TermEditor(TermSummary term)
        {
            InitializeComponent();
            this.BindingContext = new TermEditorModel(this, term);
        }
    }
}
