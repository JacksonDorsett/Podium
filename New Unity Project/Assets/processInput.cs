using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class processInput : MonoBehaviour
{
    //public GameObject presentationScreen;
    // Start is called before the first frame update
    public presentationScreen inputObject;
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            //presentationScreen scriptToAccess = presentationScreen.GetComponent<presentationScreen>();
            //scriptToAccess.nextColor();
            inputObject.NextColor();
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
