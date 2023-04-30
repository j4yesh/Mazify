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


    void Start(){
        // openconfirmationwindow("please set Source and Destination on block with same color");
        // noButton.gameObject.SetActive(false);
        a.gameObject.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.N)){
            openconfirmationwindow("FDSAFDS");
            Debug.Log("fdasfasdf");
        }
    }

    private void openconfirmationwindow(string msg){
        a.gameObject.SetActive(true);
        Debug.Log("object activated!");
        yesButton.onClick.AddListener(yesclicked);
        noButton.onClick.AddListener(noclicked);
        a.msgText.text=msg;
    }

    void yesclicked(){
        a.gameObject.SetActive(false);
        Debug.Log("yes clicked on confirmation window");
    }

    void noclicked(){
        // a.gameObject.SetActive(false);
        a.msgText.text="Fuck off!";
        Debug.Log("why not bruhhh!");
    }
}
