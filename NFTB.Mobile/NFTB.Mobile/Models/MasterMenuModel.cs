using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using NFTB.Mobile.Data.Entities;
using NFTB.Mobile.Logic.DataManagers;
using NFTB.Mobile.UI.Pages;
using Xamarin.Forms;

namespace NFTB.Mobile.Models
{
    public class MasterMenuModel
    {
        protected MasterDetailPage MasterPage;
        private NavigationPage TermListPage = new NavigationPage(new TermList());
        private NavigationPage PlayerListPage = new NavigationPage(new PlayerList());
        private NavigationPage AttendanceListPage = new NavigationPage(new AttendanceList());
        private NavigationPage TermEditorPage = new NavigationPage(new TermEditor(null));


        private TermSummary ActiveTerm = new TermSummary();

        private string ActiveTermLabel
        {
            get { return "Active term: " + this.ActiveTerm.Name; }
        }

        private string Test { get; } = "HI";

        public ICommand OnTermList
        {
            get
            {
                return new Command(() => this.TermList());
            }
        }

        public ICommand OnPlayerList
        {
            get
            {
                return new Command(() => this.PlayerList());
            }
        }

        public ICommand OnAttendanceList
        {
            get
            {
                return new Command(() => this.AttendanceList());
            }
        }

        public MasterMenuModel(MasterDetailPage masterPage)
        {
            this.MasterPage = masterPage;
            this.TermList();
            this.GetActiveTerm();
        }

        public async Task GetActiveTerm()
        {
            var termMgr = new TermManager();
            var termList = await termMgr.GetTerms(null);
            this.ActiveTerm = termList.FirstOrDefault(x => x.IsActive);
        }

        public void TermList()
        {
            this.MasterPage.Detail = this.TermListPage;
            this.MasterPage.Title = this.TermListPage.Title;
            this.MasterPage.IsPresented = false;
        }

        public void PlayerList()
        {
            this.MasterPage.Detail = this.PlayerListPage;
            this.MasterPage.Title = this.PlayerListPage.Title;
            this.MasterPage.IsPresented = false;
        }

        public void AttendanceList()
        {
            this.MasterPage.Detail = AttendanceListPage;
            this.MasterPage.Title = this.AttendanceListPage.Title;
            this.MasterPage.IsPresented = false;
        }

        public void TermEditor()
        {
            this.MasterPage.Detail = TermEditorPage;
            this.MasterPage.Title = this.TermEditorPage.Title;
            this.MasterPage.IsPresented = false;
        }

    }

}
