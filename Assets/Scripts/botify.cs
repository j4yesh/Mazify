using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class botify : MonoBehaviour
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
        trips = new List<KeyValuePair<int,int>>();
        retTrip = new Node[ROW, COL];

        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < COL; j++)
            {
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

        cur = new KeyValuePair<int, int>(15, 0);
        retTrip[cur.Key, cur.Value].nev = true;
        trips.Add(cur);

    }

        void Update()
        {
           if(Input.GetKeyDown(KeyCode.C)){    
            Debug.Log("extended flood fill called at that moment\n ");
             StartCoroutine(Solve(7,0));
           }
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
                Debug.Log("Wall saved");
            }
        }
    }

    void Queken(Queue<KeyValuePair<int, int>> q, KeyValuePair<int, int> pr)
    {
        List<KeyValuePair<int, KeyValuePair<int, int>>> vr = new List<KeyValuePair<int, KeyValuePair<int, int>>>();

        if (celler[pr.Key, pr.Value].wall[0])
        {
            KeyValuePair<int, int> innerPair = new KeyValuePair<int, int>(pr.Key - 1, pr.Value);
            KeyValuePair<int, KeyValuePair<int, int>> outerPair = new KeyValuePair<int, KeyValuePair<int, int>>(cell[pr.Key - 1, pr.Value], innerPair);
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
            KeyValuePair<int, int> innerPair = new KeyValuePair<int, int>(pr.Key + 1, pr.Value);
            KeyValuePair<int, KeyValuePair<int, int>> outerPair = new KeyValuePair<int, KeyValuePair<int, int>>(cell[pr.Key + 1, pr.Value], innerPair);
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
            v.Add(cell[cur.Key - 1, cur.Value]);
        }
        if (celler[cur.Key, cur.Value].wall[2])
        {
            v.Add(cell[cur.Key, cur.Value + 1]);
        }
        if (celler[cur.Key, cur.Value].wall[1])
        {
            v.Add(cell[cur.Key + 1, cur.Value]);
        }
        if (celler[cur.Key, cur.Value].wall[3])
        {
            v.Add(cell[cur.Key, cur.Value - 1]);
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

    IEnumerator backtrip(){
         bool [,] retEarn= new bool [ROW,ROW];
        for(int i=0;i<ROW;i++){
            for(int j=0;j<ROW;j++){
            retEarn[i,j]=false;
            }
        }
        for(int i=0;i<trips.Count;i++){
            retEarn[trips[i].Key,trips[i].Value]=true;
        }
            String str="";
        for(int i=0;i<ROW;i++){
            for(int j=0;j<ROW;j++){
                if(retEarn[i,j]==false){
                    str+="0";
                }else{
                    str+="1";
                }
            }
        }
            Debug.Log(str);
    Debug.Log("starting return journey \n");
        while(cur.Key!=4 || cur.Value!=0){

            for(int i=0;i<4;i++){
             Debug.Log(celler[cur.Key,cur.Value].wall[i]+" | ");     
            }

            Debug.Log(cur.Key);
            Debug.Log(cur.Value);
        if(celler[cur.Key,cur.Value].wall[0] && retEarn[cur.Key-1,cur.Value]){
            MoveTop();
            retEarn[cur.Key,cur.Value]=false;
            cur=new KeyValuePair<int, int>(cur.Key-1, cur.Value);
        }
        else if(celler[cur.Key,cur.Value].wall[2] && retEarn[cur.Key,cur.Value+1]){
            MoveRight();
            retEarn[cur.Key,cur.Value]=false;
            cur=new KeyValuePair<int, int>(cur.Key, cur.Value+1);
        }
        else if(celler[cur.Key,cur.Value].wall[1] && retEarn[cur.Key+1,cur.Value]){
            MoveDown();
            retEarn[cur.Key,cur.Value]=false;
            cur=new KeyValuePair<int, int>(cur.Key+1, cur.Value);
        }
        else if(celler[cur.Key,cur.Value].wall[3] && retEarn[cur.Key,cur.Value-1]){
            MoveLeft();
            retEarn[cur.Key,cur.Value]=false;
            cur=new KeyValuePair<int, int>(cur.Key, cur.Value-1);
        }
        yield return new WaitForSeconds(0.03f);
        }
        yield break;
    }

    IEnumerator Solve(int stx,int sty)
    {
        for (int i = 0; i < ROW; i++)
        {
            for (int j = 0; j < ROW; j++)
            {
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
        //retTrip[cur.Key, cur.Value].nev = true;
        // trips.Add(cur);

        Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
        q.Enqueue(cur);

        bool[] a = new bool[4];

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

            if (QNeeded(cur))
            {
                Debug.Log("Queue needed:");
                while (q.Count > 0)
                {
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

            Debug.Log(next.Key + " " + next.Value);
            if (retTrip[next.Key, next.Value].nev)
            {
                Debug.Log("One detected");
                retTrip[cur.Key, cur.Value].nev = false;
                trips.RemoveAt(trips.Count - 1);
                Debug.Log("Popping");
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

            yield return new WaitForSeconds(0.03f);

            cur = next;
            if (!retTrip[cur.Key, cur.Value].nev)
            {
                trips.Add(cur);
                Debug.Log("Pushing");
            }
            retTrip[cur.Key, cur.Value].nev = !retTrip[cur.Key, cur.Value].nev;

            if ((cur.Key == 8 && cur.Value==8)||(cur.Key == 8 && cur.Value==7)||(cur.Key == 7 && cur.Value==8)||(cur.Key == 7 && cur.Value==7))
            {
                Debug.Log("Finish!");
                 a[0] = UpSensor();
                 a[1] = DownSensor();
                 a[2] = RightSensor();
                 a[3] = LeftSensor();
                WallSaver(cur, a);

                // StartCoroutine(backtrip());
                yield break;
            }
        }
    }
}





