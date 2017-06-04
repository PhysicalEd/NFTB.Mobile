using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Logic.DataManagers;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    class TermListModel : BaseModel
    {
        public ObservableCollection<TermSummary> _TermList { get; set; }
        public ObservableCollection<TermSummary> TermList { get; set; } = new ObservableCollection<TermSummary>();

        public TermSummary SelectedTerm { get; set; }

        public ICommand OnEditTerm
        {
            get { return new Command(async () => await this.EditTerm()); }
        }

        public ICommand OnGetTerms
        {
            get { return new Command(async () => await this.GetTerms()); }
        }

        public TermListModel(ContentPage ui) : base(ui)
        {
            this.GetTerms();
            
        }

        public async Task GetTerms()
        {
            var termManager = new TermManager();
            var termList = await termManager.GetTerms();
            foreach (var term in termList) this.TermList.Add(term);
        }

        public async Task EditTerm()
        {
            var termEditorPage = new TermEditor(this.SelectedTerm);
            await this.UI.Navigation.PushModalAsync(termEditorPage);
        }


    }
}
