using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public Button btnOk;

    private void Start()
    {
        this.btnOk.onClick.AddListener(ClosePopup);
    }

    private void ClosePopup()
    {
        Destroy(gameObject);
    }
}