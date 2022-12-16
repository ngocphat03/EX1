using UnityEngine;
using System.IO;
public class GameManagers : MonoBehaviour
{
    string path;
    string data;

    private void Awake()
    {
        path = Application.persistentDataPath + "/dataUser.json";
        this.CheckFile();
    }

    public void CheckFile()
    {
        if (!File.Exists(path))
        {
            this.CreateEmptyData();
        }
        this.CheckData();
        if (this.data == "")
        {
            this.CreateEmptyData();
        }
    }
    
    private void CreateEmptyData()
    {
        string empty = "{\"ListPlayer\":[]}";
        File.WriteAllText(this.path, empty);
    }

    private void CheckData()
    {
        this.data = File.ReadAllText(Application.persistentDataPath + "/dataUser.json");
    }
}