using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Concurrent;

public class Graph
{
    public int V; // Number of vertices
    public List<List<int>> admet; // adjacency list

    public Graph(int V)
    {
        this.V = V;
        admet = new List<List<int>>(V);
        for (int i = 0; i < V; i++)
        {
            admet.Add(new List<int>());
        }
    }

    public void addEdge(int u, int v)
    {
        admet[u].Add(v);
    }

    public void print()
    {
        for (int i = 0; i < V; i++)
        {
            Debug.Log("Vertex " + i + ":");
            foreach (int v in admet[i])
            {
                Debug.Log(" " + v);
            }
        }
    }
}

public class bfs : MonoBehaviour
{

    [SerializeField]
    public static Color INSIDER = new Color(1f, 0.255f, 0.086f);
    public static Color BORDER = new Color(1f, 0.325f, 0f);

    private float DELAY = 2f;

    [SerializeField]
    private testconfirmation tc;

    List<KeyValuePair<int, int>> adj = new List<KeyValuePair<int, int>>(514);

    ConcurrentDictionary<int, KeyValuePair<int, int>> adk = new ConcurrentDictionary<int, KeyValuePair<int, int>>();

    ConcurrentDictionary<KeyValuePair<int, int>, int> adl = new ConcurrentDictionary<KeyValuePair<int, int>, int>();

    Graph addj = new Graph(514);
    void Start()
    {
        int k = 0;
        for (int i = 0; i < MET.ROW; i++)
        {
            for (int j = 0; j < MET.COL; j++)
            {
                adj.Add(new KeyValuePair<int, int>(i, j));
                adl[adj[k]] = k;
                k++;
            }
        }


        for (int i = 0; i < MET.ROW; i++)
        {
            for (int j = 0; j < MET.COL; j++)
            {
                if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color == MET.one)
                {
                    var x = new KeyValuePair<int, int>(i, j);
                    if (i < MET.ROW - 1 && MET.myArray[i + 1, j].GetComponent<SpriteRenderer>().color == MET.one)
                {
                    var y = new KeyValuePair<int, int>(i + 1, j);
                    addj.addEdge(adl[x], adl[y]);
                    addj.addEdge(adl[y], adl[x]);
                }

                if (i > 0 && MET.myArray[i - 1, j].GetComponent<SpriteRenderer>().color == MET.one)
                {
                    var y = new KeyValuePair<int, int>(i - 1, j);
                    addj.addEdge(adl[x], adl[y]);
                    addj.addEdge(adl[y], adl[x]);
                }

                if (j < MET.COL - 1 && MET.myArray[i, j + 1].GetComponent<SpriteRenderer>().color == MET.one)
                {
                    var y = new KeyValuePair<int, int>(i, j + 1);
                    addj.addEdge(adl[x], adl[y]);
                    addj.addEdge(adl[y], adl[x]);
                }

                if (j > 0 && MET.myArray[i, j - 1].GetComponent<SpriteRenderer>().color == MET.one)
                {
                    var y = new KeyValuePair<int, int>(i, j - 1);
                    addj.addEdge(adl[x], adl[y]);
                    addj.addEdge(adl[y], adl[x]);
                }

                }
            }
        }
        //addj.print();
        StartCoroutine(BFS(SETDSTSRC.sx,SETDSTSRC.sy));
    }

    IEnumerator BFS(int x,int y){

        var init=new KeyValuePair<int, int>(x, y);

        var finit=new KeyValuePair<int, int>(SETDSTSRC.dx,SETDSTSRC.dy);
        int t= adl[finit];

        int[] visited = new int[514];
        for(int i=0;i<514;i++){
            visited[i]=25000;
        }
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(adl[init]);
        visited[adl[init]] = 0;
        bool flag=true;
        while (queue.Count > 0 && flag) {
            int u = queue.Peek();
            queue.Dequeue();
            foreach (int v in addj.admet[u]) {
                if (visited[v]>visited[u]+1) {
                    KeyValuePair<int,int> pick = adj[v];
                    int m = pick.Key;
                    int n = pick.Value;

                    //MET.myArray[m,n].GetComponent<SpriteRenderer>().color=Color.red;
                    StartCoroutine(bordit(m,n));
                    yield return new WaitForSeconds(0.1f);

                    visited[v] = visited[u]+1;
                    queue.Enqueue(v);
                    
                    if(v==t){
                        flag=false;
                        break;
                    }
                }
            }
        }
        

        if (visited[t] == 25000) {
            Debug.Log("no path exist");
            tc.openconfirmationwindow("NO PATH EXIST!");
        }
        else{
            while (t != 0) {
                t = visited[t] - 1;
                KeyValuePair<int,int> pick = adj[t];
                        int m = pick.Key;
                        int n = pick.Value;
                MET.myArray[m,n].GetComponent<SpriteRenderer>().color=Color.green;
            }
             tc.openconfirmationwindow("PATH FOUND!");
            Destroy(SETDSTSRC.prevDST);
            Destroy(SETDSTSRC.prevSRC);
        }
        yield return new WaitForSeconds(1f);
    }

    IEnumerator bordit(int x,int y){
        MET.myArray[x,y].GetComponent<SpriteRenderer>().color=BORDER;
        yield return new WaitForSeconds(DELAY);
        MET.myArray[x,y].GetComponent<SpriteRenderer>().color=BORDER;
    }

    void Update()
    {

    }
}




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;
// using System.Collections.Concurrent;


