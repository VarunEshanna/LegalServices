using LegalService;
using Microsoft.Xrm.Sdk;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkLib.templates.dynamics.plugin
{
    public class PluginTemplates
    {
        public void sameEntityModifcation(Object entity, ParameterCollection inputParameters, String messageName, String className)
        {
            /*var context = new XrmFakedContext();
            var accountTarget = entity;

            inputParameters.Add("Target", accountTarget);

            var plugCtx = context.GetDefaultPluginContext();
            plugCtx.MessageName = "Update";
            plugCtx.InputParameters = inputParameters;

            Assert.DoesNotThrow(() => context.ExecutePluginWith<Type.GetType(className)> (plugCtx));*/
        }
    }
}
