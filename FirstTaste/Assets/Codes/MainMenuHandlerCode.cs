using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandlerCode : MonoBehaviour
{
    public GameObject mainMenuGroup;
    public GameObject settingsPanel;
    public GameObject creditsPanel;

    public void ShowSettings()
    {
        mainMenuGroup.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void ShowCredits()
    { 
        mainMenuGroup.SetActive(false );
        creditsPanel.SetActive(true);
    }
    public void BackToMainMenu()
    { 
        settingsPanel.SetActive(false );
        creditsPanel.SetActive(false ) ;
        mainMenuGroup.SetActive(true );
    }

    public void MoToNewGame(int sceneID)
    {
        SceneManager.LoadScene( sceneID );
    }



}
