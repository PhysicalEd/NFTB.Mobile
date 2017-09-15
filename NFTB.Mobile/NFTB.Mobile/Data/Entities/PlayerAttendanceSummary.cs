using System;

namespace NFTB.Mobile.Data.Entities
{
    public class PlayerAttendanceSummary
    {
        public int PlayerAttendanceID { get; set; }
        public int AttendanceID { get; set; }
        public int PlayerID { get; set; }
        public bool IsCasual { get; set; }
        public int? AmountPaid { get; set; }

        public bool HasAttended { get; set; } = false;

        // Player details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}
