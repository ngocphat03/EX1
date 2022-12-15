namespace Script.ListGuildController
{
    using System;
    using System.IO;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    using Newtonsoft.Json;
    using Ensign.Unity.MVC;
    using System.Collections;  
    using Script.ListGuildModel;
    using Newtonsoft.Json.Converters;
    using System.Collections.Generic;

    public class ListGuildController : Controller<ListGuildController, ListGuildPlayer>
    {

        private string path = Application.persistentDataPath + "/dataUser.json";

        protected override void Init()
        {
            base.Init();
            this.Model.ListPlayer = new List<UserModel>();
        }
    }
}