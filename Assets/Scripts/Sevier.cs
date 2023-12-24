using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sevier : MonoBehaviour
{
    // Start is called before the first frame update
        public GameObject[] buttons;
    private void Start()
    {
        // Ensure that only one instance of this button exists
        // GameObject[] buttons = GameObject.FindGameObjectsWithTag("topButton");
        // if (buttons.Length > 200)
        // {
        //     Destroy(gameObject);
        // }

        // Make this button persistent across scenes
        foreach(GameObject i in buttons){
            DontDestroyOnLoad(i);
        }
    }
}
