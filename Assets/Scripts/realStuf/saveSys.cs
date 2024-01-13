using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveSys : MonoBehaviour, uDataPersistenceManager
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

    public void changeSaveScene()
    {
        if (SceneManager.GetActiveScene().name != "SaveReal")
            SceneManager.LoadScene("SaveReal");
    }

    public void changeLoadReal()
    {
        if (SceneManager.GetActiveScene().name != "LoadReal")
            SceneManager.LoadScene("LoadReal");
    }

    public void OnNewGameClicked()
    {
        sDataPersistenceManager.instance.NewGame();
    }

    public void OnLoadGameClicked()
    {
        sDataPersistenceManager.instance.LoadGame1();
    }

    public void OnSaveGameClicked()
    {
        sDataPersistenceManager.instance.SaveGame1();
    }
    static private int choice = -1;
    public void LoadData1(GameData data)
     {  

        Debug.Log(data.deathCount);
        if (choice == -1)
        {       
            for(int i=0;i<realMazeController.ROW;i++){
                for(int j=0;j<realMazeController.COL-1;j++){
                    if(realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                        continue;
                    }
                    if(data.hor1[i,j]==1){
                        realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                    }else{
                        realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                    }
                }
            }
            for(int i=0;i<realMazeController.ROW-1;i++){
                for(int j=0;j<realMazeController.COL;j++){
                    if(realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                        continue;
                    }
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

            Debug.Log("LoadData1 choicing invoked");
               // resetMaze();
            switch (choice)
            {
                case 2:
                    Debug.Log("Option 2 selected");
                    for(int i=0;i<realMazeController.ROW;i++){
                        for(int j=0;j<realMazeController.COL-1;j++){
                            if(realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                                continue;
                            }
                            if(data.hor2[i,j]==1){
                                realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                            }else{
                                realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                            }
                        }
                    }
                    for(int i=0;i<realMazeController.ROW-1;i++){
                        for(int j=0;j<realMazeController.COL;j++){
                            if(realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                                continue;
                            }
                            if(data.ver2[i,j]==1){
                                realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                            }else{
                                realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                            }
                        } 
                    }
                    break;

                case 3:
                    Debug.Log("Option 3 selected");
                    for(int i=0;i<realMazeController.ROW;i++){
                        for(int j=0;j<realMazeController.COL-1;j++){
                            if(realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                                continue;
                            }
                            if(data.hor3[i,j]==1){
                                realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                            }else{
                                realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                            }
                        }
                    }
                    for(int i=0;i<realMazeController.ROW-1;i++){
                        for(int j=0;j<realMazeController.COL;j++){
                            if(realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                                continue;
                            }
                            if(data.ver3[i,j]==1){
                                realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                            }else{
                                realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                            }
                        } 
                    }
                    break;

                case 4:
                    Debug.Log("Option 4 selected");
                    for(int i=0;i<realMazeController.ROW;i++){
                        for(int j=0;j<realMazeController.COL-1;j++){
                            if(realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                                continue;
                            }
                            if(data.hor4[i,j]==1){
                                realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                            }else{
                                realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                            }
                        }
                    }
                    for(int i=0;i<realMazeController.ROW-1;i++){
                        for(int j=0;j<realMazeController.COL;j++){
                            if(realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                                continue;
                            }
                            if(data.ver4[i,j]==1){
                                realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                            }else{
                                realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                            }
                        } 
                    }
                    break;

                case 5:
                    Debug.Log("Option 5 selected");
                    for(int i=0;i<realMazeController.ROW;i++){
                        for(int j=0;j<realMazeController.COL-1;j++){
                            if(realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                                continue;
                            }
                            if(data.hor5[i,j]==1){
                                realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                            }else{
                                realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                            }
                        }
                    }
                    for(int i=0;i<realMazeController.ROW-1;i++){
                        for(int j=0;j<realMazeController.COL;j++){
                            if(realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color==MET.one){
                                continue;
                            }
                            if(data.ver5[i,j]==1){
                                realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.one;
                            }else{
                                realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color=MET.zero;
                            }
                        } 
                    }
                    break;

                default:
                    Debug.Log("Invalid option selected");
                    break;
            }


        }
    }

    public void SaveData1(ref GameData data)
    {   
        data.deathCount = 121;
        if(choice==-1){
            for(int i=0;i<realMazeController.ROW;i++){
                for(int j=0;j<realMazeController.COL-1;j++){
                    if(realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color!=MET.zero){
                        data.hor1[i,j]=1;
                    }else{ 
                        data.hor1[i,j]=0;
                    }
                } 
            }
            for(int i=0;i<realMazeController.ROW-1;i++){
                for(int j=0;j<realMazeController.COL;j++){
                    if(realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color!=MET.zero){
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
        {   Debug.Log("SaveData1 invoked");
            switch (choice)
            {
                case 2:
                    Debug.Log("Option 2 selected");
                    for(int i=0;i<realMazeController.ROW;i++){
                        for(int j=0;j<realMazeController.COL-1;j++){
                            if(realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color!=MET.zero){
                                
                                data.hor2[i,j]=1;
                            }else{ 
                                data.hor2[i,j]=0;
                                Debug.Log("realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color");
                            }
                        } 
                    }
                    for(int i=0;i<realMazeController.ROW-1;i++){
                        for(int j=0;j<realMazeController.COL;j++){
                            if(realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color!=MET.zero){
                                data.ver2[i,j]=1;
                            }else{ 
                                data.ver2[i,j]=0;
                            }
                        } 
                    }
                    break;

                case 3:
                    Debug.Log("Option 3 selected");
                    for(int i=0;i<realMazeController.ROW;i++){
                        for(int j=0;j<realMazeController.COL-1;j++){
                            if(realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color!=MET.zero){
                                data.hor3[i,j]=1;
                            }else{ 
                                data.hor3[i,j]=0;
                            }
                        } 
                    }
                    for(int i=0;i<realMazeController.ROW-1;i++){
                        for(int j=0;j<realMazeController.COL;j++){
                            if(realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color!=MET.zero){
                                data.ver3[i,j]=1;
                            }else{ 
                                data.ver3[i,j]=0;
                            }
                        } 
                    }
                    break;

                case 4:
                    Debug.Log("Option 4 selected");
                    for(int i=0;i<realMazeController.ROW;i++){
                        for(int j=0;j<realMazeController.COL-1;j++){
                            if(realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color!=MET.zero){
                                data.hor4[i,j]=1;
                            }else{ 
                                data.hor4[i,j]=0;
                            }
                        } 
                    }
                    for(int i=0;i<realMazeController.ROW-1;i++){
                        for(int j=0;j<realMazeController.COL;j++){
                            if(realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color!=MET.zero){
                                data.ver4[i,j]=1;
                            }else{ 
                                data.ver4[i,j]=0;
                            }
                        } 
                    }
                    break;

                case 5:
                    Debug.Log("Option 5 selected");
                    for(int i=0;i<realMazeController.ROW;i++){
                        for(int j=0;j<realMazeController.COL-1;j++){
                            if(realMazeController.horizontolwall[i,j].GetComponent<SpriteRenderer>().color!=MET.zero){
                                data.hor5[i,j]=1;
                            }else{ 
                                data.hor5[i,j]=0;
                            }
                        } 
                    }
                    for(int i=0;i<realMazeController.ROW-1;i++){
                        for(int j=0;j<realMazeController.COL;j++){
                            if(realMazeController.verticalWall[i,j].GetComponent<SpriteRenderer>().color!=MET.zero){
                                data.ver5[i,j]=1;
                            }else{ 
                                data.ver5[i,j]=0;
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
        sDataPersistenceManager.instance.SaveGame1();
        // choice=-1;
        Invoke("MicroMouseScene",1f);
    }
    public void saveTwo(){
        choice=3;
        sDataPersistenceManager.instance.SaveGame1();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }
    public void saveThree(){
        choice=4;
        sDataPersistenceManager.instance.SaveGame1();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }
    public void saveFour(){
        choice=5;
        sDataPersistenceManager.instance.SaveGame1();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }

     public void LoadOne(){
        choice=2;
        sDataPersistenceManager.instance.LoadGame1();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }
    public void LoadTwo(){
        choice=3;
        sDataPersistenceManager.instance.LoadGame1();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }
    public void LoadThree(){
        choice=4;
        sDataPersistenceManager.instance.LoadGame1();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }
    public void LoadFour(){
        choice=5;
        sDataPersistenceManager.instance.LoadGame1();
        choice=-1;
        Invoke("MicroMouseScene",1f);
    }


}
