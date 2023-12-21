  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;
public class MET : MonoBehaviour
{   
    // [SerializeField]
    private GameObject spawn;

    public static GameObject[,] myArray = new GameObject[100, 100];
    private int[,] d1=new int[100,100];
    private int[,] d2 = new int[100, 100];
    private int[,] d3={{1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0},
    {1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0},
    {1,1,1,1,1,1,1,1,0,0,1,1,1,0,1,1,1,1,0,0,0,1,0,0,0,0},
    {0,0,0,0,0,0,1,0,0,0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,1,0,1,1,1,0,1,1,1,0,0,0,0,0,1,1,1,0,0,0},
    {0,0,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0},
    {0,0,1,0,0,0,1,0,1,0,0,0,0,0,0,1,1,1,1,1,1,0,1,1,1,0},
    {0,0,1,0,0,0,0,0,1,1,1,1,0,0,0,1,0,0,0,0,0,0,0,0,1,0},
    {0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,1,1,1,0,1,1,1,1,1,1,0},
    {0,0,1,0,1,1,1,1,1,0,0,1,1,1,0,0,0,1,0,1,0,0,0,0,0,0},
    {1,1,1,0,1,0,0,0,0,0,1,1,0,1,0,0,0,1,0,1,1,1,1,0,0,0},
    {1,0,1,0,1,0,1,1,1,1,1,0,0,1,1,1,1,1,0,0,0,0,1,0,0,0},
    {1,0,1,1,1,0,1,0,0,0,0,0,0,1,0,0,0,0,0,1,1,1,1,0,0,0},
    {0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0},
    {0,0,1,1,1,1,1,0,1,1,1,1,0,0,0,1,0,0,0,0,0,1,1,1,1,0},
    {0,0,1,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,1,1,0,1,0,0,1,0},
    {0,0,1,1,1,0,0,1,1,1,0,1,0,1,0,0,0,0,0,0,0,1,0,1,1,0},
    {0,0,0,0,1,1,1,1,0,1,1,1,0,1,1,1,1,1,1,1,1,1,0,1,0,0},
    {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1}};
    private int[,] save1 = new int[100, 100];


    public static int ROW=35;
    public static int COL=55;
     [SerializeField]
    public float GEP= 0.5f;
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

    public TextMeshProUGUI sceneName;

    public static MET instance;


    private void Start()
    {   
        sceneName=FindObjectOfType<TextMeshProUGUI>();
        sceneName.text="DRAW/ERASE";
        spawn=GameObject.FindWithTag("blk");
        if(instance!=null){
            Destroy(this.gameObject);
            return;
        }
        instance=this;
        for(int i=0;i<MET.ROW;i++){
            for(int j=0;j<MET.COL;j++){               
                // spawn.x=3;
                
                myArray[i, j] = Instantiate(spawn, leftpos, transform.rotation);
                leftpos += new Vector3(GEP, 0f, 0f);
                myArray[i,j].GetComponent<SpriteRenderer>().color=zero;

                myArray[i,j].GetComponent<Flip>().x=i;
                myArray[i,j].GetComponent<Flip>().y=j;
                // Debug.Log(myArray[i,j].GetComponent<Flip>().x);
            }
            rightpos+=new Vector3(0f,-GEP,0f);
            leftpos=rightpos;
        }

        defaultMaze("d1.txt",ref d1);
        defaultMaze("d2.txt",ref d2);

        GameObject.DontDestroyOnLoad(gameObject);

    }

    public void defaultMaze(string fel,ref int [,]ar){
        string[] lines = File.ReadAllLines(@"J:\GAMeD\pathfinder-hehe\Assets\Scripts\"+fel);
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
      if(Input.GetKeyDown(KeyCode.T)){
        saveThemaze();
      }
      if(Input.GetKeyDown(KeyCode.Y)){
        displaySaved();
      }
      if(Input.GetKeyDown(KeyCode.U)){
        resetThemaze();
      }
      if(Input.GetKeyDown(KeyCode.I)){
        defaultFlood(ref d1);
      }
      if(Input.GetKeyDown(KeyCode.O)){
        defaultFlood(ref d2);
      } 
      if(Input.GetKeyDown(KeyCode.P)){
        defaultMaze();
      }
    }

   public void saveThemaze(){
        for(int i=0;i<MET.ROW;i++){
            for(int j=0;j<MET.COL;j++){
                if(myArray[i,j].GetComponent<SpriteRenderer>().color!=zero){
                    save1[i,j]=1;
                }else{
                    save1[i,j]=0;
                }
            }
        }
        Debug.Log("saved successfully");
   }

   public void displaySaved(){
        string ss="{";
         for(int i=0;i<MET.ROW;i++)
        {   string num="{";
            for(int j=0;j<MET.COL;j++)
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
        // Debug.Log(ss);
    Debug.Log("overwrited successfully");
    }

    public void resetThemaze(){
        for(int i=0;i<ROW;i++){
            for(int j=0;j<COL;j++){
                myArray[i,j].GetComponent<SpriteRenderer>().color=zero;
            }
        }
        Debug.Log("Reset Successfully");
    }

    public void defaultFlood(ref int [,]ar){
        for(int i=0;i<MET.ROW;i++){
            for(int j=0;j<MET.COL;j++){
                if(ar[i,j]==1){
                    myArray[i,j].GetComponent<SpriteRenderer>().color=one;
                }else{
                    myArray[i,j].GetComponent<SpriteRenderer>().color=zero;
                }
            }
        }
    }

    public void defaultMaze(){
        for(int i=0;i<19;i++){
            for(int j=0;j<26;j++){
                if(d3[i,j]==1){
                    myArray[i,j].GetComponent<SpriteRenderer>().color=one;
                }else{
                    myArray[i,j].GetComponent<SpriteRenderer>().color=zero;
                }
            }
        }
        Debug.Log("Default maze loaded");
    }
    public void restartScene(){
        string currentSceneName = SceneManager.GetActiveScene().name;
        if(currentSceneName=="General"){
            return;
        }
        SceneManager.LoadScene(currentSceneName);
        Debug.Log("Abort call!");
    }

    public void removeSRCDST(){
        // if(SETDSTSRC){ 
             Destroy(SETDSTSRC.prevDST);
            Destroy(SETDSTSRC.prevSRC);
        // }
    }
}



