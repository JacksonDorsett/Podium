using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.NetPeer;
using System.Net.Sockets;
using System.Threading;

public class ConnectClient : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var input = gameObject.GetComponentInChildren<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;

    }

    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
        TcpClient client = new TcpClient(arg0, ServerManager.port);
        Thread cThread = new Thread(new ThreadStart(() => ConnecttoClient(client.Client)));
        
    }
    
    private void ConnecttoClient(Socket clientSocket)
    {
        Debug.Log($"client is connected: {clientSocket.Connected}");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
