using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Common.Extensions;
using NFTB.Mobile.Contracts;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Logic.DataManagers;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    class TermDetailModel : BaseModel
    {
        public TermSummary Term { get; set; }
        public InvoiceSummary TermInvoice { get; set; } = new InvoiceSummary();

        public TermDetailModelResult _TermDetail { get; set; }

        public TermDetailModelResult TermDetail
        {
            get { return this._TermDetail; }
            set
            {
                this._TermDetail = value;
                OnPropertyChanged();
            }
        }

        public ICommand OnEditInvoice
        {
            get { return new Command(async () => await this.EditInvoice()); }
        }
        public ICommand OnLoadTermDetails
        {
            get { return new Command(async () => await this.LoadTermDetails()); }
        }

        public TermDetailModel(IContentPage ui, TermSummary term) : base(ui)
        {
            this.Term = term;
            this.LoadTermDetails();
        }

        protected override async Task OnLoad()
        {
            await this.LoadTermDetails();
        }

        public async Task LoadTermDetails()
        {
            var termMgr = new TermManager();
            this.TermDetail = await termMgr.GetTermDetail(this.Term.TermID);
            
            //this.TermInvoice = await termMgr.GetTermInvoiceByTerm()
            //this.IsBusy = false;
        }

        public async Task EditInvoice()
        {
            var invoiceEditor = new InvoiceEditor(this.TermDetail.Invoice);
            await this.GoToPage(invoiceEditor);
            invoiceEditor.Model().InvoiceSaved = async (invoice) =>
            {
                await this.ClosePage();
            };
        }


    }
}
