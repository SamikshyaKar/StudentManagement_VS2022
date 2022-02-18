using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;






namespace StudentManagement_VS2022.Models
{

    [BsonIgnoreExtraElements]
    public class Students
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }= String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("graduated")]
        public bool  Isgraduated { get; set; }

        [BsonElement("gender")]
        public string gender { get; set; } = String.Empty;
        [BsonElement("courses")]
        public string[]? courses { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }



    }
}
