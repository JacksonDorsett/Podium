using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets;
using UnityEngine.SceneManagement;
public class HostPresentation : MonoBehaviour
{
    public Button CustomButton; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        CustomButton.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        GlobalControl.Instance.isHost = true;
        SceneManager.LoadScene(1);
    }
}
