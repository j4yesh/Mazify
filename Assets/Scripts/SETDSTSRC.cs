using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SETDSTSRC : MonoBehaviour
{
    public static GameObject prevSRC;
    public static GameObject prevDST;
    private bool srcass=false;
    private bool dstass=false;

    public static Color cc = Color.blue;
   
    public static Color rr = Color.green;

    public Color psrc=MET.zero;

    public Color pdst=MET.zero;

    public static SETDSTSRC sds;

    private GameObject spawn;

    public static int sx=0,sy=0,dx=18,dy=25;

    private Color pathColor=new Color(1f, 0.92f, 0.016f, 1f);

    [SerializeField]
    public testconfirmation tc;

    private void Start()
    {  
       sx=0;sy=0;dx=MET.ROW;dy=MET.COL; 
       spawn=GameObject.FindWithTag("blk"); 
    //    if(sds!=null){
    //         Destroy(this.gameObject);
    //         return;
    //    }
    //    sds=this;
    //    GameObject.DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
            if (hit.collider != null && hit.transform.gameObject.tag=="blk")
            {   
                if(prevSRC){
                    Destroy(prevSRC);
                }
                    GameObject hitObject = hit.collider.gameObject;

                    psrc=hitObject.GetComponent<SpriteRenderer>().color;

                    Vector3 spawnPosition = hitObject.transform.position;
                    prevSRC=Instantiate(spawn, spawnPosition, Quaternion.identity); 
                    prevSRC.tag = "setsrc";
                    prevSRC.GetComponent<SpriteRenderer>().color=cc;
                    prevSRC.GetComponent<Renderer>().sortingOrder=10;
                    sx=hitObject.GetComponent<Flip>().x;
                    sy=hitObject.GetComponent<Flip>().y;
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
            if (hit.collider != null && hit.transform.gameObject.tag=="blk")
            {   
                if(prevDST){
                    Destroy(prevDST);
                }
                    GameObject hitObject = hit.collider.gameObject;

                    pdst=hitObject.GetComponent<SpriteRenderer>().color;

                    if(psrc!=pdst || psrc==MET.zero){
                        tc.openconfirmationwindow("invalid cell. make sure both should be blue!");
                    }else
                    {
                    Vector3 spawnPosition = hitObject.transform.position;
                    prevDST=Instantiate(spawn, spawnPosition, Quaternion.identity); 
                    prevDST.tag = "setsrc";
                    prevDST.GetComponent<SpriteRenderer>().color=rr;
                    prevDST.GetComponent<Renderer>().sortingOrder=10;
                    dx=hitObject.GetComponent<Flip>().x;
                    dy=hitObject.GetComponent<Flip>().y;
                    }
            }

        }

        if(Input.GetKeyDown(KeyCode.D)){
            Debug.Log("removed");
            remove();
        }

        if(Input.GetKeyDown(KeyCode.R)){
            if(prevDST){
                Destroy(prevDST);
            }
            if(prevSRC){
                Destroy(prevSRC);
            }
        }
        // if(pdst && pdst.GetComponent<SpriteRenderer>().color==pathColor){
        //     remove();
        // }
    }
    
    public static void remove()
    {
    //    for(int i=0;i<MET.ROW;i++){
    //     for(int j=0;j<MET.COL;j++){
    //         if(
    //             MET.myArray[i,j].GetComponent<SpriteRenderer>().color==Color.red || MET.myArray[i,j].GetComponent<SpriteRenderer>().color==Color.green
    //         ){
    //             MET.myArray[i,j].GetComponent<SpriteRenderer>().color=MET.one;
    //             Debug.Log("happen");
    //         }
    //     }
    //    }
    //             MET.myArray[dx,dy].GetComponent<SpriteRenderer>().color=MET.one;
            Destroy(prevDST);
            Destroy(prevSRC);
    }
}
