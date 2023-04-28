using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SETDSTSRC : MonoBehaviour
{
    private GameObject prevSRC;
    private GameObject prevDST;
    private bool srcass=false;
    private bool dstass=false;

    public static Color cc = Color.blue;
   
    public static Color rr = Color.green;

    public static SETDSTSRC sds;

    private GameObject spawn;

    public static int sx=0,sy=0,dx=18,dy=25;

    private void Start()
    {   
       sx=0;sy=0;dx=MET.ROW;dy=MET.COL; 
       spawn=GameObject.FindWithTag("blk"); 
       if(sds!=null){
            Destroy(this.gameObject);
            return;
       }
       sds=this;
       GameObject.DontDestroyOnLoad(gameObject);
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
                    Vector3 spawnPosition = hitObject.transform.position;
                    prevSRC=Instantiate(spawn, spawnPosition, Quaternion.identity); 
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
                    Vector3 spawnPosition = hitObject.transform.position;
                    prevDST=Instantiate(spawn, spawnPosition, Quaternion.identity); 
                    prevDST.GetComponent<SpriteRenderer>().color=rr;
                    prevDST.GetComponent<Renderer>().sortingOrder=10;
                dx=hitObject.GetComponent<Flip>().x;
                dy=hitObject.GetComponent<Flip>().y;
            }
        }
    }
}
