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
        private List<Socket> connectedClients;
        private Socket clientSocket;
        void Start()
        {
            connectedClients = new List<Socket>();
            clientSocket = default(Socket);
            //myIp = GetIP();
            str = GetIPString();
            myIp = GetIP();

        }

        private void Update()
        {
            
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
