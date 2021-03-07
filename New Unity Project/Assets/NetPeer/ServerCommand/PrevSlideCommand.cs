using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.NetPeer.ServerCommand
{
    class PrevSlideCommand : IServerCommand
    {
        private static presentationScreen screen = presentationScreen.Instance;
        public void Execute()
        {
            screen.PrevColor();
        }

        public byte[] Serialize()
        {
            return Encoding.UTF8.GetBytes("{\"cmd\":\"back\"}");
        }
    }
}
