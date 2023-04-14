  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class MET : MonoBehaviour
{   
    [SerializeField]
    private GameObject spawn;

    public static GameObject[,] myArray = new GameObject[100, 100];
    private int[,] d1=new int[100,100];
    private int[,] d2 = new int[100, 100];
    private int[,] save1 = new int[100, 100];

    
    [SerializeField]
    public Vector3 leftpos;
    
    [SerializeField]
    public Vector3 rightpos;

    [SerializeField]
    public static Color one=new Color(0f, 162f, 255f);

    [SerializeField]
    public static Color zero=new Color(54f / 255f, 54f / 255f, 54f / 255f);

    [SerializeField]
    public Color src=new Color();

    public SpriteRenderer rend;
    public static MET instance;
    private void Start()
    {   if(instance!=null){
            Destroy(this.gameObject);
            return;
        }
        instance=this;
        for(int i=0;i<19;i++){
            for(int j=0;j<26;j++){
                myArray[i, j] = Instantiate(spawn, leftpos, transform.rotation);
                leftpos += new Vector3(0.5f, 0f, 0f);
                myArray[i,j].GetComponent<SpriteRenderer>().color=zero;
            }
            rightpos+=new Vector3(0f,-0.5f,0f);
            leftpos=rightpos;
        }

        defaultMaze("d1.txt",ref d1);
        defaultMaze("d2.txt",ref d2); 

        GameObject.DontDestroyOnLoad(gameObject);
    }

    void defaultMaze(string fel,ref int [,]ar){
        string[] lines = File.ReadAllLines(@"J:\GAMeD\peebeeyel\Assets\Scripts\"+fel);
        for(int i=0;i<lines.Length;i++){
          for(int j=0;j<lines[i].Length;j++){
             ar[i,j]=(lines[i][j]=='1')?1:0;
          }
        }
    }

    //j->17 i->26
    private void Update()
    { 
    //   myArray[0,7].GetComponent<SpriteRenderer>().color=src;
      if(Input.GetKeyDown(KeyCode.S)){
        saveThemaze();
      }
      if(Input.GetKeyDown(KeyCode.D)){
        displaySaved();
      }
      if(Input.GetKeyDown(KeyCode.R)){
        resetThemaze();
      }
      if(Input.GetKeyDown(KeyCode.F)){
        defaultFlood(ref d1);
      }
      if(Input.GetKeyDown(KeyCode.G)){
        defaultFlood(ref d2);
      }
    }

   private void saveThemaze(){
        for(int i=0;i<19;i++){
            for(int j=0;j<26;j++){
                if(myArray[i,j].GetComponent<SpriteRenderer>().color!=zero){
                    save1[i,j]=1;
                }else{
                    save1[i,j]=0;
                }
            }
        }
        Debug.Log("saved successfully");
   }

   private void displaySaved(){
        string ss="{";
         for(int i=0;i<19;i++)
        {   string num="{";
            for(int j=0;j<26;j++)
            {
                if(save1[i,j]==1)
                {
                    myArray[i,j].GetComponent<SpriteRenderer>().color=one;
                    num+="1";
                }
                else
                {   
                    myArray[i,j].GetComponent<SpriteRenderer>().color=zero;
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
        Debug.Log(ss);
    Debug.Log("overwrited successfully");
    }

    private void resetThemaze(){
        for(int i=0;i<19;i++){
            for(int j=0;j<26;j++){
                myArray[i,j].GetComponent<SpriteRenderer>().color=zero;
            }
        }
        Debug.Log("Reset Successfully");
    }

    private void defaultFlood(ref int [,]ar){
        for(int i=0;i<19;i++){
            for(int j=0;j<26;j++){
                if(ar[i,j]==1){
                    myArray[i,j].GetComponent<SpriteRenderer>().color=one;
                }else{
                    myArray[i,j].GetComponent<SpriteRenderer>().color=zero;
                }
            }
        }
    }
}



//  if (Input.GetKey(KeyCode.Space))
//         {
//             myArray[i, j] = Instantiate(spawn, leftpos, transform.rotation);
//             i++;
            
//             if(i==25){
//                 leftpos=rightpos;
//                 rightpos+=new Vector3(0f,-0.5f,0f);
//                 i=0;
//                 j++;
//             }
//             leftpos += new Vector3(0.5f, 0f, 0f);
//         }
