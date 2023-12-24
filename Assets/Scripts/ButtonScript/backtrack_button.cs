using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtrack_button : MonoBehaviour
{
    // Start is called before the first frame update
    public static backtrack_button bb;
    void Start()
    {
        if(bb!=null){
            Destroy(this.gameObject);
            return;
        }
        bb=this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    void OnMouseDown(){
        SceneManager.LoadScene("Backtracking");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
