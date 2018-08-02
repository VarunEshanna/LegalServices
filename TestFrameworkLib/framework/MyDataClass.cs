using System;
using System.Collections;
using System.Collections.Generic;
using LegalService;
using NUnit.Framework;
using TestFrameworkLib;

namespace TestFramework
{

    public class MyDataClass
    {

        public static IEnumerable ManualAssertion(String dataSetName)
        {
            MongoDbConnection mongoDbConnection = new MongoDbConnection();
            Dictionary < String, Object > names = mongoDbConnection.getRequestData(dataSetName);

            int dataSets = 0;
            int arguments = 0;

            foreach (KeyValuePair<String, Object> entry in names)
            {
                String objectName = entry.Key;
                if (objectName.IndexOf('1') == 7)
                {
                    arguments++;
                }
                else
                {
                    break;
                }
                    
            }
            dataSets = names.Count / arguments;



            for (int i=1; i < dataSets+1; i++)
            {
                //TODO create testcases objects using reflection
                if(arguments == 1)
                {
                    yield return new TestCaseData(names["Request"+i+"1"]);
                }
                else if(arguments == 2)
                {
                    yield return new TestCaseData(names["Request" + i + "1"], names["Request" + i + "2"]);
                }
                else if (arguments == 3)
                {
                    yield return new TestCaseData(names["Request" + i + "1"], names["Request" + i + "2"], names["Request" + i + "3"]);
                }
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
    }
}
