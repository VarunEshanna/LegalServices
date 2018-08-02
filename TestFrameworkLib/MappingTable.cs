using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TestFrameworkLib
{
    [BsonNoId]
    public class MappingTable
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public String _id { get; set; }
        [BsonElement("entity")]
        public String entity { get; set; }
        [BsonElement("collection")]
        public String collection { get; set; }
    }
}