namespace Script.ListGuildModel
{
    using Ensign;
    using Ensign.Unity.MVC;

    public class PlayerData : UserModel
    {}

    public class ListGuildPlayer : ListPlayerModel
    {}
}

public class DataCache
{
    public static int idCache;
    public static string imageNumberCache;
    public static string nameCache;
    public static string descriptionCache;
    public static string ruleCache;
}