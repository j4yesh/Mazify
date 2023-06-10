using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Pair<T1, T2>
{
    public T1 First { get; set; }
    public T2 Second { get; set; }

    public Pair(T1 first, T2 second)
    {
        this.First = first;
        this.Second = second;
    }
}

public class bfs : MonoBehaviour
{
    List<Pair<int,int>> corr = new List<Pair<int, int>>();
    List<Pair<int,int>> voi = new List<Pair<int, int>>();       
    void Start()
    {
        for(int i=0;i<MET.ROW;i++){
            for(int j=0;j<MET.COL;j++){
                 corr.Add(new Pair<int, int>(i, j));
                Debug.Log(a[]);
            }
        }
    }


    void Update()
    {
        
    }
}
