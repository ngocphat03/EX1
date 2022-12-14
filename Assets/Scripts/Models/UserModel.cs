using Ensign;
using System.Collections.Generic;

public class UserModel : IDataModel 
{
    public string imageNumber;
    public string name;
    public string description;
    public string rule;
}

public class ListPlayerModel : IDataModel
{
    public List<UserModel> ListPlayer;
}