using System;
using System.Collections.Generic;
using System.Linq;

namespace NFTB.Mobile.Data.Entities
{
    public class TermDetailModelResult
    {
        public TermSummary Term { get; set; } = new TermSummary();
        public List<PlayerSummary> TermPlayers { get; set; }
        public List<AttendanceSummary> Attendances { get; set; }
        public List<PlayerAttendanceSummary> PlayerAttendances { get; set; } = new List<PlayerAttendanceSummary>();
        public List<PlayerAttendanceSummary> CasualPlayerAttendancesForTerm { get; set; } = new List<PlayerAttendanceSummary>();
        public int ExpectedAmountFromCasuals { get; set; }
        public int ActualAmountFromCasuals { get; set; }
        public int TotalAmountOwingFromTermPlayers { get; set; }

        public int NumberOfSessions { get; set; }
        public InvoiceSummary Invoice { get; set; }

    }
}
