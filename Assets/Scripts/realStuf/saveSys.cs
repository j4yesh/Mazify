using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveSys : MonoBehaviour, IDataPersistenceManger
{   
    //public realMazeController realMazeController;
    void Start()
    {
      //  realMazeController=realMazeController.FindWithTag("realMaze");
    }

    void Update()
    {
        
    }

    public void MicroMouseScene(){
        if (SceneManager.GetActiveScene().name != "MicroMouseScene")
            SceneManager.LoadScene("MicroMouse");
    }

    public void eraseRealMaze(){
        for(int i=0;i<realMazeController.ROW;i++){
            for(int j=0;j<realMazeController.COL;j++){
                if(realMazeController.verticalWall[i,j]){
                    realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                }
                if(realMazeController.horizontolwall[i,j]){
                    realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                }
            }
        }
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

    static private int choice = -1;
    public void LoadData(GameData data)
     { 
        Debug.Log(data.deathCount);
        if (choice == -1)
        {       
            for(int i=0;i<realMazeController.ROW;i++){
                for(int j=0;j<realMazeController.COL-1;j++){
                    if(data.hor1[i,j]==1){
                        realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                    }else{
                        realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                    }
                } 
            }
            for(int i=0;i<realMazeController.ROW-1;i++){
                for(int j=0;j<realMazeController.COL;j++){
                    if(data.ver1[i,j]==1){
                        realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                    }else{
                        realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                    }
                } 
            }
            if(realMazeController.instance)
                Debug.Log("load success fully from saveSys");
        }
        else
        {

            Debug.Log("LoadData choicing invoked");
               // resetMaze();
            switch (choice)
            {
                case 2:
                    Debug.Log("Option 2 selected");
                    data.met1.Clear();
                    foreach (KeyValuePair<int, int> it in data.met2)
                    {
                        //data.met1.Add(new KeyValuePair<int,int>(it.Key,it.Value));
                         if (MET.myArray[it.Key, it.Value])
                             MET.myArray[it.Key, it.Value].GetComponent<SpriteRenderer>().color = MET.one;
                    }
                    break;

                case 3:
                    Debug.Log("Option 3 selected");
                    data.met1.Clear();
                    foreach (KeyValuePair<int, int> it in data.met3)
                    {
                        //data.met1.Add(new KeyValuePair<int,int>(it.Key,it.Value));
                         if (MET.myArray[it.Key, it.Value])
                             MET.myArray[it.Key, it.Value].GetComponent<SpriteRenderer>().color = MET.one;
                    }
                    break;

                case 4:
                    Debug.Log("Option 4 selected");
                    data.met1.Clear();
                    foreach (KeyValuePair<int, int> it in data.met4)
                    {
                        //data.met1.Add(new KeyValuePair<int,int>(it.Key,it.Value));
                         if (MET.myArray[it.Key, it.Value])
                             MET.myArray[it.Key, it.Value].GetComponent<SpriteRenderer>().color = MET.one;
                    }
                    break;

                case 5:
                    Debug.Log("Option 5 selected");
                    data.met1.Clear();
                    foreach (KeyValuePair<int, int> it in data.met5)
                    {
                        //data.met1.Add(new KeyValuePair<int,int>(it.Key,it.Value));
                         if (MET.myArray[it.Key, it.Value])
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
            for(int i=0;i<realMazeController.ROW;i++){
                for(int j=0;j<realMazeController.COL-1;j++){
                    if(realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                        data.hor1[i,j]=1;
                    }else{ 
                        data.hor1[i,j]=0;
                    }
                } 
            }
            for(int i=0;i<realMazeController.ROW-1;i++){
                for(int j=0;j<realMazeController.COL;j++){
                    if(realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                        data.ver1[i,j]=1;
                    }else{ 
                        data.ver1[i,j]=0;
                    }
                } 
            }
            if(realMazeController.instance)
                Debug.Log("saved success fully from saveSys");
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
        DataPersistenceManager.instance.SaveGame();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }
    public void saveTwo(){
        choice=3;
        DataPersistenceManager.instance.SaveGame();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }
    public void saveThree(){
        choice=4;
        DataPersistenceManager.instance.SaveGame();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }
    public void saveFour(){
        choice=5;
        DataPersistenceManager.instance.SaveGame();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }

     public void LoadOne(){
        choice=2;
        DataPersistenceManager.instance.LoadGame();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }
    public void LoadTwo(){
        choice=3;
        DataPersistenceManager.instance.LoadGame();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }
    public void LoadThree(){
        choice=4;
        DataPersistenceManager.instance.LoadGame();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }
    public void LoadFour(){
        choice=5;
        DataPersistenceManager.instance.LoadGame();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }


}
