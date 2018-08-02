using Microsoft.Dynamics365.UIAutomation.Api;
using System;
using System.Net;
using System.Security;

namespace TestFrameworkLib
{
    public class TestUtility
    {
        private static readonly SecureString _username = new NetworkCredential("dharani1743@vagus.onmicrosoft.com", "dharani1743@vagus.onmicrosoft.com").SecurePassword;
        private static readonly SecureString _password = new NetworkCredential("Vidhurmeera17!", "Vidhurmeera17!").SecurePassword;
        private static readonly Uri _xrmUri = new Uri("https://vagus.crm8.dynamics.com/");

        public static void getSystemAdminUser(Browser xrmBrowser)
        {
            xrmBrowser.LoginPage.Login(_xrmUri, _username, _password);
        }


    }
}
