using System;
using AdobeCorporateService.beans;
using LegalService;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace LegalServicePlugin
{
        public class AccountPlugin : IPlugin
        {
            public void Execute(IServiceProvider serviceProvider)
            {
                IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = factory.CreateOrganizationService(context.UserId);
                ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is AccountEntity)
                {
                    AccountEntity accountEntity = (AccountEntity)context.InputParameters["Target"];
                   
                    try
                    {
                        AgreementInitiationServiceEntity agreementInitiationService = new AgreementInitiationServiceEntity();
                        agreementInitiationService.GetAdobeCorporateEntity(accountEntity);
                        agreementInitiationService.GetAgreementContractClass(accountEntity);

                    }
                    catch (Exception ex)
                    {
                        tracingService.Trace("My Plugin Exception : " + ex.Message);
                        throw ex;
                    }
                }

            }

        }
}
