using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using F.Core.Common;
using F.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace F.Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string GetSwipe()
        {
            try
            {
                List<Pic> list = new List<Pic>();

                string path = AppContext.BaseDirectory + "wwwroot\\images\\";
                foreach (string file in Directory.GetFiles(path))
                {
                    FileInfo info = new FileInfo(file);
                    Pic pic = new Pic()
                    {
                        img = "http://localhost:51917/images" + info.Name,
                        url = "#"
                    };

                    list.Add(pic);
                }

                return new Response<Pic>() { Data = list }.ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }
    }

    public class Pic
    {
        public string url { get; set; }
        public string img { get; set; }
    }
}