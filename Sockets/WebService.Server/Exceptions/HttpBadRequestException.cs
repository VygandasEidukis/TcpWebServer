using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Server.Exceptions
{
    public class HttpBadRequestException : HttpException
    {
        public override int StatusCode { get; } = 400;

        public override string ShortDescription => "Bad Request";

        public HttpBadRequestException() : this("<h1> Bad request, Error code:  400</h1>")
        {
        }

        public HttpBadRequestException(string message) : base(message)
        {
        }
    }
}
