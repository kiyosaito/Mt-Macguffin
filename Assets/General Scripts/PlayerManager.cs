using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region General Variables/References

    public int maxHealth;
    public int curHealth;
    public GameObject thePlayer;

    #endregion
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #region Martin's Code

    #region Variables/References
    [Header("Invincibility")]
    public float invincibilityLength;
    private float invincibilityCount;

    [Header("Respawn")]
    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

    #endregion

    #region Respawning

    public IEnumerator RespawnCo(){
        isRespawning = true;
        thePlayer.gameObject.SetActive(false);
        Instantiate(thePlayer.transform.position, thePlayer.transform.rotation);
    }


    #endregion


    #endregion

    #region Andrew's Code

    #endregion
}
