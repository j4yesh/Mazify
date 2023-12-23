using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testconfirmation : MonoBehaviour
{   
    [SerializeField]
    private confirmORNOT a;

    [SerializeField]
    private Button yesButton;

    [SerializeField]
    private Button noButton;

    [SerializeField]
    public GameObject[] elementsToDisable;

    public static testconfirmation tc;

    void Start(){
        // if(tc!=null){
        //     Destroy(gameObject);
        // }
        // tc=this;
        // DontDestroyOnLoad(gameObject);
        // openconfirmationwindow("please set Source and Destination on block with same color");
        // noButton.gameObject.SetActive(false);
        a.gameObject.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.N)){
            openconfirmationwindow("FDSAFDS");
        }
    }

    public void openconfirmationwindow(string msg){
        foreach( GameObject i in elementsToDisable){
            i.SetActive(false);
        }
        a.gameObject.SetActive(true);
        yesButton.onClick.AddListener(yesclicked);
        noButton.onClick.AddListener(noclicked);
        a.msgText.text=msg;
    }

    public void yesclicked(){
        Debug.Log("yes clicked at that instant");
        a.gameObject.SetActive(false);
        foreach( GameObject i in elementsToDisable){
            i.SetActive(true);
        }
    }

    public void noclicked(){
        Debug.Log("yes clicked at that instant");
        a.gameObject.SetActive(false);
        a.msgText.text="error211!";
    }

}
