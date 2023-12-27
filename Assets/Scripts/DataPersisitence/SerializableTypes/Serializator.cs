using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class Serializator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // SerializeData();
        // DeserializeData();
    }

    private void SerializeData(){
        var json=JsonConvert.SerializeObject(new GameData() );
        File.WriteAllText(Application.dataPath+"/SavePath.json",json);
    }

    private void DeserializeData(){
        var json=File.ReadAllText(Application.dataPath+"/SavePath.json");
        Debug.Log(json);
        var serializedData=JsonConvert.DeserializeObject<GameData>(json);
       // Debug.Log("serializedData"+serializedData.met1[0]);
    }

    public GameData Load()
    {
        string json = File.ReadAllText(Application.dataPath + "/SavePath.json");
        Debug.Log(json);

        GameData serializedData = JsonConvert.DeserializeObject<GameData>(json);

        //Debug.Log("gum bata" + serializedData.met1[0]);
        return serializedData;
    }

     public void Save(GameData data)
    {
        var json=JsonConvert.SerializeObject(data);
        File.WriteAllText(Application.dataPath+"/SavePath.json",json);
    }

}
