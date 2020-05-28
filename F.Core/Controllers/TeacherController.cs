using F.Core.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace F.Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly MySqlDbContext dbContext;

        public TeacherController(MySqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<string> Insert(Teacher teacher)
        {
            try
            {
                await dbContext.Teacher.AddAsync(teacher);
                await dbContext.SaveChangesAsync();
                return new Response().ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }

        [HttpGet]
        public async Task<string> GetEntities()
        {
            try
            {
                var Teachers = dbContext.Teacher.AsQueryable();
                await dbContext.SaveChangesAsync();
                return Teachers.ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }
    }
}