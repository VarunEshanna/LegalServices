using AdobeCorporateService.beans;
using Microsoft.Dynamics365.UIAutomation.Api;
using NUnit.Framework;
using System.Collections.Generic;
using TestFramework;
using TestFrameworkLib;

namespace LegalServiceTest.uitesting
{
    public class UITesting2
    {
        [Test, TestCaseSource(typeof(MyDataClass), "ManualAssertion", new object[] { "US Accounts" })]
        public void TestContactCreateWithAccountLookUp1(AccountEntity entity)
        {
            using (var xrmBrowser = new Browser(TestSettings.Options))
            {
                TestUtility.getSystemAdminUser(xrmBrowser);
                xrmBrowser.ThinkTime(1500);
                xrmBrowser.Navigation.OpenSubArea("Sales", "Contacts");

                xrmBrowser.ThinkTime(2000);
                xrmBrowser.Grid.SwitchView("Active Contacts");

                xrmBrowser.ThinkTime(1000);
                xrmBrowser.CommandBar.ClickCommand("New");
                xrmBrowser.ThinkTime(5000);

                var fields = new List<Field>
                {
                    new Field() {Id = "firstname", Value = "Varun"},
                    new Field() {Id = "lastname", Value = "Eshanna"}
                };
                xrmBrowser.Entity.SetValue(new CompositeControl() { Id = "fullname", Fields = fields });
                xrmBrowser.Entity.SelectLookup("parentcustomerid", 0);
                xrmBrowser.Entity.Save();
                xrmBrowser.ThinkTime(3000);
            }
        }
    }
}
