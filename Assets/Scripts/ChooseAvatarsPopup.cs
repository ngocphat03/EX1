namespace Script.ChooseAvatarsPopup
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ChooseAvatarsPopup : MonoBehaviour 
    {
        public Button btnClose;
        public Button btnOk;

        private void Start() {
            this.CheckImageSelected();
            this.btnOk.onClick.AddListener(SelectAvatar);
            this.btnClose.onClick.AddListener(ClosePopup);
        }

        private void SelectAvatar()
        {
            this.ClosePopup();
        }

        public void CheckImageSelected()
        {
            if(ImageManage.GetImage() == "")
            {
                btnOk.interactable = false;
            }
            else
            {
                btnOk.interactable = true;
            }
        }

        private void ClosePopup()
        {
            Destroy(gameObject);
            this.ResetStatusImages();
        }

        private void ResetStatusImages()
        {
            ImageManage.SetImage("");
        }
    }
}