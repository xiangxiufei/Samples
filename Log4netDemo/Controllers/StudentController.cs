using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        public static readonly List<Student> students = new List<Student>()
        {
            new Student(){Id=1, Name="张三",Sex="男",Age=25 },
            new Student(){Id=2, Name="李四",Sex="男",Age=24 },
            new Student(){Id=3, Name="王五",Sex="男",Age=23 }
        };

        [HttpGet("{id}")]
        public Response<List<Student>> GetStudent([FromRoute] int id)
        {
            var response = new Response<List<Student>>();

            response.data = students.Where(t => t.Id == id).ToList();

            return response;
        }

        [HttpGet]
        public Response<List<Student>> GetStudentList()
        {
            var response = new Response<List<Student>>();

            response.data = students;

            return response;
        }

        [HttpPost]
        public Response<string> InsertStudent([FromBody] Student student)
        {
            students.Add(student);

            return new Response<string>();
        }

        [HttpPut("{id}")]
        public Response<string> UpdateStudent([FromRoute]int id, [FromBody] Student student)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    students[i].Name = student.Name;
                    students[i].Sex = student.Sex;
                    students[i].Age = student.Age;
                }
            }

            return new Response<string>();
        }

        [HttpDelete("{id}")]
        public Response<string> DeleteStudent([FromRoute]int id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    students.RemoveAt(i);
                }
            }

            return new Response<string>();
        }
    }
}