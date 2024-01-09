using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class overload : MonoBehaviour
{
    public Vector3 pos { get; set; }
    public KeyValuePair<int, int> kvp { get; set; }

    // Constructor with parameters
    public overload(Vector3 position1, int u,int y)
    {
        pos = position1;
        kvp = new KeyValuePair<int,int>(u,y);
    }

    // Default constructor
    public overload()
    {
        pos = Vector3.zero;
        kvp = new KeyValuePair<int, int>(0, 0);
    }

    // Example method
    public void PrintValues()
    {
        Debug.Log("Position: " + pos + ", Key: " + kvp.Key + ", Value: " + kvp.Value);
    }
}

public class realMazeGen : MonoBehaviour
{
    public float raycastDistance = 10f; // The distance to cast the rays

    struct Node
    {
        public int row, col;
        public bool nev;
        public bool[] wall;
    }

    static int ROW = 8;
    static int COL = 8;
    public float DELAY=0.01f;
    static List<KeyValuePair<int,int>> trips;
    static Node[,] celler = new Node[8, 8];

    static KeyValuePair<int, int> cur = new KeyValuePair<int, int>(0, 0);
    static Node[,] retTrip;

    static int[,] cell = new int[8, 8]
    {
   
        { 6,  5,  4,  3,  3,  4,  5,  6},
        { 5,  4,  3,  2,  2,  3,  4,  5},
        { 4,  3,  2,  1,  1,  2,  3,  4},
        { 3,  2,  1,  0,  0,  1,  2,  3},
        { 3,  2,  1,  0,  0,  1,  2,  3},
        { 4,  3,  2,  1,  1,  2,  3,  4},
        { 5,  4,  3,  2,  2,  3,  4,  5},
        { 6,  5,  4,  3,  3,  4,  5,  6},
   
    };
    
    void Start()
    {
    }
    
        void Update()
        {
           if(Input.GetKeyDown(KeyCode.V)){    
                Debug.Log("extended flood fill called at that moment\n ");
                StartCoroutine(Solve(7, 0));
           }
          
        }


    bool RightSensor()
    {
        Ray ray = new Ray(transform.position, Vector3.right);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, raycastDistance);

        if (hit.collider != null && (hit.collider.gameObject.tag == "vw" || hit.collider.gameObject.tag == "hw"))
        {
            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = MET.zero;
        }
        return true;
    }

    bool LeftSensor()
    {
        Ray ray = new Ray(transform.position, Vector3.left);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, raycastDistance);

        if (hit.collider != null && (hit.collider.gameObject.tag == "vw" || hit.collider.gameObject.tag == "hw"))
        {
            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = MET.zero;
        }
        return true;
    }

    bool DownSensor()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, raycastDistance);

        if (hit.collider != null && (hit.collider.gameObject.tag == "vw" || hit.collider.gameObject.tag == "hw"))
        {
            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = MET.zero;
        }
        return true;
    }

    bool UpSensor()
    {
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, raycastDistance);

        if (hit.collider != null && (hit.collider.gameObject.tag == "vw" || hit.collider.gameObject.tag == "hw"))
        {
            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = MET.zero;
        }
        return true;
    }

    void MoveTop()
    {
        transform.position += new Vector3(0f, 1f, 0f);
    }

    void MoveDown()
    {
        transform.position += new Vector3(0f, -1f, 0f);
    }

    void MoveLeft()
    {
        transform.position += new Vector3(-1f, 0f, 0f);
    }

    void MoveRight()
    {
        transform.position += new Vector3(1f, 0f, 0f);
    }

    void WallSaver(KeyValuePair<int, int> temp, bool[] a)
    {
        for (int i = 0; i < 4; i++)
        {
            if (!a[i])
            {
                celler[temp.Key, temp.Value].wall[i] = false;
                Debug.Log("Wall saved");
            }
        }
    }
    private void removeWall(Vector3 next) {
        Vector3 cur = transform.position;

        if (cur + new Vector3(1f, 0f, 0f) == next) {
            RightSensor();
        }
        else if (cur + new Vector3(-1f, 0f, 0f) == next) {
            LeftSensor();
        }
        else if (cur + new Vector3(0f, 1f, 0f) == next) {
            UpSensor();
        }
        else if (cur + new Vector3(0f, -1f, 0f) == next) {
            DownSensor();
        }
    }
    IEnumerator Solve(int stx,int sty)
    {   
   

        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {   
                realMazeController.cell[i,j].GetComponent<bluep>().num.text="0";
                cell[i,j]=0;
            }
        }
       

        cur = new KeyValuePair<int, int>(stx, sty);

        Stack<overload>st=new Stack<overload>();
        st.Push(new overload(transform.position,stx,sty));

         realMazeController.cell[cur.Key,cur.Value].GetComponent<bluep>().num.text="0";
         cell[cur.Key,cur.Value]=0;
         bool[] a = new bool[4];

             int cnt=0;
         while (st.Count>0)
         {   
             overload c=st.Pop();
            Debug.Log(c.kvp.Key+"  |  "+c.kvp.Value);
            //   a[0] = UpSensor();
            //   a[1] = DownSensor();
            //   a[2] = RightSensor();
            //   a[3] = LeftSensor();
            
            if(cnt==0){
                removeWall(c.pos);
                transform.position=c.pos;
            }else{
                removeWall(c.pos);
                transform.position=c.pos;
                cnt=0;
            }
            yield return new WaitForSeconds(0.2f);
             if(c.kvp.Key-1>=0 && cell[c.kvp.Key-1,c.kvp.Value]==0){
                 cnt++;
                 cell[c.kvp.Key-1,c.kvp.Value]=1; 
                 Vector3 nextPos=transform.position;
                 nextPos += new Vector3(0f, 1f, 0f);
                 st.Push(new overload(nextPos,c.kvp.Key-1,c.kvp.Value));
             }
             if(c.kvp.Key+1<ROW && cell[c.kvp.Key+1,c.kvp.Value]==0){
                 cnt++;
                 cell[c.kvp.Key+1,c.kvp.Value]=1;
                 Vector3 nextPos=transform.position;
                 nextPos += new Vector3(0f, -1f, 0f);
                 st.Push(new overload(nextPos,c.kvp.Key+1,c.kvp.Value));
             }
             if(c.kvp.Value+1<COL && cell[c.kvp.Key,c.kvp.Value+1]==0){
                 cnt++;
                 cell[c.kvp.Key,c.kvp.Value+1]=1;
                  Vector3 nextPos=transform.position;
                 nextPos += new Vector3(1f, 0f, 0f);
                 st.Push(new overload(nextPos,c.kvp.Key,c.kvp.Value+1));
             }
             if(c.kvp.Value-1>=0 && cell[c.kvp.Key,c.kvp.Value-1]==0){
                 cnt++;
                 cell[c.kvp.Key,c.kvp.Value-1]=1;
                  Vector3 nextPos=transform.position;
                 nextPos += new Vector3(-1f, 0f, 0f);
                 st.Push(new overload(nextPos,c.kvp.Key,c.kvp.Value-1));
             }
            
         }
        yield break;
    }
}
