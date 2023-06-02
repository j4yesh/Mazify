using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{   
    public Color newColor;
    private Color originalColor;
    private bool isdown=false;
    private bool blek=false;

    // [SerializeField]
    public int x,y;

    private void Start()
    {   
        originalColor=GetComponent<SpriteRenderer>().color;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // private void OnMouseEnter()
    // {   
    //     if(isdown){
    //         GetComponent<SpriteRenderer>().color = newColor;
    //     }
    //     if(blek){
    //         GetComponent<SpriteRenderer>().color = originalColor;
    //     }
    // }
    // private void OnMouseDown(){
    //         // GetComponent<SpriteRenderer>().color=Color.green;
    //         // floodFill();
    // }
    
    void Update(){
        // Draw();
        // if(Input.GetMouseButtonDown(0)){
        //     startflood=true;
        // }
        // if(Input.GetMouseButtonUp(0)){
        //     startflood=false;
        // }
    }

    void Draw(){
        if (Input.GetMouseButtonDown(0)) 
        {   
            isdown=true;
        }
        if (Input.GetMouseButtonUp(0)) 
        {   
            isdown=false;
        }
        if(Input.GetMouseButtonDown(1)){
            blek=true;
        }
        if(Input.GetMouseButtonUp(1)){
            blek=false;
        }
    }

    void floodFill(){
        //first find pixel which is green
        for(int i=0;i<19;i++){
            for(int j=0;j<26;j++){
                if(MET.myArray[i,j].GetComponent<SpriteRenderer>().color==Color.green){
                    MET.myArray[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                    floody(i,j);
                    break;
                }
            }
        }
    }
    void floody(int row, int column)
    {
        // Check if the current cell is within the bounds of the array
        if (row < 0 || row >= 19 || column < 0 || column >= 26) {
            return;
        }

        // Check if the current cell is already filled or not
        if (MET.myArray[row, column].GetComponent<SpriteRenderer>().color != MET.zero) {
            return;
        }

        // Fill the current cell with the new color
        MET.myArray[row, column].GetComponent<SpriteRenderer>().color = Color.green;

        StartCoroutine(DelayedFunction(row-1,column));
        StartCoroutine(DelayedFunction(row+1,column));
        StartCoroutine(DelayedFunction(row,column-1));
        StartCoroutine(DelayedFunction(row,column+1));
        // Recursively fill the neighboring cells
    }

    IEnumerator DelayedFunction(int row,int column)
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Delayed function executed");
        floody(row, column);
    }

}
