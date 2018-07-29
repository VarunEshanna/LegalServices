using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegalService;
using Microsoft.Xrm.Sdk;

namespace TestFramework
{
    public class Mapper
    {

        public static GetAdobeCorporateEntityRequest EntityToGetAdobeCorporateEntityRequestMapper(Entity entity)
        {
            GetAdobeCorporateEntityRequest GetAdobeCorporateEntityRequest = new GetAdobeCorporateEntityRequest();
            GetAdobeCorporateEntityRequest.AccountCountry = entity.GetAttributeValue<String>("accountCountry");
            GetAdobeCorporateEntityRequest.AgreementType = entity.GetAttributeValue<String>("agreementType");
            GetAdobeCorporateEntityRequest.MarketSegment = entity.GetAttributeValue<String>("marketSegment");
            GetAdobeCorporateEntityRequest.isCorporateEntityOverride = entity.GetAttributeValue<Boolean>("isCorporateEntityOverride");
            return GetAdobeCorporateEntityRequest;
        }


        public static Entity GetAdobeCorporateEntityRequestMapperToEntityMapper(GetAdobeCorporateEntityResponse GetAdobeCorporateEntityResponse)
        {
            Entity entity = new Entity();
            entity.Attributes.Add("adobeCorporateEntity", GetAdobeCorporateEntityResponse.AdobeCorporateEntity);
            return entity;
        }
    }
}
