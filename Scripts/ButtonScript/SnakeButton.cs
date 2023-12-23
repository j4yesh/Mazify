using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeButton : MonoBehaviour
{
    public static SnakeButton sb;
    void Start()
    {
        if(sb!=null){
            Destroy(this.gameObject);
        }
        sb=this;
        DontDestroyOnLoad(gameObject);
    }

    void OnMouseDown(){
        SceneManager.LoadScene("snakeGame");
    }
    
    void Update()
    {
        
    }
}
