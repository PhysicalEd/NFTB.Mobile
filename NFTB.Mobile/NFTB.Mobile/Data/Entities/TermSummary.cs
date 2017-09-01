using System;
using System.Collections.Generic;
using System.Linq;

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
        public int NumberOfPlayers { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public bool IsInvoiced { get; set; }
        public string TermRange { get; set; }

    }
}
