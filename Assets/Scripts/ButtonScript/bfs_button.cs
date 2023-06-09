using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bfs_button : MonoBehaviour
{
    public static bfs_button bb;
    void Start()
    {
        if(bb!=null){
            Destroy(this.gameObject);
            return;
        }
        bb=this;
        GameObject.DontDestroyOnLoad(gameObject);
    }
    void OnMouseDown(){
        Debug.Log("entered in bfs");
        SceneManager.LoadScene("bfs");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
