using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestedPair<T1, T2>
{
    public T1 First { get; set; }
    public T2 Second { get; set; }

    public NestedPair(T1 first, T2 second)
    {
        First = first;
        Second = second;
    }
}

public class InputSnake : MonoBehaviour
{
    private int x=3,y=4;
    private string d="right";

    private float DELAY=0.1f;

    [SerializeField]
    private foodSpawner Spawner;

    [SerializeField]
    private testconfirmation tc;

    Queue<NestedPair<int, int>> queue = new Queue<NestedPair<int, int>>();
    void Start()
    {

        queue.Enqueue(new NestedPair<int, int>(x, y));
        queue.Enqueue(new NestedPair<int, int>(x-1, y));
        queue.Enqueue(new NestedPair<int, int>(x-2, y));
        queue.Enqueue(new NestedPair<int, int>(x-3, y));


        MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;    
        MET.myArray[x-1,y].GetComponent<SpriteRenderer>().color=MET.one;    
        MET.myArray[x-2,y].GetComponent<SpriteRenderer>().color=MET.one;    
        MET.myArray[x-3,y].GetComponent<SpriteRenderer>().color=MET.one;    
        
        
        StartCoroutine(Move("right"));

    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            if(d!="right"){ d="left";}

        }
        if(Input.GetKeyDown(KeyCode.D)){
            if(d!="left"){ d="right";}
        }
        if(Input.GetKeyDown(KeyCode.W)){
            if(d!="bottom") {d="top";}
        }
        if(Input.GetKeyDown(KeyCode.S)){
            if(d!="top"){ d="bottom";}
        }
    }

    IEnumerator Move(string dd){
        yield return new WaitForSeconds(DELAY);
        if(dd=="left"){
            y=(y-1+MET.COL)%MET.COL;
            StartCoroutine(mover());
        }
        else if(dd=="right"){
            y=(y+1)%MET.COL;
            StartCoroutine(mover());
        }
        else if(dd=="top"){
            x=(x-1+MET.ROW)%MET.ROW;
            StartCoroutine(mover());
        }
        else{
            x=(x+1)%MET.ROW;
            StartCoroutine(mover());
        }
        yield return StartCoroutine(Move(d));
    }

    IEnumerator mover(){
            if(MET.myArray[x,y].GetComponent<SpriteRenderer>().color!=MET.zero){
                if(MET.myArray[x,y].GetComponent<SpriteRenderer>().color==foodSpawner.foodColor){
                    queue.Enqueue(new NestedPair<int, int>(x, y));
                    MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;
                    Spawner.RandomizePosition();
                }else{
                    tc.openconfirmationwindow("GAME OVER!");
                    yield break;
                }
            }
            NestedPair<int,int> temp= queue.Dequeue();
            queue.Enqueue(new NestedPair<int, int>(x, y));
            MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;
            MET.myArray[temp.First,temp.Second].GetComponent<SpriteRenderer>().color=MET.zero;
    }

    // IEnumerator FixedUpdate(){
    //     if(d=="left"){
    //         y=(y-1+MET.COL)%MET.COL;
    //         if(MET.myArray[x,y].GetComponent<SpriteRenderer>().color!=MET.zero){
    //             tc.openconfirmationwindow("GAME OVER!");
    //         }
    //         MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;
    //     }
    //     else if(d=="right"){
    //         y=(y+1)%MET.COL;
    //         if(MET.myArray[x,y].GetComponent<SpriteRenderer>().color!=MET.zero){
    //             tc.openconfirmationwindow("GAME OVER!");
    //         }
    //         MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;
    //     }
    //     else if(d=="top"){
    //         x=(x-1+MET.ROW)%MET.ROW;
    //         if(MET.myArray[x,y].GetComponent<SpriteRenderer>().color!=MET.zero){
    //             tc.openconfirmationwindow("GAME OVER!");
    //         }
    //         MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;
    //     }
    //     else{
    //         x=(x+1)%MET.ROW;
    //         if(MET.myArray[x,y].GetComponent<SpriteRenderer>().color!=MET.zero){
    //             tc.openconfirmationwindow("GAME OVER!");
    //         }
    //         MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;
    //     }
    // }

}

// if(Input.GetKeyDown(KeyCode.A)){
//             //COL MINUS
//             y=(y-1+MET.COL)%MET.COL;
//             MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;
//         }
//         if(Input.GetKeyDown(KeyCode.D)){
//             y=(y+1)%MET.COL;
//             MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;
//         }
//         if(Input.GetKeyDown(KeyCode.W)){
//             x=(x-1+MET.ROW)%MET.ROW;
//             MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;
//         }
//         if(Input.GetKeyDown(KeyCode.S)){
//             x=(x+1)%MET.ROW;
//             MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;
//         }