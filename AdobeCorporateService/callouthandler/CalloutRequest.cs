using System;
using System.Collections.Generic;

namespace AdobeCorporateService.callouthandler
{
    public class CalloutRequest
    {
        public String endPointUrl { get; set; }
        public String additionalURI { get; set; }
        public Dictionary<String, String> mapAdditionalUrlParameters { get; set; } 
        public String calloutRequestBodyJSON { get; set; }
        public String httpMethod { get; set; }
    }
}