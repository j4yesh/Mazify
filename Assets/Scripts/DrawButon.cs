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
        SceneManager.LoadScene("General");
    }
    void Update()
    {
        
    }
}
