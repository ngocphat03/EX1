namespace Script.ListGuildView
{
    using TMPro;
    using Ensign;
    using System;
    using System.IO;
    using UnityEngine;
    using System.Linq;
    using UnityEngine.UI;
    using Script.ListGuildModel;
    using Ensign.Unity.MVC;
    using Newtonsoft.Json;
    using System.Collections;
    using Script.ListGuildController;
    using System.Collections.Generic;

    public class ListGuildView : View<ListGuildController, ListGuildPlayer>
    {
        private string path;
        [SerializeField] private Button btnCreate;
        [SerializeField] private GameObject player;
        [SerializeField] private Transform parent;
        [SerializeField] private Image avatar;
        [SerializeField] private Sprite newAvatar;
        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private TextMeshProUGUI description;

        private void Awake() { path = Application.persistentDataPath + "/dataUser.json"; }

        private void Start() {
            this.btnCreate.onClick.AddListener(CreateNewUser);
            this.CreateListPlayerToScreen();
        }

        private void CreateListPlayerToScreen()
        {
            //Get list players from file
            var outputJson     = File.ReadAllText(this.path);
            var loadedUserData = JsonConvert.DeserializeObject<ListPlayerModel>(outputJson);
            var listPlayer = loadedUserData.ListPlayer.ToArray();

            //Check length array
            int listCount = 10;
            if(listPlayer.Count() < 10) { listCount = listPlayer.Count(); }

            //Create list player
            for(int i=0; i < listCount; i++)
            {
                newAvatar = Resources.Load<Sprite>("Sprites/" + listPlayer[i].imageNumber);
                avatar.sprite = newAvatar;
                name.text = "Name: " + listPlayer[i].name;
                description.text = "Description: " + listPlayer[i].description;

                Instantiate(player, transform.position - new Vector3(0, 0, 0), transform.rotation ,parent);
            }
        }

        private void CreateNewUser()
        {
            //Reset image number
            ImageManage.SetImage("");
            Instantiate(Resources.Load<GameObject>("Popups/Guild") as GameObject);
        }
    }
}