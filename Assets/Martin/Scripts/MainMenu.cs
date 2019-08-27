using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Options Menu
    public void SetVolume()
    {

    }
    #endregion
    #region Main Menu
    public void MainMenuPlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuQuit()
    {
        Application.Quit();
    }
    #endregion
}
