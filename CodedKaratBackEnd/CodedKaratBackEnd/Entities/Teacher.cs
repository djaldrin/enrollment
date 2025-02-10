using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Net;

public class Teacher
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("accountId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string AccountId { get; set; }

    [BsonElement("firstName")]
    public string FirstName { get; set; }

    [BsonElement("lastName")]
    public string LastName { get; set; }

    [BsonElement("phoneNumber")]
    public string PhoneNumber { get; set; }

    [BsonElement("subjects")]
    public List<string> Subjects { get; set; }

    [BsonElement("department")]
    public string Department { get; set; }

    [BsonElement("address")]
    public Address Address { get; set; }
}