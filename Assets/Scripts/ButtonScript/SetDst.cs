using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetDst : MonoBehaviour
{
    // Start is called before the first frame update
    public static SetDst desinst;
    void Start()
    {
        if(desinst!=null){
            Destroy(this.gameObject);
            return;
        }
        desinst=this;
        GameObject.DontDestroyOnLoad(gameObject);
    }
    void OnMouseDown(){
                SceneManager.LoadScene("setDSTandSRC");
    }
    void Update()
    {
        // if(Input.GetMouseButton(0)){
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
