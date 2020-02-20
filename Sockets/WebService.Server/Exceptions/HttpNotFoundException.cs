using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Server.Exceptions
{
    public class HttpNotFoundException : HttpException
    {
        public override int StatusCode => 404;

        public override string ShortDescription => "Not Found";

        public HttpNotFoundException(string message) : base(message)
        {
        }

        public HttpNotFoundException() : this("<h1> Page not found, Error code: 404 </h1>")
        {
        }
    }
}
