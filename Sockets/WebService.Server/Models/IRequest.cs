using System.IO;
using WebService.Server.Enums;

namespace WebService.Server.Models
{
    public interface IRequest
    {
        HttpMethods ReqeustType { get; }
        string Page { get; set; }

        /// <summary>
        /// processes request for assigned http method
        /// </summary>
        /// <returns>returns response for client</returns>
        string Process();
    }
}
