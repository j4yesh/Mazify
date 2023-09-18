using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;
using System.Collections.Concurrent;

public class Union
{
    private int[] parent;

    public Union()
    {
        parent = new int[10000];
        for (int i = 0; i < 10000; i++)
        {
            parent[i] = i;
        }
    }

    public int Find(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = Find(parent[x]); // Path compression
        }
        return parent[x];
    }

    public bool Friend(int x, int y,KeyValuePair<int,int>a,KeyValuePair<int,int>b)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        
        if (rootX == rootY)
        {  
            return false; // x and y are already in the same set
        }

        parent[rootX] = rootY;
        return true;
    }
}

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
    List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>> edji = new List<KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>>();
        ConcurrentDictionary<KeyValuePair<int, int>, int> visited = new ConcurrentDictionary<KeyValuePair<int, int>, int>();
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
        int cnt=0;
        for (int i = 0; i < MET.ROW; i++)
        {
            for (int j = 0; j < MET.COL; j++)
            {  

                // if(i%2==0 && j%2==0){
                // }
                
                if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color == MET.zero && i%2==0 && j%2==0)
                {
                    MET.myArray[i,j].GetComponent<SpriteRenderer>().color=Color.black;
                    var x = new KeyValuePair<int, int>(i, j);
                    visited[x]=0;
                    if (i < MET.ROW - 1 && MET.myArray[i + 1, j].GetComponent<SpriteRenderer>().color == MET.zero)
                    {
                        var y = new KeyValuePair<int, int>(i + 1, j);
                        addj.addEdge(adl[x], adl[y]);
                        addj.addEdge(adl[y], adl[x]);
                        KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(x, y);
                        KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp2 = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(y,x);
                        edji.Add(temp);
                        edji.Add(temp2);
                    }

                    if (i > 0 && MET.myArray[i - 1, j].GetComponent<SpriteRenderer>().color == MET.zero)
                    {
                        var y = new KeyValuePair<int, int>(i - 1, j);
                        addj.addEdge(adl[x], adl[y]);
                        addj.addEdge(adl[y], adl[x]);
                        KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(x, y);
                        KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp2 = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(y,x);
                        edji.Add(temp);
                        edji.Add(temp2);
                    }

                    if (j < MET.COL - 1 && MET.myArray[i, j + 1].GetComponent<SpriteRenderer>().color == MET.zero)
                    {
                        var y = new KeyValuePair<int, int>(i, j + 1);
                        addj.addEdge(adl[x], adl[y]);
                        addj.addEdge(adl[y], adl[x]);
                        KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(x, y);
                        KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp2 = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(y,x);
                        edji.Add(temp);
                        edji.Add(temp2);
                    }

                    if (j > 0 && MET.myArray[i, j - 1].GetComponent<SpriteRenderer>().color == MET.zero)
                    {
                        var y = new KeyValuePair<int, int>(i, j - 1);
                        addj.addEdge(adl[x], adl[y]);
                        addj.addEdge(adl[y], adl[x]);
                        KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(x, y);
                        KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp2 = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(y,x);
                        edji.Add(temp);
                        edji.Add(temp2);
                    }
                }
            }
        }
        //addj.print();
        StartCoroutine (mazeGen());
    }
    
    IEnumerator mazeGen()
    {
        KeyValuePair<int,int>node=findNode();
        Stack<KeyValuePair<int, int>> st = new Stack<KeyValuePair<int, int>>();
        st.Push(node);
            while(st.Count!=0){
                    node=st.Peek();
                    int i=node.Key,j=node.Value;
                    if(i==-1){
                        continue;
                    }
                    st.Pop();
                    MET.myArray[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                    yield return new WaitForSeconds(0.5f);
                    InsertRandomNodes(i,j,st);
                }
        yield break;
    }
   private void InsertRandomNodes(int i, int j, Stack<KeyValuePair<int, int>> st)
{
    List<int> availableOptions = new List<int>();

    if (i + 2 < MET.ROW && MET.myArray[i + 2, j].GetComponent<SpriteRenderer>().color == Color.black)
    {
        availableOptions.Add(1);
    }

    if (i - 2 >= 0 && MET.myArray[i - 2, j].GetComponent<SpriteRenderer>().color == Color.black)
    {
        availableOptions.Add(2);
    }

    if (j + 2 < MET.COL && MET.myArray[i, j + 2].GetComponent<SpriteRenderer>().color == Color.black)
    {
        availableOptions.Add(3);
    }

    if (j - 2 >= 0 && MET.myArray[i, j - 2].GetComponent<SpriteRenderer>().color == Color.black)
    {
        availableOptions.Add(4);
    }

    if (availableOptions.Count == 0)
    {
        return;
    }

    // Shuffle the availableOptions list
    for (int k = availableOptions.Count - 1; k > 0; k--)
    {
        int randIndex = Random.Range(0, k + 1);
        int temp = availableOptions[k];
        availableOptions[k] = availableOptions[randIndex];
        availableOptions[randIndex] = temp;
    }

    // Push elements onto the stack in random order
    foreach (int randomNumber in availableOptions)
    {
        switch (randomNumber)
        {
            case 1:
                st.Push(new KeyValuePair<int, int>(i + 2, j));
                break;
            case 2:
                st.Push(new KeyValuePair<int, int>(i - 2, j));
                break;
            case 3:
                st.Push(new KeyValuePair<int, int>(i, j + 2));
                break;
            case 4:
                st.Push(new KeyValuePair<int, int>(i, j - 2));
                break;
        }
    }
    }
    private KeyValuePair<int,int> findNode(){
        for(int i=0;i<MET.ROW;i++){
            for(int j=0;j<MET.COL;j++){
                if(i%2==0 && j%2==0 && MET.myArray[i,j].GetComponent<SpriteRenderer>().color==Color.black){
                    return new KeyValuePair<int, int>(i,j);
                }
            }
        }
        return new KeyValuePair<int, int>(-1,-1);
    }
}


