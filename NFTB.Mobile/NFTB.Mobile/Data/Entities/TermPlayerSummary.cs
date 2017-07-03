using System;

namespace NFTB.Mobile.Data.Entities
{
    public class TermPlayerSummary
    {
        public int TermPlayerID { get; set; }
        public int TermID { get; set; }
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlayerName { get { return string.Format("{0} {1}", this.FirstName, this.LastName); } }
        public int BondPaid { get; set; }
        public int TermDue { get; set; }
        public int TermOwing { get; set; }
    }
}
