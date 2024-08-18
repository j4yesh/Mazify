using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sevier : MonoBehaviour
{
    // Start is called before the first frame update
        public GameObject[] buttons;
    public static Sevier instance;
    private void Start()
    {
        if(instance!=null){
            Destroy(this.gameObject);
            return;
        }
        instance=this;
       // GameObject[] buttons = GameObject.FindGameObjectsWithTag("topButton");
        if (buttons.Length > 200)
        {
            Destroy(gameObject);
        }
            foreach(GameObject i in buttons){
           DontDestroyOnLoad(i);
        }
    }
}
