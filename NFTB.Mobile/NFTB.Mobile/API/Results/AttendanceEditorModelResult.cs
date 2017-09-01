using System.Collections.Generic;
using System.Collections.ObjectModel;
using NFTB.Mobile.Data.Entities;

namespace NFTB.Mobile.API.Results
{
    public class AttendanceEditorModelResult
    {
        public AttendanceSummary Attendance { get; set; } = new AttendanceSummary();
        public List<PlayerAttendanceSummary> PlayerAttendances { get; set; } = new List<PlayerAttendanceSummary>();
        public ObservableCollection<PlayerAttendanceSummary> TermPlayerAttendances { get; set; } = new ObservableCollection<PlayerAttendanceSummary>();
        public ObservableCollection<PlayerAttendanceSummary> CasualPlayerAttendances { get; set; } = new ObservableCollection<PlayerAttendanceSummary>();
        public List<PlayerSummary> PlayerList { get; set; } = new List<PlayerSummary>();


    }
}
