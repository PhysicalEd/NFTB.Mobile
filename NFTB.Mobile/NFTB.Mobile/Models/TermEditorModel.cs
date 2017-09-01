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

    class TermEditorModel : BaseModel
    {
        public TermSummary Term { get; set; }


        public event Action<bool> OnPageClosed;


        public ICommand OnCancel
        {
            get { return new Command(async () => await this.Cancel()); }
        }

        public ICommand OnSaveTerm
        {
            get { return new Command(async () => await this.SaveTerm()); }
        }

        public TermEditorModel(IContentPage ui, TermSummary term) : base(ui)
        {
            if (term == null)
            {
                // Set defaults
                term = new TermSummary();
                term.TermStart = DateTime.Now;
                term.TermEnd = DateTime.Now;
            }
            this.Term = term;

        }

        public async Task Cancel()
        {
            await this.ClosePage();

        }

        public async Task SaveTerm()
        {
            var termMgr = new TermManager();
            await termMgr.SaveTerm(this.Term);
        }

    }
}
