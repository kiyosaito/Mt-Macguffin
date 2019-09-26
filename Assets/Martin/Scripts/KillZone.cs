using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private Player playerScript, respawnPoint;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DisablePlayer();
            Invoke("RespawnPlayer", 1);
            Invoke("EnablePlayer", 2);
        }
    }
    void RespawnPlayer()
    {
        player.transform.position = playerScript.playerGhost;
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
