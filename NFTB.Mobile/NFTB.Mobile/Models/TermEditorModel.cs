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

    class TermEditorModel : BaseModel
    {
        public TermSummary Term { get; set; }

        public TermEditorModel(ContentPage ui, TermSummary term) : base(ui)
        {
            this.Term = term;

        }

    }
}
