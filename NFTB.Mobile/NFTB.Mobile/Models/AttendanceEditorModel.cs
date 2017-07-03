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

    class AttendanceEditorModel : BaseModel
    {
        public ObservableCollection<PlayerSummary> PlayerList { get; set; } = new ObservableCollection<PlayerSummary>();
        public ObservableCollection<PlayerAttendanceSummary> PlayerAttendances { get; set; } = new ObservableCollection<PlayerAttendanceSummary>();

        public AttendanceSummary Attendance { get; set; }

        public ICommand OnSaveAttendance
        {
            get { return new Command(async () => await this.SaveAttendance()); }
        }

        public AttendanceEditorModel(ContentPage ui, AttendanceSummary attendance) : base(ui)
        {
            this.Attendance = attendance == null ? new AttendanceSummary() : attendance;
            this.LoadAttendances();
        }

        public async Task LoadAttendances()
        {
            var attendanceMgr = new AttendanceManager();
            var playerMgr = new PlayerManager();
            
            var playerList = await playerMgr.GetPlayers();

            if (!(this.Attendance.AttendanceID > 0))
            {
                foreach (var player in playerList)
                {
                    var playerAttendance = new PlayerAttendanceSummary()
                    {
                        PlayerID = player.PlayerID,
                        PlayerName = player.PlayerName
                    };
                    this.PlayerAttendances.Add(playerAttendance);
                }
            }
        }


        public async Task SaveAttendance()
        {
            //var termMgr = new TermManager();

        }

    }
}
