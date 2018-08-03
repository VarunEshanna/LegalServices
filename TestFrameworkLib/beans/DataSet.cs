using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace TestFrameworkLib
{
    [BsonNoId]
    public class DataSet
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public String _id { get; set; }
        [BsonElement("Name")]
        public String Name { get; set; }
        [BsonElement("EntityRequestData")]
        public List<Dictionary<String, String>> entityRequestData;
        [BsonElement("EntityResponseData")]
        public List<Dictionary<String, String>> entityResponeData;
    }
}