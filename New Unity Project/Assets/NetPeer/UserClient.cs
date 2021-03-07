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
    int id;
    public UserClient()
    {
        System.Random rand = new System.Random();
        id = rand.Next();
        this.clientSocket = Assets.GlobalControl.Instance.playerSocket;
        handler = new ClientCommandHandler(clientSocket);
        Thread t = new Thread(new ThreadStart(() => Listen(clientSocket)));
        t.Start();
    }

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //handler.Send(new SendLocationCommand(id, Assets.GlobalControl.Instance.player.transform.position));
    }

    void Listen(Socket client)
    {
        Debug.Log("Entered Client Listen");
        while (true)
        {
            byte[] buf = new byte[client.ReceiveBufferSize];

            client.Receive(buf);

            handler.Recieve(buf);

        }
    }
}
