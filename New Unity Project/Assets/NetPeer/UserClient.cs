using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class UserClient : MonoBehaviour
{
    private Socket clientSocket;
    public UserClient(Socket clientSocket)
    {
        this.clientSocket = clientSocket;
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


        }
    }
}
