using Ensign;
using UnityEngine;
using System.Collections.Generic;

public class UserModel : IDataModel 
{
    public int id;
    public string imageNumber;
    public string name;
    public string description;
    public string rule;
}

public class ListPlayerModel : IDataModel
{
    public List<UserModel> ListPlayer;
}

public class DataModel
{
    public static void IncreaseId()
    {
        int idPl = PlayerPrefs.GetInt("idPlayer");
        idPl++;
        PlayerPrefs.SetInt("idPlayer", idPl);
    }
}