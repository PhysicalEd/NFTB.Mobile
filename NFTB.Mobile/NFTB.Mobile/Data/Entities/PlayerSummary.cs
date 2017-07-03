using System;

namespace NFTB.Mobile.Data.Entities
{
    public class PlayerSummary
    {
        public int PlayerID { get; set; }
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PlayerName { get { return string.Format("{0} {1}", this.FirstName, this.LastName); } }
    }
}
