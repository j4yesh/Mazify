using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class State{
    public int [,]celli=new int [8,8];
    public Vector3 pos=new Vector3();
    public Color [,] verticalWall=new Color[9,9];
    public Color [,] horizontolWall=new Color[9,9];
    public int r=9,c=9;
    public State(int [,]cell,Vector3 posi, GameObject [,] ver,GameObject [,] hor){
        for(int i=0;i<r;i++){
            for(int j=0;j<c;j++){
                if(i<8 && j<8)this.celli[i,j]=cell[i,j];
                if(ver[i,j]){
                    this.verticalWall[i,j]=ver[i,j].GetComponent<SpriteRenderer>().color;
                }
                if(hor[i,j]){
                    this.horizontolWall[i,j]=hor[i,j].GetComponent<SpriteRenderer>().color;
                }
            }
        }
                this.pos=posi;
    }
}

public class botify : MonoBehaviour
{
    public float raycastDistance = 10f; // The distance to cast the rays
    public List<State>Trip=new List<State>();
    struct Node
    {
        public int row, col;
        public bool nev;
        public bool[] wall;
    }

    static int ROW = 8;
    static int COL = 8;
    public float DELAY=0.01f;
    public testconfirmation tc;

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
    static int[,] valueExtractor = new int[8, 8]
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
    public GameObject[] objectsWithTag;
     private TrailRenderer trailRenderer;    
    private List<Coroutine> activeCoroutines = new List<Coroutine>();
    void Start()
    {   
         trailRenderer = GetComponent<TrailRenderer>();
        objectsWithTag = GameObject.FindGameObjectsWithTag("frontback");
        foreach (GameObject obj in objectsWithTag)
                {
                    Button khupBhari=obj.GetComponent<Button>();
                    khupBhari.interactable=false;
                }
        Invoke("kuchTohKarkeExecutekr",1f);
    }
     private void StopAllCoroutines()
    {
        foreach (Coroutine coroutine in activeCoroutines)
        {
            StopCoroutine(coroutine);
        }
        activeCoroutines.Clear();
    }

    void kuchTohKarkeExecutekr(){
         trips = new List<KeyValuePair<int,int>>();
        retTrip = new Node[ROW, COL];

        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {   
                realMazeController.cell[i,j].GetComponent<bluep>().num.text=cell[i,j].ToString();
                celler[i, j] = new Node();
                celler[i, j].wall = new bool[4];
                celler[i, j].wall[0] = true;
                celler[i, j].wall[1] = true;
                celler[i, j].wall[2] = true;
                celler[i, j].wall[3] = true;
            }
        }

