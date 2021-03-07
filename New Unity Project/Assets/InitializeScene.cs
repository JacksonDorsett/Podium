using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using Assets.NetPeer;
using System.Net.Sockets;

public class InitializeScene : MonoBehaviour
{
    private GameObject server;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        if (GlobalControl.Instance.isHost)
        {
            InitializeHost();
            //InitializeNormal();
        }
        else
        {
            InitializeNormal();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeHost()
    {
        var g = GameObject.Instantiate(Resources.Load("Server") as GameObject);
        /*ServerManager s = g.GetComponent<ServerManager>();
        TcpClient client = new TcpClient(s.str, 8083);
        GlobalControl.Instance.playerSocket = client.Client;
        Debug.Log(GlobalControl.Instance.playerSocket.ToString());*/
    }
    private void InitializeNormal()
    {
        GameObject.Instantiate(Resources.Load("Client") as GameObject);
    }
}
