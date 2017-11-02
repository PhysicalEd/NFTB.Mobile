using System;
using NFTB.Mobile.Contracts;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFTB.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InvoiceEditor : IContentPage<InvoiceEditorModel>
    {
        public InvoiceEditor(InvoiceSummary invoice)
        {
            InitializeComponent();
            this.BindingContext = new InvoiceEditorModel(this, invoice);
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
        }
        public void OnEditContextAction(object sender, EventArgs e)
        {
        }

    }
}
