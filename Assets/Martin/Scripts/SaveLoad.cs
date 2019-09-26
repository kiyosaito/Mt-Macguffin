using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{
    public static void SaveCheckpoint(PauseMenu saveCheckpoint)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Saves/" + "LastCheckpoint.bat";
        FileStream stream = new FileStream(path, FileMode.Create);
        DataToSave data = new DataToSave(saveCheckpoint);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static DataToSave LoadCheckPoint()
    {
        string path = Application.persistentDataPath + "/Saves/"+"LastCheckpoint.bat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DataToSave data = formatter.Deserialize(stream) as DataToSave;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Couldn't find file to load");
            return null;

        }
    }
    public static bool SaveExists()
    {
        string path = Application.persistentDataPath + "/Saves/" + "LastCheckpoint.bat";
        return File.Exists(path);
    }
    public static void ResetSaves()
    {
        string path = Application.persistentDataPath + "/Saves/" + "LastCheckpoint.bat";
        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete(true);
        Directory.CreateDirectory(path);
    }
}
