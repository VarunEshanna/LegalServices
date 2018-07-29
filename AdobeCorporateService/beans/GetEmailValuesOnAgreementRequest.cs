using System.Collections.Generic;

namespace LegalService
{
    public class GetEmailValuesOnAgreementRequest
    {
        public string AddressCountry { get; set; }

        public override bool Equals(object obj)
        {
            var request = obj as GetEmailValuesOnAgreementRequest;
            return request != null &&
                   AddressCountry == request.AddressCountry;
        }

        public override int GetHashCode()
        {
            return -472475245 + EqualityComparer<string>.Default.GetHashCode(AddressCountry);
        }
    }
}