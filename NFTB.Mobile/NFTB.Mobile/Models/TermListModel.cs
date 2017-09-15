using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Logic.DataManagers;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;
using NFTB.Mobile.Contracts;

namespace NFTB.Mobile.Models
{

    class TermListModel : BaseModel
    {
        public ObservableCollection<TermSummary> _TermList { get; set; }
        public ObservableCollection<TermSummary> TermList { get; set; } = new ObservableCollection<TermSummary>();
        private bool _IsBusy { get; set; }

        public bool IsBusy
        {
            get { return this._IsBusy; }
            set
            {
                if (this._IsBusy == value) return;
                this._IsBusy = value;
                OnPropertyChanged();
            }
        }

        public TermSummary _SelectedTerm { get; set; }
        public TermSummary SelectedTerm
        {
            get { return this._SelectedTerm; }
            set
            {
                this._SelectedTerm = value;
                if (this._SelectedTerm != null) this.SelectTerm();
            }
        }

        public ICommand OnEditTerm
        {
            get { return new Command(async () => await this.EditTerm()); }
        }

        public ICommand OnSelectTerm
        {
            get { return new Command(async () => await this.SelectTerm()); }
        }

        public ICommand OnDeleteTerm
        {
            get { return new Command(async () => await this.DeleteTerm()); }
        }

        public ICommand OnGetTerms
        {
            get { return new Command(async () => await this.GetTerms()); }
        }

        public TermListModel(IContentPage ui) : base(ui)
        {
            this.GetTerms();
        }

        protected override async Task OnAppearing()
        {
            this.SelectedTerm = null;
        }
        public async Task GetTerms()
        {
            this.TermList.Clear();
            var termMgr = new TermManager();
            var termList = await termMgr.GetTerms(null);
            foreach (var term in termList)
            {
                this.TermList.Add(term);
            }
            this.IsBusy = false;
        }

        public async Task EditTerm()
        {
            var termEditorPage = new TermEditor(this.SelectedTerm);
            await this.GoToPage(termEditorPage);
        }

        public async Task SelectTerm()
        {
            var termDetailPage = new TermDetail(this.SelectedTerm);
            await this.GoToPage(termDetailPage);
        }



        public async Task DeleteTerm()
        {
            var termMgr = new TermManager();
            await termMgr.DeleteTerm(this.SelectedTerm.TermID);
        }
    }
}
