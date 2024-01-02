using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_General : MonoBehaviour
{   
    void Start()
    {
        
    }

    void Update()
    {   //do for eraser
        if(Input.GetMouseButton(0)){
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                //hitObject.GetComponent<SpriteRenderer>().color=new Color(0f, 162f, 255f);
                hitObject.GetComponent<SpriteRenderer>().color=MET.one;
            }
        }
        if(Input.GetMouseButton(1)){
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                hitObject.GetComponent<SpriteRenderer>().color=MET.zero;
            }
        }
    }
}
