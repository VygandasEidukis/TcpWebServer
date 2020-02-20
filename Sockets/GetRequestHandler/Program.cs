using System;
using System.IO;
//using System.Net;
//using System.Net.Sockets;
using System.Text;
using System.Threading;
using WebService.Server.Models;
//using WebService.Server.Models;

namespace GetRequestHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            //Servers servers = new Servers(420);
            //servers.Start();
            Server server = new Server(420);
            server.Start();
            Console.ReadKey();
        }
    }
}
