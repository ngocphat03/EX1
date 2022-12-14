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
        [SerializeField] private Image avatar;
        [SerializeField] private Sprite newAvatar;
        [SerializeField] private Button btnSelectAvatar;
        [SerializeField] private Button btnConfirm;
        [SerializeField] private TMP_InputField inputName;
        [SerializeField] private TMP_InputField inputDescription;
        [SerializeField] private TMP_InputField inputRule;

        public static GuildView Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void Start() {
            this.btnConfirm.onClick.AddListener(Confirm);
            this.btnSelectAvatar.onClick.AddListener(OpenChooseAvatar);
            this.ChangeAvatarInGuildPopup();
        }

        private void FixedUpdate() {
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
            this.ResetImageNumber();
            this.CloserPopup();
        }

        private void SaveData()
        {
            this.Controller.LoadDataToFile();
            this.Model.ListPlayer.Add( new UserModel
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
            if(ImageManage.GetImage() != "")
                this.newAvatar = Resources.Load<Sprite>("Sprites/" + ImageManage.GetImage());
        }

        private void CloserPopup()
        {
            Destroy(gameObject);
        }

        private void ResetImageNumber()
        {
            ImageManage.SetImage("");
        }
    }
}