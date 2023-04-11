using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MET : MonoBehaviour
{   
    [SerializeField]
    private GameObject spawn;

    private GameObject[,] myArray = new GameObject[100, 100];
    private int i = 0, j = 0;
    
    [SerializeField]
    public Vector3 leftpos;
    
    [SerializeField]
    public Vector3 rightpos;

    [SerializeField]
    public Color one=new Color();

    [SerializeField]
    public Color zero=new Color();

    public SpriteRenderer rend;
    private void Start()
    {   
        for(int i=0;i<17;i++){
            for(int j=0;j<26;j++){
                myArray[i, j] = Instantiate(spawn, leftpos, transform.rotation);
                leftpos += new Vector3(0.5f, 0f, 0f);
                if(i%2==1){
                    myArray[i,j].GetComponent<SpriteRenderer>().color=one;
                }else{
                    myArray[i,j].GetComponent<SpriteRenderer>().color=zero;
                }
            }
            rightpos+=new Vector3(0f,-0.5f,0f);
            leftpos=rightpos;
        }
        myArray[0,0].GetComponent<SpriteRenderer>().color = zero;

    }
    //j->17 i->26
    private void Update()
    {
       
    }
}



//  if (Input.GetKey(KeyCode.Space))
//         {
//             myArray[i, j] = Instantiate(spawn, leftpos, transform.rotation);
//             i++;
            
//             if(i==25){
//                 leftpos=rightpos;
//                 rightpos+=new Vector3(0f,-0.5f,0f);
//                 i=0;
//                 j++;
//             }
//             leftpos += new Vector3(0.5f, 0f, 0f);
//         }
