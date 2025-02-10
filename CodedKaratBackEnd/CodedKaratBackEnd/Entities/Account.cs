using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Account
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("email")]
    public string Email { get; set; }

    [BsonElement("passwordHash")]
    public string PasswordHash { get; set; }

    [BsonElement("role")]
    public string Role { get; set; } // "teacher" or "student"

    [BsonElement("isActive")]
    public bool IsActive { get; set; }

    [BsonElement("isVerified")]
    public bool IsVerified { get; set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [BsonElement("lastLogin")]
    public DateTime LastLogin { get; set; }
}