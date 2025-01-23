using CodedKaratBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IEnumerable<Student>> Get()
    {
        return await _studentService.GetAllStudentsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student?>> GetById(string id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        return student is not null ? Ok(student) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Student student)
    {
        await _studentService.CreateStudentAsync(student);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    [HttpPut]
    public async Task<ActionResult> Update(Student student)
    {
        await _studentService.UpdateStudentAsync(student);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        await _studentService.DeleteStudentAsync(id);
        return Ok();
    }
}