using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Assets.NetPeer.ServerCommand;
using UnityEngine;
using System.Net.Sockets;

namespace Assets.NetPeer.ServerCommand
{
    public class ClientCommandHandler : CommandHandler
    {
        Socket socket;
        public ClientCommandHandler(Socket connection)
        {
            socket = connection;
        }
        public override void Recieve(byte[] data)
        {
             var jCmd = JObject.Parse(Encoding.UTF8.GetString(data));

            switch (jCmd["cmd"].ToString())
            {
                case "next":
                    new NextSlideCommand().Execute();
                    Debug.Log("next slide executed");
                    break;
                case "back":
                    new PrevSlideCommand().Execute();
                    break;
            }
        }

        public override void Send(IServerCommand command)
        {
            socket.Send(command.Serialize());
        }
    }
}
