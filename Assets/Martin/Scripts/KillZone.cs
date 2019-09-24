using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : Respawning
{
    public Player playerScript;
    private void Awake()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        DisablePlayer();
        Invoke("RespawnPlayer", 1);
        Invoke("EnablePlayer", 2);
    }
    void RespawnPlayer()
    {
        player.transform.position = playerGhost;
    }
    void DisablePlayer()
    {
        playerScript.enabled = false;
    }
    void EnablePlayer()
    {
        playerScript.enabled = true;
    }
}
