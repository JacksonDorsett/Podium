using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.NetPeer.ServerCommand
{
    class ServerCommandInterpereter
    {
        private ServerCommandInterpereter mInstance;

        private ServerCommandInterpereter()
        {
            mInstance = this;
        }

        public IServerCommand interperet(byte[] bytes)
        {
            // interperet the command and construct the object.
            return null;
        }

        public ServerCommandInterpereter Instance
        {
            get
            {
                if (mInstance == null) mInstance = new ServerCommandInterpereter();
                return mInstance;
            }
        }
    }
}
