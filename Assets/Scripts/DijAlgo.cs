using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Concurrent;
using System.Linq;

public class DijAlgo : MonoBehaviour
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
                        addj.addEdge(adl[x], adl[y]); // Weight of 1 for unweighted graph
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
        StartCoroutine(Dijkstra(SETDSTSRC.sx, SETDSTSRC.sy));
    }

    IEnumerator Dijkstra(int x, int y)
    {
        var init = new KeyValuePair<int, int>(x, y);
        var finit = new KeyValuePair<int, int>(SETDSTSRC.dx, SETDSTSRC.dy);
        int t = adl[finit];

        int[] dist = new int[514];
        for (int i = 0; i < 514; i++)
        {
            dist[i] = int.MaxValue;
        }
        dist[adl[init]] = 0;

        bool[] visited = new bool[514];

        CustomPriorityQueue priorityQueue = new CustomPriorityQueue();
        priorityQueue.Enqueue(adl[init], 0);
        bool fleg=true;
        while (!priorityQueue.IsEmpty && fleg)
        {
            int u = priorityQueue.Dequeue();

            if (visited[u]) continue;

            visited[u] = true;

            foreach (int v in addj.admet[u])
            {
                if (!visited[v] && dist[u] != int.MaxValue && dist[u] + 1 < dist[v]) // Assuming unweighted graph
                {
                    dist[v] = dist[u] + 1;

                    KeyValuePair<int, int> pick = adj[v];
                    int m = pick.Key;
                    int n = pick.Value;

                    StartCoroutine(BordIt(m, n));
                    yield return new WaitForSeconds(0.05f);

                    priorityQueue.Enqueue(v, dist[v]);
                    if(SETDSTSRC.dx==m&&SETDSTSRC.dy==n){
                        fleg=false;
                        break;
                    }
                }
            }
        }

        if (dist[t] == int.MaxValue)
        {
            Debug.Log("No path exists");
            tc.openconfirmationwindow("NO PATH EXIST!");
        }
        else
        {
            while (t != adl[init])
            {
                t = dist[t];
                KeyValuePair<int, int> pick = adj[t];
                int m = pick.Key;
                int n = pick.Value;
                MET.myArray[m, n].GetComponent<SpriteRenderer>().color = Color.green;
            }
            tc.openconfirmationwindow("PATH FOUND!");
            Destroy(SETDSTSRC.prevDST);
            Destroy(SETDSTSRC.prevSRC);
        }
        yield return new WaitForSeconds(1f);
    }

    IEnumerator BordIt(int x, int y)
    {
        MET.myArray[x, y].GetComponent<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(0.325f);
        MET.myArray[x, y].GetComponent<SpriteRenderer>().color = BORDER;
    }

    void Update()
    {

    }
}

public class CustomPriorityQueue
{
    private List<Tuple<int, int>> elements = new List<Tuple<int, int>>();

    public bool IsEmpty => elements.Count == 0;

    public void Enqueue(int item, int priority)
    {
        elements.Add(new Tuple<int, int>(item, priority));
        elements.Sort((a, b) => a.Item2.CompareTo(b.Item2));
    }

    public int Dequeue()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("PriorityQueue is empty.");
        }

        int item = elements[0].Item1;
        elements.RemoveAt(0);
        return item;
    }
}







// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;
// using System.Collections.Concurrent;



// public class DijAlgo : MonoBehaviour
// {
//    [SerializeField]
//     public static Color INSIDER = new Color(1f, 0.255f, 0.086f);
//     public static Color BORDER = new Color(1f, 0.325f, 0f);

//     private float DELAY = 2f;

//     [SerializeField]
//     private testconfirmation tc;

//     List<KeyValuePair<int, int>> adj = new List<KeyValuePair<int, int>>(514);

//     ConcurrentDictionary<int, KeyValuePair<int, int>> adk = new ConcurrentDictionary<int, KeyValuePair<int, int>>();

//     ConcurrentDictionary<KeyValuePair<int, int>, int> adl = new ConcurrentDictionary<KeyValuePair<int, int>, int>();

//     Graph addj = new Graph(514);
//     void Start()
//     {
//         int k = 0;
//         for (int i = 0; i < MET.ROW; i++)
//         {
//             for (int j = 0; j < MET.COL; j++)
//             {
//                 adj.Add(new KeyValuePair<int, int>(i, j));
//                 adl[adj[k]] = k;
//                 k++;
//             }
//         }


