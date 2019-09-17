using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{
    public GameObject player;
    private bool _isRespawning;
    private Vector3 _respawnPoint;
    void Start()
    {
        _respawnPoint = player.transform.position;
    }

    void Update()
    {
        
    }
    public void Respawn()
    {
        player.transform.position = _respawnPoint;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "KillZone")
        {
            Respawn();
        }
    }
}
