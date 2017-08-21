using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Thrift.Transport
{
    /// <summary>
    /// 服务器没接收一个客户端请求时，生成一个处理请求的上下文
    /// </summary>
    public class THttpContext : TStreamTransport
    {
        private HttpListenerContext context;
        public THttpContext(Stream inputStream, Stream outputStream)
            : base(inputStream, outputStream)
        {
        }

        public THttpContext(HttpListenerContext context)
            : this(context.Request.InputStream, context.Response.OutputStream)
        {
            this.context = context;
        }
    }
}
