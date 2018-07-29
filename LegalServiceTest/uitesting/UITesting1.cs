using Microsoft.Dynamics365.UIAutomation.Api;
using NUnit.Framework;
using System;
using System.Net;
using System.Security;
using TestFramework;


namespace LegalServiceTest.uitesting
{
    public class UITesting1
    {

        private readonly SecureString _username = new NetworkCredential("crm8@trng1.onmicrosoft.com", "testcrm8@trng1.onmicrosoft.com").SecurePassword;
        private readonly SecureString _password = new NetworkCredential("Training$CRM@123", "Training$CRM@123").SecurePassword;
        private readonly Uri _xrmUri = new Uri("https://trng1.crm8.dynamics.com");

        [Test, TestCaseSource(typeof(MyDataClass), "ManualAssertion", new object[] { "US Accounts" })]
        public void TestAccountPluginUpdateForUSAccounts(Microsoft.Xrm.Sdk.Entity entity)
        {
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.ThinkTime(1500);
                xrmBrowser.Navigation.OpenSubArea("Sales", "Accounts");

                xrmBrowser.ThinkTime(2000);
                xrmBrowser.Grid.SwitchView("Active Accounts");

                xrmBrowser.ThinkTime(1000);
                xrmBrowser.CommandBar.ClickCommand("New");

                xrmBrowser.ThinkTime(5000);
                xrmBrowser.Entity.SetValue("name", "Test Account");
                xrmBrowser.Entity.SetValue("new_agreementtype", entity.GetAttributeValue<String>("AgreementType"));
                xrmBrowser.Entity.SetValue("new_accountcountry", entity.GetAttributeValue<String>("AccountCountry"));
                xrmBrowser.Entity.SetValue("new_marketsegment", entity.GetAttributeValue<String>("MarketSegment"));
                xrmBrowser.Entity.SetValue("new_iscorporateentityoverride", entity.GetAttributeValue<Boolean>("isCorporateEntityOverride"));

                xrmBrowser.CommandBar.ClickCommand("Save");
                xrmBrowser.ThinkTime(2000);
               
                xrmBrowser.ThinkTime(2000);
            }
        }
    }
}
