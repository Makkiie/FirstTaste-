using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;


public class PauseCode : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;


    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BackBtn()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;

    }




}
