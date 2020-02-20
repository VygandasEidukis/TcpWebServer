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
        private string rootDirectory;

        public GetRequest(string Page, string rootDirectory, HttpMethods RequestType = HttpMethods.GET)
        {
            this.ReqeustType = ReqeustType;
            this.rootDirectory = rootDirectory;
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

        private string LinkRootWithPage()
        {
            if (rootDirectory[rootDirectory.Length - 1] != '/')
                rootDirectory += "/";
            var pageLink = rootDirectory + Page;
            return pageLink;
        }

    public string Process()
        {
            try
            {
                string pageLink = LinkRootWithPage();

                if (!File.Exists(pageLink))
                    throw new HttpNotFoundException();

                StreamReader file = new StreamReader(pageLink);
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
