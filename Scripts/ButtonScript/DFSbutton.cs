using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DFSbutton : MonoBehaviour
{

    public static DFSbutton dfsb;
    void Start()
    {
         if(dfsb!=null){
            Destroy(this.gameObject);
            return;
        }
        dfsb=this;
        GameObject.DontDestroyOnLoad(gameObject);
    }
     void OnMouseDown(){
        SceneManager.LoadScene("dfs");
    }

    void Update()
    {
        
    }
}
