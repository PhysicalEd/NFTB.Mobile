using System;

namespace NFTB.Mobile.Data.Entities
{
    public class TermSummary
    {
        public int TermID { get; set; }
        public string Name { get; set; }
        public DateTime TermStart { get; set; }
        public DateTime? TermEnd { get; set; }
        public int BondAmount { get; set; }
        public int CasualRate { get; set; }
        public bool IncludeOrganizer { get; set; }

    }
}
