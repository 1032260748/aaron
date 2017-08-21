using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Transport;
using Thrift.Protocol;
using Thrift.Server;
using System.Net;
using System.Net.Sockets;

namespace ThriftServer
{
    public class Server
    {
        public void Start()
        {
            HttpListener httpListener = new HttpListener();
            httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;

            foreach (string item in this.GetListenPrefixes())
            {
                httpListener.Prefixes.Add(item);
            }

            THttpServerTransport serverTransport = new THttpServerTransport(httpListener);
            HelloService.Processor processor = new HelloService.Processor(new BusinessImpl());
            TServer server = new TSimpleServer(processor, serverTransport);
            Console.WriteLine("Starting server on port 8911 ...");
            server.Serve();
        }

        private List<string> GetListenPrefixes()
        {
            List<string> result = new List<string>();

            //端口号
            string port = System.Configuration.ConfigurationSettings.AppSettings["port"];

            result.Add(string.Format("http://localhost:{0}/", port));
            result.Add(string.Format("http://127.0.0.1:{0}/", port));

            string hostName = Dns.GetHostName();

            IPHostEntry localhost = Dns.GetHostEntry(Dns.GetHostName());
            result.Add(string.Format("http://{0}:{1}/", localhost.HostName, port));
            IPAddress[] ipAddresses = localhost.AddressList.Where(item => item.AddressFamily == AddressFamily.InterNetwork).ToArray();

            if (ipAddresses != null && ipAddresses.Count() > 0)
            {
                foreach (var item in ipAddresses)
                {
                    result.Add(string.Format("http://{0}:{1}/", item.ToString(), port));
                }
            }
            return result;
        }
    }
}
