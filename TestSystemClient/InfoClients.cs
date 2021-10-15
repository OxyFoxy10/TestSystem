using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestSystemClient
{
    public class InfoClients : IDisposable
    {
        public Socket ClientSocket { get; set; }
        public String RemoteEndPoint { get; set; } // кінцева точка тобто фактично це ip
        public DAL_TestSystem.User userClient { get; set; }

        public void Dispose()
        {
            if (ClientSocket != null)
            {
                ClientSocket.Close();
            }
        }

        public override string ToString()
        {
            return $" Client {userClient.Login} IP: {RemoteEndPoint}";
        }
    }
}
