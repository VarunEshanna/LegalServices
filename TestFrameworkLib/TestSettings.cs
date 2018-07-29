using Microsoft.Dynamics365.UIAutomation.Browser;
using System;

namespace TestFramework
{
    public class TestSettings
    {
        public static string InvalidAccountLogicalName = "accounts";

        public static string LookupField = "primarycontactid";
        public static string LookupName = "Rene Valdes (sample)";

        //IE,Chrome,Firefox,Edge
        private static readonly string Type = "Chrome";

        public static BrowserOptions Options = new BrowserOptions
        {
            BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), Type),
            PrivateMode = true,
            FireEvents = true,
            Headless = false,
            UserAgent = false
        };
    }
}
