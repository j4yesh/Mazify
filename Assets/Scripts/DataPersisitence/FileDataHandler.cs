
using System;
using System.IO;
using UnityEngine;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";

                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occurred when trying to load data from file " + fullPath + "\n" + e);
            }
        }

        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occurred when trying to save data to file " + fullPath + "\n" + e);
        }
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;
// using System.IO;
// public class FileDataHandler
// {
//         private string dataDirPath="";
//     private string dataFileName="";

//     public  FileDataHandler(string dataDirPath,string dataFileName){
//         this.dataDirPath=dataDirPath;
//         this.dataFileName=dataFileName;
//     }
//     public GameData Load(){
//         string fullpath=Path.Combine(dataDirPath,dataFileName);
//         GameData loadedData=null;
//         if(File.Exists(fullpath)){
//             try{
//                 string dataToLoad="";
//                 using (FileStream stream=new FileStream(fullpath,FileMode.Open)){
//                     using  (StreamReader reader=new StreamReader(stream)){
//                         dataToLoad=reader.ReadToEnd();
//                     }
//                 }        
//                 loadedData=JsonUtility.FromJson<GameData>(dataToLoad)
//             }catch(Exception e){
//                 Debug.LogError("error occur when trying to save data to file"+fullpath+"/n"+e);
//             }
//         }
//         return loadedData;
//     }

//     public void Save(GameData data){
//         string fullpath=Path.Combine(dataDirPath,dataFileName);
//         try{
//             Directory.CreateDirectory(Path.GetDirectoryName(fullpath));
//             string dataToStore=JsonUtility.ToJson(data,true);
//             using (FileStream stream=new FileStream(fullpath,FileMode.Create)){
//                 using (StreamWriter writer=new StreamWriter(stream)){
//                     writer.Write(dataToStore);
//                 }
//             }
//         }
//         catch(Exception e){
//             Debug.LogError("error occur when trying to save data to file"+fullpath+"/n"+e);
//         }
//     }
// }
