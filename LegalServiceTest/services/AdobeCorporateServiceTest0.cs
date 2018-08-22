using System;
using AdobeCorporateService.beans;
using LegalService;
using NUnit.Framework;
using TestFramework;

namespace LegalServiceTest
{
    [TestFixture]
    public class AdobeCorporateServiceTest0
    {

        [Test]
        public void GetAdobeCorporateEntityTest1()
        {
            GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest = new GetAdobeCorporateEntityRequest();
            GetAdobeCorporateEntityRequest.AccountCountry = "US";
            GetAdobeCorporateEntityRequest.AgreementType = "DMA";
            GetAdobeCorporateEntityRequest.MarketSegment = "Commercial";
            GetAdobeCorporateEntityRequest.isCorporateEntityOverride = true;

            AgreementInitiationService adobeCorporateService = new AgreementInitiationService();
            GetAdobeCorporateEntityResponse GetAdobeCorporateEntityResponse = adobeCorporateService.GetAdobeCorporateEntity(GetAdobeCorporateEntityRequest);

            Assert.AreEqual(GetAdobeCorporateEntityResponse.AdobeCorporateEntity, "ADUS");
        }

        [Test]
        public void GetAdobeCorporateEntityTest2()
        {
            GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest = new GetAdobeCorporateEntityRequest();
            GetAdobeCorporateEntityRequest.AccountCountry = "UK";
            GetAdobeCorporateEntityRequest.AgreementType = "DMA";
            GetAdobeCorporateEntityRequest.MarketSegment = "Commercial";
            GetAdobeCorporateEntityRequest.isCorporateEntityOverride = true;

            AgreementInitiationService adobeCorporateService = new AgreementInitiationService();
            GetAdobeCorporateEntityResponse GetAdobeCorporateEntityResponse = adobeCorporateService.GetAdobeCorporateEntity(GetAdobeCorporateEntityRequest);

            Assert.AreEqual(GetAdobeCorporateEntityResponse.AdobeCorporateEntity, "ADIR");
        }

        [Test]
        public void GetAgreementContractClassTest1()
        {
            GetAgreementContractClassRequest GetAgreementContractClassRequest = new GetAgreementContractClassRequest();
            GetAgreementContractClassRequest.AgreementType = "DMA";

            AgreementInitiationService adobeCorporateService = new AgreementInitiationService();
            GetAgreementContractClassResponse GetAgreementContractClassResponse = adobeCorporateService.GetAgreementContractClass(GetAgreementContractClassRequest);

            Assert.AreEqual(GetAgreementContractClassResponse.ContractClass, "RG");
        }

        [Test]
        public void GetAgreementContractClassTest2()
        {
            GetAgreementContractClassRequest GetAgreementContractClassRequest = new GetAgreementContractClassRequest();
            GetAgreementContractClassRequest.AgreementType = "NDA";

            AgreementInitiationService adobeCorporateService = new AgreementInitiationService();
            GetAgreementContractClassResponse GetAgreementContractClassResponse = adobeCorporateService.GetAgreementContractClass(GetAgreementContractClassRequest);

            Assert.AreEqual(GetAgreementContractClassResponse.ContractClass, "NRG");
        }
    }
}
