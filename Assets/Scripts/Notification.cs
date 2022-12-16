using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Notification : MonoBehaviour
{
    public UnityEngine.UI.Image avatar;
    public TMP_InputField inputName;
    public TMP_InputField inputRule;
    public TextMeshProUGUI textScreen;
    public Button btnOk;

    private string changeTextInScreen = "You need to fill in additional fields: ";

    private void Start()
    {
        this.btnOk.onClick.AddListener(ClosePopup);
        avatar = (UnityEngine.UI.Image)GameObject.FindWithTag("Avatar").GetComponent<UnityEngine.UI.Image>();
        inputName = (TMP_InputField)GameObject.FindWithTag ("InputName").GetComponent<TMP_InputField>();
        inputRule = (TMP_InputField)GameObject.FindWithTag ("InputRule").GetComponent<TMP_InputField>();
        ChangeText();
    }

    private void ClosePopup()
    {
        Destroy(gameObject);
    }

    private void ChangeText()
    {
        if(avatar.sprite == null)
        {
            changeTextInScreen += "choose avatar, ";
        }
        if(inputName.text == "")
        {
            changeTextInScreen += "name ";
        }
        if(inputRule.text == "")
        {
            changeTextInScreen += "rule ";
        }
        Debug.Log(changeTextInScreen);
        textScreen.text = changeTextInScreen;
    }
}