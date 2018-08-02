using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace TestFrameworkLib
{
    [BsonNoId]
    public class MongoEntityObject
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public String _id { get; set; }
        [BsonElement("Name")]
        public String Name { get; set; }
        [BsonElement("Entity")]
        public Dictionary<String, Object> Entity { get; set; }
        public object Id { get; internal set; }
    }
}