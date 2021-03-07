using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.NetPeer.ServerCommand
{
    public interface IServerCommand
    {
        byte[] Serialize();
        void Execute();
    }
}
