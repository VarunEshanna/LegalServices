using LegalService;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestFramework;
using TestFrameworkLib.beans;

namespace LegalServiceTest
{
    [TestFixture]
    class AdobeCorporateServiceTest3
    {
        [Test, TestCaseSource(typeof(MyDataClass), "AutoAutoAssertion1", new object[] { "Adobe Corporate Entity Records,Adobe Contract Class Records" }), CustomAttr]
        public Object ServiceTest(ClassDetails classDetails, Object request)
        {
            Assembly mainAssembly = typeof(AgreementInitiationService).Assembly;
            Module module = mainAssembly.GetModule("AdobeCorporateService.dll");
            Type classType = module.GetType(classDetails.ClassName);
            Object instance = Activator.CreateInstance(classType);
            MethodInfo methodInfo = classType.GetMethod(classDetails.MethodName);
            ParameterInfo[] parameters = methodInfo.GetParameters();
            object[] parametersArray = new object[] { request };
            Type responseType = module.GetType(classDetails.ResponseType);
            return Convert.ChangeType(methodInfo.Invoke(instance, parametersArray), responseType);
        }
    }
}
