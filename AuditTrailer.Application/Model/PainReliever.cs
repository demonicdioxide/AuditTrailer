using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuditTrailer.Application.Model
{
    public class PainReliever
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Analgesic MainAnalgesic { get; set; }
        public double MainAnalgesicAmount { get; set; }
        public Analgesic SecondaryAnalgesic { get; set; }
        public double SecondaryAnalgesicAmount { get; set; }
        public bool IsPrescriptionOnly { get; set; }
        public IEnumerable<BoxSize> BoxSizes { get; set; } 
    }
}
