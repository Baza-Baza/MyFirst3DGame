using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static  class SaveSystem
{
    public static void SaveDataGAme(SaveScript saveScript)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(saveScript);

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/data.fun";
        FileStream stream = new FileStream(path, FileMode.Open);
        if (File.Exists(path) && stream.Length > 0)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            GameData gameData = binaryFormatter.Deserialize(stream) as GameData;
            stream.Close();

            return gameData;
            
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            BinaryFormatter formatter = new BinaryFormatter();
            GameData data = new GameData(saveScript);
            formatter.Serialize(stream, data);
            stream.Close();
            return null;
        }
    }
}
