using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.NetPeer.ServerCommand;
namespace Assets.NetPeer
{
    public abstract class CommandHandler : MonoBehaviour
    {
        public abstract void Send(IServerCommand command);
        public abstract void Recieve(byte[] buf);

    }
}
