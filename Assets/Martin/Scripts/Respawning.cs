using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{

    public GameObject player;
    public GameObject playerGhost;

    private void Start()
    {
        playerGhost = GameObject.FindGameObjectWithTag("RespawnPoint");
        player = GameObject.FindGameObjectWithTag("Player");
        playerGhost.transform.position = player.transform.position;
    }
}
