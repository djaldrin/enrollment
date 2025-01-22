using MongoDB.Bson.Serialization.Attributes;

namespace CodedKaratBackEnd.Entities
{
    public class Student
    {
        [BsonId]
        [BsonElement("_id"),BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("first_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? FirstName { get; set; }
        [BsonElement("last_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? LastName { get; set; }
        [BsonElement("email"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Email { get; set; }
      
    }
}
