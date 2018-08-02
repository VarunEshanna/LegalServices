using AdobeCorporateService.beans;
using Microsoft.Dynamics365.UIAutomation.Api;
using NUnit.Framework;
using System;
using TestFramework;
using TestFrameworkLib;

namespace LegalServiceTest.uitesting
{
    public class UITesting1
    {
        [Test, TestCaseSource(typeof(MyDataClass), "ManualAssertion", new object[] { "US Accounts" })]
        public void TestAccountPluginUpdateForUSAccounts(AccountEntity entity)
        {
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                TestUtility.getSystemAdminUser(xrmBrowser);
                xrmBrowser.GuidedHelp.CloseGuidedHelp();

                xrmBrowser.ThinkTime(1500);
                xrmBrowser.Navigation.OpenSubArea("Sales", "Accounts");

                xrmBrowser.ThinkTime(2000);
                xrmBrowser.Grid.SwitchView("Active Accounts");

                xrmBrowser.ThinkTime(1000);
                xrmBrowser.CommandBar.ClickCommand("New");

                xrmBrowser.ThinkTime(5000);
                xrmBrowser.Entity.SetValue("name", "Test Account");
                /*xrmBrowser.Entity.SetValue("new_agreementtype", entity.GetAttributeValue<String>("AgreementType"));
                xrmBrowser.Entity.SetValue("new_accountcountry", entity.GetAttributeValue<String>("AccountCountry"));
                xrmBrowser.Entity.SetValue("new_marketsegment", entity.GetAttributeValue<String>("MarketSegment"));
                xrmBrowser.Entity.SetValue("new_iscorporateentityoverride", entity.GetAttributeValue<Boolean>("isCorporateEntityOverride"));*/

                xrmBrowser.CommandBar.ClickCommand("Save");
                xrmBrowser.ThinkTime(2000);
               
                xrmBrowser.ThinkTime(2000);
            }
        }
    }
}
