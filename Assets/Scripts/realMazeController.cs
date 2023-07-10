using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realMazeController : MonoBehaviour
{   

    int ROW=17,COL=17;
    public bool swipe=true;

    [SerializeField]
    private GameObject vw;
    private GameObject hw;

    [SerializeField]
    public Vector3 leftpos;
    
    [SerializeField]
    public Vector3 rightpos;
    public  Vector3 hpos;
    public Vector3 hposref;

    [SerializeField]
    public static Color one=new Color(0f, 162f, 255f);

    public static GameObject[,] verticalWall = new GameObject[100, 100];
    public static GameObject[,] horizontolwall = new GameObject[100, 100];

    void Start()
    {
        vw=GameObject.FindWithTag("vw");
        hw=GameObject.FindWithTag("hw");
        StartCoroutine(mazeChange(swipe));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {   //Input.GetKeyDown(KeyCode.J)
            Debug.Log("j");
            swipe=swipe^true;
            StartCoroutine(mazeChange(swipe));
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
            for (int j = 0; j < COL+1; j++)
            {
                if(!verticalWall[i,j])
                    Destroy(verticalWall[i,j]);
                    verticalWall[i, j] = Instantiate(vw, leftpos, transform.rotation);

                leftpos += new Vector3(0.5f, 0f, 0f);
                // verticalWall[i,j].GetComponent<SpriteRenderer>().color=one;

                verticalWall[i,j].GetComponent<verticalWall>().x=i;
                verticalWall[i,j].GetComponent<verticalWall>().y=j;
                // Debug.Log(myArray[i,j].GetComponent<Flip>().x);

                

            }
            rightpos+=new Vector3(0f,-0.6f,0f);
            leftpos=rightpos;
        }

        for(int i=0;i<ROW;i++){
            for(int j=0;j<COL;j++){
                if(!horizontolwall[i,j])
                    Destroy(horizontolwall[i,j]);
                    horizontolwall[i,j]=Instantiate(hw,hpos,transform.rotation);

                // verticalWall[i,j].GetComponent<SpriteRenderer>().color=one;
                horizontolwall[i,j].GetComponent<horizontolwall>().x=i;
                horizontolwall[i,j].GetComponent<horizontolwall>().y=j;
                hpos += new Vector3(0.5f, 0f, 0f);

            }
            hposref+=new Vector3(0f,-0.6f,0f);
            hpos=hposref;
        }
        
    }

}
