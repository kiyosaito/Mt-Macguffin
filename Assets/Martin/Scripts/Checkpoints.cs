using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : Respawning
{
    
    private void OnTriggerEnter(Collider other)
    {
        playerGhost.transform.position = gameObject.transform.position;
        gameObject.SetActive(false);
    }
}
