using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

    public class AttendanceEditorModel : BaseModel
    {
        public Action<AttendanceSummary> AttendanceSaved = (attendance) => { };

        private AttendanceEditorModelResult ModelResult { get; set; } = new AttendanceEditorModelResult();
        public List<PlayerSummary> PlayerList { get; set; } = new List<PlayerSummary>();
        public ObservableCollection<PlayerAttendanceSummary> TermPlayerAttendances { get; set; } = new ObservableCollection<PlayerAttendanceSummary>();
        public ObservableCollection<PlayerAttendanceSummary> CasualPlayerAttendances { get; set; } = new ObservableCollection<PlayerAttendanceSummary>();

        public DatePicker DatePicker { get; set; }
        public ObservableCollection<PlayerAttendanceSummary> PlayerAttendances { get; set; } = new ObservableCollection<PlayerAttendanceSummary>();
        // Need to populate this programmatically
        //public TermSummary SelectedTerm { get; set; } = new TermSummary() {TermID = 1};
        public AttendanceSummary Attendance { get; set; }

        public ICommand OnSaveAttendance
        {
            get { return new Command(async () => await this.SaveAttendance()); }
        }


        public AttendanceEditorModel(IContentPage ui, AttendanceSummary attendance) : base(ui)
        {
            // EO TODO Testing
            //this.Attendance = new AttendanceSummary();
            this.Attendance = attendance == null ? new AttendanceSummary() : attendance;
            this.LoadAttendances();
        }

        public async Task LoadAttendances()
        {
            //var playerMgr = new PlayerManager();
            

            //this.PlayerList = await playerMgr.GetPlayers(this.SelectedTerm.TermID);


            //// If no attendance is loaded, means new attendances
            //if (!(this.Attendance.AttendanceID > 0))
            //{
            //    await this.LoadAllPlayers();
            //}
            //else
            //{
            //    await this.LoadTermPlayerAttendances();
            //}

            var attendanceMgr = new AttendanceManager();
            //this.Attendance = new AttendanceSummary();
            this.ModelResult = await attendanceMgr.GetAttendanceEditorModel(this.Attendance);

            // Bind data...
            this.PlayerList = this.ModelResult.PlayerList;
            foreach (var attendance in this.ModelResult.TermPlayerAttendances) this.TermPlayerAttendances.Add((attendance));
            foreach (var attendance in this.ModelResult.CasualPlayerAttendances) this.CasualPlayerAttendances.Add((attendance));

            //this.CasualPlayerAttendances = this.ModelResult.CasualPlayerAttendances;
            //if (!(this.Attendance.AttendanceID > 0)) await this.LoadAllPlayers();
        }

        public async Task LoadTermPlayerAttendances()
        {
            
        }

        public async Task LoadAllPlayers()
        {
            //if (this.Attendance.AttendanceID > 0)
            //{
            //    // Load all players for the term and all casuals first
            //    foreach (var player in this.PlayerList)
            //    {
            //        var playerAttendance = new PlayerAttendanceSummary()
            //        {
            //            PlayerID = player.PlayerID,
            //            DisplayName = player.DisplayName
            //        };
            //        if (player.TermID > 0)
            //        {
            //            this.TermPlayerAttendances.Add(playerAttendance);
            //        }
            //        else
            //        {
            //            this.CasualPlayerAttendances.Add(playerAttendance);
            //        }
            //    }

            //}
            //else
            //{
            //    foreach (var player in this.PlayerList)
            //    {
            //        var playerAttendance = new PlayerAttendanceSummary()
            //        {
            //            PlayerID = player.PlayerID,
            //            DisplayName = player.DisplayName
            //        };
            //        if (player.TermID > 0) { this.TermPlayerAttendances.Add(playerAttendance); } else { this.CasualPlayerAttendances.Add(playerAttendance); }
            //    }

            //}



        }




        public async Task SaveAttendance()
        {

            // EO TODO This is ugly as...

            // Clear list to avoid double ups...
            this.Attendance.PlayerAttendances.Clear();
            // Join both casual and permanents that have been marked as attended
            try
            {
                foreach (var attendance in this.TermPlayerAttendances) //this.Attendance.PlayerAttendances.Add(attendance);
                    if (attendance.HasAttended) this.Attendance.PlayerAttendances.Add(attendance);
                foreach (var attendance in this.CasualPlayerAttendances) //this.Attendance.PlayerAttendances.Add(attendance);
                    if (attendance.HasAttended) this.Attendance.PlayerAttendances.Add(attendance);
            }
            catch (Exception ex)
            {
                var s = 3;
            }
            //this.Attendance.AttendanceDate = DateTime.Now;
            var attendanceMgr = new AttendanceManager();
            // Close after save...
            var att = await attendanceMgr.SaveAttendance(this.Attendance);
            this.AttendanceSaved(att);
            //var termMgr = new TermManager();

        }

    }
}