        for (int i = 0; i < ROW; i++)
        {
            celler[0, i].wall[0] = false;
            celler[ROW - 1, i].wall[1] = false;
            celler[i, ROW - 1].wall[2] = false;
            celler[i, 0].wall[3] = false;
        }

    }
    public void CallTheFloodFill(){
        Coroutine coroutine = StartCoroutine( Solve(7, 0));
        activeCoroutines.Add(coroutine);
    }
    int idx=0;
        void Update()
        {
           if(Input.GetKeyDown(KeyCode.C)){    
                StartCoroutine(Solve(7, 0));
           }
           if(Input.GetKeyDown(KeyCode.M)){
            forwardIterate();
           }
           if(Input.GetKeyDown(KeyCode.N)){
            backwardIterate();
           }
           if(Input.GetKeyDown(KeyCode.G)){
            checkSolutionExist(7,0);
           }
        }
    
    public void forwardIterate(){
        if(idx+1<0 || idx+1>=Trip.Count){
            changeState();
            return;
        }
        idx++;changeState();
    }
    public void backwardIterate(){
        if(idx-1<0 || idx-1>=Trip.Count){
            changeState();
            return;
        }
        idx--;changeState();
    }
    void changeState(){
        for(int i=0;i<9;i++){
            for(int j=0;j<9;j++){
                if(realMazeController.cell[i,j]){
                realMazeController.cell[i,j].GetComponent<bluep>().num.text=Trip[idx].celli[i,j].ToString();
                }
                if(realMazeController.verticalWall[i,j]){
                    realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color=Trip[idx].verticalWall[i,j];
                }
                if(realMazeController.horizontolwall[i,j]){
                    realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=Trip[idx].horizontolWall[i,j];
                }
            }
        }
        transform.position=Trip[idx].pos;
    }
    bool RightSensor()
    {
        Ray ray = new Ray(transform.position, Vector3.right);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, raycastDistance);

        if (hit.collider != null && (hit.collider.gameObject.tag == "vw" || hit.collider.gameObject.tag == "hw"))
        {
            if (hit.collider.gameObject.GetComponent<SpriteRenderer>().color == MET.one || hit.collider.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
            {
                Debug.Log("Right sensor hit");
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                return false;
            }
        }
        return true;
    }

    bool LeftSensor()
    {
        Ray ray = new Ray(transform.position, Vector3.left);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, raycastDistance);

        if (hit.collider != null && (hit.collider.gameObject.tag == "vw" || hit.collider.gameObject.tag == "hw"))
        {
            if (hit.collider.gameObject.GetComponent<SpriteRenderer>().color == MET.one || hit.collider.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
            {
                Debug.Log("Left sensor hit");
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                return false;
            }
        }
        return true;
    }

    bool DownSensor()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, raycastDistance);

        if (hit.collider != null && (hit.collider.gameObject.tag == "vw" || hit.collider.gameObject.tag == "hw"))
        {
            if (hit.collider.gameObject.GetComponent<SpriteRenderer>().color == MET.one || hit.collider.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
            {
                Debug.Log("Down sensor hit");
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                return false;
            }
        }
        return true;
    }

    bool UpSensor()
    {
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, raycastDistance);

        if (hit.collider != null && (hit.collider.gameObject.tag == "vw" || hit.collider.gameObject.tag == "hw"))
        {
            if (hit.collider.gameObject.GetComponent<SpriteRenderer>().color == MET.one || hit.collider.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
            {
                Debug.Log("Up sensor hit");
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                return false;
            }
        }
        return true;
    }

     bool[] GetInput()
    {   
         bool[] a = new bool[4];
        a[0] = UpSensor();
        a[1] = DownSensor();
        a[2] = RightSensor();
        a[3] = LeftSensor();
        Debug.Log("Sensor values:");
        Debug.Log("Up: " + a[0]);
        Debug.Log("Down: " + a[1]);
        Debug.Log("Right: " + a[2]);
        Debug.Log("Left: " + a[3]);

        return a;
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
                if(i==0 && temp.Key-1>=0){
                    celler[temp.Key-1,temp.Value].wall[1]=false;
                }
                else if(i==1 && temp.Key+1<8){
                    celler[temp.Key+1,temp.Value].wall[0]=false;
                }
                else if(i==2 && temp.Value+1<8){
                    celler[temp.Key,temp.Value+1].wall[3]=false;
                }else if(temp.Value-1>=0){
                    celler[temp.Key,temp.Value-1].wall[2]=false;
                }
            }
        }
    }

    void Queken(Queue<KeyValuePair<int, int>> q, KeyValuePair<int, int> pr)
    {
        List<KeyValuePair<int, KeyValuePair<int, int>>> vr = new List<KeyValuePair<int, KeyValuePair<int, int>>>();

        if (celler[pr.Key, pr.Value].wall[0])
        {
            KeyValuePair<int, int> innerPair = new KeyValuePair<int, int>(pr.Key -1, pr.Value);
            KeyValuePair<int, KeyValuePair<int, int>> outerPair = new KeyValuePair<int, KeyValuePair<int, int>>(cell[pr.Key -1, pr.Value], innerPair);
            vr.Add(outerPair);
        }
        if (celler[pr.Key, pr.Value].wall[2])
        {
            KeyValuePair<int, int> innerPair = new KeyValuePair<int, int>(pr.Key, pr.Value + 1);
            KeyValuePair<int, KeyValuePair<int, int>> outerPair = new KeyValuePair<int, KeyValuePair<int, int>>(cell[pr.Key, pr.Value + 1], innerPair);
            vr.Add(outerPair);
        }
        if (celler[pr.Key, pr.Value].wall[1])
        {
            KeyValuePair<int, int> innerPair = new KeyValuePair<int, int>(pr.Key +1, pr.Value);
            KeyValuePair<int, KeyValuePair<int, int>> outerPair = new KeyValuePair<int, KeyValuePair<int, int>>(cell[pr.Key +1, pr.Value], innerPair);
            vr.Add(outerPair);
        }
        if (celler[pr.Key, pr.Value].wall[3])
        {
            KeyValuePair<int, int> innerPair = new KeyValuePair<int, int>(pr.Key, pr.Value - 1);
            KeyValuePair<int, KeyValuePair<int, int>> outerPair = new KeyValuePair<int, KeyValuePair<int, int>>(cell[pr.Key, pr.Value - 1], innerPair);
            vr.Add(outerPair);
        }

        int minValue = int.MaxValue;
        foreach (var it in vr)
        {
            minValue = Math.Min(it.Key, minValue);
        }
        if (minValue != int.MaxValue && cell[pr.Key, pr.Value] <= minValue)
        {
            cell[pr.Key, pr.Value] = minValue + 1;
            foreach (var it in vr)
            {
                q.Enqueue(new KeyValuePair<int, int>(it.Value.Key, it.Value.Value));
            }
            Debug.Log("minValue: " + minValue);
        }
    }


    bool QNeeded(KeyValuePair<int, int> pr)
    {
        List<int> v = new List<int>();

        if (celler[pr.Key, pr.Value].wall[0])
        {
            v.Add(cell[pr.Key - 1, pr.Value]);
        }
        if (celler[pr.Key, pr.Value].wall[1])
        {
            v.Add(cell[pr.Key + 1, pr.Value]);
        }
        if (celler[pr.Key, pr.Value].wall[2])
        {
            v.Add(cell[pr.Key, pr.Value + 1]);
        }
        if (celler[pr.Key, pr.Value].wall[3])
        {
            v.Add(cell[pr.Key, pr.Value - 1]);
        }
        if(v.Count==0){
            return false;
        }
        if (v.Count == 1)
        {
            Debug.Log("Only one element in queue");
            return false;
        }
        int firstElement = v[0];
        for (int i = 1; i < v.Count; i++)
        {
            if (v[i] != firstElement)
            {
                Debug.Log("Not all elements in queue are same");
                return false;
            }
        }
        return true;
    }

    int BringTheVal(int val)
    {
        List<int> v = new List<int>();
        Debug.Log("pixel is: ");
        Debug.Log(cur.Key);
        Debug.Log(cur.Value);
        if (celler[cur.Key, cur.Value].wall[0])
        {   
            v.Add(cell[cur.Key - 1, cur.Value]); //-1
        }
        if (celler[cur.Key, cur.Value].wall[2])
        {
            v.Add(cell[cur.Key, cur.Value + 1]); //+1
        }
        if (celler[cur.Key, cur.Value].wall[1])
        {
            v.Add(cell[cur.Key + 1, cur.Value]); //+1
        }
        if (celler[cur.Key, cur.Value].wall[3]) 
        {
            v.Add(cell[cur.Key, cur.Value - 1]); //-1
        }
        if(v.Count==0){
            Debug.Log("just cannot!");
            return 0;
        }
        int temp = v[0];
        for (int i = 0; i < v.Count; i++)
        {
            if (temp > v[i])
            {
                temp = v[i];
            }
        }
        Debug.Log("Returning: " + temp);
        return temp;
    }

    IEnumerator Solve(int stx,int sty)
    {   
        trailRenderer.time=70;    
        
       foreach (GameObject obj in objectsWithTag)
                {
                    Button khupBhari=obj.GetComponent<Button>();
                    khupBhari.interactable=false;
                }
        transform.position=new Vector3(-5.49f,-3.996f,0f);

        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {
                cell[i,j]=valueExtractor[i,j];
                if(realMazeController.cell[i,j]){   
                realMazeController.cell[i,j].GetComponent<bluep>().num.text=cell[i,j].ToString();
                }
                celler[i, j] = new Node();
                celler[i, j].wall = new bool[4];
                celler[i, j].wall[0] = true;
                celler[i, j].wall[1] = true;
                celler[i, j].wall[2] = true;
                celler[i, j].wall[3] = true;
            }
        }

        for (int i = 0; i < ROW; i++)
        {
            celler[0, i].wall[0] = false;
            celler[ROW - 1, i].wall[1] = false;
            celler[i, ROW - 1].wall[2] = false;
            celler[i, 0].wall[3] = false;
        }

        cur = new KeyValuePair<int, int>(stx, sty);
        Trip.Clear();

        Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
        
        q.Enqueue(cur);

        bool[] a = new bool[4];
        Trip.Add(new State(cell,transform.position,realMazeController.verticalWall,realMazeController.horizontolwall));
        while (true)
        {   
            KeyValuePair<int, int> next = cur;
            int minVal = cell[cur.Key, cur.Value];
            a[0] = UpSensor();
            a[1] = DownSensor();
            a[2] = RightSensor();
            a[3] = LeftSensor();
            
            Debug.Log(a[0]);
            Debug.Log(a[1]);
            Debug.Log(a[2]);
            Debug.Log(a[3]);


            WallSaver(cur, a);
            checkSolutionExist(cur.Key,cur.Value);
            if (QNeeded(cur))  //if there are more than one way
            {
                Debug.Log("Queue needed:");
                while (q.Count > 0)
                {   
                    Debug.Log(q.Count+" q counter dude");
                    KeyValuePair<int, int> temp = q.Dequeue();
                    Queken(q, temp);
                }
            }
            else
            {
                while (q.Count > 0)
                {
                    q.Dequeue();
                }
            }

            if (BringTheVal(cell[cur.Key, cur.Value]) >= cell[cur.Key, cur.Value])
            {
                cell[cur.Key, cur.Value] = BringTheVal(cell[cur.Key, cur.Value]) + 1;
                realMazeController.cell[cur.Key,cur.Value].GetComponent<bluep>().num.text=cell[cur.Key,cur.Value].ToString();
            }

            string dir = "";
            if (a[0])
            {
                if (cell[cur.Key, cur.Value] > cell[cur.Key - 1, cur.Value])
                {
                    q.Enqueue(new KeyValuePair<int, int>(cur.Key - 1, cur.Value));
                    minVal = cell[cur.Key - 1, cur.Value];
                    next = new KeyValuePair<int, int>(cur.Key - 1, cur.Value);
                    dir = "top";
                }
            }

            if (a[2])
            {
                if (cell[cur.Key, cur.Value] > cell[cur.Key, cur.Value + 1])
                {
                    q.Enqueue(new KeyValuePair<int, int>(cur.Key, cur.Value + 1));
                    minVal = cell[cur.Key, cur.Value + 1];
                    next = new KeyValuePair<int, int>(cur.Key, cur.Value + 1);
                    dir = "right";
                }
            }
            
            if (a[1])
            {
                if (cell[cur.Key, cur.Value] > cell[cur.Key + 1, cur.Value])
                {
                    q.Enqueue(new KeyValuePair<int, int>(cur.Key + 1, cur.Value));
                    minVal = cell[cur.Key + 1, cur.Value];
                    next = new KeyValuePair<int, int>(cur.Key + 1, cur.Value);
                    Debug.Log("Moving down");
                    dir = "bottom";
                }
            }

            if (a[3])
            {
                if (cell[cur.Key, cur.Value] > cell[cur.Key, cur.Value - 1])
                {
                    q.Enqueue(new KeyValuePair<int, int>(cur.Key, cur.Value - 1));
                    minVal = cell[cur.Key, cur.Value - 1];
                    next = new KeyValuePair<int, int>(cur.Key, cur.Value - 1);
                    dir = "left";
                }
            }

            if(dir==""){
                StopAllCoroutines();
            }

            if (dir == "top")
            {
                MoveTop();
            }
            else if (dir == "bottom")
            {
                MoveDown();
            }
            else if (dir == "right")
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }

            yield return new WaitForSeconds(DELAY);

            cur = next;

            if (cell[cur.Key,cur.Value]==0 )
            {   
                foreach (GameObject obj in objectsWithTag)
                {
                    Button khupBhari=obj.GetComponent<Button>();
                    khupBhari.interactable=true;
                }
                Debug.Log("Finish!");
                 a[0] = UpSensor();
                 a[1] = DownSensor();
                 a[2] = RightSensor();
                 a[3] = LeftSensor();
                WallSaver(cur, a);
                Trip.Add(new State(cell,transform.position,realMazeController.verticalWall,realMazeController.horizontolwall));
                 for(int i=0;i<9;i++){
                    for(int j=0;j<9;j++){
                        if(realMazeController.cell[i,j]){
                        realMazeController.cell[i,j].GetComponent<bluep>().num.text=cell[i,j].ToString();
                        }
                    }
                }
                idx=Trip.Count-1;
                 trailRenderer.time=0;    
                yield break;
            }
            for(int i=0;i<9;i++){
                for(int j=0;j<9;j++){
                    if(realMazeController.cell[i,j]){
                    realMazeController.cell[i,j].GetComponent<bluep>().num.text=cell[i,j].ToString();
                    }
                }
            }
            Trip.Add(new State(cell,transform.position,realMazeController.verticalWall,realMazeController.horizontolwall));
        }
        
        trailRenderer.time=0;    
        yield break;
    }


        private void checkSolutionExist(int endx, int endy)
    {
        Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
        int[,] celity = new int[8, 8]
        {
            { -1,-1,-1,-1,-1,-1,-1,-1},
            { -1,-1,-1,-1,-1,-1,-1,-1},
            { -1,-1,-1,-1,-1,-1,-1,-1},
            { -1,-1,-1, 0, 0,-1,-1,-1},
            { -1,-1,-1, 0, 0,-1,-1,-1},
            { -1,-1,-1,-1,-1,-1,-1,-1},
            { -1,-1,-1,-1,-1,-1,-1,-1},
            { -1,-1,-1,-1,-1,-1,-1,-1},
        };
        int[,] vis = new int[8, 8]
        {
            { -1,-1,-1,-1,-1,-1,-1,-1},
            { -1,-1,-1,-1,-1,-1,-1,-1},
            { -1,-1,-1,-1,-1,-1,-1,-1},
            { -1,-1,-1, 1, 1,-1,-1,-1},
            { -1,-1,-1, 1, 1,-1,-1,-1},
            { -1,-1,-1,-1,-1,-1,-1,-1},
            { -1,-1,-1,-1,-1,-1,-1,-1},
            { -1,-1,-1,-1,-1,-1,-1,-1},
        };
        int layer = 0;
        q.Enqueue(new KeyValuePair<int, int>(3, 3));
        q.Enqueue(new KeyValuePair<int, int>(3, 4));
        q.Enqueue(new KeyValuePair<int, int>(4, 3));
        q.Enqueue(new KeyValuePair<int, int>(4, 4));

        while (q.Count > 0)
        {   
            int size = q.Count;
            for(int i=0;i<size;i++)
            {
                Debug.Log("calibrating");
                KeyValuePair<int, int> cur = q.Dequeue();
                celity[cur.Key, cur.Value] = layer;

                if (cur.Key - 1 >= 0 && vis[cur.Key - 1, cur.Value]==-1 && celler[cur.Key, cur.Value].wall[0])
                {
                    vis[cur.Key - 1, cur.Value]=1;
                    KeyValuePair<int, int> next = new KeyValuePair<int, int>(cur.Key - 1, cur.Value);
                    q.Enqueue(new KeyValuePair<int, int>(next.Key, next.Value));
                }
                if (cur.Value + 1 < 8 && vis[cur.Key, cur.Value+1]==-1 && celler[cur.Key, cur.Value].wall[2])
                {   
                    vis[cur.Key, cur.Value+1]=1;
                    KeyValuePair<int, int> next = new KeyValuePair<int, int>(cur.Key, cur.Value + 1);
                    q.Enqueue(new KeyValuePair<int, int>(next.Key, next.Value));
                }
                if (cur.Key + 1 < 8 && vis[cur.Key + 1, cur.Value]==-1&& celler[cur.Key, cur.Value].wall[1])
                {   
                    vis[cur.Key + 1, cur.Value]=1;
                    KeyValuePair<int, int> next = new KeyValuePair<int, int>(cur.Key + 1, cur.Value);
                    q.Enqueue(new KeyValuePair<int, int>(next.Key, next.Value));
                }
                if (cur.Value - 1 >= 0 && vis[cur.Key, cur.Value-1]==-1&& celler[cur.Key, cur.Value].wall[3])
                {   
                    vis[cur.Key , cur.Value-1]=1;
                    KeyValuePair<int, int> next = new KeyValuePair<int, int>(cur.Key, cur.Value - 1);
                    q.Enqueue(new KeyValuePair<int, int>(next.Key, next.Value));
                }
            }
            layer++;
        }
        if (celity[endx, endy] == -1)
        {
            Debug.Log("i said kill the coroutine");
            tc.openconfirmationwindow("solution does not exist");
            StopAllCoroutines();
        }else{
            Debug.Log("yes solution exist");
        }

    }

    

}





