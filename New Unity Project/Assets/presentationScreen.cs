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
        if(x > 0) {
            x--;
        } /*else {
            x = material.Length - 1;
        } */
        
    }

    public void PrevColor() {
        if(x < material.Length - 1) {
            x++;
        } /*else {
            x = 0;
        }*/
    }
}