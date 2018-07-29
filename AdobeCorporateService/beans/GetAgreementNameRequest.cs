using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdobeCorporateService.beans
{
    public class GetAgreementNameRequest
    {
        public String ContractGroup { get; set; }
        public String ContractingOrganization { get; set; }
        public String RecordType { get; set; }
        public String EndUserOrgination { get; set; }
        public String AccountName { get; set; }
        public String MarketingSegment { get; set; }
        public String ContractLanguage { get; set; }
        public String AgreementCategory { get; set; }
        public String ProgramType { get; set; }

        public override bool Equals(object obj)
        {
            var request = obj as GetAgreementNameRequest;
            return request != null &&
                   ContractGroup == request.ContractGroup &&
                   ContractingOrganization == request.ContractingOrganization &&
                   RecordType == request.RecordType &&
                   EndUserOrgination == request.EndUserOrgination &&
                   AccountName == request.AccountName &&
                   MarketingSegment == request.MarketingSegment &&
                   ContractLanguage == request.ContractLanguage &&
                   AgreementCategory == request.AgreementCategory &&
                   ProgramType == request.ProgramType;
        }

        public override int GetHashCode()
        {
            var hashCode = -490121531;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContractGroup);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContractingOrganization);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RecordType);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EndUserOrgination);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AccountName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MarketingSegment);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContractLanguage);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AgreementCategory);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProgramType);
            return hashCode;
        }
    }
}
