using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.NetPeer.ServerCommand
{
    public abstract class CommandHandler
    {
        public abstract void Send(IServerCommand command);
        public abstract void Recieve(byte[] data);
    }
}
