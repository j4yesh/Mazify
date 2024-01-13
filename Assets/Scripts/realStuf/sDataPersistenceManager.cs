using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class sDataPersistenceManager : MonoBehaviour
{
      [Header("File Storage Config")]
    [SerializeField] private string fileName;
    public static sDataPersistenceManager instance { get; private set; }
    private List<uDataPersistenceManager> dataPersistenceObjects;
    private GameData gameData; 

   public Serializator dataHandler;

    private void Start()
    {   
        // this.dataHandler=new Serializator();
        if (dataHandler == null)
            {
                dataHandler = gameObject.AddComponent<Serializator>();
            }
        this.gameData=new GameData();
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame1();
        // Invoke("LoadGame1", 1f);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene");
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData(); 
    }

    public void LoadGame1()
    {
        this.gameData=dataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing to default");
            NewGame();
        }

        // Push data to other scripts
        foreach (uDataPersistenceManager dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData1(this.gameData);
        }

        Debug.Log("Load death count: " + this.gameData.deathCount);
        
    }
   
    public void SaveGame1()
    {
        // Pass data to other scripts
        foreach (uDataPersistenceManager dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData1(ref this.gameData);
        }

        Debug.Log("Saved death count: " + this.gameData.deathCount);
        // Save file using file handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {   
        //Invoke("SaveGame1", 0.3f);
        //SaveGame1();
    }

    private List<uDataPersistenceManager> FindAllDataPersistenceObjects()
    {
        IEnumerable<uDataPersistenceManager> dataPersistenceObject = FindObjectsOfType<MonoBehaviour>().OfType<uDataPersistenceManager>();
        return new List<uDataPersistenceManager>(dataPersistenceObject);
    }
}
