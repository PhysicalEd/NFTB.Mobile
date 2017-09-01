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
        private AttendanceEditorModelResult ModelResult { get; set; }
        public List<PlayerSummary> PlayerList { get; set; } = new List<PlayerSummary>();
        public ObservableCollection<PlayerAttendanceSummary> TermPlayerAttendances { get; set; } = new ObservableCollection<PlayerAttendanceSummary>();
        public ObservableCollection<PlayerAttendanceSummary> CasualPlayerAttendances { get; set; } = new ObservableCollection<PlayerAttendanceSummary>();

        public List<PlayerAttendanceSummary> PlayerAttendances { get; set; } = new List<PlayerAttendanceSummary>();
        // Need to populate this programmatically
        //public TermSummary SelectedTerm { get; set; } = new TermSummary() {TermID = 1};
        public AttendanceSummary Attendance { get; set; }

        public ICommand OnSaveAttendance
        {
            get { return new Command(async () => await this.SaveAttendance()); }
        }


        public AttendanceEditorModel(IContentPage ui, AttendanceSummary attendance) : base(ui)
        {
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
            this.Attendance = new AttendanceSummary();
            this.ModelResult = await attendanceMgr.GetAttendanceEditorModel(this.Attendance);
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
            //            FullName = player.PlayerName
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
            //            FullName = player.PlayerName
            //        };
            //        if (player.TermID > 0) { this.TermPlayerAttendances.Add(playerAttendance); } else { this.CasualPlayerAttendances.Add(playerAttendance); }
            //    }

            //}



        }




        public async Task SaveAttendance()
        {
            // Join both casual and permanents that have been marked as attended
            try
            {
                foreach (var attendance in this.TermPlayerAttendances)
                    if (attendance.HasAttended) this.Attendance.PlayerAttendances.Add(attendance);
                foreach (var attendance in this.CasualPlayerAttendances)
                    if (attendance.HasAttended) this.Attendance.PlayerAttendances.Add(attendance);

            }
            catch (Exception ex)
            {
                var s = 3;
            }
            this.Attendance.AttendanceDate = DateTime.Now;
            var attendanceMgr = new AttendanceManager();
            // Close after save...
            await attendanceMgr.SaveAttendance(this.Attendance);

            //var termMgr = new TermManager();

        }

    }
}
