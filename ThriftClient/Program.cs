using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Transport;
using Thrift.Protocol;

namespace ThriftClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:8911/");
            THttpClient httpClient = new THttpClient(uri);
            TProtocol protocol = new TBinaryProtocol(httpClient);
            HelloService.Client client = new HelloService.Client(protocol);
            httpClient.Open();
            Console.WriteLine("Client calls .....");
            Console.WriteLine(client.hello("jian wang"));
            Console.WriteLine(client.add(1, 2));
            httpClient.Close();
            Console.ReadKey();
        }
    }
}
