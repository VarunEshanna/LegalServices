using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TestFramework
{
    public class TestMethodDataEntity
    {
        public ObjectId _id { get; set; }
        public String TestMethodName { get; set; }
        public String TestClassName { get; set; }
        public String TestDataReference { get; set; }
        public String DefaultTestDataNode{ get; set; }
        public Boolean Result { get; set; }
        public String Message { get; set; }  
    }

    public class TestClassDataEntity
    {
        public String Sprint { get; set; }
        public String ClassName { get; set; }
        public int LinesCovered { get; set; }
        public int LinesNotCovered { get; set; }
        public DateTime LastSuccessfulRun { get; set; }
        public String Module { get; set; }
        public String Project { get; set; }
    }
}
