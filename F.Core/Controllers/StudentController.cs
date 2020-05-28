using F.Core.Common;
using F.Core.IRepository;
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
        private readonly IStudentRepository studentRepository;
        private readonly ITeacherRepository teacherRepository;

        public StudentController(IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
        }

        [HttpPost]
        public string Insert(Student student)
        {
            try
            {
                studentRepository.Add(student);

                Teacher teacher = new Teacher() { Tid = 1, Tname = "苍老师" };

                teacherRepository.Add(teacher);

                studentRepository.SaveChanges();
                //teacherRepository.SaveChanges();

                return new Response().ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }

        [HttpGet]
        public string GetEntities()
        {
            try
            {
                var students = studentRepository.Select(t => true);
                return students.ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }
    }
}