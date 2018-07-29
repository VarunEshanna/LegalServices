using System;

namespace CommonCalloutTypes
{
    public class CalloutResponse
    {
        public String responseBodyJSON { get; set; }
        public Boolean isSuccess { get; set; }
        public String errorMessage { get; set; }
    }
}