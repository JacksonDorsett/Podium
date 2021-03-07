using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class presentationScreen : MonoBehaviour {

    public Material[] material;
    public int x;
    Renderer rend;
    Shader shader;
    Texture texture;
    Color color;

    public int Index { get { return x; } }

    void Start() {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        /*rend.material = new Material(shader);
        rend.material.mainTexture = texture;
        rend.material.color = color;*/
        rend.sharedMaterial = material[x];
    }

    void Update() {
        rend.sharedMaterial = material[x];
    }

    public void NextColor() {
/*else {
            x = material.Length - 1;
        } */
        if (x < material.Length - 1)
        {
            x++;
        }

    }

    public void PrevColor() {
        /*else {
           x = 0;
       }*/
        if (x > 0)
        {
            x--;
        }
    }
}