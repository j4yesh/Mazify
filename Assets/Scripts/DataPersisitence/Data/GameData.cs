using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData 
{   

        [SerializeField]
  
    public List<KeyValuePair<int, int>> met1 = new List<KeyValuePair<int, int>>();
    public List<KeyValuePair<int, int>> met2 = new List<KeyValuePair<int, int>>();
    public List<KeyValuePair<int, int>> met3 = new List<KeyValuePair<int, int>>();
    public List<KeyValuePair<int, int>> met4 = new List<KeyValuePair<int, int>>();
    public List<KeyValuePair<int, int>> met5 = new List<KeyValuePair<int, int>>();
    public int deathCount;
    // public SerializableDictionary<string,int> metsaw;
    public int [,] hor1=new int[100,100];
    public int [,] ver1=new int[100,100];
    
    public int [,] hor2=new int[100,100];
    public int [,] ver2=new int[100,100];

    public int [,] hor3=new int[100,100];
    public int [,] ver3=new int[100,100];
    
    public int [,] hor4=new int[100,100];
    public int [,] ver4=new int[100,100];
    
    public int [,] hor5=new int[100,100];
    public int [,] ver5=new int[100,100];

    
    public GameData(){
        this.deathCount=0;
        
        
    }
}
