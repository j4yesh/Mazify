using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializeData
{
    [SerializeField]
  
    public List<KeyValuePair<int, int>> met1 = new List<KeyValuePair<int, int>>();
    public List<KeyValuePair<int, int>> met2 = new List<KeyValuePair<int, int>>();
    public List<KeyValuePair<int, int>> met3 = new List<KeyValuePair<int, int>>();
    public List<KeyValuePair<int, int>> met4 = new List<KeyValuePair<int, int>>();
    public List<KeyValuePair<int, int>> met5 = new List<KeyValuePair<int, int>>();


    public SerializeData()
    {
        // met1.Add(new KeyValuePair<int, int>(1, 1));
    }
}
