using UnityEngine;
    
public class ImageManage : MonoBehaviour {

    public static void SetImage(string imageName)
    {
        PlayerPrefs.SetString("image", imageName);
        Debug.Log(GetImage());
    } 

    public static string GetImage() => PlayerPrefs.GetString("image");  

    protected void TurnOffAllStatusForImage()
    {
        GameObject[] statusImages = GameObject.FindGameObjectsWithTag("StatusImage");
        foreach(GameObject image in statusImages)
            image.SetActive(false);
    }
}