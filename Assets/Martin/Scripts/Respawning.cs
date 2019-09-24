using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{

    public GameObject player;
    public Vector3 playerGhost;

    private void Start()
    {
        playerGhost = GameObject.FindGameObjectWithTag("RespawnPoint").transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
}
