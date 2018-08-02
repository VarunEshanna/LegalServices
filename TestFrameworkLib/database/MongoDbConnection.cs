using LegalService;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Configuration;

namespace TestFrameworkLib
{
    public class MongoDbConnection
    {
        private MongoDatabase database;

        public MongoDbConnection()
        {
            database = getMongoDBConnection();
        }

        private MongoDatabase getMongoDBConnection()
        {
            String connectionString = ConfigurationManager.AppSettings["connectionString"];
            String databaseName = ConfigurationManager.AppSettings["database"];

            // TODO: Get the connection string and database name from app config and remove the hardcoded values
            connectionString = "mongodb://localhost";
            databaseName = "testdb";

            // TODO: Create MongoDatabase object using new API
            return new MongoClient(connectionString).GetServer().GetDatabase(databaseName);

        }

        public Dictionary<String, Object> getRequestData(String dataSetName)
        {
            var query = Query<DataSet>.EQ(ds => ds.Name, dataSetName);
            var dataSetObject = database.GetCollection<DataSet>("Dataset").FindOne(query);
            BsonDocument bsonDocument = dataSetObject.ToBsonDocument();
            DataSet dataSet = BsonSerializer.Deserialize<DataSet>(bsonDocument);

            List<Dictionary<String, String>> entityDataList = new List<Dictionary<String, String>>();
            entityDataList = dataSet.entityData;

            int argumentSize = entityDataList.Count;
            Dictionary<String, Object> names = new Dictionary<String, Object>();

            Assembly mainAssembly = typeof(GetAdobeCorporateEntityRequest).Assembly;
            Module module = mainAssembly.GetModule("AdobeCorporateService.dll");

            int outerCounter = 0;
            foreach (Dictionary<String, String> entityData in entityDataList)
            {
                outerCounter++;
                int counter = 0;
                foreach(KeyValuePair<String, String> entry in entityData)
                {
                    String entityName = entry.Key;
                    String entityObjectIdReference = entry.Value;

                    var collectionName = database.GetCollection(entityName);
                    var entity = collectionName.FindOneById(new ObjectId(entry.Value));
                    BsonDocument bsonDoc = entity.ToBsonDocument();
                    MongoEntityObject mongoEntityObject = BsonSerializer.Deserialize<MongoEntityObject>(bsonDoc);

                    var query1 = Query<MappingTable>.EQ(ds => ds.collection, entityName);
                    var mappingTableEntries = database.GetCollection<MappingTable>("mappingtable").FindOne(query1);
                    BsonDocument bsonDocument1 = mappingTableEntries.ToBsonDocument();
                    MappingTable mappingTable = BsonSerializer.Deserialize<MappingTable>(bsonDocument1);

                    Type RequestType = module.GetType(mappingTable.entity);
                    Object Request = Activator.CreateInstance(RequestType);

                    Dictionary<String, Object> myDictionary = new Dictionary<String, Object>();
                    myDictionary = mongoEntityObject.Entity;
                    foreach (KeyValuePair<string, object> entityDataFields in myDictionary)
                    {
                        PropertyInfo RequestProperty = RequestType.GetProperty(entityDataFields.Key);
                        RequestProperty.SetValue(Request, entityDataFields.Value);

                    }
                    counter++;
                    names.Add(String.Format("Request{0}{1}", outerCounter.ToString(), counter.ToString()), Request);
                }
                counter = 0;
            }
            return names;
        }

        public void insertData()
        {
            DataSet dataSet = new DataSet();
            dataSet.Name = "New Name";
            Dictionary<String, String> myDictionary1 = new Dictionary<String, String>();
            myDictionary1.Add("Account", "asdasdacecace");
            myDictionary1.Add("Contact", "asdasdawdawdadaacecace");
            myDictionary1.Add("Oppty", "asdaawawdawd");

            Dictionary<String, String> myDictionary2 = new Dictionary<String, String>();
            myDictionary2.Add("Account", "asdasdacecace");
            myDictionary2.Add("Contact", "asdasdawdawdadaacecace");
            myDictionary2.Add("Oppty", "asdaawawdawd");

            List<Dictionary<String, String>> newList = new List<Dictionary<String, String>>();
            newList.Add(myDictionary1);
            newList.Add(myDictionary2);
            dataSet.entityData = newList;
            var collection = database.GetCollection<DataSet>("Dataset");

            collection.Insert(dataSet);
            var id = dataSet._id;
        }
    }
}
