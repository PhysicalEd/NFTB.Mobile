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

        public TermDetailModel(IContentPage ui, TermSummary term) : base(ui)
        {
            this.LoadTermDetails(term.TermID);
        }

        public async Task LoadTermDetails(int termID)
        {
            
        }


    }
}
