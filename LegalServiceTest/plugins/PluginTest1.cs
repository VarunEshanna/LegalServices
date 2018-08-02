using AdobeCorporateService.beans;
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
        public void TestAccountPluginUpdateForUSAccounts(AccountEntity entity)
        {
            var context = new XrmFakedContext();
            var accountTarget = entity;

            ParameterCollection inputParameters = new ParameterCollection();
            inputParameters.Add("Target", accountTarget);

            var plugCtx = context.GetDefaultPluginContext();
            plugCtx.MessageName = "Update";
            plugCtx.InputParameters = inputParameters;

            Assert.DoesNotThrow(() => context.ExecutePluginWith<AccountPlugin>(plugCtx));
            Assert.AreEqual(entity.AdobeCorporateEntity, "ADUS");
            Assert.AreEqual(entity.ContractClass, "RG");
        }

        [Test, TestCaseSource(typeof(MyDataClass), "ManualAssertion", new object[] { "Non US Accounts" })]
        public void TestAccountPluginUpdateForNonUSAccounts(AccountEntity entity)
        {

            var context = new XrmFakedContext();
            var accountTarget = entity;

            ParameterCollection inputParameters = new ParameterCollection();
            inputParameters.Add("Target", accountTarget);

            var plugCtx = context.GetDefaultPluginContext();
            plugCtx.MessageName = "Update";
            plugCtx.InputParameters = inputParameters;

            Assert.DoesNotThrow(() => context.ExecutePluginWith<AccountPlugin>(plugCtx));
            Assert.AreEqual(entity.AdobeCorporateEntity, "ADIR");
            Assert.AreEqual(entity.ContractClass, "NRG");
        }

    }

}
