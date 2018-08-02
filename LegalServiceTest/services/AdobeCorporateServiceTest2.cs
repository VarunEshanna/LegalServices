using LegalService;
using NUnit.Framework;
using TestFramework;

namespace LegalServiceTest
{
    [TestFixture]
    public class AdobeCorporateServiceTest2
    {

        [Test, TestCaseSource(typeof(MyDataClass), "AutoAssertion", new object[] { "Adobe Corporate Entity Records" })]
        public GetAdobeCorporateEntityResponse GetAdobeCorporateEntityTest(GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest)
        {
            AgreementInitiationService adobeCorporateService = new AgreementInitiationService();
            return adobeCorporateService.GetAdobeCorporateEntity(GetAdobeCorporateEntityRequest);
        }

        [Test, TestCaseSource(typeof(MyDataClass), "AutoAssertion", new object[] { "Adobe Contract Class Records" })]
        public GetAgreementContractClassResponse GetAgreementContractClassTest(GetAgreementContractClassRequest GetAgreementContractClassRequest)
        {
            AgreementInitiationService adobeCorporateService = new AgreementInitiationService();
            return adobeCorporateService.GetAgreementContractClass(GetAgreementContractClassRequest);
        }
    }
}
