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

    public GameData(){
        this.deathCount=0;
 
        
    }
}