// public class Graph {
//     public int V; // Number of vertices
//     public List<List<int>> admet; // admetacency list

//     public Graph(int V) {
//         this.V = V;
//         admet = new List<List<int>>(V);
//         for (int i = 0; i < V; i++) {
//             admet[i] = new List<int>();
//         }
//     }

//     public void addEdge(int u, int v) {
//         admet[u].Add(v);
//     }

//     public void print() {
//         for (int i = 0; i < V; i++) {
//             Debug.Log("Vertex " + i + ":");
//             foreach (int v in admet[i]) {
//                 Debug.Log(" " + v);
//             }
//         }
//     }
// }

// public class bfs : MonoBehaviour
// {
//         // Create a vector of pairs to store the adjacency list
//         List<KeyValuePair<int, int>> adj = new List<KeyValuePair<int, int>>(514);

//         // Create an unordered map to store the adjacency list by index
//         ConcurrentDictionary<int, KeyValuePair<int, int>> adk = new ConcurrentDictionary<int, KeyValuePair<int, int>>();

//         // Create an unordered map to store the adjacency list by pair
//         ConcurrentDictionary<KeyValuePair<int, int>, int> adl = new ConcurrentDictionary<KeyValuePair<int, int>, int>();

//     void Start()
//     {
//         int k = 0;
//         for (int i = 0; i < MET.ROW; i++){ 
//             for (int j = 0; j < MET.COL; j++){
//                 adj[k] = new KeyValuePair<int, int>(i, j);
//                 adl[adj[k]] = k;
//                 k++;
//             }
//         }
        
//         Graph addj = new Graph(514);
        
//         for(int i=0;i<MET.ROW;i++){
//             for(int j=0;j<MET.COL;j++){
//                 if(MET.myArray[i,j].GetComponent<SpriteRenderer>().color==MET.one){
//                         var x = new KeyValuePair<int, int>(i, j);
//                     if(i<MET.ROW-1 && MET.myArray[i+1,j].GetComponent<SpriteRenderer>().color==MET.one){
//                         var y = new KeyValuePair<int, int>(i+1, j);
//                         addj.addEdge(adl[x],adl[y]);
//                         addj.addEdge(adl[y],adl[x]);
//                     }
//                 }
//             }
//         }
//         addj.print();
//     }

//     void Update()
//     {
        
//     }
// }
