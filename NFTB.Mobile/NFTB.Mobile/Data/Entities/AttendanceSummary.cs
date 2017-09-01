using System;
using System.Collections.Generic;
using System.Linq;

namespace NFTB.Mobile.Data.Entities
{
    public class AttendanceSummary
    {
        public int AttendanceID { get; set; }
        public int TermID { get; set; }
        public string TermName { get; set; }
        public DateTime AttendanceDate { get; set; }
        public List<PlayerAttendanceSummary> PlayerAttendances { get; set; } = new List<PlayerAttendanceSummary>();
        public int TotalPlayersAttended => this.PlayerAttendances.Count();
        public int CasualsAttended => this.PlayerAttendances.Count(x => x.IsCasual);
        public int TermPlayersAttended => this.PlayerAttendances.Count(x => !x.IsCasual);
    }
}
