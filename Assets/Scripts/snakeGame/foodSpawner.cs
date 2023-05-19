using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSpawner : MonoBehaviour
{   
    public static Color foodColor= new Color(186f, 183f, 17f);
    public Collider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        int x = Random.Range(0, MET.ROW);
        int y = Random.Range(0, MET.COL);

        // Round the values to ensure it aligns with the grid
        // x = Mathf.Round(x);
        // y = Mathf.Round(y);

        if(MET.myArray[x,y].GetComponent<SpriteRenderer>().color==MET.one){
            RandomizePosition();
        }
        else{
            MET.myArray[x,y].GetComponent<SpriteRenderer>().color=foodColor;
        }
    }

}
