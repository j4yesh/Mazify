using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalWall : MonoBehaviour
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

    void Update(){
        
    }
 
}
