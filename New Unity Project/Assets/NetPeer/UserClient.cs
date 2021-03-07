using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using Assets.NetPeer.ServerCommand;

public class UserClient : MonoBehaviour
{
    private Socket clientSocket;
    private ClientCommandHandler handler;
    public UserClient()
    {
        this.clientSocket = Assets.GlobalControl.Instance.playerSocket;

        Thread t = new Thread(new ThreadStart(() => Listen(clientSocket)));
    }

    private void Awake()
    {
        handler = new ClientCommandHandler();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Listen(Socket client)
    {
        while (true)
        {
            byte[] buf = new byte[client.ReceiveBufferSize];

            client.Receive(buf);

            handler.Recieve(buf);

        }
    }
}