// int k = 0;
//         for (int i = 0; i < MET.ROW; i++)
//         {
//             for (int j = 0; j < MET.COL; j++)
//             {   
//                 adj.Add(new KeyValuePair<int, int>(i, j));
//                 adl[adj[k]] = k;
//                 k++;
//             }
//         }
//         int cnt=0;
//         for (int i = 0; i < MET.ROW; i++)
//         {
//             for (int j = 0; j < MET.COL; j++)
//             {  
//                 if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color == MET.zero)
//                 {
//                     var x = new KeyValuePair<int, int>(i, j);
//                     if (i < MET.ROW - 1 && MET.myArray[i + 1, j].GetComponent<SpriteRenderer>().color == MET.zero)
//                     {
//                         var y = new KeyValuePair<int, int>(i + 1, j);
//                         addj.addEdge(adl[x], adl[y]);
//                         addj.addEdge(adl[y], adl[x]);
//                         KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(x, y);
//                         KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp2 = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(y,x);
//                         edji.Add(temp);
//                         edji.Add(temp2);
//                     }

//                     if (i > 0 && MET.myArray[i - 1, j].GetComponent<SpriteRenderer>().color == MET.zero)
//                     {
//                         var y = new KeyValuePair<int, int>(i - 1, j);
//                         addj.addEdge(adl[x], adl[y]);
//                         addj.addEdge(adl[y], adl[x]);
//                         KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(x, y);
//                         KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp2 = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(y,x);
//                         edji.Add(temp);
//                         edji.Add(temp2);
//                     }

//                     if (j < MET.COL - 1 && MET.myArray[i, j + 1].GetComponent<SpriteRenderer>().color == MET.zero)
//                     {
//                         var y = new KeyValuePair<int, int>(i, j + 1);
//                         addj.addEdge(adl[x], adl[y]);
//                         addj.addEdge(adl[y], adl[x]);
//                         KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(x, y);
//                         KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp2 = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(y,x);
//                         edji.Add(temp);
//                         edji.Add(temp2);
//                     }

//                     if (j > 0 && MET.myArray[i, j - 1].GetComponent<SpriteRenderer>().color == MET.zero)
//                     {
//                         var y = new KeyValuePair<int, int>(i, j - 1);
//                         addj.addEdge(adl[x], adl[y]);
//                         addj.addEdge(adl[y], adl[x]);
//                         KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(x, y);
//                         KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>> temp2 = new KeyValuePair<KeyValuePair<int, int>, KeyValuePair<int, int>>(y,x);
//                         edji.Add(temp);
//                         edji.Add(temp2);
//                     }
//                 }
//             }
//         }
//         //addj.print();
//         StartCoroutine (mazeGen());