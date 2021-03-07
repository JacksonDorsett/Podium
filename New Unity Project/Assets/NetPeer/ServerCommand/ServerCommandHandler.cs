using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Assets.NetPeer.ServerCommand
{
    public class ServerCommandHandler : CommandHandler
    {
        private List<Socket> clients;
        public ServerCommandHandler(List<Socket> connected)
        {
            clients = connected;
        }
        public override void Recieve(byte[] data)
        {
            JObject commandJson = JObject.Parse(Encoding.UTF8.GetString(data));
            switch (commandJson["cmd"].ToString())
            {
                case "next":
                    break;

            }
        }

        public override void Send(IServerCommand command)
        {
            foreach (Socket s in clients)
            {
                
                s.Send(command.Serialize(), 0, command.Serialize().Length, SocketFlags.None);
                Debug.Log("Sent to client");
            }
        }
    }
}
