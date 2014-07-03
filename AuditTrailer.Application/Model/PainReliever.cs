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
        public string AliasedMedicine { get; set; }
        public bool HasAlias
        {
        	get { return !string.IsNullOrEmpty(AliasedMedicine); }
        }
        
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			PainReliever other = obj as PainReliever;
			if (other == null) 
			{
				// it's not a pain reliever
				return false;
			}
			
			return other.Name.Equals(Name, StringComparison.OrdinalIgnoreCase);
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				hashCode += 1000000007 * ID.GetHashCode();
				if (Name != null)
					hashCode += 1000000009 * Name.GetHashCode();
				if (MainAnalgesic != null)
					hashCode += 1000000021 * MainAnalgesic.GetHashCode();
				hashCode += 1000000033 * MainAnalgesicAmount.GetHashCode();
				if (SecondaryAnalgesic != null)
					hashCode += 1000000087 * SecondaryAnalgesic.GetHashCode();
				hashCode += 1000000093 * SecondaryAnalgesicAmount.GetHashCode();
				hashCode += 1000000097 * IsPrescriptionOnly.GetHashCode();
				if (BoxSizes != null)
					hashCode += 1000000103 * BoxSizes.GetHashCode();
				if (AliasedMedicine != null)
					hashCode += 1000000123 * AliasedMedicine.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(PainReliever lhs, PainReliever rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(PainReliever lhs, PainReliever rhs) {
			return !(lhs == rhs);
		}

		#endregion
    }
}
