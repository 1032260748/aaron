using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThriftServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }
    }
}
