using System;

namespace WebService.Server.Models
{
    public static class RequestHandler
    {
        public static IRequest GetRequestType(string request, string rootDirectory)
        {
            string[] tokens = request.Split(' ');
            switch (tokens[0])
            {
                case "GET":
                    {
                        var requestMethod = new GetRequest(tokens[1], rootDirectory);
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
