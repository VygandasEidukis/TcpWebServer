using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebService.Server.Exceptions;

namespace WebService.Server.Models
{

    public class Server
    {
        public int _port { get; }
        private int _backlog { get; } = 5;
        private TcpNetworkListener _server { get; set; }

        public Server(int port = 80)
        {
            _port = port;
        }

        public void Start()
        {
            try
            {
                _server = new TcpNetworkListener(_port, ProcessRequest);
                _server.Start(_backlog);
                Console.WriteLine("Server created");
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Server failed to be created \n" + e.Message);
            }
        }

        public string ProcessRequest(string request)
        {
            try
            {
                IRequest requestMethod = RequestHandler.GetRequestType(request);
                string requestResponse = "HTTP/1.1 200 OK\n\n";
                requestResponse += requestMethod.Process();
                return requestResponse;
            }catch(HttpException exception)
            {
                string errorMessage = $"HTTP/1.1 {exception.StatusCode} {exception.ShortDescription}\n\n {exception.Message}";
                return errorMessage;
            }catch
            {
                var exception = new HttpBadRequestException();
                string errorMessage = $"HTTP/1.1 {exception.StatusCode} {exception.ShortDescription}\n\n {exception.Message}";
                return errorMessage;
            }
        }
    }
}
