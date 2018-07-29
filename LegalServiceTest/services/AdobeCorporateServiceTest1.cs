using System;
using LegalService;
using Microsoft.Xrm.Sdk;
using NUnit.Framework;
using TestFramework;

namespace LegalServiceTest
{
    [TestFixture]
    public class AdobeCorporateServiceTest1
    {

        [Test, TestCaseSource(typeof(MyDataClass), "ManualAssertion", new object[] { "US Accounts" })]
        public void GetAdobeCorporateTestEntityForUSAccounts(Entity entity)
        {
            AgreementInitiationServiceEntity agreementInitiationServiceEntity = new AgreementInitiationServiceEntity();
            agreementInitiationServiceEntity.GetAdobeCorporateEntity(entity);
            Assert.AreEqual(entity.GetAttributeValue<String>("AdobeCorporateEntity"), "ADUS");
        }

        [Test, TestCaseSource(typeof(MyDataClass), "ManualAssertion", new object[] { "Non US Accounts" })]
        public void GetAdobeCorporateTestEntityForNonUSAccounts(Entity entity)
        {
            AgreementInitiationServiceEntity agreementInitiationServiceEntity = new AgreementInitiationServiceEntity();
            agreementInitiationServiceEntity.GetAdobeCorporateEntity(entity);
            Assert.AreEqual(entity.GetAttributeValue<String>("AdobeCorporateEntity"), "ADIR");
        }


        [Test, TestCaseSource(typeof(MyDataClass), "ManualAssertion", new object[] { "US Accounts" })]
        public void GetAgreementContractClassTestEntityForRGTypes(Entity entity)
        {
            AgreementInitiationServiceEntity agreementInitiationServiceEntity = new AgreementInitiationServiceEntity();
            agreementInitiationServiceEntity.GetAgreementContractClass(entity);
            Assert.AreEqual(entity.GetAttributeValue<String>("ContractClass"), "RG");
        }


        [Test, TestCaseSource(typeof(MyDataClass), "ManualAssertion", new object[] { "Non US Accounts" })]
        public void GetAgreementContractClassTestEntityForNRGTypes(Entity entity)
        {
            AgreementInitiationServiceEntity agreementInitiationServiceEntity = new AgreementInitiationServiceEntity();
            agreementInitiationServiceEntity.GetAgreementContractClass(entity);
            Assert.AreEqual(entity.GetAttributeValue<String>("ContractClass"), "NRG");
        }
    }
}
