using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class floodfill_general : MonoBehaviour
{   public static floodfill_general finst;
    void Start()
    {   if(finst!=null){
            Destroy(this.gameObject);
            return;
        }
        finst=this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    private void OnMouseDown(){
        SceneManager.LoadScene("Flood");
    }

    void Update()
    {
        
    }
}
