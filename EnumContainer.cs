using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityBridge
{
    public class EnumContainer
    {
        public enum ProtocolType
        {
            UDP = 0,
            TCP = 1,
            OSC = 2,
            TUIO = 3,
            SerialPort = 4,
            MIDI = 5,
            ArtNet = 6,
            Unknown = 7,
        }
    }
}
