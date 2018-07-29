using System;
using FakeXrmEasy;
using LegalServicePlugin;
using Microsoft.Xrm.Sdk;
using NUnit.Framework;
using TestFramework;

namespace LegalServiceTest
{
    public class PluginTest
    {



        //[Test, TestCaseSource(typeof(MyDataClass), "TestCases3")]
        public void test7(Entity entity)
        {

            var context = new XrmFakedContext();

            // Should not create GUID ID during create process.
            var accountGuid = Guid.NewGuid();
            var accountTarget = entity;

            ParameterCollection inputParameters = new ParameterCollection();
            inputParameters.Add("Target", accountTarget);

            var plugCtx = context.GetDefaultPluginContext();
            plugCtx.MessageName = "Create";
            plugCtx.InputParameters = inputParameters;

            Assert.DoesNotThrow(() => context.ExecutePluginWith<AccountPlugin>(plugCtx));
            Assert.AreEqual((String)accountTarget["AdobeCorporateEntity"], "ADUS");
            Assert.AreEqual((String)accountTarget["ContractClass"], "RG");
        }


       // [Test, TestCaseSource(typeof(MyDataClass), "TestCases4")]
        public void test8(Entity entity)
        {

            var context = new XrmFakedContext();
            var accountGuid = Guid.NewGuid();
            var accountTarget = entity;

            ParameterCollection inputParameters = new ParameterCollection();
            inputParameters.Add("Target", accountTarget);
           

            var plugCtx = context.GetDefaultPluginContext();
            plugCtx.MessageName = "Create";
            plugCtx.InputParameters = inputParameters;


            context.Initialize(new[] {
                new Entity ("integrationdetails")
                {
                    Id = accountGuid,
                    Attributes = new AttributeCollection
                    {
                        { "name", "SAPConnection" },
                        { "url", "http" },
                        { "httpmethod", "post" }
                    }
                }
            });


            Assert.DoesNotThrow(() => context.ExecutePluginWith<AccountPlugin>(plugCtx));
            Assert.AreEqual((String)accountTarget["AdobeCorporateEntity"], "ADIR");
            Assert.AreEqual((String)accountTarget["ContractClass"], "NRG");
        }












