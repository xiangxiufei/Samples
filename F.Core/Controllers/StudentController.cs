using F.Core.Common;
using F.Core.IService;
using F.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace F.Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        public async Task<string> Insert([FromForm] Student student)
        {
            try
            {
                await studentService.Insert(student);

                return new Response().ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }

        [HttpPost]
        public async Task<string> Update([FromForm] Student student)
        {
            try
            {
                //await studentService.Update(student);
                await studentService.Update(t => t.Sid == student.Sid, t => new Student() { Sage = student.Sage });

                return new Response().ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }

        [HttpPost]
        public async Task<string> Delete(int id)
        {
            try
            {
                await studentService.Delete(t => t.Sid == id);

                return new Response().ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }

        [HttpGet]
        public async Task<string> Select()
        {
            try
            {
                var students = await studentService.Select(t => true);
                return new Response<Student>() { Data = students }.ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }

        [HttpPost]
        public async Task<string> UOW([FromForm] Student student)
        {
            try
            {
                Teacher teacher = new Teacher() { Tid = student.Sid, Tname = student.Sname };

                await studentService.UOW(student, teacher);

                return new Response().ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }
    }
}