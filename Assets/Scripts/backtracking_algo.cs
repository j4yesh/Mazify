using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backtracking_algo : MonoBehaviour
{   
    private int[,] maze=new int[MET.ROW,MET.COL];
    private int[,] ans=new int[MET.ROW,MET.COL];

    [SerializeField]
    private Color pathColor=new Color(1f, 0.92f, 0.016f, 1f);
    // private int sx=0,sy=0,dx=MET.ROW-1,dy=MET.COL-1;
    private float DELAY=0.1f;

    [SerializeField]
    private testconfirmation tc;
    
    // [SerializeField]
    // private SETDSTSRC sds;

    private bool notfound=false;
    void Start()
    {   
        // GameObject temp= GameObject.FindWithTag("setsrc");
        // temp.SetActive(false);
        for(int i=0;i<MET.ROW;i++){
            for(int j=0;j<MET.COL;j++){
                if(MET.myArray[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                    maze[i,j]=1;
                }else{
                    maze[i,j]=0;
                }
            }
        }
        StartCoroutine(backtrack(SETDSTSRC.sx,SETDSTSRC.sy));
        // while(notfound!=true||done!=true){

        // }
        // if(notfound==false){
        //     tc.openconfirmationwindow("PATH NOT FOUND BRUHH!");
        // }
    }
    void Update(){
        // if(notfound){
        //     tc.openconfirmationwindow("PATH NOT FOUND BRUHH!");
        //     notfound=false;
        // }
        // if(done){
        //     tc.openconfirmationwindow("PATH FOUND BRUHHH!");
        //     done=false;
        // }
    }

    private bool done=false;
    IEnumerator backtrack(int row, int col)
    {
        if (row == SETDSTSRC.dx && col == SETDSTSRC.dy)
        {
            MET.myArray[row, col].GetComponent<SpriteRenderer>().color = pathColor;
            yield return new WaitForSeconds(DELAY);
            // yield return null;
            done=true;
            tc.openconfirmationwindow("PATH FOUND BRUHHH!");
            Destroy(SETDSTSRC.prevDST);
            Destroy(SETDSTSRC.prevSRC);
            yield break;
        }
        MET.myArray[row, col].GetComponent<SpriteRenderer>().color = pathColor;
        ans[row, col] = 1;

        yield return new WaitForSeconds(DELAY);

        if (isValidMove(row + 1, col))
        {
            yield return StartCoroutine(backtrack(row + 1, col));
            if(done)yield break;
            // yield break;
        }

        if (isValidMove(row, col + 1))
        {
            yield return StartCoroutine(backtrack(row, col + 1));
            if(done)yield break;
            // yield break;
        }

        if (isValidMove(row - 1, col))
        {
            yield return StartCoroutine(backtrack(row - 1, col));
            if(done)yield break;
            // yield break;
        }

        if (isValidMove(row, col - 1))
        {
            yield return StartCoroutine(backtrack(row, col - 1));
            if(done)yield break;
            // yield break;
        }

            yield return new WaitForSeconds(DELAY);
        MET.myArray[row, col].GetComponent<SpriteRenderer>().color = MET.one;
        ans[row, col] = 0;

        if(MET.myArray[SETDSTSRC.sx, SETDSTSRC.sy].GetComponent<SpriteRenderer>().color == MET.one){
            notfound=true;
            tc.openconfirmationwindow("PATH NOT FOUND BRUHH!");
           // SETDSTSRC.GetComponent<remove>();
        }

        yield return null;
        // yield break;
    }

    bool isValidMove(int row, int col)
    {   bool a=row >= 0 && row < MET.ROW && col >= 0 && col < MET.COL && maze[row, col] == 1 && ans[row, col] == 0;
        return a;
    }


}