        /*



        [Test]
        public void testmethod1()
        {
            var fakedContext = new XrmFakedContext();

            var accountGuid = Guid.NewGuid();
            var accountTarget = new Entity("account") { Id = accountGuid };
            accountTarget.Attributes.Add("tickersymbol","ADBE");

            //Execute our plugin against a target that doesn't contains the accountnumber attribute
            var fakedPlugin = fakedContext.ExecutePluginWithTarget<AccountPlugin>(accountTarget);

            //Assert that the target contains a new attribute
            Assert.True(accountTarget.Attributes.Contains("email"));
            Assert.AreEqual((String)accountTarget["email"], "eshanna@adobe.com");

        }


        [Test]
        public void testmethod2()
        {

            var context = new XrmFakedContext();

            var accountGuid = Guid.NewGuid();
            var accountTarget = new Entity("account") { Id = accountGuid };
            accountTarget.Attributes.Add("tickersymbol", "ADBE");

            //var accountTargetFromDb = MongoDB.getEntityDataFromName("account", "Test Account");
            //var accountTargetFromDb = MongoDB.getEntityDataFromId("account", "asdau1ac3");


            ParameterCollection inputParameters = new ParameterCollection();
            inputParameters.Add("Target", accountTarget);

            //Let's get a default plugin context, and then tell the framework this plugin context emulates a "Create" message with a target entity
            var plugCtx = context.GetDefaultPluginContext();
            plugCtx.MessageName = "Update";
            plugCtx.InputParameters = inputParameters;
            plugCtx.InitiatingUserId = new Guid();
            
            

            Assert.DoesNotThrow(() => context.ExecutePluginWith<AccountPlugin>(plugCtx));

            Assert.True(inputParameters.Contains("Target"));
            Entity targetValue = (Entity)inputParameters["Target"];
            Assert.True(targetValue.Attributes.Contains("EMailAddress1"));
            Assert.AreEqual((String)targetValue["EMailAddress1"], "eshanna@adobe.com");

        }

        [Test]
        //[Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException (typeof(System.ServiceModel.FaultException))]
        public void test3()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Test user without update priviliges - Sales Manager role
            //var userGuid = new Guid("08C98B95-9E5D-E811-A955-000D3AF27775");

            // Test user with update priviliges - Admin
            var userGuid = new Guid("979B9517-67AF-4B30-A5E7-13B7C8370FC8");

            var userTarget = new Entity("systemuser") { Id = userGuid };
            //userTarget.Attributes.Add("roletemplateid", "1A9C8A09-E3B1-4107-8BA0-1A72792B7813");
            

            AuthenticationCredentials clientCredentials = new AuthenticationCredentials();
            clientCredentials.ClientCredentials.UserName.UserName = "crm8@trng1.onmicrosoft.com";
            clientCredentials.ClientCredentials.UserName.Password = "Training$CRM@123";

            String uri = "https://trng1.api.crm8.dynamics.com/XRMServices/2011/Organization.svc";
            OrganizationServiceProxy serviceProxy = new OrganizationServiceProxy(new Uri(uri), null, clientCredentials.ClientCredentials, null);
            serviceProxy.CallerId = userGuid;



            var accountGuid = new Guid("AAA19CDD-88DF-E311-B8E5-6C3BE5A8B200");
            var accountTarget = new Entity("account") { Id = accountGuid };
            accountTarget.Attributes.Add("tickersymbol", "ADBE");

            ParameterCollection inputParameters = new ParameterCollection();
            inputParameters.Add("Target", accountTarget);

            var context = new XrmRealContext(serviceProxy);

            IOrganizationService IOrganizationService = context.GetOrganizationService();

            var executionContext = context.GetDefaultPluginContext();
            executionContext.MessageName = "Update";
            executionContext.InputParameters = inputParameters;
            executionContext.InitiatingUserId = userGuid;




            //var target = accountTarget;
            //executionContext.MessageName = "Update";
            //executionContext.Stage = 20;
            //executionContext.PrimaryEntityId = target.Id;
            //executionContext.PrimaryEntityName = target.LogicalName;
            //executionContext.InputParameters = new ParameterCollection
            //{
             //   new KeyValuePair<string, object>("Target", target)
            //};

            Assert.DoesNotThrow(() => context.ExecutePluginWith<AccountPlugin>(executionContext));
            Assert.True(inputParameters.Contains("Target"));
            Entity targetValue = (Entity)inputParameters["Target"];
            Assert.True(targetValue.Attributes.Contains("emailaddress1"));
            Assert.AreEqual((String)targetValue["emailaddress1"], "eshanna@adobe.com");

        }


        [Test]
        public void test4()
        {

            var fakedContext = new XrmFakedContext();

            var accountGuid = Guid.NewGuid();
            var accountTarget = new Entity("account") { Id = accountGuid };
            accountTarget.Attributes.Add("tickersymbol", "ADBE");
            accountTarget.Attributes.Add("AgreementType", "DMA");
            accountTarget.Attributes.Add("AccountCountry", "US");
            accountTarget.Attributes.Add("MarketSegment", "Commercial");
            accountTarget.Attributes.Add("isCorporateEntityOverride", true);

            var fakedPlugin = fakedContext.ExecutePluginWithTarget<AccountPlugin>(accountTarget);

            //Assert that the target contains a new attribute
            Assert.True(accountTarget.Attributes.Contains("EMailAddress1"));
            Assert.AreEqual((String)accountTarget["AdobeCorporateEntity"], "ADUS");

        }


        [Test, TestCaseSource(typeof(MyDataClass), "TestCases3")]
        public void test6(Entity entity)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var fakedContext = new XrmRealContext("CRMOnline2");
            var accountTarget = entity;
            var fakedPlugin = fakedContext.ExecutePluginWithTarget<AccountPlugin>(accountTarget);

            //Assert that the target contains a new attribute
            Assert.True(accountTarget.Attributes.Contains("AgreementType"));
            Assert.AreEqual((String)accountTarget["AgreementType"], "DMA");
            Assert.True(accountTarget.Attributes.Contains("AdobeCorporateEntity"));
            Assert.AreEqual((String)accountTarget["AdobeCorporateEntity"], "ADUS");
            Assert.AreEqual((String)accountTarget["ContractClass"], "RG");

        }



        [Test, TestCaseSource(typeof(MyDataClass), "TestCases3")]
        public void test5(Entity entity)
        {
            var fakedContext = new XrmFakedContext();
            var accountTarget = entity;
            var fakedPlugin = fakedContext.ExecutePluginWithTarget<AccountPlugin>(accountTarget);

            //Assert that the target contains a new attribute
            Assert.True(accountTarget.Attributes.Contains("AgreementType"));
            Assert.AreEqual((String)accountTarget["AgreementType"], "DMA");
            Assert.True(accountTarget.Attributes.Contains("AdobeCorporateEntity"));
            Assert.AreEqual((String)accountTarget["AdobeCorporateEntity"], "ADUS");
            Assert.AreEqual((String)accountTarget["ContractClass"], "RG");
        }

        */
    }

}
