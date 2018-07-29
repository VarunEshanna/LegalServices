using System;
using System.Collections.Generic;

namespace LegalService
{
    public class GetAdobeCorporateEntityRequest
    {
        public String AgreementType { get; set; }
        public String AccountCountry { get; set; }
        public String MarketSegment { get; set; }
        public Boolean isCorporateEntityOverride { get; set; }

        public override bool Equals(object obj)
        {
            var request = obj as GetAdobeCorporateEntityRequest;
            return request != null &&
                   AgreementType == request.AgreementType &&
                   AccountCountry == request.AccountCountry &&
                   MarketSegment == request.MarketSegment &&
                   isCorporateEntityOverride == request.isCorporateEntityOverride;
        }

        public override int GetHashCode()
        {
            var hashCode = -1259491826;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AgreementType);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AccountCountry);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MarketSegment);
            hashCode = hashCode * -1521134295 + isCorporateEntityOverride.GetHashCode();
            return hashCode;
        }
    }
}