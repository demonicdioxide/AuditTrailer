using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuditTrailer.Application.Model
{
    public class Store
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public TimeSpan? OpeningStartTime { get; set; }
        public TimeSpan? OpeningEndTime { get; set; }
        public bool IsOnlineStore { get; set; }
        public int PackagingRating { get; set;}
        public string Notes { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
