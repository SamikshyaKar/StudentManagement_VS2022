using Microsoft.AspNetCore.Mvc;
using StudentManagement_VS2022.Models;
using StudentManagement_VS2022.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagement_VS2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IstudentService studentService;

        public StudentsController(IstudentService studentService)
        {
            this.studentService = studentService;
        }



        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<Students>> Get()
        {
            return studentService.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Students> Get(string id)
        {
            var student= studentService.GetById(id);
            if(student==null)
            {
                return NotFound($"Student with ID= {id} not found");
            }
            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Students> Post([FromBody] Students studentobj)
        {
            studentService.Create(studentobj);

            return CreatedAtAction(nameof(Get), new { id = studentobj.Id }, studentobj);

        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Students> Put(string id, [FromBody] Students studentobj)
        {
            var existingstudent= studentService.GetById(id);

            if(existingstudent==null)
            {
                return NotFound($"Student with ID= {id} Not Found");
            }
            studentService.Update(id, studentobj);
            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Students> Delete(string id)
        {
            var existingstudent= studentService.GetById(id);
            if( existingstudent==null)
            {
                return NotFound($"Student Not Found with ID= {id} Not Found ");

            }
            studentService.Remove(existingstudent.Id);

            return Ok($"Student with ID = {id} Deleted");



        }
    }
}
