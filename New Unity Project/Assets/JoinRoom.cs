using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using UnityEngine.UI;
using System.Net.Sockets;

public class JoinRoom : MonoBehaviour
{
    InputField input;
    public Button CustomButton;
    // Start is called before the first frame update
    void Start()
    {
        input = GameObject.FindObjectsOfType<InputField>()[0];
    }

    private void Awake()
    {
        CustomButton.onClick.AddListener(OnClick);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        TcpClient client = new TcpClient(input.text, 8083);
        GlobalControl.Instance.playerSocket = client.Client;
        Debug.Log(GlobalControl.Instance.playerSocket.ToString());
        GlobalControl.Instance.isHost = false;
    }
}
