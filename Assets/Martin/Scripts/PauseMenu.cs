using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Respawning checkpoint;
    public float x, y, z;

    private void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("Menu");
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        Pause();
    }
    public void Save()
    {
        x = checkpoint.playerGhost.x;
        y = checkpoint.playerGhost.y;
        z = checkpoint.playerGhost.z;
    }
    public void Load()
    {
        DataToSave data = SaveLoad.LoadCheckPoint();
        x = data.x;
        y = data.y;
        z = data.z;
        checkpoint.playerGhost = new Vector3(x, y, z);
    }
    public void DeleteAllSaves()
    {
        SaveLoad.ResetSaves();
    }

    public void Pause()
    {
        if (pauseMenu.activeSelf == true)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {

            }
        }
    }

}
