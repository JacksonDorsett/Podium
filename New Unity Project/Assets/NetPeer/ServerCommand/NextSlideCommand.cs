using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.NetPeer.ServerCommand
{
    class NextSlideCommand : IServerCommand
    {
        private static presentationScreen screen = GameObject.FindObjectOfType(Type.GetType("presentationScreen")) as presentationScreen;
        void Start()
        {
            //if (screen == null) screen = GameObject.FindObjectOfType(Type.GetType("presentationScreen")) as presentationScreen;
        }
        public void Execute()
        {
            screen.NextColor();
        }

        public byte[] Serialize()
        {
            return Encoding.UTF8.GetBytes("{cmd:\"next\"}");
        }
    }
}
