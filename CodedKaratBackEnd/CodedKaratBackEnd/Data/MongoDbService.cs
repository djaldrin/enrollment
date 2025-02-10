using MongoDB.Driver;

namespace CodedKaratBackEnd.Data
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(IConfiguration configuration)
        {
            // Read connection string and create MongoDB client
            var connectionString = configuration.GetConnectionString("DbConnection");
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);

            // Initialize the database using the database name in the connection string
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        // Expose collections as properties for centralized access
        public IMongoCollection<Student> Students => _database.GetCollection<Student>("student");
        public IMongoCollection<Teacher> Teachers => _database.GetCollection<Teacher>("teacher");
        public IMongoCollection<Account> Accounts => _database.GetCollection<Account>("account");

        public IMongoDatabase Database => _database;
    }
}
