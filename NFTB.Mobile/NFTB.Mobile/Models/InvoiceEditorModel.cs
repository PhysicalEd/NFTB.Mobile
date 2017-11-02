using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Contracts;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Logic.DataManagers;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    class InvoiceEditorModel : BaseModel
    {
        public InvoiceSummary Invoice { get; set; }

        public Action<InvoiceSummary> InvoiceSaved = (player) => { };

        public ICommand OnSaveInvoice
        {
            get { return new Command(async () => await this.SaveInvoice()); }
        }

        public InvoiceEditorModel(IContentPage ui, InvoiceSummary invoice) : base(ui)
        {
            //if (player == null) this.Player = new PlayerSummary();
             this.Invoice = invoice;
        }

        public async Task Cancel()
        {
            await this.ClosePage();
        }

        public async Task SaveInvoice()
        {
            var termMgr = new TermManager();
            var invoice = await termMgr.SaveInvoice(this.Invoice);
            this.InvoiceSaved(invoice);
        }

    }
}
