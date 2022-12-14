namespace Script.GuildController
{
    using System;
    using System.IO;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    using Newtonsoft.Json;
    using Ensign.Unity.MVC;
    using Script.GuildModel;
    using System.Collections;  
    using Newtonsoft.Json.Converters;
    using System.Collections.Generic;

    public class GuildController : Controller<GuildController, ListGuildPlayer>
    {

        private string path = Application.persistentDataPath + "/dataUser.json";

        protected override void Init()
        {
            base.Init();
            this.Model.ListPlayer = new List<UserModel>();
        }

        public void SaveDataToFile()
        {
            var serializer = new JsonSerializer();
            using var sw = new StreamWriter(Application.persistentDataPath + "/dataUser.json");
            using JsonWriter writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, this.Model);
            Debug.Log("Save success");
        }

        public void LoadDataToFile()
        {
            var outputJson     = File.ReadAllText(Application.persistentDataPath + "/dataUser.json");
            ListPlayerModel loadedUserData = JsonConvert.DeserializeObject<ListPlayerModel>(outputJson);
            this.Model.ListPlayer = loadedUserData.ListPlayer;
        }
    }

}