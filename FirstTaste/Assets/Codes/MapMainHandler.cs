using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class MapMainHandler : MonoBehaviour
{
    public GameObject MapOceanPanel;
    public GameObject DescriptionPanel;
    public GameObject SettingPanel;

    public void ShowDescription()
    { 
        DescriptionPanel.SetActive(true);
    }
    public void ShowSettign()
    { 
        SettingPanel.SetActive(true);
    }
    public void BackToMapOceanPanel()
    {
        SettingPanel.SetActive(false);
        DescriptionPanel.SetActive(false);
        MapOceanPanel.SetActive(true);
    }
    public void MoveToPlayGame(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void MoveToMainMenu(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

}
