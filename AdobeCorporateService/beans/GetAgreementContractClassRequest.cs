using System.Collections.Generic;

namespace LegalService
{
    public class GetAgreementContractClassRequest
    {
        public string AgreementType { get; set; }

        public override bool Equals(object obj)
        {
            var request = obj as GetAgreementContractClassRequest;
            return request != null &&
                   AgreementType == request.AgreementType;
        }

        public override int GetHashCode()
        {
            return 1908178551 + EqualityComparer<string>.Default.GetHashCode(AgreementType);
        }
    }
}