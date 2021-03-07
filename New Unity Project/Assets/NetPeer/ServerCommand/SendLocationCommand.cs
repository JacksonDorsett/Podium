using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.NetPeer.ServerCommand
{
    class SendLocationCommand : IServerCommand
    {
        int id;
        Vector3 Position;
        public SendLocationCommand(int ID, Vector3 position)
        {
            id = ID;
            Position = position;
        }

        public void Execute()
        {
            ConnectedUsers.Instance.UpdatePos(id, Position);
            Debug.Log("send position executed.");
        }

        public byte[] Serialize()
        {
            FormattableString msg = $"{{\"cmd\":\"move\",\"ID\":{0},\"x\":{1},\"y\":{2},\"z\":{3}}}";
            //var s = string.Format("{\"cmd\":\"move\",\"ID\":{0},\"x\":{1},\"y\":{2},\"z\":{3}", id, Position.x, Position.y, Position.z);
            return Encoding.UTF8.GetBytes(msg.ToString());
        }
    }
}
