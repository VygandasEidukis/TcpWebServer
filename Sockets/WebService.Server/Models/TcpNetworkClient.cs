using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebService.Server.Models
{
    public class TcpNetworkClient : IDisposable
    {
        public delegate string ProcessRequest(string message);
        public static ProcessRequest requestProcessor;

        private Socket _clientSocket;
        private NetworkStream _dataStream;
        private StringBuilder recievedContent = new StringBuilder();

        private static readonly int bufferSize = 32;
        private byte[] buffer { get; set; } = new byte[bufferSize];

        public TcpNetworkClient(Socket acceptedSocket)
        {
            _clientSocket = acceptedSocket;
            BeginRecievingData();
        }

        private void BeginRecievingData()
        {
            _clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReadCallback), null);
        }

        private void ReadCallback(IAsyncResult asyncResult)
        {
            int bytesRead = _clientSocket.EndReceive(asyncResult);
            if (bytesRead > 0)
            {
                string recievedBuffer = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                recievedContent.Append(recievedBuffer);

                if (_clientSocket.Available > 0)
                {
                    BeginRecievingData();
                }
                else
                {
                    DelegateResponse();
                }
            }
        }

        private void DelegateResponse()
        {
            string response = requestProcessor?.Invoke(recievedContent.ToString());
            Send(response);
        }

        public void Send(string content)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(content);
            _clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
        }

        private void SendCallback(IAsyncResult asyncResult)
        {
            try
            {
                int bytesSent = _clientSocket.EndSend(asyncResult);
                Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Close()
        {
            ((IDisposable)this).Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                IDisposable dataStream = _dataStream;
                if (dataStream != null)
                {
                    dataStream.Dispose();
                }
                else
                {
                    Socket checkClientSocket = _clientSocket;
                    if (checkClientSocket != null)
                    {
                        try
                        {
                            checkClientSocket.Shutdown(SocketShutdown.Both);
                        }
                        finally
                        {
                            checkClientSocket.Close();
                            _clientSocket = null;
                        }
                    }
                }
                GC.SuppressFinalize(this);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
