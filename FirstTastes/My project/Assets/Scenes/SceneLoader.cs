using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void LoadSceneOne()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSceneTwo()
    {
        SceneManager.LoadScene(1);
    }


}
