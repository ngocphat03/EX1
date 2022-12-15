using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button name;
    public static int tesettt;

    private void Start() {
        this.name.onClick.AddListener(Test01);
    }
    private void Test01()
    {
        Debug.Log("CLICK");
    }

    private void OnMouseDown() {
        Debug.LogError("Clicckkkk");
    }
}
