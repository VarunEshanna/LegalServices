using System;
using FakeXrmEasy;
using LegalServicePlugin;
using Microsoft.Xrm.Sdk;
using NUnit.Framework;
using TestFramework;

namespace LegalServiceTest
{
    public class PluginTest1
    {

        [Test, TestCaseSource(typeof(MyDataClass), "ManualAssertion", new object[] { "US Accounts" })]
        public void TestAccountPluginUpdateForUSAccounts(Entity entity)
        {

            var context = new XrmFakedContext();
            var accountTarget = entity;

            ParameterCollection inputParameters = new ParameterCollection();
            inputParameters.Add("Target", accountTarget);

            var plugCtx = context.GetDefaultPluginContext();
            plugCtx.MessageName = "Update";
            plugCtx.InputParameters = inputParameters;

            Assert.DoesNotThrow(() => context.ExecutePluginWith<AccountPlugin>(plugCtx));
            Assert.AreEqual((String)accountTarget["AdobeCorporateEntity"], "ADUS");
            Assert.AreEqual((String)accountTarget["ContractClass"], "RG");
        }

        [Test, TestCaseSource(typeof(MyDataClass), "ManualAssertion", new object[] { "Non US Accounts" })]
        public void TestAccountPluginUpdateForNonUSAccounts(Entity entity)
        {

            var context = new XrmFakedContext();
            var accountTarget = entity;

            ParameterCollection inputParameters = new ParameterCollection();
            inputParameters.Add("Target", accountTarget);

            var plugCtx = context.GetDefaultPluginContext();
            plugCtx.MessageName = "Update";
            plugCtx.InputParameters = inputParameters;

            Assert.DoesNotThrow(() => context.ExecutePluginWith<AccountPlugin>(plugCtx));
            Assert.AreEqual((String)accountTarget["AdobeCorporateEntity"], "ADIR");
            Assert.AreEqual((String)accountTarget["ContractClass"], "NRG");
        }

    }

}
