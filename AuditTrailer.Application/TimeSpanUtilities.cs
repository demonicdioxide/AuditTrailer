using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuditTrailer.Common
{
    public class TimeSpanUtilities
    {
        public static string ToStringWitHoursAndMinutes(TimeSpan timeSpan)
        {
            var toStringed = timeSpan.ToString();
            var splitUpString = toStringed.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            return string.Format("{0}:{1}", splitUpString.First(), splitUpString.ElementAt(1));
        }
    }
}
