using System;

namespace NFTB.Mobile.Data.Entities
{
    public class AttendanceSummary
    {
        public int AttendanceID { get; set; }
        public int TermID { get; set; }
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlayerName { get { return string.Format("{0} {1}", this.FirstName, this.LastName); } }
        public DateTime DateAttended { get; set; }
    }
}
