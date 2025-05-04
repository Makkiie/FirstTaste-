using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayHandler : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject Resume;
    [SerializeField] private GameObject Cookbook;
    [SerializeField] private GameObject InventoryIcon;

    public void ShowSettings()
    {
        PauseMenu.SetActive(true);
        Resume.SetActive(false); 
        Cookbook.SetActive(false);
    }

    public void ResumeSet()
    {
        Cookbook.SetActive(false);
        PauseMenu.SetActive(false);
        Resume.SetActive(true);
    }

    public void CookbookSet()
    {
        InventoryIcon.SetActive(false);
        Cookbook.SetActive(false);
        PauseMenu.SetActive(false);
        Resume.SetActive(false);
    }
    public void InventorSet()
    {

        Cookbook.SetActive(false);
        PauseMenu.SetActive(false);
        Resume.SetActive(false);
        InventoryIcon.SetActive(true);
    }

    public void MoToGame1(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

}
