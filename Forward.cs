using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UnityBridge
{
    public sealed class Forward
    {
        #region 单例
        private static Forward _instance = null;
        private static readonly object SynObject = new object();

        Forward()
        {

        }

        public static Forward Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (SynObject)
                    {
                        if (null == _instance) _instance = new Forward();
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region UDP多播 转发
        private UdpClient sendUdpClient;
        private IPEndPoint endPoint;

        public void ForwardMessage(string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            ForwardMessage(data);
        }

        public void ForwardMessage(byte[] data)
        {
            try
            {
                InitUdpClient();
                sendUdpClient.Send(data, data.Length, endPoint);
            }
            catch (Exception)
            {
                CloseForward();
            }
        }

        public void CloseForward()
        {
            if (sendUdpClient != null)
            {
                sendUdpClient.Close();
                sendUdpClient = null;
            }
        }

        private void InitUdpClient()
        {
            if (sendUdpClient == null)
            {
                sendUdpClient = new UdpClient();
                sendUdpClient.Ttl = 50;
                endPoint = new IPEndPoint(IPAddress.Parse("239.52.52.52"), 23952);
            }
        }

        #endregion
    }
}
