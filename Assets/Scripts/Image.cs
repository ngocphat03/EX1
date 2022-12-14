using UnityEngine;
using UnityEngine.UI;
using Script.ChooseAvatarsPopup;

public class Image : ImageManage {
    public Button image;
    public GameObject statusImages;
    public string imageNumber;
    private ChooseAvatarsPopup chooseAvt;
    private GameObject chooseAvtPopup;

    private void Start() {
        this.GetScriptChooseAvatarsPopup();
        this.image.onClick.AddListener(SetImageNumberToVarible);
        this.CheckImageSelected();
    }

    private void GetScriptChooseAvatarsPopup()
    {
        chooseAvtPopup = GameObject.FindGameObjectWithTag("ChooseAvatarsPopup");
        chooseAvt = chooseAvtPopup.GetComponent<ChooseAvatarsPopup>();
    }

    private void SetImageNumberToVarible()
    {
        ImageManage.SetImage(imageNumber);
        TurnOffAllStatusForImage();
        this.statusImages.SetActive(true);
        chooseAvt.CheckImageSelected();
    }

    private void CheckImageSelected()
    {
        if(ImageManage.GetImage() == imageNumber)
        {
            SetImageNumberToVarible();
        }
    }
}