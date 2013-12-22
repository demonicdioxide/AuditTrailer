using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AuditTrailer.Application.DotNetFourEmulation;

namespace AuditTrailer.Application.Model
{
    public class Trip
    {
        public Store Store { get; set; }
        public User User { get; set; }
        public Tuple<string, int, int> MedicineDetails { get; set; }

        public PainReliever PainRelieverBought { get; set; }

        public string MedicineBought
        {
            get
            {
                return MedicineDetails.First;
            }
        }

        public int BoxSizeBought
        {
            get
            {
                return MedicineDetails.Second;
            }
        }
        public DateTime DateOccurred { get; set; }
        public int AmountBought
        {
            get
            {
                return MedicineDetails.Third;
            }
        }
    }
}
