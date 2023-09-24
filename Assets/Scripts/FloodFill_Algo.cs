﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodFill_Algo : MonoBehaviour
{
    private bool flooded=false;
    private int row,col;
    public float DELAY=0.01f;
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

    void Update()
    {
        if(!flooded && Input.GetMouseButton(0)){
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector3.forward);
            if (hit.collider != null && hit.transform.gameObject.tag=="blk")
            {
                GameObject hitObject = hit.collider.gameObject;
                // hitObject.GetComponent<SpriteRenderer>().color=new Color(185f, 94f, 255f);
                row=hitObject.GetComponent<Flip>().x;
                col=hitObject.GetComponent<Flip>().y;
                floodFill();
            }
        }
    }

     void floodFill(){
        //first find pixel which is green
        // for(int i=0;i<19;i++){
        //     for(int j=0;j<26;j++){
        //         if(MET.myArray[i,j].GetComponent<SpriteRenderer>().color==new Color(185f, 94f, 255f)){
        //             MET.myArray[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
        //             floody(i,j);
        //             break;
        //         }
        //     }
        // }
        floody(row,col);
    }
    void floody(int row, int column)
    {
        if (row < 0 || row >= MET.ROW || column < 0 || column >= MET.COL) {
            return;
        }

        if (MET.myArray[row, column].GetComponent<SpriteRenderer>().color != MET.zero) {
            return;
        }

        MET.myArray[row, column].GetComponent<SpriteRenderer>().color = MET.one;

        StartCoroutine(DelayedFunction(row-1,column));
        StartCoroutine(DelayedFunction(row+1,column));
        StartCoroutine(DelayedFunction(row,column-1));
        StartCoroutine(DelayedFunction(row,column+1));
    }

    IEnumerator DelayedFunction(int row,int column)
    {
        yield return new WaitForSeconds(DELAY);
        // Debug.Log("Delayed function executed");
        floody(row, column);
    }
}
