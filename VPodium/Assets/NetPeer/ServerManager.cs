using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Net.Sockets;
namespace Assets.NetPeer
{
    class ServerManager : MonoBehaviour
    {
        private List<Socket> connectedClients;
        private Socket clientSocket;
        void Start()
        {
            connectedClients = new List<Socket>();
            clientSocket = default(Socket);
        }

        private void Update()
        {
            
        }
    }
}
