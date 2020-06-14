using F.Core.Common;
using F.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace F.Core.Controllers
{
    /// <summary>
    /// 简单配置下接口,主要为了学习vue
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private static List<Comment> comments = new List<Comment>();

        #region 获取轮播图

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
                        img = "http://192.168.1.5:5000/images/" + info.Name,
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

        #endregion 获取轮播图

        #region 获取新闻列表

        [HttpGet]
        public string GetNewsList()
        {
            try
            {
                List<News> list = new List<News>();

                list.Add(new News()
                {
                    id = 1,
                    title = "三文鱼应无罪 但暂时不要生吃",
                    add_time = DateTime.Now,
                    click = 0,
                    zhaiyao = "6月12日晚，北京新发地批发市场董事长张玉玺接受媒体采访时曾表示，相关部门抽检时从切割进口三文鱼的案板中检测到了新冠病毒，而该产品的货源来自京深海鲜市场。",
                    img_url = "https://dss2.baidu.com/6ONYsjip0QIZ8tyhnq/it/u=2333205389,3684334615&fm=55&app=54&f=JPEG?w=1140&h=640"
                });

                list.Add(new News()
                {
                    id = 2,
                    title = "北京丰台区启动战时机制 成立现场指挥部",
                    add_time = DateTime.Now,
                    click = 0,
                    zhaiyao = "6月13日，在北京市新型冠状病毒肺炎疫情防控工作第114场新闻发布会上，北京市丰台区区长初军威通报新发地市场疫情防控情况。",
                    img_url = "https://portrait.gitee.com/uploads/avatars/user/706/2120843_xiangxiufei_1578966666.png!avatar30"
                });

                for (int i = 3; i < 15; i++)
                {
                    list.Add(new News()
                    {
                        id = i,
                        title = "北京丰台区启动战时机制 成立现场指挥部",
                        add_time = DateTime.Now,
                        click = 0,
                        zhaiyao = "6月13日，在北京市新型冠状病毒肺炎疫情防控工作第114场新闻发布会上，北京市丰台区区长初军威通报新发地市场疫情防控情况。",
                        img_url = "https://dss1.baidu.com/6ONXsjip0QIZ8tyhnq/it/u=3696375490,3360195757&fm=173&app=49&size=f242,162&n=0&g=0n&f=JPEG?s=AB03B0444491847D54EA58910300508B&sec=1592133957&t=558094da69fed283108106ee7bf7b590"
                    });
                }

                return new Response<News>() { Data = list }.ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }

        #endregion 获取新闻列表

        #region 获取新闻详情

        [HttpGet]
        public string GetNewsInfo(int id)
        {
            try
            {
                List<News> list = new List<News>();

                News model = new News();
                if (id == 1)
                {
                    model = new News()
                    {
                        id = 1,
                        title = "三文鱼应无罪 但暂时不要生吃",
                        add_time = DateTime.Now,
                        click = 0,
                        content = @"<p style='text-indent:2em;'>北京新发地批发市场董事长张玉玺接受媒体采访时曾表示，相关部门抽检时从切割进口三文鱼的案板中检测到了新冠病毒，而该产品的货源来自京深海鲜市场。</p>
                          <p><img src='https://cms-bucket.ws.126.net/2020/0613/2e9dcfbfp00qbult30046c000h800b3c.png?imageView&amp;thumbnail=550x0'><br></p>
                         <p style='text-indent:2em;'>这一消息让三文鱼一时间引发各方热议。随着而来的信息是，北京主要商超企业超市发、物美、家乐福都已连夜下架全部三文鱼。</p>
                         <p style='text-indent:2em;'>“新冠病毒的宿主为哺乳类动物，三文鱼和海鲜不是新冠病毒的宿主，不会感染病毒，体内不会潜伏新冠病毒。但是表面可能会因为环境而存在病毒。”一位病毒学家表示。</p>
                         <p style='text-indent:2em;'>不过，由于目前不知道三文鱼等海鲜类产品上的病毒到底来自何方，所以科信食品与营养信息交流中心副主任钟凯博士建议：暂时不要生吃三文鱼。</p>
                         <p style='text-indent:2em;'>同时，钟凯建议，重点还是强调个人防护，外出采买戴口罩，处理食物前后要洗手。三文鱼携带病毒的可能性几乎为零，应该还是被人污染的，传染的途径很可能依然是黏膜接触，比如揉眼睛、抠鼻子之类。<!--EndFragment--></p>"
                    };
                }
                else
                {
                    model = new News()
                    {
                        id = 2,
                        title = "北京丰台区启动战时机制 成立现场指挥部",
                        add_time = DateTime.Now,
                        click = 0,
                        zhaiyao = "6月13日，在北京市新型冠状病毒肺炎疫情防控工作第114场新闻发布会上，北京市丰台区区长初军威通报新发地市场疫情防控情况。",
                        img_url = "https://portrait.gitee.com/uploads/avatars/user/706/2120843_xiangxiufei_1578966666.png!avatar30",
                        content = @"<p style='text-indent:2em;'>6月13日，在北京市新型冠状病毒肺炎疫情防控工作第114场新闻发布会上，北京市丰台区区长初军威通报新发地市场疫情防控情况。初军威介绍说，6月12日0时至24时，丰台区共报告5例新冠肺炎确诊病例。市、区卫生健康委立即对病例进行调查追溯，病例行动轨迹涉及新发地市场部分商户，丰台区迅速启动战时机制，成立现场指挥部，本着“人民群众安全和身体健康至上”的原则，对新发地市场及周边小区采取封闭管理措施，现将相关工作开展情况通报如下。新发地市场管控情况具体如下：</p>
                          <p style='text-indent:2em;'>一是暂时关停市场。针对新发地市场人流量大、人员结构复杂、疫情扩散风险大的特点，紧急于6月13日3时起暂时关停市场，调查市场相关人员及外部环境污染现状，评估感染风险，全面有序进行卫生整治和环境消杀。</p>
                          <p style='text-indent:2em;'>二是扩大流调范围。市区两级疾控中心围绕确诊病例的活动轨迹，扩大调查范围，开展病例搜索，确定可能涉及的场所和人员，做好病例的追踪溯源。目前已摸排丰台区确诊病例的密切接触者139人，全部实施集中隔离。</p> <p style='text-indent:2em;'>三是做到应检尽检。紧急落实核酸检测排查，采集市场从业人员咽拭子样本517件。同时，加强市场环境检测，已采集各类物体表面、肉类及肉制品、加工台、清洗池、门把手、垃圾桶等1901件样本。</p>
                          <p style='text-indent:2em;'>四是保障必需品供应。调整设置3处蔬菜和水果临时露天交易区，实行闭环管理，做到“人人测温、车车消毒、佩戴口罩、有序限流”，确保交易区绝对安全，保障首都市场果蔬供应。</p> "
                    };
                }

                list.Add(model);

                return new Response<News>() { Data = list }.ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }

        #endregion 获取新闻详情

        #region 获取评论

        [HttpGet]
        public string GetComments(int pageIndex)
        {
            try
            {
                if (comments.Count < 1)
                {
                    for (int i = 1; i <= 15; i++)
                    {
                        Comment comment = new Comment()
                        {
                            user_name = "用户" + i.ToString().PadLeft(3, '0'),
                            add_time = DateTime.Now.AddDays(-1),
                            content = "hello,I am " + i.ToString().PadLeft(3, '0')
                        };

                        comments.Add(comment);
                    }
                }

                List<Comment> list = comments.Skip(10 * (pageIndex - 1)).Take(10).ToList();

                return new Response<Comment>() { Data = list }.ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }

        #endregion 获取评论

        #region 发表评论

        [HttpPost]
        public string PostComment([FromForm] Comment comment)
        {
            try
            {
                comments.Add(comment);

                return new Response().ToJson();
            }
            catch (Exception e)
            {
                return new Response() { Code = 500, Message = e.Message }.ToJson();
            }
        }

        #endregion 发表评论

        public class News
        {
            public int id { get; set; }
            public string title { get; set; }
            public DateTime add_time { get; set; }
            public string zhaiyao { get; set; }
            public int click { get; set; }
            public string img_url { get; set; }
            public string content { get; set; }
        }

        public class Pic
        {
            public string url { get; set; }
            public string img { get; set; }
        }

        public class Comment
        {
            public string user_name { get; set; }
            public DateTime add_time { get; set; }
            public string content { get; set; }
        }
    }
}