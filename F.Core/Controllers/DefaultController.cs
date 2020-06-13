using F.Core.Common;
using F.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

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
                        img = "http://127.0.0.1:5000/images/" + info.Name,
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