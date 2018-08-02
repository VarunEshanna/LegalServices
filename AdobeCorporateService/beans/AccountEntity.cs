using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdobeCorporateService.beans
{
    //[BsonNoId]
    public class AccountEntity
    {
        public String Id { get; set; }
        public String AgreementType { get; set; }
        public String AccountCountry { get; set; }
        public String MarketSegment { get; set; }
        public String isCorporateEntityOverride { get; set; }
        public String AdobeCorporateEntity { get; set; }

    }
}
