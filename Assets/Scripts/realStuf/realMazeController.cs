using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realMazeController : MonoBehaviour
{   

    public static int ROW=9,COL=9; 
    public bool swipe=true;

    private GameObject vw;
    private GameObject hw;
    private GameObject celler;

    [SerializeField]
    public Vector3 leftpos;
    
    [SerializeField]
    public Vector3 rightpos;
    public  Vector3 hpos;
    public Vector3 hposref;

    public Vector3 inpos,inpos2;

    // public Color greit=new Color(0f, 162f, 255f);
    public Color greit=MET.zero;

    public float GEP=10f;
    public float GEPX=10f;

    [SerializeField]
    public GameObject parentObject ;

    public static GameObject[,] verticalWall = new GameObject[100, 100];
    public static GameObject[,] horizontolwall = new GameObject[100, 100];
    public static GameObject[,] cell=new GameObject[100,100];

    private int [,] ver={
                        {1,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1},
                        {1,0,1,0,1,1,1,1,0,0,1,1,1,0,0,1,1},
                        {1,0,1,0,1,1,0,1,1,0,1,0,0,1,0,0,1},
                        {1,0,1,0,1,1,1,1,0,1,0,1,0,0,1,0,1},
                        {1,1,0,0,1,1,1,0,1,0,1,1,1,0,0,1,1},
                        {1,1,0,0,1,1,0,1,1,0,0,1,1,1,1,1,1},
                        {1,1,0,1,1,0,1,1,0,1,1,1,0,0,0,0,1},
                        {1,0,1,0,1,1,0,1,0,0,0,0,1,0,0,0,1},
                        {1,1,1,0,1,0,0,1,0,1,1,0,0,1,0,0,1},
                        {1,0,0,1,0,1,0,1,0,0,0,1,1,0,1,0,1},
                        {1,0,0,0,0,0,0,1,1,0,1,1,0,1,0,0,1},
                        {1,1,0,1,0,1,0,1,0,1,0,1,0,0,0,0,1},
                        {1,0,1,0,1,0,0,1,1,1,1,0,0,0,0,0,1},
                        {1,1,0,1,0,1,0,1,1,1,0,0,0,0,0,0,1},
                        {1,1,1,0,1,0,1,1,1,1,0,0,0,0,0,0,1},
                        {1,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1}
                        };
    private int [,]hor= {
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        {0,1,1,0,0,0,0,0,1,1,0,1,1,1,1,0},
                        {0,1,0,1,0,0,0,0,1,0,1,0,0,1,0,0},
                        {1,0,1,0,0,0,0,1,0,1,0,1,1,0,1,0},
                        {0,1,1,0,0,0,0,0,1,0,1,0,1,1,0,1},
                        {0,0,1,1,0,0,0,1,0,1,0,0,0,1,1,0},
                        {0,1,1,0,0,1,0,0,0,1,0,0,0,0,0,0},
                        {0,0,1,0,0,0,1,1,1,0,0,1,0,1,1,1},
                        {0,0,0,1,0,1,0,0,0,1,1,1,1,0,1,0},
                        {1,0,1,0,0,1,1,1,1,0,0,1,0,1,0,1},
                        {0,1,1,1,1,0,1,0,0,1,0,0,1,0,1,0},
                        {0,1,1,0,1,0,1,1,1,0,0,0,1,1,1,0},
                        {0,0,0,1,0,1,0,0,0,0,0,1,1,1,1,1},
                        {0,1,1,0,1,0,0,0,0,1,1,1,1,1,1,0},
                        {0,0,0,1,0,1,0,0,0,1,0,1,1,1,1,1},
                        {0,0,1,0,1,0,0,0,0,1,1,1,1,1,1,0},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
                        };
    static public realMazeController instance;  
    // void Awake(){
    //     if(instance!=null){
    //         Destroy(gameObject);
    //     }else{
    //         instance=this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }

    void Start()
    {   
        if(instance!=null){
            Destroy(this.gameObject);
            return;
        }
        instance=this;
        GameObject.DontDestroyOnLoad(gameObject);

        vw=GameObject.FindWithTag("vw");
        hw=GameObject.FindWithTag("hw");
        celler=GameObject.FindWithTag("celler");
        StartCoroutine(mazeChange(swipe));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {   //Input.GetKeyDown(KeyCode.J)
            Debug.Log("j");
            swipe=swipe^true;
            printvertical();
        }
    }

    void printvertical(){
        string str="";
        Debug.Log("printing ::: ");
        for(int i=0;i<ROW-1;i++){
            str+="{";
            for(int j=0;j<COL;j++){
                if(verticalWall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                    str+="1,";
                }else{
                    str+="0,";
                }
            }
            str+="},";
        }
        Debug.Log(str);    
        str="";
        Debug.Log("now for horizontol");
        for(int i=0;i<ROW;i++){
            str+="{";
            for(int j=0;j<COL-1;j++){
                 if(horizontolwall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                    str+="1,";
                }else{
                    str+="0,";
                }
            }
            str+="},";
        }
            Debug.Log(str);
        for(int i=0;i<ROW-1;i++){
            for(int j=0;j<COL;j++){
                if(ver[i,j]==1){
                    verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                }else{
                    verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                }
            }    
        }
        for(int i=0;i<ROW;i++){
            for(int j=0;j<COL-1;j++){
                if(hor[i,j]==1){
                    horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                }else{
                    horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                }
            }
        }
    }

    IEnumerator mazeChange(bool en)
    {
        
        yield return new WaitForSeconds(0.5f);
        
        for(int i=0;i<MET.ROW;i++){
            for(int j=0;j<MET.COL;j++){
                MET.myArray[i, j].SetActive(false);
            }
        }

        for (int i = 0; i < ROW-1; i++)
        {
            for (int j = 0; j < COL; j++)
            {
                // if(!verticalWall[i,j])
                    // Destroy(verticalWall[i,j]);
                    verticalWall[i, j] = Instantiate(vw, leftpos, transform.rotation);

                leftpos += new Vector3(GEP, 0f, 0f);
                verticalWall[i,j].GetComponent<SpriteRenderer>().color=greit;


                verticalWall[i,j].GetComponent<verticalWall>().x=i;
                verticalWall[i,j].GetComponent<verticalWall>().y=j;
                // Debug.Log(myArray[i,j].GetComponent<Flip>().x);
            }
            rightpos+=new Vector3(0f,-GEP,0f);
            leftpos=rightpos;
        }

        for(int i=0;i<ROW;i++){
            for(int j=0;j<COL-1;j++){
                // if(!horizontolwall[i,j])
                    // Destroy(horizontolwall[i,j]);
                    horizontolwall[i,j]=Instantiate(hw,hpos,transform.rotation);

                hpos += new Vector3(GEPX, 0f, 0f);
                horizontolwall[i,j].GetComponent<SpriteRenderer>().color=greit;
                horizontolwall[i,j].GetComponent<horizontolwall>().x=i;
                horizontolwall[i,j].GetComponent<horizontolwall>().y=j;

            }
            hposref+=new Vector3(0f,-GEPX,0f);
            hpos=hposref;
        }
        GEP=45f;
        for(int i=0;i<ROW-1;i++){
            for(int j=0;j<COL-1;j++){
                cell[i,j]=Instantiate(celler,inpos,transform.rotation);
             
                  cell[i,j].transform.parent = parentObject.transform;
                       cell[i,j].transform.localPosition = inpos;
                    // cell[i,j].transform.localRotation = Quaternion.identity;


                cell[i,j].GetComponent<bluep>().x=i;
                cell[i,j].GetComponent<bluep>().y=j;
                inpos += new Vector3(GEP,0f,0f);
            }
            inpos2+=new Vector3(0f,-GEP,0f);
            inpos=inpos2;
        }
        
    }

}
