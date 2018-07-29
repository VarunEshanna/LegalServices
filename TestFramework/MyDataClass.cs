using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using LegalService;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using NUnit.Framework;

namespace TestFramework
{

    public static class EntityExtension
    {
        public static bool IsEqual(Entity entity, String dataSetReturnValue) {
            return true;
        }
    }

    public class MyDataClass
    {

        public static IEnumerable TestCases1
        {
            get
            {
                String asmName= Assembly.GetExecutingAssembly().GetName().Name;

                Assembly mainAssembly = typeof(GetAdobeCorporateEntityRequest).Assembly;

                //Assembly asm = Assembly.Load(@"C:\Users\eshanna\Desktop\AdobeCorporateService.dll");
                Module module = mainAssembly.GetModule("AdobeCorporateService.dll");

                String TestMethodName = "GetAdobeCorporateEntityTest";
                // For the given TestMethodName, find the request, response types from registration table

                List<String> RequestTypeValueList = new List<String>();
                RequestTypeValueList.Add("LegalService.GetAdobeCorporateEntityRequest"); // Retrieved from Registration table
                String ResponseTypeValue = "LegalService.GetAdobeCorporateEntityResponse"; // Retrieved from Registration table

                // From the test method name, get the request and response id from mapping table and then get the id from entity

                Dictionary<String, Object> myDictionary = new Dictionary<String, Object>();
                myDictionary.Add("AgreementType", "DMA");
                myDictionary.Add("AccountCountry", "US");
                myDictionary.Add("MarketSegment", "Commercial");
                myDictionary.Add("isCorporateEntityOverride", true);

                List<Object> RequestList = new List<Object>();
                Object Request1 = null;

                // Creating Request Instance
                for (int i= 0; i < RequestTypeValueList.Count; i++)
                {
                    Type RequestType = module.GetType(RequestTypeValueList[i]);
                    Object Request = Activator.CreateInstance(RequestType);


                    foreach (KeyValuePair<string, object> entry in myDictionary)
                    {
                        // do something with entry.Value or entry.Key
                        PropertyInfo RequestProperty = RequestType.GetProperty(entry.Key);
                        RequestProperty.SetValue(Request, entry.Value);
                    }
                    RequestList.Add(Request);
                    Request1 = Request;
                }

                // Creating Response Instance
                Type ResponseType = module.GetType(ResponseTypeValue);
                Object Response = Activator.CreateInstance(ResponseType);

                myDictionary = new Dictionary<String, Object>();
                myDictionary.Add("AdobeCorporateEntity", "ADUS");

                foreach (KeyValuePair<string, object> entry in myDictionary)
                {
                    PropertyInfo RequestProperty = ResponseType.GetProperty(entry.Key);
                    RequestProperty.SetValue(Response, entry.Value);
                }
                
                yield return new TestCaseData(Request1).Returns(Response);
            }
        }



        public static IEnumerable TestCases2
        {
            get
            {
                GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest1 = new GetAdobeCorporateEntityRequest();
                GetAdobeCorporateEntityRequest1.AccountCountry = "US";
                GetAdobeCorporateEntityRequest1.AgreementType = "DMA";
                GetAdobeCorporateEntityRequest1.MarketSegment = "Commercial";
                GetAdobeCorporateEntityRequest1.isCorporateEntityOverride = true;

                GetAdobeCorporateEntityResponse GetAdobeCorporateEntityResponse1 = new GetAdobeCorporateEntityResponse();
                GetAdobeCorporateEntityResponse1.AdobeCorporateEntity = "ADUS";
                yield return new TestCaseData(GetAdobeCorporateEntityRequest1).Returns(GetAdobeCorporateEntityResponse1);

                GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest2 = new GetAdobeCorporateEntityRequest();
                GetAdobeCorporateEntityRequest2.AccountCountry = "UK";
                GetAdobeCorporateEntityRequest2.AgreementType = "DMA";
                GetAdobeCorporateEntityRequest2.MarketSegment = "Commercial";
                GetAdobeCorporateEntityRequest2.isCorporateEntityOverride = true;

                GetAdobeCorporateEntityResponse GetAdobeCorporateEntityResponse2 = new GetAdobeCorporateEntityResponse();
                GetAdobeCorporateEntityResponse2.AdobeCorporateEntity = "ADIR";
                yield return new TestCaseData(GetAdobeCorporateEntityRequest2).Returns(GetAdobeCorporateEntityResponse1);
            }

        }





        public static IEnumerable TestCases3
        {
            get
            {
                var accountGuid1 = Guid.NewGuid();
                var request1 = new Entity("account") { Id = accountGuid1 };
                request1.Attributes.Add("AgreementType", "DMA");
                request1.Attributes.Add("AccountCountry", "US");
                request1.Attributes.Add("MarketSegment", "Commercial");
                request1.Attributes.Add("isCorporateEntityOverride", true);
                yield return new TestCaseData(request1);
            }
        }


        public static IEnumerable TestCases4
        {
            get
            {
                var accountGuid2 = Guid.NewGuid();
                var request2 = new Entity("account") { Id = accountGuid2 };
                request2.Attributes.Add("AgreementType", "NDA");
                request2.Attributes.Add("AccountCountry", "UK");
                request2.Attributes.Add("MarketSegment", "Commercial");
                request2.Attributes.Add("isCorporateEntityOverride", true);
                yield return new TestCaseData(request2);
            }
        }


