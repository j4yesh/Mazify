using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class backtracking_algo : MonoBehaviour
{   
    private int[,] maze=new int[MET.ROW,MET.COL];
    private int[,] ans=new int[MET.ROW,MET.COL];


    [SerializeField]
    private Color pathColor=new Color();
    void Start()
    {
        for(int i=0;i<MET.ROW;i++){
            for(int j=0;j<MET.COL;j++){
                if(MET.myArray[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                    maze[i,j]=1;
                }else{
                    maze[i,j]=0;
                }
            }
        }
        backtrack(0,0);
    }

    void Update()
    {
        
    }

    
    bool backtrack(int row, int col)
    {
        if (row == MET.ROW - 1 && col == MET.COL - 1)
        {
            // Reached the destination
            return true;
        }

        // Mark current cell as part of the solution path
        MET.myArray[row, col].GetComponent<SpriteRenderer>().color = pathColor;
        ans[row, col] = 1;
        
        // Try all possible moves from the current cell
        if (isValidMove(row + 1, col))
        {
            // Move down
            if (backtrack(row + 1, col)) return true;
        }

        if (isValidMove(row, col + 1))
        {
            // Move right
            if (backtrack(row, col + 1)) return true;
        }

        if (isValidMove(row - 1, col))
        {
            // Move up
            if (backtrack(row - 1, col)) return true;
        }

        if (isValidMove(row, col - 1))
        {
            // Move left
            if (backtrack(row, col - 1)) return true;
        }

        // Backtrack
        MET.myArray[row, col].GetComponent<SpriteRenderer>().color = MET.one;
        ans[row, col] = 0;
        return false;
    }

    bool isValidMove(int row, int col)
    {
        // Check if the cell is within the maze boundaries and is not a wall or already visited
        return row >= 0 && row < MET.ROW && col >= 0 && col < MET.COL && maze[row, col] == 1 && ans[row, col] == 0;
    }

    IEnumerator caller(int row, int col)
    {
        yield return new WaitForSeconds(0.1f); // adjust the delay time as needed
        
    }

}