//         for (int i = 0; i < MET.ROW; i++)
//         {
//             for (int j = 0; j < MET.COL; j++)
//             {
//                 if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color == MET.one)
//                 {
//                     var x = new KeyValuePair<int, int>(i, j);
//                     if (i < MET.ROW - 1 && MET.myArray[i + 1, j].GetComponent<SpriteRenderer>().color == MET.one)
//                 {
//                     var y = new KeyValuePair<int, int>(i + 1, j);
//                     addj.addEdge(adl[x], adl[y]);
//                     addj.addEdge(adl[y], adl[x]);
//                 }

//                 if (i > 0 && MET.myArray[i - 1, j].GetComponent<SpriteRenderer>().color == MET.one)
//                 {
//                     var y = new KeyValuePair<int, int>(i - 1, j);
//                     addj.addEdge(adl[x], adl[y]);
//                     addj.addEdge(adl[y], adl[x]);
//                 }

//                 if (j < MET.COL - 1 && MET.myArray[i, j + 1].GetComponent<SpriteRenderer>().color == MET.one)
//                 {
//                     var y = new KeyValuePair<int, int>(i, j + 1);
//                     addj.addEdge(adl[x], adl[y]);
//                     addj.addEdge(adl[y], adl[x]);
//                 }

//                 if (j > 0 && MET.myArray[i, j - 1].GetComponent<SpriteRenderer>().color == MET.one)
//                 {
//                     var y = new KeyValuePair<int, int>(i, j - 1);
//                     addj.addEdge(adl[x], adl[y]);
//                     addj.addEdge(adl[y], adl[x]);
//                 }

//                 }
//             }
//         }
//         //addj.print();
//         StartCoroutine(BFS(SETDSTSRC.sx,SETDSTSRC.sy));
//     }

//     IEnumerator BFS(int x,int y){

//         var init=new KeyValuePair<int, int>(x, y);

//         var finit=new KeyValuePair<int, int>(SETDSTSRC.dx,SETDSTSRC.dy);
//         int t= adl[finit];

//         int[] visited = new int[514];
//         int[] dist = new int[514];
//         for(int i=0;i<514;i++){
//             visited[i]=25000;
//             dist[i]=-1;
//         }
//         Queue<int> queue = new Queue<int>();

//         queue.Enqueue(adl[init]);
//         visited[adl[init]] = 0;
//         bool flag=true;
//         while (queue.Count > 0 && flag) {
//             int u = queue.Peek();
//             queue.Dequeue();
//             foreach (int v in addj.admet[u]) {
//                 if (visited[v]>visited[u]+1) {
//                     dist[v]=u;
                    
//                     KeyValuePair<int,int> pick = adj[v];
//                     int m = pick.Key;
//                     int n = pick.Value;

//                     //MET.myArray[m,n].GetComponent<SpriteRenderer>().color=Color.red;
//                     StartCoroutine(bordit(m,n));
//                     yield return new WaitForSeconds(0.1f);

//                     visited[v] = visited[u]+1;
//                     queue.Enqueue(v);
                    
//                     if(v==t){
//                         flag=false;
//                         break;
//                     }
//                 }
//             }
//         }
        

//         if (visited[t] == 25000) {
//             Debug.Log("no path exist");
//             tc.openconfirmationwindow("NO PATH EXIST!");
//         }
//         else{
//             while (t != adl[init]) {
//                 t = dist[t];
//                 KeyValuePair<int,int> pick = adj[t];
//                 int m = pick.Key;
//                 int n = pick.Value;
//                 MET.myArray[m,n].GetComponent<SpriteRenderer>().color=Color.green;
//             }
//             tc.openconfirmationwindow("PATH FOUND!");
//             Destroy(SETDSTSRC.prevDST);
//             Destroy(SETDSTSRC.prevSRC);
//         }
//         yield return new WaitForSeconds(1f);
//     }

//     IEnumerator bordit(int x,int y){
//         MET.myArray[x,y].GetComponent<SpriteRenderer>().color=BORDER;
//         // yield return new WaitForSeconds(DELAY);
//         // MET.myArray[x,y].GetComponent<SpriteRenderer>().color=BORDER;
//         yield break;
//     }

//     void Update()
//     {

//     }
// }
