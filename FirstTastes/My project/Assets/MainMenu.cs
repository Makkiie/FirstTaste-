using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void MoveToScene(int sceneID)
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
