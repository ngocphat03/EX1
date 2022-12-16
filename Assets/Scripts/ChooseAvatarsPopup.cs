namespace Script.ChooseAvatarsPopup
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ChooseAvatarsPopup : MonoBehaviour
    {
        public Button btnClose;
        public Button btnOk;

        private void Start()
        {
            this.CheckImageSelected();
            this.btnOk.onClick.AddListener(SelectAvatar);
            this.btnClose.onClick.AddListener(CancelSelect);
            ImageManage.SetImageCache();
        }

        private void SelectAvatar()
        {
            this.ClosePopup();
        }

        private void CancelSelect()
        {
            ImageManage.SetImage(ImageManage.GetImageCache().ToString());
            this.ClosePopup();
            btnOk.interactable = false;
        }

        public void CheckImageSelected()
        {
            if (ImageManage.GetImage() == "" || ImageManage.GetImage() == "0")
            {
                btnOk.interactable = false;
                Debug.Log(ImageManage.GetImage() );
            }
            else
            {
                btnOk.interactable = true;
                Debug.Log(ImageManage.GetImage() );
            }
        }

        private void ClosePopup()
        {
            Destroy(gameObject);
        }
    }
}