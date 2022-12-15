using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Script.GuildView;
using System.Collections;
using System.Collections.Generic;

public class EditGuild : MonoBehaviour
{
    public static bool editStatus = false;

    [Header("Information player")]
    [SerializeField] private TextMeshProUGUI informationPlayer;

    [Header("All informatioin")]
    [SerializeField] private string allInformation;
    public string imageNumberPlayer;
    public string namePlayer;
    public string descriptionPlayer;
    public string rulePlayer;

    [Header("Listen event onclick")]
    [SerializeField] private Button player;

    private void Start()
    {
        GetData();
        this.player.onClick.AddListener(EditInformationPlayer);
    }

    private void LoadAllInformation()
    {
        this.allInformation = this.informationPlayer.text;
    }

    private void GetData()
    {
        this.LoadAllInformation();
        if (this.allInformation != "")
        {
            this.imageNumberPlayer = allInformation.Substring(allInformation.IndexOf("ImageNumberPlayer:") + 19, allInformation.IndexOf("::endImg") - allInformation.IndexOf("ImageNumberPlayer:") - 20);
            this.namePlayer = allInformation.Substring(allInformation.IndexOf("NamePlayer:") + 12, allInformation.IndexOf("::endName") - allInformation.IndexOf("NamePlayer:") - 13);
            this.descriptionPlayer = allInformation.Substring(allInformation.IndexOf("DescriptionPlayer:") + 19, allInformation.IndexOf("::endDes") - allInformation.IndexOf("DescriptionPlayer:") - 20);
            this.rulePlayer = allInformation.Substring(allInformation.IndexOf("RulePlayer:") + 12, allInformation.IndexOf("::endRule") - allInformation.IndexOf("RulePlayer:") - 13);
        }
    }

    private void EditInformationPlayer()
    {
        editStatus = true;
        this.ChangeDataCache();
        Instantiate(Resources.Load<GameObject>("Popups/Guild") as GameObject);
    }

    private void ChangeDataCache()
    {
        DataCache.imageNumberCache = this.imageNumberPlayer;
        DataCache.nameCache = this.namePlayer;
        DataCache.descriptionCache = this.descriptionPlayer;
        DataCache.ruleCache = this.rulePlayer;
    }
}