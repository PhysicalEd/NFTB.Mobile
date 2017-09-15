using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.API;
using NFTB.Mobile.API.Results;
using NFTB.Mobile.Contracts;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Logic.DataManagers;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{

    class TermDetailModel : BaseModel
    {
        public TermSummary Term { get; set; }
        public TermDetailModelResult TermDetail { get; set; }
        
        public TermDetailModel(IContentPage ui, TermSummary term) : base(ui)
        {
            this.Term = term;
            this.LoadTermDetails();
        }

        public async Task LoadTermDetails()
        {
            var termMgr = new TermManager();
            var termDetail = await termMgr.GetTermDetail(this.Term.TermID);
            this.TermDetail = termDetail;
            //this.IsBusy = false;
        }


    }
}
