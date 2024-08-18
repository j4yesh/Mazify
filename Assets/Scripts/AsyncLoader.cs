using UnityEngine.UI;  
using UnityEngine.SceneManagement;
using UnityEngine;  
using System.Collections;
using System;
public class AsyncLoader : MonoBehaviour
{
    [Header("Menu Screens")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject slide;

    
    [Header("Slider")]
    [SerializeField] private Slider loadingSlider;
    void Start(){
        slide.SetActive(false);
    }
    public void LoadLevelBtn(string levelToLoad)
    {
        slide.SetActive(true);
        loadingScreen.SetActive(true);
        mainMenu.SetActive(false);
        StartCoroutine(LoadLevelASync(levelToLoad));  
    }

    IEnumerator LoadLevelASync(string levelToLoad)
{
    AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

    float timer = 0f;
    float duration = 1f; 

    while (!loadOperation.isDone)
    {
        float progressValue = Mathf.Clamp01(loadOperation.progress);
        Debug.Log(progressValue);

        loadingSlider.value = Mathf.SmoothStep(loadingSlider.value, progressValue, timer / duration);

        timer += Time.deltaTime;
        yield return null;
    }

    loadingSlider.value = 1f;
}
}
