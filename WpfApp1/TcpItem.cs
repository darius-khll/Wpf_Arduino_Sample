using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class TcpItem
    {
        public NetworkStream Initial(string ip, int port = 23)
        {
            TcpClient server = new TcpClient(ip, port);
            return server.GetStream(); //ethernet
        }
    }
}
