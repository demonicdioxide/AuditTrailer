using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                return MedicineDetails.Item1;
            }
        }

        public int BoxSizeBought
        {
            get
            {
                return MedicineDetails.Item2;
            }
        }
        public DateTime DateOccurred { get; set; }
        public int AmountBought
        {
            get
            {
                return MedicineDetails.Item3;
            }
        }
    }
}
