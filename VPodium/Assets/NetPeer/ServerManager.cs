using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using UnityEngine;
using System.Net.Sockets;
using System.Threading;

namespace Assets.NetPeer
{
    class ServerManager : MonoBehaviour
    {
        private int port = 8083;
        private IPEndPoint ipEndPoint;
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
            Bind();
            Thread clientThread = new Thread(new ThreadStart(() =>
           this.Listen()));

        }

        private void Update()
        {
            
        }

        private void Listen()
        {
            Debug.Log("Starting Server");
            while (true)
            {
                clientSocket = serverListener.Accept();
                connectedClientCount++;
                connectedClients.Add(clientSocket);

                Thread clientThread = new Thread(new ThreadStart( () =>
                    this.ListenUser(clientSocket)));
            }
        }

        public IPAddress IPAddress
        {
            get
            {
                return myIp;
            }
        }
        private void ListenUser(Socket client)
        {
            Debug.Log($"Client connected with ip: {client.RemoteEndPoint.ToString()}")
            while (client.Connected)
            {
                byte[] msg = new byte[1024];
                int size = client.Receive(msg);
                Console.WriteLine("Client>> " +
                System.Text.Encoding.ASCII.GetString(msg, 0, size));

                // rebroadcast
                foreach (Socket clientSocket in connectedClients)
                {
                    client.Send(msg, 0, size, SocketFlags.None);
                }
            }

            connectedClientCount--;
        }
        private void Bind()
        {
            str = GetIPString();
            myIp = GetIP();
            connectedClientCount = 0;
            serverListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ipEndPoint = new IPEndPoint(IPAddress, port);
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
