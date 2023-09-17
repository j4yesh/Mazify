using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realMazeController : MonoBehaviour
{   

    int ROW=17,COL=17;
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
    public Vector3 inpos;
    public Vector3 inpos2;

    // public Color greit=new Color(0f, 162f, 255f);
    public Color greit=MET.zero;


    [SerializeField]

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


    void Start()
    {
        vw=GameObject.FindWithTag("vw");
        hw=GameObject.FindWithTag("hw");
        celler=GameObject.FindWithTag("cell");
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
                if(!verticalWall[i,j])
                    Destroy(verticalWall[i,j]);
                    verticalWall[i, j] = Instantiate(vw, leftpos, transform.rotation);

                leftpos += new Vector3(0.6f, 0f, 0f);
                verticalWall[i,j].GetComponent<SpriteRenderer>().color=greit;


                verticalWall[i,j].GetComponent<verticalWall>().x=i;
                verticalWall[i,j].GetComponent<verticalWall>().y=j;
                // Debug.Log(myArray[i,j].GetComponent<Flip>().x);

                

            }
            rightpos+=new Vector3(0f,-0.6f,0f);
            leftpos=rightpos;
        }

        for(int i=0;i<ROW;i++){
            for(int j=0;j<COL-1;j++){
                if(!horizontolwall[i,j])
                    Destroy(horizontolwall[i,j]);
                    horizontolwall[i,j]=Instantiate(hw,hpos,transform.rotation);

                horizontolwall[i,j].GetComponent<SpriteRenderer>().color=greit;
                horizontolwall[i,j].GetComponent<horizontolwall>().x=i;
                horizontolwall[i,j].GetComponent<horizontolwall>().y=j;
                hpos += new Vector3(0.6f, 0f, 0f);

            }
            hposref+=new Vector3(0f,-0.6f,0f);
            hpos=hposref;
        }

        // for(int i=0;i<ROW-1;i++){
        //     for(int j=0;j<COL-1;j++){
        //         cell[i,j]=Instantiate(celler,inpos,transform.rotation);
        //         cell[i,j].GetComponent<SpriteRenderer>().color=greit;
        //         cell[i,j].GetComponent<Flip>().x=i;
        //         cell[i,j].GetComponent<Flip>().y=j;
        //         inpos += new Vector3(0.6f,0f,0f);
        //         Debug.Log("lund ka bal");
        //     }
        //     inpos2+=new Vector3(0f,-0.6f,0f);
        //     inpos=inpos2;
        // }

        // cell[8,8].GetComponent<SpriteRenderer>().color=Color.green;
        // cell[7,7].GetComponent<SpriteRenderer>().color=Color.green;
        // cell[7,8].GetComponent<SpriteRenderer>().color=Color.green;
        // cell[8,7].GetComponent<SpriteRenderer>().color=Color.green;

        
    }

}
