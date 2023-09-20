using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dp_button : MonoBehaviour
{
    public static dp_button dpb;

    void Start()
    {
        if(dpb){
            Destroy(this.gameObject);
            return;
        }
        dpb=this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

     void OnMouseDown(){
        Debug.Log("entered in dp mode");
        SceneManager.LoadScene("dpflood");
    }
}
