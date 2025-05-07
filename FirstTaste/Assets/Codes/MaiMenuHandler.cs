using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class MaiMenuHandler : MonoBehaviour
{
    public GameObject mainMenuGroup;
    public GameObject settingsPanel;
    public GameObject creditsPanel;

    public void ShowSettings()
    {
        

            settingsPanel.SetActive(true);
        
    }
    public void ShowCredits()
    {
       
        creditsPanel.SetActive(true);
    }
    public void BackToMainMenu()
    {
       settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        mainMenuGroup.SetActive(true);
    }

    public void MoToNewGame(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }


}
