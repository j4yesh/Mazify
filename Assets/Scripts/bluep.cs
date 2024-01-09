using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bluep : MonoBehaviour
{
    public Color newColor;
    private Color originalColor;
    [SerializeField]
    public int x=0,y=0;
    public Text num; // Reference to the Text component in Unity Editor

    void Start()
    {
        identify("44");
    }
    
    // Function to change the text
    public void identify(string newText)
    {
        if (num != null)
        {
            num.text = newText;
        }
        else
        {
            Debug.LogError("Text component not assigned in the inspector!");
        }
    }
}
