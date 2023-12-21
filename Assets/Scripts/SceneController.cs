using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private int[,] save1 = new int[100, 100];
    void Start()
    {
        // if(dinst!=null){
        //     Destroy(this.gameObject);
        //     return;
        // }
        // dinst=this;
        // GameObject.DontDestroyOnLoad(gameObject);
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

    public void removeSRCDST(){
         GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("setsrc");

        foreach (GameObject obj in objectsToDelete)
        {   
            Debug.Log("deleted");
            DestroyImmediate(obj);
        }
            Debug.Log("removeSRCDST DESTROYed");

    }

    public void removePath(){
        for(int i=0;i<MET.ROW;i++){
            for(int j=0;j<MET.COL;j++){
                if( MET.myArray[i,j].GetComponent<SpriteRenderer>().color!=MET.one
                    && MET.myArray[i,j].GetComponent<SpriteRenderer>().color!=MET.zero
                ){
            MET.myArray[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                    Debug.Log("destroyed for path");
                }
            }
        }
                    Debug.Log("REMOVE path func. invoked");
    }

    public void resetMaze(){
        for(int i=0;i<MET.ROW;i++){
            for(int j=0;j<MET.COL;j++){
            MET.myArray[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
            }
        }
                 
    }

    public void saveThemaze(){
        for(int i=0;i<MET.ROW;i++){
            for(int j=0;j<MET.COL;j++){
                if(MET.myArray[i,j].GetComponent<SpriteRenderer>().color!=MET.zero){
                    save1[i,j]=1;
                }else{
                    save1[i,j]=0;
                }
            }
        }
        Debug.Log("temporary saved successfully");
   }

    public void displaySaved(){
        string ss="{";
         for(int i=0;i<MET.ROW;i++)
        {   string num="{";
            for(int j=0;j<MET.COL;j++)
            {
                if(save1[i,j]==1)
                {
                    MET.myArray[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                    num+="1";
                }
                else
                {   
                    MET.myArray[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                    num+="0";
                }
                if(j!=25){
                    num+=',';
                }
            }
            num+="}";
            if(i!=18){
                num+=',';
            }
            ss+=num;
        }
        // Debug.Log(ss);
    Debug.Log("overwrited successfully");
    }


}
