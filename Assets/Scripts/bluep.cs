using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bluep : MonoBehaviour
{
    public Color newColor;
    private Color originalColor;
    [SerializeField]
    public int x=0,y=0;
    public Text num; // Reference to the Text component in Unity Editor
    // public bluep instance;
    void Start()
    {   
          //GameObject.DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        // Subscribe to the sceneLoaded event.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // void OnDisable()
    // {
    //     // Unsubscribe from the sceneLoaded event.
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    // }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SaveMenu"||scene.name=="LoadMenu")
        {
            SetObjectVisibility(false);
        }
        else
        {
            SetObjectVisibility(true);
        }
    }

    void SetObjectVisibility(bool isVisible)
    {
        // You can choose one of the following methods to hide/show the object.

        // Method 1: Using SetActive
        gameObject.SetActive(isVisible);

        // Method 2: If you want to adjust the visibility of a Renderer component
        // Renderer rendererComponent = gameObject.GetComponent<Renderer>();
        // if (rendererComponent != null)
        // {
        //     rendererComponent.enabled = isVisible;
        // }
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
