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

    public class Server : IDisposable
    {
        private bool disposed = false;

        public int _port { get; }
        private int _backlog { get; } = 5;
        private TcpNetworkListener _server { get; set; }
        public string rootDirectory { get; set; }

        public Server(int port = 80, string rootDirectory = "./")
        {
            if (!Directory.Exists(rootDirectory))
            {
                if(rootDirectory != "./")
                    throw new DirectoryNotFoundException("Bad root directory");
            }
                

            this.rootDirectory = rootDirectory;
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

        public void Stop()
        {
            _server.Stop();
            this.Dispose();
        }

        public string ProcessRequest(string request)
        {
            try
            {
                IRequest requestMethod = RequestHandler.GetRequestType(request, rootDirectory);
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if(_server != null)
                _server.Stop();
            }

            disposed = true;
        }
    }
}
