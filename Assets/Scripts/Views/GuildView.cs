namespace Script.GuildView
{
    using TMPro;
    using Ensign;
    using UnityEngine;
    using UnityEngine.UI;
    using Script.GuildModel;
    using Ensign.Unity.MVC;
    using System.Collections;
    using Script.GuildController;

    public class GuildView : View<GuildController, ListGuildPlayer>
    {
        [Header("Button and content button")]
        [SerializeField] private Button btnSelectAvatar;
        [SerializeField] private Button btnConfirm;
        [SerializeField] private TextMeshProUGUI textBtn;

        [Header("Output")]
        [SerializeField] private Image avatar;
        [SerializeField] private Sprite newAvatar;

        [Header("Input user")]
        [SerializeField] private TMP_InputField inputName;
        [SerializeField] private TMP_InputField inputDescription;
        [SerializeField] private TMP_InputField inputRule;

        public static GuildView Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            this.btnConfirm.onClick.AddListener(Confirm);
            this.btnSelectAvatar.onClick.AddListener(OpenChooseAvatar);
            this.EditPlayer();
        }

        private void FixedUpdate()
        {
            this.ChangeAvatarInGuildPopup();
            this.LoadAvatarFormFile();
        }

        private void OpenChooseAvatar()
        {
            Instantiate(Resources.Load<GameObject>("Popups/ChooseAvatar") as GameObject);
        }

        public void ChangeAvatarInGuildPopup()
        {
            this.avatar.sprite = this.newAvatar;
        }

        private void Confirm()
        {
            this.SaveData();
            this.RestStatusEdit();
            this.ResetImageNumber();
            this.CloserPopup();
        }

        private void SaveData()
        {
            this.Controller.LoadDataToFile();
            this.Model.ListPlayer.Add(new UserModel
            {
                imageNumber = ImageManage.GetImage(),
                name = inputName.text,
                description = inputDescription.text,
                rule = inputRule.text,
            });
            this.Controller.SaveDataToFile();
        }

        private void LoadAvatarFormFile()
        {
            if (ImageManage.GetImage() != "") //Check user choosed avatar
            {
                this.newAvatar = Resources.Load<Sprite>("Sprites/" + ImageManage.GetImage());
            }
        }

        private void CloserPopup()
        {
            Destroy(gameObject);
        }

        private void ResetImageNumber()
        {
            ImageManage.SetImage("");
        }

        private void RestStatusEdit()
        {
            EditGuild.editStatus = false;
        }

        private void EditPlayer()
        {
            if(EditGuild.editStatus == true)
            {
                this.ChangeContentFormCache();
                this.inputName.interactable = false;
                this.textBtn.text = "Confirm";
            }
        }

        private void ChangeContentFormCache()
        {
            ImageManage.SetImage(DataCache.imageNumberCache);
            this.inputName.text = DataCache.nameCache;
            this.inputDescription.text = DataCache.descriptionCache;
            this.inputRule.text = DataCache.ruleCache;
        }
    }
}