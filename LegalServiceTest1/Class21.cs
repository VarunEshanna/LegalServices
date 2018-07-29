using System;
using System.Collections;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace LegalServiceTest1
{
    [TestFixture]
    public class AdobeCorporateServiceTest
    {
        [Test]
        public void GetAdobeCorporateEntityTestMethod1()
        {

            LegalService.GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest1 = new LegalService.GetAdobeCorporateEntityRequest();
            GetAdobeCorporateEntityRequest1.AccountCountry = "US";
            GetAdobeCorporateEntityRequest1.AgreementType = "DMA";
            GetAdobeCorporateEntityRequest1.MarketSegment = "Commercial";


            LegalService.AdobeCorporateService adobeCorporateService = new LegalService.AdobeCorporateService();
            LegalService.GetAdobeCorporateEntityResponse GetAdobeCorporateEntityResponse = null;
            GetAdobeCorporateEntityResponse = adobeCorporateService.GetAdobeCorporateEntity(GetAdobeCorporateEntityRequest1);
            Assert.Equals("3PTY", GetAdobeCorporateEntityResponse.AdobeCorporateEntity);
        }


        public class MyDataClass
        {
            public static IEnumerable TestCases1
            {
                get
                {
                    LegalService.GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest1 = new LegalService.GetAdobeCorporateEntityRequest();
                    GetAdobeCorporateEntityRequest1.AccountCountry = "US";
                    GetAdobeCorporateEntityRequest1.AgreementType = "DMA";
                    GetAdobeCorporateEntityRequest1.MarketSegment = "Commercial";
                    GetAdobeCorporateEntityRequest1.isCorporateEntityOverride = true;
                    //LegalService.GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest2 = new LegalService.GetAdobeCorporateEntityRequest();
                    //LegalService.GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest3 = new LegalService.GetAdobeCorporateEntityRequest();
                    //LegalService.GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest4 = new LegalService.GetAdobeCorporateEntityRequest();

                    yield return new TestCaseData(GetAdobeCorporateEntityRequest1).Returns(4);
                    //yield return new TestCaseData(GetAdobeCorporateEntityRequest2).Returns(3);
                    //yield return new TestCaseData(GetAdobeCorporateEntityRequest3).Returns(3);
                    //yield return new TestCaseData(GetAdobeCorporateEntityRequest4).Returns(4);
                }
            }
        }

    }
}
