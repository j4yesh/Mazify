using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SETDSTSRC : MonoBehaviour
{
    private bool srcass = false;
    private bool dstass = false;

    public static Color cc = Color.blue;
    public static Color rr = Color.red; 

    public Color psrc = Color.magenta; 
    public Color pdst = Color.magenta; 

    public static SETDSTSRC sds;

    private GameObject spawn;

    public static int sx = 0, sy = 0, dx = 18, dy = 25;

    private Color pathColor = new Color(1f, 0.92f, 0.016f, 1f);

    [SerializeField]
    public testconfirmation tc;

    private KeyValuePair<int, int> prevSRC = new KeyValuePair<int, int>(-1, -1);
    private KeyValuePair<int, int> prevDST = new KeyValuePair<int, int>(-1, -1);
    private void Start()
    {
        // Remove unnecessary comments and assignments
        // sx = 0; sy = 0; dx = MET.ROW; dy = MET.COL;
        spawn = GameObject.FindWithTag("blk");
        // if (sds != null)
        // {
        //     Destroy(this.gameObject);
        //     return;
        // }
        // sds = this;
        // GameObject.DontDestroyOnLoad(gameObject);
        for (int i = 0; i < MET.ROW; i++)
        {
            for (int j = 0; j < MET.COL; j++)
            {
                if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color == Color.blue)
                {
                    // Debug.Log("happening");
                    prevSRC = new KeyValuePair<int, int>(i, j);
                    psrc=MET.one;
                }
                else if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color == Color.red)
                {
                    prevDST = new KeyValuePair<int, int>(i, j);
                    pdst=Color.red;
                }
            }
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
            if (hit.collider != null && hit.transform.gameObject.tag == "blk")
            {   
                GameObject hitObject = hit.collider.gameObject;
                if(hitObject.GetComponent<SpriteRenderer>().color!=MET.one){
                     tc.openconfirmationwindow("Only blue pixel can be set as SRC/DST!"); 
                }else{
                Vector3 spawnPosition = hitObject.transform.position;
                Color temp = hitObject.GetComponent<SpriteRenderer>().color ;
                hitObject.GetComponent<SpriteRenderer>().color = Color.blue;
                if (prevSRC.Key != -1)
                {
                    MET.myArray[prevSRC.Key, prevSRC.Value].GetComponent<SpriteRenderer>().color = psrc;
                }
                psrc = temp;
                prevSRC = new KeyValuePair<int, int>(hitObject.GetComponent<Flip>().x, hitObject.GetComponent<Flip>().y);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
            if (hit.collider != null && hit.transform.gameObject.tag == "blk")
            {
                GameObject hitObject = hit.collider.gameObject;
                pdst = hitObject.GetComponent<SpriteRenderer>().color;
                if (psrc != pdst)
                {
                    tc.openconfirmationwindow("Invalid choice!"); // Change "invalid h brohh!" to "Invalid choice!"
                }
                else
                {   
                    if(prevDST.Key!=-1){
                        MET.myArray[prevDST.Key,prevDST.Value].GetComponent<SpriteRenderer>().color=pdst;
                    }
                    Vector3 spawnPosition = hitObject.transform.position;
                    hitObject.GetComponent<SpriteRenderer>().color = Color.red;
                    prevDST = new KeyValuePair<int, int>(hitObject.GetComponent<Flip>().x, hitObject.GetComponent<Flip>().y);
                    
                    // dx = prevDST.Key;
                    // dy = prevDST.Value;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Removed");
            remove();
        }
    }

    public void remove()
    {
       for(int i=0;i<MET.ROW;i++){
        for(int j=0;j<MET.COL;j++){
            if(
                MET.myArray[i,j].GetComponent<SpriteRenderer>().color==Color.red || MET.myArray[i,j].GetComponent<SpriteRenderer>().color==Color.blue
            ){
                MET.myArray[i,j].GetComponent<SpriteRenderer>().color=MET.one;
            }
        }
       }
    }
    
}



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class SETDSTSRC : MonoBehaviour
// {
//     private bool srcass=false;
//     private bool dstass=false;

//     public static Color cc = Color.blue;
   
//     public static Color rr = Color.green;

//     public Color psrc=MET.zero;

//     public Color pdst=MET.zero;

//     public static SETDSTSRC sds;

//     private GameObject spawn;

//     public static int sx=0,sy=0,dx=18,dy=25;

//     private Color pathColor=new Color(1f, 0.92f, 0.016f, 1f);

//     [SerializeField]
//     public testconfirmation tc;

//     private void Start()
//     {  
//     //    sx=0;sy=0;dx=MET.ROW;dy=MET.COL; 
//        spawn=GameObject.FindWithTag("blk"); 
//        if(sds!=null){
//             Destroy(this.gameObject);
//             return;
//        }
//        sds=this;
//        GameObject.DontDestroyOnLoad(gameObject);
//     }
//     private KeyValuePair<int,int>prevSRC=new KeyValuePair<int, int>(-1,-1);
//     private KeyValuePair<int,int>prevDST=new KeyValuePair<int, int>(-1,-1);
//     private void Update()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//             Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
//             if (hit.collider != null && hit.transform.gameObject.tag=="blk")
//             {   
//                     GameObject hitObject = hit.collider.gameObject;
//                     Vector3 spawnPosition = hitObject.transform.position;
//                     hitObject.GetComponent<SpriteRenderer>().color=Color.blue;
//                     if(prevSRC.Key!=-1){
//                         MET.myArray[prevSRC.Key,prevSRC.Value].GetComponent<SpriteRenderer>().color=psrc;
//                     }
//                     psrc=hitObject.GetComponent<SpriteRenderer>().color;
//                     prevSRC=new KeyValuePair<int,int>(hitObject.GetComponent<Flip>().x,GetComponent<Flip>().y);
//             }
//         }


//         // if (Input.GetMouseButtonDown(1))
//         // {
//         //     Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         //     RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
//         //     if (hit.collider != null && hit.transform.gameObject.tag=="blk")
//         //     {   
//         //         if(prevDST){
//         //             Destroy(prevDST);
//         //         }
//         //             GameObject hitObject = hit.collider.gameObject;

//         //             pdst=hitObject.GetComponent<SpriteRenderer>().color;

//         //             if(psrc!=pdst || psrc==MET.zero){
//         //                 tc.openconfirmationwindow("invalid h brohh!");
//         //             }else
//         //             {
//         //             Vector3 spawnPosition = hitObject.transform.position;
//         //             hitObject.GetComponent<SpriteRenderer>().color=Color.red;
//         //             }
//         //     }

//         // }

//         if(Input.GetKeyDown(KeyCode.D)){
//             Debug.Log("removed");
//             // remove();
//         }
//         // if(pdst && pdst.GetComponent<SpriteRenderer>().color==pathColor){
//         //     remove();
//         // }
//     }
    
// }



// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;
// // using TMPro;

// // public class SETDSTSRC : MonoBehaviour
// // {
// //     public static GameObject prevSRC;
// //     public static GameObject prevDST;
// //     private bool srcass=false;
// //     private bool dstass=false;

// //     public static Color cc = Color.blue;
   
// //     public static Color rr = Color.green;

// //     public Color psrc=MET.zero;

// //     public Color pdst=MET.zero;

// //     public static SETDSTSRC sds;

// //     private GameObject spawn;

// //     public static int sx=0,sy=0,dx=18,dy=25;

// //     private Color pathColor=new Color(1f, 0.92f, 0.016f, 1f);

// //     [SerializeField]
// //     public testconfirmation tc;

// //     private void Start()
// //     {  
// //        sx=0;sy=0;dx=MET.ROW;dy=MET.COL; 
// //        spawn=GameObject.FindWithTag("blk"); 
// //        if(sds!=null){
// //             Destroy(this.gameObject);
// //             return;
// //        }
// //        sds=this;
// //        GameObject.DontDestroyOnLoad(gameObject);
// //     }

// //     private void Update()
// //     {
// //         if (Input.GetMouseButtonDown(0))
// //         {
// //             Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
// //             RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
// //             if (hit.collider != null && hit.transform.gameObject.tag=="blk")
// //             {   
// //                 if(prevSRC){
// //                     Destroy(prevSRC);
// //                 }
// //                     GameObject hitObject = hit.collider.gameObject;

// //                     psrc=hitObject.GetComponent<SpriteRenderer>().color;

// //                     Vector3 spawnPosition = hitObject.transform.position;
// //                     prevSRC=Instantiate(spawn, spawnPosition, Quaternion.identity); 
// //                     prevSRC.GetComponent<SpriteRenderer>().color=cc;
// //                     prevSRC.GetComponent<Renderer>().sortingOrder=10;
// //                     sx=hitObject.GetComponent<Flip>().x;
// //                     sy=hitObject.GetComponent<Flip>().y;
// //                     MET.source=new KeyValuePair<int,int>(sx,sy);
// //             }
// //         }


// //         if (Input.GetMouseButtonDown(1))
// //         {
// //             Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
// //             RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
// //             if (hit.collider != null && hit.transform.gameObject.tag=="blk")
// //             {   
// //                 if(prevDST){
// //                     Destroy(prevDST);
// //                 }
// //                     GameObject hitObject = hit.collider.gameObject;

// //                     pdst=hitObject.GetComponent<SpriteRenderer>().color;

// //                     if(psrc!=pdst || psrc==MET.zero){
// //                         tc.openconfirmationwindow("invalid h brohh!");
// //                     }else
// //                     {
// //                     Vector3 spawnPosition = hitObject.transform.position;
// //                     prevDST=Instantiate(spawn, spawnPosition, Quaternion.identity); 
// //                     prevDST.GetComponent<SpriteRenderer>().color=rr;
// //                     prevDST.GetComponent<Renderer>().sortingOrder=10;
// //                     dx=hitObject.GetComponent<Flip>().x;
// //                     dy=hitObject.GetComponent<Flip>().y;
// //                     MET.destination=new KeyValuePair<int,int>(dx,dy);
// //                     }
// //             }

// //         }

// //         if(Input.GetKeyDown(KeyCode.D)){
// //             Debug.Log("removed");
// //             remove();
// //         }

// //         if(Input.GetKeyDown(KeyCode.R)){
// //             if(prevDST){
// //                 Destroy(prevDST);
// //             }
// //             if(prevSRC){
// //                 Destroy(prevSRC);
// //             }
// //         }
// //         // if(pdst && pdst.GetComponent<SpriteRenderer>().color==pathColor){
// //         //     remove();
// //         // }
// //     }
    
// //     public void remove(){
// //             Destroy(prevDST);
// //             Destroy(prevSRC);
// //     }
// // }
