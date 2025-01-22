using CodedKaratBackEnd.Data;
using CodedKaratBackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Diagnostics.Contracts;

namespace CodedKaratBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMongoCollection<Student>? _students;

        public StudentController(MongoDbService mongoDbService)
        {
            _students = mongoDbService.Database?.GetCollection<Student>("student");
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> Get()
        { 
            return await _students.Find(FilterDefinition<Student>.Empty).ToListAsync();   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student?>> GetById(string id)
        {
            var filter = Builders<Student>.Filter.Eq(x => x.Id, id);
            var student = _students.Find(filter).FirstOrDefault();
            return student is not null ? Ok(student) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Student student)
        {
            await _students.InsertOneAsync(student);
            return CreatedAtAction(nameof(GetById), new {id = student.Id},student);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Student student)
        {
            var filter = Builders<Student>.Filter.Eq(x => x.Id,student.Id);

            await _students.ReplaceOneAsync(filter, student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        { 
            var filter = Builders<Student>.Filter.Eq(x => x.Id,id);
            await _students.DeleteOneAsync(filter);
            return Ok();
        }

    }
}