        public static IEnumerable ManualAssertion(String DataSetName)
        {
            if (DataSetName.Equals("US Accounts"))
            {
                var accountGuid1 = Guid.NewGuid();
                var request1 = new Entity("account") { Id = accountGuid1 };
                request1.Attributes.Add("AgreementType", "DMA");
                request1.Attributes.Add("AccountCountry", "US");
                request1.Attributes.Add("MarketSegment", "Commercial");
                request1.Attributes.Add("isCorporateEntityOverride", true);
                yield return new TestCaseData(request1);
            }
            else if (DataSetName.Equals("Non US Accounts"))
            {
                var accountGuid3 = Guid.NewGuid();
                var request3 = new Entity("account") { Id = accountGuid3 };
                request3.Attributes.Add("AgreementType", "NDA");
                request3.Attributes.Add("AccountCountry", "UK");
                request3.Attributes.Add("MarketSegment", "Commercial");
                request3.Attributes.Add("isCorporateEntityOverride", true);
                yield return new TestCaseData(request3);
            }
        }


        public static IEnumerable AutoAssertion(String DataSetName)
        {
            if (DataSetName.Equals("Adobe Corporate Entity Records"))
            {
                GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest1 = new GetAdobeCorporateEntityRequest();
                GetAdobeCorporateEntityRequest1.AccountCountry = "US";
                GetAdobeCorporateEntityRequest1.AgreementType = "DMA";
                GetAdobeCorporateEntityRequest1.MarketSegment = "Commercial";
                GetAdobeCorporateEntityRequest1.isCorporateEntityOverride = true;

                GetAdobeCorporateEntityResponse GetAdobeCorporateEntityResponse1 = new GetAdobeCorporateEntityResponse();
                GetAdobeCorporateEntityResponse1.AdobeCorporateEntity = "ADUS";
                yield return new TestCaseData(GetAdobeCorporateEntityRequest1).Returns(GetAdobeCorporateEntityResponse1);

                GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest2 = new GetAdobeCorporateEntityRequest();
                GetAdobeCorporateEntityRequest2.AccountCountry = "UK";
                GetAdobeCorporateEntityRequest2.AgreementType = "DMA";
                GetAdobeCorporateEntityRequest2.MarketSegment = "Commercial";
                GetAdobeCorporateEntityRequest2.isCorporateEntityOverride = true;

                GetAdobeCorporateEntityResponse GetAdobeCorporateEntityResponse2 = new GetAdobeCorporateEntityResponse();
                GetAdobeCorporateEntityResponse2.AdobeCorporateEntity = "ADIR";
                yield return new TestCaseData(GetAdobeCorporateEntityRequest2).Returns(GetAdobeCorporateEntityResponse2);
            }
            else if (DataSetName.Equals("Adobe Contract Class Records"))
            {
                GetAgreementContractClassRequest getAgreementContractClassRequest1 = new GetAgreementContractClassRequest();
                getAgreementContractClassRequest1.AgreementType = "DMA";

                GetAgreementContractClassResponse getAgreementContractClassResponse1 = new GetAgreementContractClassResponse();
                getAgreementContractClassResponse1.ContractClass = "RG";
                yield return new TestCaseData(getAgreementContractClassRequest1).Returns(getAgreementContractClassResponse1);

                GetAgreementContractClassRequest getAgreementContractClassRequest2 = new GetAgreementContractClassRequest();
                getAgreementContractClassRequest2.AgreementType = "NDA";

                GetAgreementContractClassResponse getAgreementContractClassResponse2 = new GetAgreementContractClassResponse();
                getAgreementContractClassResponse2.ContractClass = "NRG";
                yield return new TestCaseData(getAgreementContractClassRequest2).Returns(getAgreementContractClassResponse2);
            }


        }

        public static IEnumerable TestMethod1(String DataSetName)
        {
            Console.WriteLine(DataSetName);
            GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest1 = new GetAdobeCorporateEntityRequest();
            GetAdobeCorporateEntityRequest1.AccountCountry = "US";
            GetAdobeCorporateEntityRequest1.AgreementType = "DMA";
            GetAdobeCorporateEntityRequest1.MarketSegment = "Commercial";
            GetAdobeCorporateEntityRequest1.isCorporateEntityOverride = true;

            GetAdobeCorporateEntityResponse GetAdobeCorporateEntityResponse1 = new GetAdobeCorporateEntityResponse();
            GetAdobeCorporateEntityResponse1.AdobeCorporateEntity = "ADUS";
            yield return new TestCaseData(GetAdobeCorporateEntityRequest1).Returns(GetAdobeCorporateEntityResponse1);

            GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest2 = new GetAdobeCorporateEntityRequest();
            GetAdobeCorporateEntityRequest2.AccountCountry = "UK";
            GetAdobeCorporateEntityRequest2.AgreementType = "DMA";
            GetAdobeCorporateEntityRequest2.MarketSegment = "Commercial";
            GetAdobeCorporateEntityRequest2.isCorporateEntityOverride = true;

            GetAdobeCorporateEntityResponse GetAdobeCorporateEntityResponse2 = new GetAdobeCorporateEntityResponse();
            GetAdobeCorporateEntityResponse2.AdobeCorporateEntity = "ADIR";
            yield return new TestCaseData(GetAdobeCorporateEntityRequest2).Returns(GetAdobeCorporateEntityResponse2);
        }

    }
}
