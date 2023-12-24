using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DrawButon : MonoBehaviour
{   
    public static DrawButon dinst;
    void Start()
    {   
        if(dinst!=null){
            Destroy(this.gameObject);
            return;
        }
        dinst=this;
        GameObject.DontDestroyOnLoad(gameObject);
    }
    void OnMouseDown(){
        Debug.Log("entered in snake game");
        SceneManager.LoadScene("General");
    }
    void Update()
    {
        // if(Input.GetMouseButton(1)){
        //     Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
        //     if (hit.collider != null)
        //     {
        //         GameObject hitObject = hit.collider.gameObject;
        //         hitObject.GetComponent<SpriteRenderer>().color=new Color(66f, 245f, 84f);
        //     }
        // }
    }
}
