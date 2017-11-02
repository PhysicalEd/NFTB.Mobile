using System;
using System.Collections.Generic;
using System.Linq;

namespace NFTB.Mobile.Data.Entities
{
    public class InvoiceSummary
    {
        public int InvoiceID { get; set; }
        public int TermID { get; set; }
        public string TermName { get; set; }

        public DateTime TermStart { get; set; }
        public DateTime? TermEnd { get; set; }
        public string TermRange { get; set; }

        public bool OrganizerIncluded { get; set; }

        public DateTime InvoiceDate { get; set; }
        public int TotalAmount { get; set; }
        public int NumberOfSessions { get; set; }

        public DateTime? WhenPaid { get; set; } = new DateTime();
    }
}
