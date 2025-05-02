using UnityEngine;
using UnityEngine.SceneManagement;

public class MapHandlerCode : MonoBehaviour
{
    public GameObject mainMapGroup;
    public GameObject MapInfoPanel;

    public void ShowMapInfo()
    {
       
        MapInfoPanel.SetActive(true); 
        mainMapGroup.SetActive(false);
    }
    public void BackToMainMap()
    {
        MapInfoPanel.SetActive(false);
        mainMapGroup.SetActive(true);
    }
    public void MoToGame1(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
