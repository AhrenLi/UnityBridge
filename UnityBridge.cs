using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace UnityBridge
{
    public partial class UnityBridge : ServiceBase
    {
        UDPBridge udp;
        public UnityBridge()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
             udp = new UDPBridge();
            udp.OnReceiveMsg();
        }

        protected override void OnStop()
        {
            udp.Close();
            Forward.Instance.CloseForward();
        }
    }
}
