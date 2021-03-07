using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace Assets.NetPeer.ServerCommand
{
    class ServerCommandHandler : CommandHandler
    {
        public override void Recieve(byte[] data)
        {
            /*JObject commandJson = JObject.Parse(Encoding.UTF8.GetString(data));
            switch (commandJson["cmd"].ToString())
            {
                case "newConnection":
                    
                    break;

            }*/
        }

        public override void Send(IServerCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
