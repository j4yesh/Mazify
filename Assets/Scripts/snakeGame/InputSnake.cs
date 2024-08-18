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
    private int x = 3, y = 4;
    private string d = "right";

    private float DELAY = 0.1f;

    [SerializeField]
    private foodSpawner Spawner;

    [SerializeField]
    private testconfirmation tc;

    Queue<NestedPair<int, int>> queue = new Queue<NestedPair<int, int>>();

    private int nCol,nRow;

    void Start()
    {
        queue.Enqueue(new NestedPair<int, int>(x, y));
        queue.Enqueue(new NestedPair<int, int>(x - 1, y));
        queue.Enqueue(new NestedPair<int, int>(x - 2, y));
        queue.Enqueue(new NestedPair<int, int>(x - 3, y));

        SetCellColor(x, y, MET.one);
        SetCellColor(x - 1, y, MET.one);
        SetCellColor(x - 2, y, MET.one);
        SetCellColor(x - 3, y, MET.one);

       
        nRow=MET.ROW;
        nCol=MET.COL;
            StartCoroutine(Move("right"));

    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A) && d != "right")
        {
            d = "left";
        }
        else if (Input.GetKeyDown(KeyCode.D) && d != "left")
        {
            d = "right";
        }
        else if (Input.GetKeyDown(KeyCode.W) && d != "bottom")
        {
            d = "top";
        }
        else if (Input.GetKeyDown(KeyCode.S) && d != "top")
        {
            d = "bottom";
        }
    }

    IEnumerator Move(string dd)
    {

        UpdatePosition(dd);
        yield return new WaitForSeconds(DELAY);

        StartCoroutine(Move(d));
    }

    void UpdatePosition(string dd)
    {
        if (dd == "left")
        {
            y = (y - 1 + nCol) % (nCol);
        }
        else if (dd == "right")
        {
            y = (y + 1) % (nCol);
        }
        else if (dd == "top")
        {
            x = (x - 1 + nRow) % (nRow);
        }
        else
        {
            x = (x + 1) % (nRow);
        }

        StartCoroutine(Mover());
    }

    IEnumerator Mover()
    {
        if (IsCellOccupied(x, y))
        {
            if (GetCellColor(x, y) == foodSpawner.foodColor)
            {
                queue.Enqueue(new NestedPair<int, int>(x, y));
                SetCellColor(x, y, MET.one);
                Spawner.RandomizePosition();
            }
            else
            {
                tc.openconfirmationwindow("GAME OVER!");
                yield break;
            }
        }

        NestedPair<int, int> temp = queue.Dequeue();
        queue.Enqueue(new NestedPair<int, int>(x, y));
        SetCellColor(x, y, MET.one);
        SetCellColor(temp.First, temp.Second, MET.zero);
    }

    bool IsCellOccupied(int i, int j)
    {
        return MET.myArray[i, j].GetComponent<SpriteRenderer>().color != MET.zero;
    }

    void SetCellColor(int i, int j, Color color)
    {
        MET.myArray[i, j].GetComponent<SpriteRenderer>().color = color;
    }

    Color GetCellColor(int i, int j)
    {
        return MET.myArray[i, j].GetComponent<SpriteRenderer>().color;
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class NestedPair<T1, T2>
// {
//     public T1 First { get; set; }
//     public T2 Second { get; set; }

//     public NestedPair(T1 first, T2 second)
//     {
//         First = first;
//         Second = second;
//     }
// }

// public class InputSnake : MonoBehaviour
// {
//     private int x=3,y=4;
//     private string d="right";

//     private float DELAY=0.1f;

//     [SerializeField]
//     private foodSpawner Spawner;

//     [SerializeField]
//     private testconfirmation tc;

//     Queue<NestedPair<int, int>> queue = new Queue<NestedPair<int, int>>();
//     void Start()
//     {

//         queue.Enqueue(new NestedPair<int, int>(x, y));
//         queue.Enqueue(new NestedPair<int, int>(x-1, y));
//         queue.Enqueue(new NestedPair<int, int>(x-2, y));
//         queue.Enqueue(new NestedPair<int, int>(x-3, y));


//         MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;    
//         MET.myArray[x-1,y].GetComponent<SpriteRenderer>().color=MET.one;    
//         MET.myArray[x-2,y].GetComponent<SpriteRenderer>().color=MET.one;    
//         MET.myArray[x-3,y].GetComponent<SpriteRenderer>().color=MET.one;    
        
        
//         StartCoroutine(Move("right"));

//     }

    
//     void Update()
//     {   
//         if(Input.GetKeyDown(KeyCode.A)){
//             if(d!="right"){ d="left";}

//         }
//         if(Input.GetKeyDown(KeyCode.D)){
//             if(d!="left"){ d="right";}
//         }
//         if(Input.GetKeyDown(KeyCode.W)){
//             if(d!="bottom") {d="top";}
//         }
//         if(Input.GetKeyDown(KeyCode.S)){
//             if(d!="top"){ d="bottom";}
//         }
//     }

//     IEnumerator Move(string dd){
//         yield return new WaitForSeconds(DELAY);
//         if(dd=="left"){
//             y=(y-1+nCol)%(nCol-1);
//             StartCoroutine(mover());
//         }
//         else if(dd=="right"){
//             y=(y+1)%(nCol-1);
//             StartCoroutine(mover());
//         }
//         else if(dd=="top"){
//             x=(x-1+nRow)%(nRow-1);
//             StartCoroutine(mover());
//         }
//         else{
//             x=(x+1)%(nRow-1);
//             StartCoroutine(mover());
//         }
//         yield return StartCoroutine(Move(d));
//     }

//     IEnumerator mover(){
//             if(MET.myArray[x,y].GetComponent<SpriteRenderer>().color!=MET.zero){
//                 if(MET.myArray[x,y].GetComponent<SpriteRenderer>().color==foodSpawner.foodColor){
//                     queue.Enqueue(new NestedPair<int, int>(x, y));
//                     MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;
//                     Spawner.RandomizePosition();
//                 }else{
//                     tc.openconfirmationwindow("GAME OVER!");
//                     yield break;
//                 }
//             }
//             NestedPair<int,int> temp= queue.Dequeue();
//             queue.Enqueue(new NestedPair<int, int>(x, y));
//             MET.myArray[x,y].GetComponent<SpriteRenderer>().color=MET.one;
//             MET.myArray[temp.First,temp.Second].GetComponent<SpriteRenderer>().color=MET.zero;
//     }
