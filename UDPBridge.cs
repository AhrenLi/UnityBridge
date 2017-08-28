using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace UnityBridge
{
    public class UDPBridge : Bridge
    {
        private UdpClient udpClient;
        private IPEndPoint endPoint;

        private void Init()
        {
            if (udpClient == null)
            {
                udpClient = new UdpClient(4001);
                endPoint = new IPEndPoint(IPAddress.Parse("192.168.1.30"), 4002);
            }
        }
        public void Close()
        {
            if (udpClient != null)
            {
                udpClient.Close();
                udpClient = null;
            }
        }

        public void OnReceiveMsg()
        {
            Thread th = new Thread(RecMsg);
            th.Start();
        }
        private void RecMsg()
        {
            Init();
            while (true)
            {
                try
                {
                    byte[] data = udpClient.Receive(ref endPoint);
                    Forward.Instance.ForwardMessage(data);          //转发出去
                }
                catch (Exception)
                {
                    Close();
                }
            }
        }
    }
}
