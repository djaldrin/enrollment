using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Net;

public class Student
{
    [BsonId]
    [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("accountId"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? AccountId { get; set; }

    [BsonElement("firstName")]
    public string? FirstName { get; set; }

    [BsonElement("lastName")]
    public string LastName { get; set; }

    [BsonElement("phoneNumber")]
    public string PhoneNumber { get; set; }

    [BsonElement("gradeLevel")]
    public int GradeLevel { get; set; }

    [BsonElement("section")]
    public string Section { get; set; }

    [BsonElement("parentContact")]
    public ParentContact ParentContact { get; set; }

    [BsonElement("address")]
    public Address Address { get; set; }


}

public class Address
{
    [BsonElement("street")]
    public string Street { get; set; }
    [BsonElement("city")]
    public string City { get; set; }
    [BsonElement("province")]
    public string Province { get; set; }
    [BsonElement("postalCode")]
    public string PostalCode { get; set; }
}

public class ParentContact
{
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("phoneNumber")]
    public string PhoneNumber { get; set; }
}