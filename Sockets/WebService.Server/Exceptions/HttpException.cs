using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Server.Exceptions
{
    public abstract class HttpException : Exception
    {
        public HttpException()
        {
        }

        public HttpException(string message) : base(message)
        {
        }

        public abstract int StatusCode { get; }
        public abstract string ShortDescription { get; }
    }
}
