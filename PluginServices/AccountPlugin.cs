using System;
using LegalService;
using Microsoft.Xrm.Sdk;

namespace SamplePlugin
{
    public class AccountPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                Entity entity = (Entity)context.InputParameters["Target"];
                if (entity.LogicalName != "account")
                {
                    return;
                }

                // update Agreement object

                try
                {

                    if (entity.GetAttributeValue<String>("tickersymbol") == null)
                    {
                        if (entity.GetAttributeValue<String>("tickersymbol") == "ADBE")
                        {
                            entity.Attributes.Add("email", "eshanna@adobe.com");
                        }
                        else if (entity.GetAttributeValue<String>("tickersymbol") == "MFST")
                        {
                            entity.Attributes.Add("email", "vikas@microsoft.com");
                        }
                    }

                    //AgreementInitiationServiceEntity agreementInitiationService = new AgreementInitiationServiceEntity();
                    //agreementInitiationService.GetAdobeCorporateEntity(entity);
                    //agreementInitiationService.GetAgreementContractClass(entity);
                }
                catch (Exception ex)
                {
                    tracingService.Trace("My Plugin Exception : " + ex.Message);
                    throw ex;
                }
            }

        }

        private GetAdobeCorporateEntityRequest EntityToGetAdobeCorporateEntityRequestMapper(Entity entity)
        {
            GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest = new GetAdobeCorporateEntityRequest();
            GetAdobeCorporateEntityRequest.AccountCountry = entity.GetAttributeValue<String>("accountCountry");
            GetAdobeCorporateEntityRequest.AgreementType = entity.GetAttributeValue<String>("agreementType");
            GetAdobeCorporateEntityRequest.MarketSegment = entity.GetAttributeValue<String>("marketSegment");
            GetAdobeCorporateEntityRequest.isCorporateEntityOverride = entity.GetAttributeValue<Boolean>("isCorporateEntityOverride");
            return GetAdobeCorporateEntityRequest;
        }


        private Entity GetAdobeCorporateEntityRequestMapperToEntityMapper(Entity entity, GetAdobeCorporateEntityResponse GetAdobeCorporateEntityResponse)
        {
            entity.Attributes.Add("adobeCorporateEntity", GetAdobeCorporateEntityResponse.AdobeCorporateEntity);
            return entity;
        }


    }
}
