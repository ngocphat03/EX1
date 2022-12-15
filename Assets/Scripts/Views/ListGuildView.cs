namespace Script.ListGuildView
{
    using TMPro;
    using Ensign;
    using System;
    using System.IO;
    using UnityEngine;
    using System.Linq;
    using UnityEngine.UI;
    using Newtonsoft.Json;
    using Ensign.Unity.MVC;
    using System.Collections;
    using Script.ListGuildModel;
    using Script.ListGuildController;
    using System.Collections.Generic;

    public class ListGuildView : View<ListGuildController, ListGuildPlayer>
    {
        private string path;

        [Header("Get object to instantiate")]
        [SerializeField] private Button btnCreate;
        [SerializeField] private GameObject player;
        [SerializeField] private Transform parent;

        [Header("Information player")]
        [SerializeField] private Sprite newAvatar;
        [SerializeField] private Image avatar;
        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private TextMeshProUGUI description;
        [SerializeField] private TextMeshProUGUI informationPlayer;

        private void Awake() { path = Application.persistentDataPath + "/dataUser.json"; }

        private void Start() {
            this.btnCreate.onClick.AddListener(CreateNewUser);
            this.CreateListPlayerToScreen();
        }

        private void CreateListPlayerToScreen()
        {
            string ddd;
            //Get list players from file
            var outputJson = File.ReadAllText(this.path);
            var listPlayer = JsonConvert.DeserializeObject<ListPlayerModel>(outputJson).ListPlayer.ToArray();

            //Create list player
            for(int i=0; i < listPlayer.Count(); i++)
            {
                newAvatar                   = Resources.Load<Sprite>("Sprites/" + listPlayer[i].imageNumber);
                avatar.sprite               = newAvatar;
                name.text                   = "Name: " + listPlayer[i].name;
                description.text            = "Description: " + listPlayer[i].description;
                informationPlayer.text      = "ImageNumberPlayer: " + listPlayer[i].imageNumber + " ::endImg || NamePlayer: " + listPlayer[i].name + " ::endName || DescriptionPlayer: " + listPlayer[i].description + " ::endDes || RulePlayer: " + listPlayer[i].rule + " ::endRule";

                Instantiate(player, transform.position - new Vector3(0, 0, 0), transform.rotation ,parent); 
            }
        }

        private void CreateNewUser()
        {
            ImageManage.SetImage(""); //Reset image number
            Instantiate(Resources.Load<GameObject>("Popups/Guild") as GameObject);
        }
    }
}