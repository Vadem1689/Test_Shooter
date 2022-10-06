using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelWin;


    public void NextGame()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        panelWin.SetActive(false);
    }
    public void PauseLevel()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        panelWin.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        panelWin.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        panelWin.SetActive(false);
    }
}
