using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    public static DataPersistenceManager instance { get; private set; }
    private List<IDataPersistenceManger> dataPersistenceObjects;
    private GameData gameData; // You need to declare the GameData variable.

    private FileDataHandler dataHandler;



    private void Start()
    {   
        this.dataHandler=new FileDataHandler(Application.persistentDataPath,fileName);

        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
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
        this.gameData = new GameData(); // You need to create an instance of GameData.
    }

    public void LoadGame()
    {
        this.gameData=dataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing to default");
            NewGame();
        }

        // Push data to other scripts
        foreach (IDataPersistenceManger dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(this.gameData);
        }

        Debug.Log("Load death count: " + this.gameData.deathCount);
    }

    public void SaveGame()
    {
        // Pass data to other scripts
        foreach (IDataPersistenceManger dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref this.gameData);
        }

        Debug.Log("Saved death count: " + this.gameData.deathCount);
        // Save file using file handler
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistenceManger> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistenceManger> dataPersistenceObject = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistenceManger>();
        return new List<IDataPersistenceManger>(dataPersistenceObject);
    }
}
