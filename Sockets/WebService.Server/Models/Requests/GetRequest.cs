using System;
using System.IO;
using System.Text;
using WebService.Server.Enums;
using WebService.Server.Exceptions;

namespace WebService.Server.Models
{
    class GetRequest : IRequest
    {
        public HttpMethods ReqeustType { get; }
        public string Page { get; set; }
        private StringBuilder response { get; } = new StringBuilder();

        public GetRequest(string Page, HttpMethods RequestType = HttpMethods.GET)
        {
            this.ReqeustType = ReqeustType;
            this.Page = Page;
            LinkToMainPage();
        }

        private void LinkToMainPage()
        {
            if(Page == "/")
            {
                Page = "index.html";
            }
        }

        public string Process()
        {
            try
            {
                if(!File.Exists("./"+Page))
                    throw new HttpNotFoundException();

                StreamReader file = new StreamReader("./" + Page);
                string data = file.ReadLine();
                while (data != null)
                {
                    response.Append(data);
                    data = file.ReadLine();
                }

                return response.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
