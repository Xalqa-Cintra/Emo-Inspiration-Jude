using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCode : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditMenu;

    private void Start()
    {
        mainMenu.SetActive(true);
        creditMenu.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Credits()
    {
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        creditMenu.SetActive(false);
    }

}
