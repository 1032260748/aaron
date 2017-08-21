using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThriftServer
{
    public class BusinessImpl : HelloService.Iface
    {
        public string hello(string para)
        {
            Console.WriteLine("Hello: " + para);
            return para;
        }

        public int add(int a, int b)
        {
            Console.WriteLine("{0}+{1}={2}", a, b, a + b);
            return a + b;
        }
    }
}
