namespace F.Core.Model
{
    public class Response
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public Response()
        {
            Code = 200;
            Message = "操作成功";
        }
    }
}