using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using UnityEngine;
using System.Net.Sockets;
namespace Assets.NetPeer
{
    class ServerManager : MonoBehaviour
    {

        public string str;
        public IPAddress myIp;
        private Socket serverListener;
            private int connectedClientCount;
        private List<Socket> connectedClients; // could be made into its own class
        private Socket clientSocket;
        void Start()
        {
            connectedClients = new List<Socket>();
            clientSocket = default(Socket);
            connectedClientCount = 0;
            serverListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            str = GetIPString();
            myIp = GetIP();

        }

        private void Update()
        {
            
        }

        private void Listen()
        {
            while (true)
            {
                clientSocket = serverListener.Accept();
                connectedClientCount++;
                connectedClients.Add(clientSocket);
            }
        }

        public IPAddress IPAddress
        {
            get
            {
                return myIp;
            }
        }

        private string GetIPString()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        private IPAddress GetIP()
        {
            
            return IPAddress.Parse(GetIPString());
        }
    }
}
