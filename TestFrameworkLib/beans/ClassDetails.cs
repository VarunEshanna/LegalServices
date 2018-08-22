using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace TestFrameworkLib.beans
{
    [BsonNoId]
    public class ClassDetails
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public String _id { get; set; }
        [BsonElement("DataSet")]
        public String DataSet{ get; set; }
        [BsonElement("ClassName")]
        public String ClassName { get; set; }
        [BsonElement("MethodName")]
        public String MethodName { get; set; }
        [BsonElement("RequestTypes")]
        public List<String> entityResponeData { get; set; }
        [BsonElement("ResponseType")]
        public String ResponseType { get; set; }
    }
}
