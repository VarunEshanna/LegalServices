using System;
using AdobeCorporateService.beans;
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
        public void GetAdobeCorporateTestEntityForUSAccounts(AccountEntity entity)
        {
            AgreementInitiationServiceEntity agreementInitiationServiceEntity = new AgreementInitiationServiceEntity();
            agreementInitiationServiceEntity.GetAdobeCorporateEntity(entity);
            Assert.AreEqual(entity.AdobeCorporateEntity, "ADUS");
        }

        [Test, TestCaseSource(typeof(MyDataClass), "ManualAssertion", new object[] { "Non US Accounts" })]
        public void GetAdobeCorporateTestEntityForNonUSAccounts(AccountEntity entity)
        {
            AgreementInitiationServiceEntity agreementInitiationServiceEntity = new AgreementInitiationServiceEntity();
            agreementInitiationServiceEntity.GetAdobeCorporateEntity(entity);
            Assert.AreEqual(entity.AdobeCorporateEntity, "ADIR");
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

        [Test, TestCaseSource(typeof(MyDataClass), "ManualAssertion", new object[] { "US Accounts and US Contact" })]
        public void GetAdobeCorporateTestEntityForUSAccounts1(AccountEntity entity, ContactEntity contact)
        {
            AgreementInitiationServiceEntity agreementInitiationServiceEntity = new AgreementInitiationServiceEntity();
            String test = agreementInitiationServiceEntity.GetAdobeCorporateEntity(entity,contact);
            Assert.AreEqual(test, "test");
        }
    }
}
