using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using UnityEngine;
using System.Net.Sockets;
using System.Threading;
using Assets.NetPeer.ServerCommand;

namespace Assets.NetPeer
{
    class ServerManager : MonoBehaviour
    {
        ServerCommandHandler cmdHandler;
        public static int port = 8083;
        private IPEndPoint ipEndPoint;
        public string str;
        public IPAddress myIp;
        private Socket serverListener;
        private int connectedClientCount;
        public List<Socket> connectedClients; // could be made into its own class
        private Socket clientSocket;
        void Start()
        {
            connectedClients = new List<Socket>();
            clientSocket = default(Socket);
            cmdHandler = new ServerCommandHandler(connectedClients);
            Bind();
            Debug.Log("Done Binding");
            Thread clientThread = new Thread(new ThreadStart(() =>
           this.Listen()));
            clientThread.Start();

        }

        private void Update()
        {
            
        }

        private void Listen()
        {
            serverListener.Listen(0);
            Debug.Log("Starting Server");
            while (true)
            {
                clientSocket = serverListener.Accept();
                connectedClientCount++;
                connectedClients.Add(clientSocket);

                Thread clientThread = new Thread(new ThreadStart( () =>
                    this.ListenUser(clientSocket)));
                clientThread.Start();
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
            Debug.Log($"Client connected with ip: {client.RemoteEndPoint.ToString()}");
            while (client.Connected)
            {
                byte[] msg = new byte[1024];
                int size = client.Receive(msg);
                Console.WriteLine("Client>> " +
                System.Text.Encoding.ASCII.GetString(msg, 0, size));

                // rebroadcast
                foreach (Socket clientSocket in connectedClients)
                {
                    //if (clientSocket == client) continue;
                    clientSocket.Send(msg, 0, size, SocketFlags.None);
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
            serverListener.Bind(ipEndPoint);
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

        private void RemoveDisconnected()
        {
            for(int i = connectedClients.Count - 1; i >= 0; i--)
            {
                lock (connectedClients)
                {
                    if (!connectedClients[i].Connected)
                    {
                        connectedClients.Remove(connectedClients[i]);
                        //send message to users.
                    }
                }
            }
        }
    }
}
