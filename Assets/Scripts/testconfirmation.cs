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
        noButton.gameObject.SetActive(false);
        a.gameObject.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.N)){
            openconfirmationwindow("FDSAFDS");
        }
    }

    public void openconfirmationwindow(string msg){
        a.gameObject.SetActive(true);
        yesButton.onClick.AddListener(yesclicked);
        noButton.onClick.AddListener(noclicked);
        a.msgText.text=msg;
    }

    public void yesclicked(){
        a.gameObject.SetActive(false);
    }

    public void noclicked(){
        a.gameObject.SetActive(false);
        a.msgText.text="error211!";
    }
}
