using Microsoft.Dynamics365.UIAutomation.Api;
using System;

namespace TestFrameworkLib.templates.dynamics.ui
{
    public class UITemplates
    {
        public static void getEntityView(Browser xrmBrowser, String EntityName, String viewName)
        {
            xrmBrowser.ThinkTime(1500);
            xrmBrowser.Navigation.OpenSubArea("Sales", EntityName);

            xrmBrowser.ThinkTime(2000);
            xrmBrowser.Grid.SwitchView(viewName);

            xrmBrowser.ThinkTime(5000);
        }

    }
}
