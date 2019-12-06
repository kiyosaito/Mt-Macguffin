using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;
    private Vector3 savePosition;
    public float x, y, z;
    private Player respawnPoint;
    private GameObject player;
    public static bool isPaused = false;
    private int currentSceneIndex;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pauseMenu = GameObject.FindGameObjectWithTag("Menu");
        pauseMenu.SetActive(false);
        respawnPoint = player.GetComponent<Player>();
    }
    private void Update()
    {
        Pause();
    }
    public void Save()
    {
        x = respawnPoint.playerGhost.x;
        y = respawnPoint.playerGhost.y;
        z = respawnPoint.playerGhost.z;
        SaveLoad.SaveCheckpoint(this);
    }
    public void Load()
    {
        DataToSave data = SaveLoad.LoadCheckPoint();
        x = data.x;
        y = data.y;
        z = data.z;
        respawnPoint.playerGhost = new Vector3(x, y, z);
        player.transform.position = respawnPoint.playerGhost;
    }
    public void DeleteAllSaves()
    {
        SaveLoad.ResetSaves();
    }

    public void Pause()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
                Debug.Log("Hey looky");
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
    }
    public void PauseQuit()
    {
        //currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        Application.Quit();
    }
    public void MainMenu()
    {
        //currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
