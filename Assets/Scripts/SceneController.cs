using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour, IDataPersistenceManger
{
    private int[,] save1 = new int[100, 100];

    void Start()
    {
        // if(dinst!=null){
        //     Destroy(this.gameObject);
        //     return;
        // }
        // dinst=this;
        // GameObject.DontDestroyOnLoad(gameObject);
    }

    public void changeDraw()
    {
        Debug.Log("entered in general");
        if (SceneManager.GetActiveScene().name != "General")
            SceneManager.LoadScene("General");
    }

    public void changeSnake()
    {
        Debug.Log("entered in general");
        if (SceneManager.GetActiveScene().name != "snakeGame")
            SceneManager.LoadScene("snakeGame");
    }

    public void setDSTandSRC()
    {
        Debug.Log("entered in general");
        if (SceneManager.GetActiveScene().name != "setDSTandSRC")
            SceneManager.LoadScene("setDSTandSRC");
    }

    public void Backtracking()
    {
        Debug.Log("entered in general");
        if (SceneManager.GetActiveScene().name != "Backtracking")
            SceneManager.LoadScene("Backtracking");
    }

    public void bfs()
    {
        Debug.Log("entered in general");
        if (SceneManager.GetActiveScene().name != "bfs")
            SceneManager.LoadScene("bfs");
    }


    public void dfs()
    {
        Debug.Log("entered in general");
        if (SceneManager.GetActiveScene().name != "dfs")
            SceneManager.LoadScene("dfs");
    }


    public void dijkshtra()
    {
        Debug.Log("entered in general");
        if (SceneManager.GetActiveScene().name != "dijkshtra")
            SceneManager.LoadScene("dijkshtra");
    }


    public void dpflood()
    {
        Debug.Log("entered in general");
        if (SceneManager.GetActiveScene().name != "dpflood")
            SceneManager.LoadScene("dpflood");
    }

    public void Flood()
    {
        Debug.Log("entered in general");
        if (SceneManager.GetActiveScene().name != "Flood")
            SceneManager.LoadScene("Flood");
    }

    public void SaveMenu()
    {
        Debug.Log("entered in general");
        if (SceneManager.GetActiveScene().name != "SaveMenu")
            SceneManager.LoadScene("SaveMenu");
    }

    public void LoadMenu()
    {
        Debug.Log("entered in general");
        if (SceneManager.GetActiveScene().name != "LoadMenu")
            SceneManager.LoadScene("LoadMenu");
    }

    public void removeSRCDST()
    {
        GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("setsrc");

        foreach (GameObject obj in objectsToDelete)
        {
            Debug.Log("deleted");
            DestroyImmediate(obj);
        }
        Debug.Log("removeSRCDST DESTROYed");

    }

    public void removePath()
    {
        for (int i = 0; i < MET.ROW; i++)
        {
            for (int j = 0; j < MET.COL; j++)
            {
                if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color != MET.one
                    && MET.myArray[i, j].GetComponent<SpriteRenderer>().color != MET.zero
                )
                {
                    MET.myArray[i, j].GetComponent<SpriteRenderer>().color = MET.one;
                    Debug.Log("destroyed for path");
                }
            }
        }
        Debug.Log("REMOVE path func. invoked");
    }

    public void resetMaze()
    {
        for (int i = 0; i < MET.ROW; i++)
        {
            for (int j = 0; j < MET.COL; j++)
            {
                MET.myArray[i, j].GetComponent<SpriteRenderer>().color = MET.zero;
            }
        }

    }

    public void saveThemaze()
    {
        for (int i = 0; i < MET.ROW; i++)
        {
            for (int j = 0; j < MET.COL; j++)
            {
                if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color != MET.zero)
                {
                    save1[i, j] = 1;
                }
                else
                {
                    save1[i, j] = 0;
                }
            }
        }
        Debug.Log("temporary saved successfully");
    }

    public void displaySaved()
    {
        string ss = "{";
        for (int i = 0; i < MET.ROW; i++)
        {
            string num = "{";
            for (int j = 0; j < MET.COL; j++)
            {
                if (save1[i, j] == 1)
                {
                    MET.myArray[i, j].GetComponent<SpriteRenderer>().color = MET.one;
                    num += "1";
                }
                else
                {
                    MET.myArray[i, j].GetComponent<SpriteRenderer>().color = MET.zero;
                    num += "0";
                }
                if (j != 25)
                {
                    num += ',';
                }
            }
            num += "}";
            if (i != 18)
            {
                num += ',';
            }
            ss += num;
        }
        // Debug.Log(ss);
        Debug.Log("overwrited successfully");
    }

    public void OnNewGameClicked()
    {
        DataPersistenceManager.instance.NewGame();
    }

    public void OnLoadGameClicked()
    {
        DataPersistenceManager.instance.LoadGame();
    }

    public void OnSaveGameClicked()
    {
        DataPersistenceManager.instance.SaveGame();
    }

    static public int choice = -1;
    public void LoadData(GameData data)
     { 
        Debug.Log(data.deathCount);
        if (choice == -1)
        {       Debug.Log("First Place invoking");
                //resetMaze();

            foreach (KeyValuePair<int, int> it in data.met1)
            {
                if (MET.myArray[it.Key, it.Value])
                    MET.myArray[it.Key, it.Value].GetComponent<SpriteRenderer>().color = MET.one;
            }
        }
        else
        {

            Debug.Log("LoadData choicing invoked");
               // resetMaze();
            switch (choice)
            {
                case 2:
                    Debug.Log("Option 2 selected");
                    // data.met1.Clear();
                    foreach (KeyValuePair<int, int> it in data.met2)
                    {
                        //data.met1.Add(new KeyValuePair<int,int>(it.Key,it.Value));
                        //  if (MET.myArray[it.Key, it.Value])
                             MET.myArray[it.Key, it.Value].GetComponent<SpriteRenderer>().color = MET.one;
                        Debug.Log(it.Key+" "+it.Value);
                    }
                    Debug.Log(data.met2.Count  + "size of the list");
                    break;

                case 3:
                    Debug.Log("Option 3 selected");
                    // data.met1.Clear();
                    foreach (KeyValuePair<int, int> it in data.met3)
                    {
                        //data.met1.Add(new KeyValuePair<int,int>(it.Key,it.Value));
                        //  if (MET.myArray[it.Key, it.Value])
                             MET.myArray[it.Key, it.Value].GetComponent<SpriteRenderer>().color = MET.one;
                    }
                    break;

                case 4:
                    Debug.Log("Option 4 selected");
                    // data.met1.Clear();
                    foreach (KeyValuePair<int, int> it in data.met4)
                    {
                        //data.met1.Add(new KeyValuePair<int,int>(it.Key,it.Value));
                        //  if (MET.myArray[it.Key, it.Value])
                             MET.myArray[it.Key, it.Value].GetComponent<SpriteRenderer>().color = MET.one;
                    }
                    break;

                case 5:
                    Debug.Log("Option 5 selected");
                    // data.met1.Clear();
                    foreach (KeyValuePair<int, int> it in data.met5)
                    {
                        //data.met1.Add(new KeyValuePair<int,int>(it.Key,it.Value));
                        //  if (MET.myArray[it.Key, it.Value])
                             MET.myArray[it.Key, it.Value].GetComponent<SpriteRenderer>().color = MET.one;
                    }
                    break;

                default:
                    Debug.Log("Invalid option selected");
                    // Perform actions for default case (when none of the specified cases match)
                    break;
            }


        }
    }

    public void SaveData(ref GameData data)
    {
        data.deathCount = 121;
        if(choice==-1){
            data.met1.Clear();
            Debug.Log("Default Persistence Saving");
        for (int i = 0; i < MET.ROW; i++)
        {
            for (int j = 0; j < MET.COL; j++)
            {
                if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color != MET.zero)
                {
                    data.met1.Add(new KeyValuePair<int, int>(i, j));
                }
            }
        }
        }

        if (choice != -1)
        {   Debug.Log("SaveData invoked");
            switch (choice)
            {
                case 2:
                    Debug.Log("Option 2 selected");
                    data.met2.Clear();
                    for (int i = 0; i < MET.ROW; i++)
                    {
                        for (int j = 0; j < MET.COL; j++)
                        {
                            if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color != MET.zero)
                            {
                                data.met2.Add(new KeyValuePair<int, int>(i, j));
                            }
                        }
                    }
                    break;

                case 3:
                    Debug.Log("Option 3 selected");
                    data.met3.Clear();
                    for (int i = 0; i < MET.ROW; i++)
                    {
                        for (int j = 0; j < MET.COL; j++)
                        {
                            if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color != MET.zero)
                            {
                                data.met3.Add(new KeyValuePair<int, int>(i, j));
                            }
                        }
                    }
                    break;

                case 4:
                    Debug.Log("Option 4 selected");
                    data.met4.Clear();
                    for (int i = 0; i < MET.ROW; i++)
                    {
                        for (int j = 0; j < MET.COL; j++)
                        {
                            if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color != MET.zero)
                            {
                                data.met4.Add(new KeyValuePair<int, int>(i, j));
                            }
                        }
                    }
                    break;

                case 5:
                    Debug.Log("Option 5 selected");
                    data.met5.Clear();
                    for (int i = 0; i < MET.ROW; i++)
                    {
                        for (int j = 0; j < MET.COL; j++)
                        {
                            if (MET.myArray[i, j].GetComponent<SpriteRenderer>().color != MET.zero)
                            {
                                data.met5.Add(new KeyValuePair<int, int>(i, j));
                            }
                        }
                    }
                    break;

                default:
                    Debug.Log("Invalid option selected");
                    break;
            }


            Debug.Log("save data succ.");
        }
    }

    public void saveOne(){
        choice=2;
        if(DataPersistenceManager.instance)DataPersistenceManager.instance.SaveGame();
        choice=-1;
        if(!realMazeController.instance)Invoke("changeDraw",1f);
    }
    public void saveTwo(){
        choice=3;
        DataPersistenceManager.instance.SaveGame();
        choice=-1;
        if(!realMazeController.instance)Invoke("changeDraw",1f);
    }
    public void saveThree(){
        choice=4;
        DataPersistenceManager.instance.SaveGame();
        choice=-1;
        if(!realMazeController.instance)Invoke("changeDraw",1f);
    }
    public void saveFour(){
        choice=5;
        DataPersistenceManager.instance.SaveGame();
        choice=-1;
        if(!realMazeController.instance)Invoke("changeDraw",1f);
    }

     public void LoadOne(){
        choice=2;
        DataPersistenceManager.instance.LoadGame();
        choice=-1;
        if(!realMazeController.instance)Invoke("changeDraw",1f);
    }
    public void LoadTwo(){
        choice=3;
        DataPersistenceManager.instance.LoadGame();
        choice=-1;
        if(!realMazeController.instance)Invoke("changeDraw",1f);
    }
    public void LoadThree(){
        choice=4;
        DataPersistenceManager.instance.LoadGame();
        choice=-1;
        if(!realMazeController.instance)Invoke("changeDraw",1f);
    }
    public void LoadFour(){
        choice=5;
        DataPersistenceManager.instance.LoadGame();
        choice=-1;
        if(!realMazeController.instance)Invoke("changeDraw",1f);
    }


};

