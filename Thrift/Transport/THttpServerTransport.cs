using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Thrift.Transport
{
    /// <summary>
    /// 服务端用于监听
    /// </summary>
    public class THttpServerTransport : TServerTransport
    {
        private HttpListener listener;

        public THttpServerTransport(HttpListener listener)
        {
            this.listener = listener;
        }

        public override void Close()
        {
            if (this.listener != null)
            {
                try
                {
                    this.listener.Close();
                }
                catch (Exception)
                {

                }
            }
        }

        public override void Listen()
        {
            if (this.listener == null)
            {
                throw new ArgumentNullException("Listener");
            }
            this.listener.Start();
        }

        protected override TTransport AcceptImpl()
        {
            try
            {
                THttpContext result2 = null;
                HttpListenerContext result = this.listener.GetContext();
                try
                {
                    result2 = new THttpContext(result);
                    return result2;
                }
                catch (System.Exception)
                {
                    if (result2 != null)
                    {
                        result2.Dispose();
                    }
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw new TTransportException(ex.ToString());
            }
        }
    }
}
