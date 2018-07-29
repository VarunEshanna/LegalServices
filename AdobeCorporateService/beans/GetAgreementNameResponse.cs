using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdobeCorporateService.beans
{
    public class GetAgreementNameResponse
    {
        public String AgreementName { get; set; }

        public override bool Equals(object obj)
        {
            var response = obj as GetAgreementNameResponse;
            return response != null &&
                   AgreementName == response.AgreementName;
        }

        public override int GetHashCode()
        {
            return -1079735964 + EqualityComparer<string>.Default.GetHashCode(AgreementName);
        }
    }
}
