﻿using F.Core.Common;
using F.Core.IService;
using F.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public string Insert(Student student)
        {
            try
            {
                studentService.Add(student);

                return new Response().ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }

        /// <summary>
        /// 工作单元--多表操作,一次提交,commit/rollback
        /// </summary>
        [HttpPost]
        public string UOW(Student student)
        {
            try
            {
                Teacher teacher = new Teacher() { Tid = 1, Tname = student.Sname };

                studentService.UOW(student, teacher);

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
                var students = studentService.Select(t => true);
                return students.ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }
    }
}