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
        public UnityBridge()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            using (StreamWriter sw = new StreamWriter("c://log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + "  On Start ");
            }
        }

        protected override void OnStop()
        {
            using (StreamWriter sw = new StreamWriter("c://log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString() + "  On Stop ");
            }
        }
    }
}
