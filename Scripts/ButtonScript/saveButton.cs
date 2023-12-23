using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveButton : MonoBehaviour
{   
    public static saveButton sb;
    Dictionary<string,int [,]>dict=new Dictionary<string,int[,]>();
    void Start()
    {   
        if(sb!=null){
            Destroy(this.gameObject);
        }
        sb=this;
        DontDestroyOnLoad(gameObject);
    }

    void OnMouseDown(){
        Debug.Log("mouse clicked on save button!");
       int[,] temp=new int[100,100];
        for(int i=0;i<19;i++){
            for(int j=0;j<26;j++){
                if(MET.myArray[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                    temp[i,j]=1;
                }else{
                    temp[i,j]=0;
                }
            }
        }
        string key="temp1";
        dict.Add(key,temp);
        Debug.Log("saved by button successfully\n");        
    }

    void nowsave(){
        
    }

    void Update()
    {
        
    }
}
