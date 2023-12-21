using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public static SceneController dinst;
    void Start()
    {
        if(dinst!=null){
            Destroy(this.gameObject);
            return;
        }
        dinst=this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public void changeDraw(){
        Debug.Log("entered in general");
        if(SceneManager.GetActiveScene().name!="General")
            SceneManager.LoadScene("General");
    }

    public void changeSnake(){
        Debug.Log("entered in general");
        if(SceneManager.GetActiveScene().name!="snakeGame")
                SceneManager.LoadScene("snakeGame");
    }

    public void setDSTandSRC(){
        Debug.Log("entered in general");
        if(SceneManager.GetActiveScene().name!="setDSTandSRC")
                SceneManager.LoadScene("setDSTandSRC");
    } 

    public void Backtracking(){
        Debug.Log("entered in general");
        if(SceneManager.GetActiveScene().name!="Backtracking")
                SceneManager.LoadScene("Backtracking");
    } 

    public void bfs(){
        Debug.Log("entered in general");
        if(SceneManager.GetActiveScene().name!="bfs")
                SceneManager.LoadScene("bfs");
    } 


    public void dfs(){
        Debug.Log("entered in general");
        if(SceneManager.GetActiveScene().name!="dfs")
                SceneManager.LoadScene("dfs");
    } 


    public void dijkshtra(){
        Debug.Log("entered in general");
        if(SceneManager.GetActiveScene().name!="dijkshtra")
                SceneManager.LoadScene("dijkshtra");
    } 


    public void dpflood(){
        Debug.Log("entered in general");
        if(SceneManager.GetActiveScene().name!="dpflood")
                SceneManager.LoadScene("dpflood");
    } 

    public void Flood(){
        Debug.Log("entered in general");
        if(SceneManager.GetActiveScene().name!="Flood")
                SceneManager.LoadScene("Flood");
    } 



}
