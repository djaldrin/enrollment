using CodedKaratBackEnd.Data;
using CodedKaratBackEnd.Services;
using MongoDB.Driver;

public class StudentService : IStudentService
{
    private readonly IMongoCollection<Student> _students;

    public StudentService(MongoDbService mongoDbService)
    {
        _students = mongoDbService.Database.GetCollection<Student>("student");
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _students.Find(FilterDefinition<Student>.Empty).ToListAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(string id)
    {
        var filter = Builders<Student>.Filter.Eq(x => x.Id, id);
        return await _students.Find(filter).FirstOrDefaultAsync();
    }

    public async Task CreateStudentAsync(Student student)
    {
        await _students.InsertOneAsync(student);
    }

    public async Task UpdateStudentAsync(Student student)
    {
        var filter = Builders<Student>.Filter.Eq(x => x.Id, student.Id);
        await _students.ReplaceOneAsync(filter, student);
    }

    public async Task DeleteStudentAsync(string id)
    {
        var filter = Builders<Student>.Filter.Eq(x => x.Id, id);
        await _students.DeleteOneAsync(filter);
    }
}