using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Server.Models
{
    public static class RequestHandler
    {
        public static IRequest GetRequestType(string request)
        {
            string[] tokens = request.Split(' ');
            switch (tokens[0])
            {
                case "GET":
                    {
                        var requestMethod = new GetRequest(tokens[1]);
                        return requestMethod;
                    }
                default:
                    {
                        throw new Exception("Incorrect method");
                    }
            }
        }
    }
}
