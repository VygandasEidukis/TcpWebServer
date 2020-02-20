using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WebService.Server.Models
{
    public class TcpNetworkListener
    {
        private bool _isServerDisposed = false;

        private IPEndPoint _serverEndpoint;
        private Socket _serverSocket;
        private bool _isSocketActive;

        private readonly ManualResetEvent _allDone = new ManualResetEvent(false);

        public TcpNetworkListener(int port, TcpNetworkClient.ProcessRequest requestProcessor)
        {
            _serverEndpoint = new IPEndPoint(IPAddress.Any, port);
            _serverSocket = new Socket(_serverEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            TcpNetworkClient.requestProcessor += requestProcessor;
        }

        public void Start()
        {
            Start((int)SocketOptionName.MaxConnections);
        }

        public void Start(int backlog)
        {
            _serverSocket.Bind(_serverEndpoint);
            try
            {
                _serverSocket.Listen(backlog);
                AcceptClients();
            }
            catch (Exception e)
            {
                Stop();
                throw e;
            }
            _isSocketActive = true;
        }

        private void AcceptClients()
        {
            while (true)
            {
                _allDone.Set();
                _serverSocket.BeginAccept(new AsyncCallback(ConnectionCallback), _serverSocket);
                _allDone.Reset();
                Thread.Sleep(10);
            }
        }

        private void ConnectionCallback(IAsyncResult asyncResult)
        {
            Console.WriteLine("accepted a connection");
            _allDone.Set();

            Socket listener = (Socket)asyncResult.AsyncState;
            
            if(!_isServerDisposed)
            {
                Socket handler = listener.EndAccept(asyncResult);

                var client = new TcpNetworkClient(handler);
            }            
        }

        public void Stop()
        {
            if (this._isServerDisposed)
                return;

            _isServerDisposed = true;

            if (_serverSocket != null)
            {
                _serverSocket.Close();
                _serverSocket.Dispose();
            }
            _isSocketActive = false;
            _serverSocket = new Socket(_serverEndpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public TcpNetworkClient AcceptTcpClient()
        {
            if (!_isSocketActive)
                throw new Exception("Scoket is inactive");

            Socket acceptedSocket = _serverSocket.Accept();
            TcpNetworkClient returnValue = new TcpNetworkClient(acceptedSocket);
            return returnValue;
        }
    }
}
