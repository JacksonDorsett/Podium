using Assets.NetPeer;
using Assets.NetPeer.ServerCommand;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class processInput : MonoBehaviour
{
    ServerCommandHandler handler;
    //public GameObject presentationScreen;
    // Start is called before the first frame update
    public presentationScreen inputObject;
    void Start()
    {
        if (Assets.GlobalControl.Instance.isHost)
        {
            var s = GameObject.FindObjectOfType<ServerManager>() as ServerManager;
            handler = s.cmdHandler;

        }
    }

    private void Awake()
    {
        //if(Assets.GlobalControl.Instance.isHost)
        //{
        //    handler = (ServerCommandHandler)GameObject.Find;

        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Assets.GlobalControl.Instance.isHost)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                //presentationScreen scriptToAccess = presentationScreen.GetComponent<presentationScreen>();
                //scriptToAccess.nextColor();
                inputObject.NextColor();
                IServerCommand s = new NextSlideCommand();
                string str = Encoding.UTF8.GetString(s.Serialize());
                Debug.Log(str);
                handler.Send(s);
                print("P key was pressed");
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                //presentationScreen scriptToAccess = presentationScreen.GetComponent<presentationScreen>();
                //scriptToAccess.nextColor();
                inputObject.PrevColor();
                print("space key was pressed");
            }
        }
        
    }
}
