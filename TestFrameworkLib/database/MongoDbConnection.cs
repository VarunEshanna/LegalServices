﻿using LegalService;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Configuration;
using TestFramework;
using System.Collections;

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
                foreach (KeyValuePair<String, String> entry in entityData)
                {
                    String entityName = entry.Key;
                    String entityObjectIdReference = entry.Value;

                    var collectionName = database.GetCollection(entityName);
                    var entity = collectionName.FindOneById(new ObjectId(entry.Value));
                    BsonDocument bsonDoc = entity.ToBsonDocument();
                    MongoEntityObject mongoEntityObject = BsonSerializer.Deserialize<MongoEntityObject>(bsonDoc);
                    
                    Type RequestType = module.GetType(mongoEntityObject.Name);
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

        public void upsertTestResultsData(TestMethodDataEntity testMethodDataEntity)
        {
            var collection = database.GetCollection<TestMethodDataEntity>("TestMethodDataEntity");
            var query = Query.And(
                    Query<TestMethodDataEntity>.EQ(p => p.TestMethodName, testMethodDataEntity.TestMethodName),
                    Query<TestMethodDataEntity>.EQ(p => p.TestClassName, testMethodDataEntity.TestClassName),
                    Query<TestMethodDataEntity>.EQ(p => p.TestDataReference, testMethodDataEntity.TestDataReference)
                );
            var testMethodData = collection.Find(query);
            if (testMethodData.Count() == 0)
            {
                collection.Insert(testMethodDataEntity);
                var id = testMethodDataEntity._id;
            }
            else if (testMethodData.Count() == 1)
            {
                /*
                BsonDocument bsonDocument1 = testMethodData.ToBsonDocument();
                TestMethodDataEntity testMethodDataEntity1 = BsonSerializer.Deserialize<TestMethodDataEntity>(bsonDocument1);
                testMethodDataEntity._id = testMethodDataEntity1._id;
                var replacement = Update<TestMethodDataEntity>.Replace(testMethodDataEntity);
                collection.Update(query, replacement);
                */
            }
            else
            {
                // throw error
            }


        }

        public BsonArray ToBsonDocumentArray(IEnumerable list)
        {
            var array = new BsonArray();
            foreach (var item in list)
            {
                array.Add(item.ToBson());
            }
            return array;
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