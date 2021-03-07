using Assets.NetPeer.ServerCommand;
using System.Collections;
using System.Collections.Generic;
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
        
    }

    private void Awake()
    {
        if(Assets.GlobalControl.Instance.isHost)
        {
            handler = GameObject.FindObjectOfType<ServerCommandHandler>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Assets.GlobalControl.Instance.isHost)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                //presentationScreen scriptToAccess = presentationScreen.GetComponent<presentationScreen>();
                //scriptToAccess.nextColor();
                inputObject.NextColor();
                handler.Send(new NextSlideCommand());
                print("space key was pressed");
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                //presentationScreen scriptToAccess = presentationScreen.GetComponent<presentationScreen>();
                //scriptToAccess.nextColor();
                inputObject.PrevColor();
                print("space key was pressed");
            }
        }
        
    }
}
