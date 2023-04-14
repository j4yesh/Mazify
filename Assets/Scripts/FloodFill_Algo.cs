using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodFill_Algo : MonoBehaviour
{
    private bool flooded=false;
    // public static FloodFill_Algo ffinst;
    void Start()
    {   
        // if(ffinst!=null){
        //     Destroy(this.gameObject);
        //     return;
        // }
        // ffinst=this;
        // GameObject.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(!flooded && Input.GetMouseButton(0)){
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                hitObject.GetComponent<SpriteRenderer>().color=Color.green;
                flooded=true;
                floodFill();
                flooded=false;
            }
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
