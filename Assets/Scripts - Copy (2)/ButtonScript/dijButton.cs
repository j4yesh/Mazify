using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dijButton : MonoBehaviour
{
    public static dijButton db;
    void Start()
    {   if(db!=null){
            Destroy(this.gameObject);return;
        }
        db=this;
        GameObject.DontDestroyOnLoad(gameObject);

    }

    void OnMouseDown(){
        SceneManager.LoadScene("dijkshtra");
    }
}
