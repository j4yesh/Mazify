using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{   
    public Color newColor;
    private Color originalColor;
    private bool isdown=false;
    private bool blek=false;
    private void Start()
    {
        originalColor=GetComponent<SpriteRenderer>().color;
    }

    private void OnMouseEnter()
    {   
        if(isdown){
            GetComponent<SpriteRenderer>().color = newColor;
        }
        if(blek){
            GetComponent<SpriteRenderer>().color = originalColor;
        }
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)) 
        {   
            isdown=true;
        }
        if (Input.GetMouseButtonUp(0)) 
        {   
            isdown=false;
        }
        if(Input.GetMouseButtonDown(1)){
            blek=true;
        }
        if(Input.GetMouseButtonUp(1)){
            blek=false;
        }
    }

}
